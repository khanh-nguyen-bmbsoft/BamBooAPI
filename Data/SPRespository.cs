using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Utilities.Constants;
using Microsoft.SharePoint.Client;

namespace BambooAirwayBE.API.Data
{
    public class SPRespository
    {
        public readonly ClientContext _clientContext;
        protected readonly List _oList;

        public SPRespository(ClientContext context, string listUrl, Web parentWeb = null)
        {
            _clientContext = context;
            if (parentWeb == null)
                _oList = _clientContext.Web.GetList(listUrl);
            else
                _oList = parentWeb.GetList(listUrl);
        }

        public IEnumerable<TItem> GetAll<TItem>(Func<ListItem, TItem> geneateTItem) where TItem : BaseItem
        {
            Microsoft.SharePoint.Client.CamlQuery query = new Microsoft.SharePoint.Client.CamlQuery();
            query.ViewXml = "<View>"
                                + "<Query>"
                                + string.Format(CamlQueryConstants.OrderPatern, FieldInternalNames.ID, CamlQueryConstants.SPTrueValue)
                                + "</Query>" +
                            "</View>";
            ListItemCollection listItems = _oList.GetItems(query);
            _clientContext.Load(listItems);
            _clientContext.ExecuteQuery();
            IList<TItem> result = new List<TItem>();

            foreach (var item in listItems)
            {
                if (item != null)
                    result.Add(geneateTItem(item));
            }
            return result.ToArray();
        }

        public IEnumerable<TItem> Query<TItem>(CamlQuery query, Func<ListItem, TItem> geneateTItem) where TItem : BaseItem
        {
            ListItemCollection listItems = _oList.GetItems(query);
            _clientContext.Load(listItems);
            _clientContext.ExecuteQueryRetry();
            IList<TItem> result = new List<TItem>();

            foreach (var item in listItems)
            {
                if (item != null)
                    result.Add(geneateTItem(item));
            }
            return result.ToArray();
        }

        public TItem GetItemById<TItem>(int id, Func<ListItem, TItem> geneateTItem) where TItem : BaseItem
        {
            ListItem oListItem = _oList.GetItemById(id);
            _clientContext.Load(oListItem);
            _clientContext.ExecuteQueryRetry();
            return geneateTItem(oListItem);
        }

        public TItem AddOrUpdate<TItem>(TItem item) where TItem : BaseItem
        {
            if (item._item == null)
            {
                ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                item._item = _oList.AddItem(itemCreateInfo);
            }
            item.SyncToSPItem();
            item._item.Update();
            _clientContext.ExecuteQueryRetry();
            return item;
        }
        
        public void Delete<TItem>(TItem item) where TItem : BaseItem
        {
            item._item.DeleteObject();
            _clientContext.ExecuteQueryRetry();
        }

        public string[] GetOptionsFromFieldChoice(string internalName)
        {
            var choiceField = _clientContext.CastTo<FieldChoice>(_oList.Fields.GetByInternalNameOrTitle(internalName));
            _clientContext.Load(choiceField);
            _clientContext.ExecuteQueryRetry();
            return choiceField.Choices;
        }

        public void AttachFile<TItem>(TItem item, string fileName, byte[] content) where TItem : BaseItem
        {
            if (item._item != null)
            {
                var attInfo = new AttachmentCreationInformation();
                attInfo.FileName = fileName;
                attInfo.ContentStream = new MemoryStream(content);
                Attachment att = item._item.AttachmentFiles.Add(attInfo); //Add to File

                _clientContext.Load(att);
                _clientContext.ExecuteQuery();

                ListItem oListItem = _oList.GetItemById(item.ID.Value);
                _clientContext.Load(oListItem);
                _clientContext.ExecuteQuery();
                item._item = oListItem;
            }
        }
    }
}
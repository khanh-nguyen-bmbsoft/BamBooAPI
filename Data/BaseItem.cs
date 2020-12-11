using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SP = Microsoft.SharePoint.Client;

namespace BambooAirwayBE.API.Data
{
    public abstract class BaseItem
    {
        public int? ID
        {
            get
            {
                if (_item != null)
                    return _item.Id;
                return null;
            }
        }
        public readonly SPRespository _respository;
        internal SP.ListItem _item;
        public BaseItem(SPRespository respository, SP.ListItem item)
        {
            _respository = respository;
            _item = item;
        }
        public abstract BaseItem SyncToSPItem();
    }
}
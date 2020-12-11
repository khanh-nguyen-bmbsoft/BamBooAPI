using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.SPModels
{
    public class ImageUrlField
    {
        public string type { get; set; }
        public string fileName { get; set; }
        public object nativeFile { get; set; }
        public string fieldName { get; set; }
        public string serverUrl { get; set; }
        public string serverRelativeUrl { get; set; }
        public string id { get; set; }
    }

    public class ImageViewUrlField
    {
        public string FileName { get; set; }
        public string Base64 { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp
{
    [DataContract]
    public class ExportDataConditionModel
    {
        [DataMember]
        public int type { get; set; }
        [DataMember]
        public string data { get; set; }
        [DataMember]
        public string filterStr { get; set; }
    }
}
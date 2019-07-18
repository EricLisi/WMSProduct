using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 行政区域表
    /// </summary>
    [DataContract]
    public class SaveTempScanEntity
    {
        [DataMember]
        public string ORDERNO { get; set; }

        [DataMember]
        public string ORDERTYPE { get; set; }

        [DataMember]
        public string CWHCODE { get; set; }

        [DataMember]
        public string BARCODE { get; set; }

        [DataMember]
        public string CPOSCODE { get; set; }

        [DataMember]
        public string OPERUSER { get; set; }

        [DataMember]
        public bool BDEL { get; set; }


        [DataMember]
        public decimal QTY { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 扫描差异类
    /// </summary>
    [DataContract]
    public class ScanCyModel
    {
        /// <summary>
        /// 货号
        /// </summary>
        [DataMember]
        public string cInvCode { get; set; }

        /// <summary>
        /// 单据数量
        /// </summary>
        [DataMember]
        public int qty { get; set; }

        /// <summary>
        /// 扫描数量
        /// </summary>
        [DataMember]
        public int doneqty { get; set; }

        /// <summary>
        /// 差异数量
        /// </summary>
        [DataMember]
        public int cyqty { get; set; }
    }
}
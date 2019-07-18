using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 下拉框
    /// </summary>
    [DataContract]
    public class SelectModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public string id { get; set; }
        /// <summary>
        /// 文本名称
        /// </summary>
        [DataMember]
        public string text { get; set; }
     
    }
}
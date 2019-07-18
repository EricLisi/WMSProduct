using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 树形结构图
    /// </summary>
    [DataContract]
    public class GetModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string icon { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public string title { get; set; }
        /// <summary>
        /// 文本名称
        /// </summary>
        [DataMember]
        public string src { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [DataMember]
        public string parent { get; set; }
    }
}
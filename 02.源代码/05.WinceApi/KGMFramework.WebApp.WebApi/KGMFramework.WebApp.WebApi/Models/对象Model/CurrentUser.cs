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
    public class GetTreeModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string parentId { get; set; }
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
        /// <summary>
        /// 值
        /// </summary>
        [DataMember]
        public string value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? checkstate { get; set; }
        /// <summary>
        /// 是否有复选框
        /// </summary>
        [DataMember]
        public bool showcheck { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        [DataMember]
        public bool complete { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        [DataMember]
        public bool isexpand { get; set; }
        /// <summary>
        /// 是否有子节点
        /// </summary>
        [DataMember]
        public bool hasChildren { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [DataMember]
        public string img { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string title { get; set; }
    }
}
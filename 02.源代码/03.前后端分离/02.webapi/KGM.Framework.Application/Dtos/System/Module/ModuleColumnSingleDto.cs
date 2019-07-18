using Newtonsoft.Json;
using System;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 模块列Dto
    /// </summary> 
    public class ModuleColumnSignleDto
    {  
        /// <summary>
        /// 主键
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Id { get; set; }
         
        /// <summary>
        /// 图标
        /// </summary>
        [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Icon { get; set; }

        /// <summary>
        /// 连接地址
        /// </summary>
        [JsonProperty(PropertyName = "actionaddress", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ActionAddress { get; set; } 

        /// <summary>
        /// 节点
        /// </summary>
        [JsonProperty(PropertyName = "parentid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ParentId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        [JsonProperty(PropertyName = "encode", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty(PropertyName = "fullname", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FullName { get; set; }

        /// <summary>
        /// 描述
        /// </summary> 
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// 排序码
        /// </summary> 
        [JsonProperty(PropertyName = "sortcode", NullValueHandling = NullValueHandling.Ignore)]
        public int? SortCode { get; set; } 
    }
}

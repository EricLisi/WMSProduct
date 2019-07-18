using Newtonsoft.Json;
using System;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 模块查询列表Dto
    /// </summary> 
    public class ModuleGridDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Include)]
        public string Id { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [JsonProperty(PropertyName = "parentid", NullValueHandling = NullValueHandling.Include)]
        public string ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        [JsonProperty(PropertyName = "layers", NullValueHandling = NullValueHandling.Include)]
        public int? Layers { get; set; } 

        /// <summary>
        /// 编码
        /// </summary>
        [JsonProperty(PropertyName = "encode", NullValueHandling = NullValueHandling.Include)]
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty(PropertyName = "fullname", NullValueHandling = NullValueHandling.Include)]
        public string FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Include)]
        public string Icon { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        [JsonProperty(PropertyName = "urladdress", NullValueHandling = NullValueHandling.Include)]
        public string UrlAddress { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Include)]
        public string Target { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [JsonProperty(PropertyName = "ismenu", NullValueHandling = NullValueHandling.Include)]
        public bool? IsMenu { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        [JsonProperty(PropertyName = "isexpand", NullValueHandling = NullValueHandling.Include)]
        public bool? IsExpand { get; set; }

        /// <summary>
        /// 公共
        /// </summary>
        [JsonProperty(PropertyName = "ispublic", NullValueHandling = NullValueHandling.Include)]
        public virtual bool? IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        [JsonProperty(PropertyName = "allowedit", NullValueHandling = NullValueHandling.Include)]
        public virtual bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        [JsonProperty(PropertyName = "allowdelete", NullValueHandling = NullValueHandling.Include)]
        public virtual bool? AllowDelete { get; set; }
        /// <summary>
        /// 是否App
        /// </summary>
        [JsonProperty(PropertyName = "isapp", NullValueHandling = NullValueHandling.Include)]
        public virtual bool? IsApp { get; set; }

        /// <summary>
        /// 描述
        /// </summary> 
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Include)]
        public string Description { get; set; }

        /// <summary>
        /// 排序码
        /// </summary> 
        [JsonProperty(PropertyName = "sortcode", NullValueHandling = NullValueHandling.Include)]
        public int? SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary> 
        [JsonProperty(PropertyName = "deletemark", NullValueHandling = NullValueHandling.Include)]
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary> 
        [JsonProperty(PropertyName = "enabledmark", NullValueHandling = NullValueHandling.Include)]
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty(PropertyName = "creatortime", NullValueHandling = NullValueHandling.Include)]
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [JsonProperty(PropertyName = "creatoruserid", NullValueHandling = NullValueHandling.Include)]
        public string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty(PropertyName = "lastmodifytime", NullValueHandling = NullValueHandling.Include)]
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [JsonProperty(PropertyName = "lastmodifyuserid", NullValueHandling = NullValueHandling.Include)]
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [JsonProperty(PropertyName = "deletetime", NullValueHandling = NullValueHandling.Include)]
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary> 
        [JsonProperty(PropertyName = "deleteuserid", NullValueHandling = NullValueHandling.Include)]
        public string DeleteUserId { get; set; } 
    }
}

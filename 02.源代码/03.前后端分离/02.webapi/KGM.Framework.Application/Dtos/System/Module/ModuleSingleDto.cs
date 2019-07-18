using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 模块Dto
    /// </summary> 
    public class ModuleSingleDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 平台Id
        /// </summary>
        [JsonProperty(PropertyName = "platformid", NullValueHandling = NullValueHandling.Ignore)]
        public string PlatformId { get; set; }
         
        /// <summary>
        /// 父级
        /// </summary>
        [JsonProperty(PropertyName = "parentid", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        [JsonProperty(PropertyName = "layers", NullValueHandling = NullValueHandling.Ignore)]
        public int? Layers { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [JsonProperty(PropertyName = "encode", NullValueHandling = NullValueHandling.Ignore)]
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty(PropertyName = "fullname", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        [JsonProperty(PropertyName = "urladdress", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlAddress { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        [JsonProperty(PropertyName = "target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [JsonProperty(PropertyName = "ismenu", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMenu { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        [JsonProperty(PropertyName = "isexpand", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsExpand { get; set; }

        /// <summary>
        /// 公共
        /// </summary>
        [JsonProperty(PropertyName = "ispublic", NullValueHandling = NullValueHandling.Ignore)]
        public virtual bool? IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        [JsonProperty(PropertyName = "allowedit", NullValueHandling = NullValueHandling.Ignore)]
        public virtual bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        [JsonProperty(PropertyName = "allowdelete", NullValueHandling = NullValueHandling.Ignore)]
        public virtual bool? AllowDelete { get; set; }
        /// <summary>
        /// 是否App
        /// </summary>
        [JsonProperty(PropertyName = "isapp", NullValueHandling = NullValueHandling.Ignore)]
        public virtual bool? IsApp { get; set; }

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

        /// <summary>
        /// 删除标志
        /// </summary> 
        [JsonProperty(PropertyName = "deletemark", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary> 
        [JsonProperty(PropertyName = "enabledmark", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty(PropertyName = "creatortime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [JsonProperty(PropertyName = "creatoruserid", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty(PropertyName = "lastmodifytime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [JsonProperty(PropertyName = "lastmodifyuserid", NullValueHandling = NullValueHandling.Ignore)]
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [JsonProperty(PropertyName = "deletetime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary> 
        [JsonProperty(PropertyName = "deleteuserid", NullValueHandling = NullValueHandling.Ignore)]
        public string DeleteUserId { get; set; }

        /// <summary>
        /// 模块按钮
        /// </summary>
        [JsonProperty(PropertyName = "buttons", NullValueHandling = NullValueHandling.Ignore)]
        public virtual List<ModuleButtonSingleDto> ButtonEntities { get; set; }

        /// <summary>
        /// 模块页面表单
        /// </summary>
        [JsonProperty(PropertyName = "forms", NullValueHandling = NullValueHandling.Ignore)]
        public virtual List<ModuleFormSingleDto> FormEntities { get; set; }

        /// <summary>
        /// 模块列
        /// </summary>
        [JsonProperty(PropertyName = "columns", NullValueHandling = NullValueHandling.Ignore)]
        public virtual List<ModuleColumnSignleDto> ColumnEntities { get; set; }


    }
}

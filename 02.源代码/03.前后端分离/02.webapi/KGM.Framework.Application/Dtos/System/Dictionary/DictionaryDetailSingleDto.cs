using Newtonsoft.Json;
using System;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 模块按钮Dto
    /// </summary> 
    public class DictionaryDetailSingleDto
    {
        #region Property Members

        /// <summary>
        /// 主键
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Id { get; set; } 

        /// <summary>
        /// 节点
        /// </summary>
        [JsonProperty(PropertyName = "parentid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ParentId { get; set; }

        /// <summary>
        /// 主表id
        /// </summary>
        [JsonProperty(PropertyName = "itemid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 主表编码
        /// </summary>
        [JsonProperty(PropertyName = "itemcode", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ItemCode { get; set; }

        /// <summary>
        /// 主表名称
        /// </summary>
        [JsonProperty(PropertyName = "itemname", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ItemName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [JsonProperty(PropertyName = "simplespelling", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string SimpleSpelling { get; set; }

        /// <summary>
        /// 默认
        /// </summary>
        [JsonProperty(PropertyName = "isdefault", NullValueHandling = NullValueHandling.Ignore)]
        public virtual bool? IsDefault { get; set; }

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


        #endregion
    }
}

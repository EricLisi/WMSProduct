using Newtonsoft.Json;
using System;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 条码规则子表Dto
    /// </summary> 
    public class BarCodeRuleDetailSingleDto
    {
        #region Property Members

        /// <summary>
        /// 主键
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Id { get; set; } 

        /// <summary>
        /// 主表ID
        /// </summary>
        [JsonProperty(PropertyName = "mainid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string MainId { get; set; }

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
        /// 长度
        /// </summary>
        [JsonProperty(PropertyName = "length", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Length { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Type { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [JsonProperty(PropertyName = "number", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Number { get; set; }

        /// <summary>
        /// 自定义一
        /// </summary>
        [JsonProperty(PropertyName = "define1", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Define1 { get; set; }

        /// <summary>
        /// 自定义二
        /// </summary>
        [JsonProperty(PropertyName = "define2", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Define2 { get; set; }

        /// <summary>
        /// 自定义三
        /// </summary>
        [JsonProperty(PropertyName = "define3", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Define3 { get; set; }


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

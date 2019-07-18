using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 条码规则查询列表Dto
    /// </summary> 
    public class BarCodeRuleGridDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

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
        /// 类型
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// 分隔符
        /// </summary>
        [JsonProperty(PropertyName = "separator", NullValueHandling = NullValueHandling.Ignore)]
        public string Separator { get; set; }

        /// <summary>
        /// 自定义项1
        /// </summary>
        [JsonProperty(PropertyName = "define1", NullValueHandling = NullValueHandling.Ignore)]
        public string Define1 { get; set; }

        /// <summary>
        /// 自定义项2
        /// </summary>
        [JsonProperty(PropertyName = "define2", NullValueHandling = NullValueHandling.Ignore)]
        public string Define2 { get; set; }

        /// <summary>
        /// 自定义项3
        /// </summary>
        [JsonProperty(PropertyName = "define3", NullValueHandling = NullValueHandling.Ignore)]
        public string Define3 { get; set; }

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
        [JsonProperty(PropertyName = "barcoderuledetail", NullValueHandling = NullValueHandling.Ignore)]
        public virtual List<BarCodeRuleDetailSingleDto> ButtonEntities { get; set; }
    }
}

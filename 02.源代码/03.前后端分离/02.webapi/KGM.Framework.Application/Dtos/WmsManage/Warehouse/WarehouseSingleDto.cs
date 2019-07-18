using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// WarehouseSingleDto
    /// </summary>
    public class WarehouseSingleDto
    {
        #region Property Members
        
        /// <summary>
        /// id
        /// </summary>
		[JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public  string Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
		[JsonProperty(PropertyName = "encode", NullValueHandling = NullValueHandling.Ignore)]
        public  string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
		[JsonProperty(PropertyName = "fullname", NullValueHandling = NullValueHandling.Ignore)]
        public  string FullName { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
		[JsonProperty(PropertyName = "whperson", NullValueHandling = NullValueHandling.Ignore)]
        public  string WhPerson { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
		[JsonProperty(PropertyName = "whphone", NullValueHandling = NullValueHandling.Ignore)]
        public  string WhPhone { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
		[JsonProperty(PropertyName = "whemail", NullValueHandling = NullValueHandling.Ignore)]
        public  string WhEmail { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
		[JsonProperty(PropertyName = "whaddress", NullValueHandling = NullValueHandling.Ignore)]
        public  string WhAddress { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
		[JsonProperty(PropertyName = "whtype", NullValueHandling = NullValueHandling.Ignore)]
        public  string WhType { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
		[JsonProperty(PropertyName = "define1", NullValueHandling = NullValueHandling.Ignore)]
        public  string Define1 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
		[JsonProperty(PropertyName = "define2", NullValueHandling = NullValueHandling.Ignore)]
        public  string Define2 { get; set; }
        
        /// <summary>
        /// 自定义3
        /// </summary>
		[JsonProperty(PropertyName = "define3", NullValueHandling = NullValueHandling.Ignore)]
        public  string Define3 { get; set; }

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
        /// 数据字典
        /// </summary>
        [JsonProperty(PropertyName = "position", NullValueHandling = NullValueHandling.Ignore)]
        public virtual List<PositionSingleDto> PositionEntities { get; set; }
        #endregion

    }
}
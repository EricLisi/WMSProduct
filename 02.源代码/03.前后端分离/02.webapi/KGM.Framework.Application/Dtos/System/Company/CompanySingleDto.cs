using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 公司Dto
    /// </summary> 
    public class CompanySingleDto
    { 
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 父节点
        /// </summary> 
        [JsonProperty(PropertyName = "parentid", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }

        /// <summary>
        /// 图标
        /// </summary> 
        [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        /// <summary>
        ///编号
        /// </summary>
        [JsonProperty(PropertyName = "encode", NullValueHandling = NullValueHandling.Ignore)]
        public string EnCode { get; set; }

        /// <summary>
        ///名称
        /// </summary>
        [JsonProperty(PropertyName = "fullname", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        /// <summary>
        ///简称
        /// </summary>
        [JsonProperty(PropertyName = "shortname", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortName { get; set; }

        /// <summary>
        ///公司类型
        /// </summary>
        [JsonProperty(PropertyName = "nature", NullValueHandling = NullValueHandling.Ignore)]
        public int? Nature { get; set; }

        /// <summary>
        ///公司电话
        /// </summary>
        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        ///公司邮箱
        /// </summary>
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string EMail { get; set; }

        /// <summary>
        ///传真
        /// </summary>
        [JsonProperty(PropertyName = "fax", NullValueHandling = NullValueHandling.Ignore)]
        public string Fax { get; set; }

        /// <summary>
        ///联系人
        /// </summary>
        [JsonProperty(PropertyName = "manager", NullValueHandling = NullValueHandling.Ignore)]
        public string Manager { get; set; }

        /// <summary>
        ///地址
        /// </summary>
        [JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        ///公司网址
        /// </summary>
        [JsonProperty(PropertyName = "webaddress", NullValueHandling = NullValueHandling.Ignore)]
        public string WebAddress { get; set; }


        /// <summary>
        /// 省区
        /// </summary> 
        [JsonProperty(PropertyName = "provinceid", NullValueHandling = NullValueHandling.Ignore)]
        public string ProvinceId { get; set; }

        /// <summary>
        /// 市区
        /// </summary> 
        [JsonProperty(PropertyName = "cityid", NullValueHandling = NullValueHandling.Ignore)]
        public string CityId { get; set; }

        /// <summary>
        /// 县区
        /// </summary> 
        [JsonProperty(PropertyName = "countyid", NullValueHandling = NullValueHandling.Ignore)]
        public string CountyId { get; set; }

        /// <summary>
        /// 邮编
        /// </summary> 
        [JsonProperty(PropertyName = "postalcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Postalcode { get; set; }

        /// <summary>
        /// 部门集合
        /// </summary>
        [JsonProperty(PropertyName = "departments", NullValueHandling = NullValueHandling.Ignore)]
        public List<DepartmentSingleDto> Departments { get; set; }

        /// <summary>
        /// 排序码
        /// </summary> 
        [JsonProperty(PropertyName = "sortcode", NullValueHandling = NullValueHandling.Ignore)]
        public int? SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary> 
        [JsonProperty(PropertyName = "deletemark", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeleteMark { get; set; } = false;

        /// <summary>
        /// 有效标志
        /// </summary> 
        [JsonProperty(PropertyName = "enabledmark", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnabledMark { get; set; } = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty(PropertyName = "creatortime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatorTime { get; set; } = DateTime.Now;

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

    }
}

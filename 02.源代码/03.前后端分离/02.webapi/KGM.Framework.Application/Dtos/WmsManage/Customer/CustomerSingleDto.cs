using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// MST_CUSTOMERInfo
    /// </summary>
    public class CustomerSingleDto
    {
        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public  string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "encode", NullValueHandling = NullValueHandling.Ignore)]
        public  string EnCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "fullname", NullValueHandling = NullValueHandling.Ignore)]
        public  string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "person", NullValueHandling = NullValueHandling.Ignore)]
        public  string Person { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public  string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "mobile", NullValueHandling = NullValueHandling.Ignore)]
        public  string Mobile { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public  string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Ignore)]
        public  string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "province", NullValueHandling = NullValueHandling.Ignore)]
        public  string Province { get; set; }

  //      /// <summary>
  //      /// 省名称
  //      /// </summary> 
  //      [JsonProperty(PropertyName = "provincename", NullValueHandling = NullValueHandling.Ignore)]
  //      public string ProvincelistFullName { get; set; }


  //      /// <summary>
  //      /// 市名称
  //      /// </summary>
		//[JsonProperty(PropertyName = "cityname", NullValueHandling = NullValueHandling.Ignore)]
  //      public string CitylistFullName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "provincecode", NullValueHandling = NullValueHandling.Ignore)]
        public  string ProvinceCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "city", NullValueHandling = NullValueHandling.Ignore)]
        public  string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "citycode", NullValueHandling = NullValueHandling.Ignore)]
        public  string CityCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "define1", NullValueHandling = NullValueHandling.Ignore)]
        public  string Define1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[JsonProperty(PropertyName = "define2", NullValueHandling = NullValueHandling.Ignore)]
        public  string Define2 { get; set; }

        /// <summary>
        /// 
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
        [JsonProperty(PropertyName = "owner", NullValueHandling = NullValueHandling.Ignore)]
        public virtual List<CustomerOwnerSingleDto> OwnerEntities { get; set; }


    }
}
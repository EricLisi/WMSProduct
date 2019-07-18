using Newtonsoft.Json;
using System;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 地区Dto
    /// </summary>
   public class AreaSingleDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        /// <summary>
        /// 节点
        /// </summary> 
        [JsonProperty(PropertyName = "parentid", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }

        /// <summary>
        /// 层
        /// </summary> 
        [JsonProperty(PropertyName = "layer", NullValueHandling = NullValueHandling.Ignore)]
        public int Layer { get; set; }

        /// <summary>
        /// 编号
        /// </summary> 
        [JsonProperty(PropertyName = "encode", NullValueHandling = NullValueHandling.Ignore)]
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary> 
        [JsonProperty(PropertyName = "fullname", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [JsonProperty(PropertyName = "simplespelling", NullValueHandling = NullValueHandling.Ignore)]
        public string SimpleSpelling { get; set; }



    }
}

using Newtonsoft.Json;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 角色Dto
    /// </summary>
    public class RoleInsertDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

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
        ///是否是超级管理员
        /// </summary>
        [JsonProperty(PropertyName = "isadmin", NullValueHandling = NullValueHandling.Ignore)]

        public bool IsAdmin { get; set; }

        /// <summary>
        /// 描述
        /// </summary> 
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]

        public virtual string Description { get; set; }
    }
}

using Newtonsoft.Json;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 角色按钮Dto
    /// </summary>
    public class RoleButtonSingleDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 按钮Id
        /// </summary> 
        [JsonProperty(PropertyName = "mobulebuttonid", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleButtonId { get; set; }


        /// <summary>
        /// 按钮编码
        /// </summary> 
        [JsonProperty(PropertyName = "roleid", NullValueHandling = NullValueHandling.Ignore)]
        public string RoleId { get; set; }

        ///// <summary>
        ///// 按钮名称
        ///// </summary> 
        //[JsonProperty(PropertyName = "buttonfullname", NullValueHandling = NullValueHandling.Ignore)]
        //public string ModuleFullName { get; set; }


        ///// <summary>
        ///// 按钮所属模块
        ///// </summary> 
        //[JsonProperty(PropertyName = "buttonmoduleid", NullValueHandling = NullValueHandling.Ignore)]
        //public string ButtonModuleId { get; set; }

    }
}

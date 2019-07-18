using Newtonsoft.Json;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 角色列表Dto
    /// </summary>
    public class RoleColumnSingleDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 按钮Id
        /// </summary> 
        [JsonProperty(PropertyName = "mobulecolumnid", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleButtonId { get; set; }


        /// <summary>
        /// 按钮编码
        /// </summary> 
        [JsonProperty(PropertyName = "columnencode", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonEnCode { get; set; }

        /// <summary>
        /// 按钮名称
        /// </summary> 
        [JsonProperty(PropertyName = "columnfullname", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleFullName { get; set; }


        /// <summary>
        /// 按钮所属模块
        /// </summary> 
        [JsonProperty(PropertyName = "columnmoduleid", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonModuleId { get; set; }

    }
}

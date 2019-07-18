using Newtonsoft.Json;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 角色Dto
    /// </summary>
    public class RoleModuleSingleDto
    {
        
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// RoleId
        /// </summary>
        [JsonProperty(PropertyName = "roleid", NullValueHandling = NullValueHandling.Ignore)]
        public string RoleId { get; set; }
        /// <summary>
        /// 模块Id
        /// </summary> 
        [JsonProperty(PropertyName = "moduleid", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleId { get; set; }


        /// <summary>
        /// 模块编码
        /// </summary> 
        [JsonProperty(PropertyName = "moduleencode", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleEnCode { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary> 
        [JsonProperty(PropertyName = "modulefullname", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleFullName { get; set; }


        /// <summary>
        /// 模块父节点
        /// </summary> 
        [JsonProperty(PropertyName = "moduleparentid", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleParentId { get; set; }

        /// <summary>
        /// 模块图标
        /// </summary> 
        [JsonProperty(PropertyName = "moduleicon", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleIcon { get; set; }

        /// <summary>
        /// 模块目标地址
        /// </summary> 
        [JsonProperty(PropertyName = "moduleurladdress", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleUrlAddress { get; set; }


        /// <summary>
        /// 模块目标
        /// </summary> 
        [JsonProperty(PropertyName = "moduletarget", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleTarget { get; set; }

        /// <summary>
        /// 模块是否菜单
        /// </summary> 
        [JsonProperty(PropertyName = "moduleismenu", NullValueHandling = NullValueHandling.Ignore)]
        public bool ModuleIsMenu { get; set; }

        /// <summary>
        /// 模块是否可用
        /// </summary> 
        [JsonProperty(PropertyName = "moduleenabledmark", NullValueHandling = NullValueHandling.Ignore)]
        public bool ModuleEnabledMark { get; set; }

        /// <summary>
        /// 模块描述
        /// </summary> 
        [JsonProperty(PropertyName = "moduledescription", NullValueHandling = NullValueHandling.Ignore)]
        public string ModuleDescription { get; set; }

        /// <summary>
        /// 模块排序
        /// </summary> 
        [JsonProperty(PropertyName = "modulesortcode", NullValueHandling = NullValueHandling.Ignore)]
        public int? ModuleSortCode { get; set; }
    }
}

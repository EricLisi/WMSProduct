using Newtonsoft.Json;
using System.Collections.Generic;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 角色Dto
    /// </summary>
    public class RoleSingleDto
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
        ///模块
        /// </summary>
        [JsonProperty(PropertyName = "modules", NullValueHandling = NullValueHandling.Ignore)]

        public List<RoleModuleSingleDto> Modules { get; set; }


        /// <summary>
        ///按钮
        /// </summary>
        [JsonProperty(PropertyName = "buttons", NullValueHandling = NullValueHandling.Ignore)]

        public List<RoleButtonSingleDto> Buttons { get; set; }

        /// <summary>
        ///列表
        /// </summary>
        [JsonProperty(PropertyName = "columns", NullValueHandling = NullValueHandling.Ignore)]

        public List<RoleColumnSingleDto> Columns { get; set; }
    }
}

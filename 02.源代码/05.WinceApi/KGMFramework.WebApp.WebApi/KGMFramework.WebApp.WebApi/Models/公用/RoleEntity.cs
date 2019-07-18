using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 提交角色参数
    /// </summary>
    public class RoleEntity
    {
        /// <summary>
        /// 表体对象
        /// </summary>
        [DataMember]
        public Sys_RoleInfo info { get; set; }

        /// <summary>
        /// permissionIds
        /// </summary>
        [DataMember]
        public List<string> promiss { get; set; }
    }
}
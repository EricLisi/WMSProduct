using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models.Post对象
{
    [DataContract]
    public class RoleModel
    {
        /// <summary>
        /// 角色对象
        /// </summary>
        [DataMember]
        public Sys_RoleInfo role { get; set; }

        /// <summary>
        /// 角色权限集合
        /// </summary>
        [DataMember]
        public List<Sys_RoleAuthorizeInfo> roleAuthorizelist { get; set; }
    }
}
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;

namespace KGMFramework.WebApp.IDAL
{
    /// <summary>
    /// 角色表
    /// </summary>
    public interface ISys_Role : IBaseDAL<Sys_RoleInfo>
    {
        void Save(Sys_RoleInfo info, List<Sys_RoleAuthorizeInfo> permissionIds, string keyValue);
    }
}
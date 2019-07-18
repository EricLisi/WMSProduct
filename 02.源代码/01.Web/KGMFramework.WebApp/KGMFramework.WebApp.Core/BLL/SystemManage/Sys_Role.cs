using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.BLL
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Sys_Role : BaseBLL<Sys_RoleInfo>
    {
        public Sys_Role()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="info"></param>
        /// <param name="permissionIds"></param>
        /// <param name="keyValue"></param>
        public void Save(Sys_RoleInfo info, List<Sys_RoleAuthorizeInfo> permissionIds, string keyValue)
        {
            ISys_Role dal = baseDal as ISys_Role;
            dal.Save(info, permissionIds, keyValue);
        }
    }
}

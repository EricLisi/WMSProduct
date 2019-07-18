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
    /// 角色授权表
    /// </summary>
	public interface ISys_RoleAuthorize : IBaseDAL<Sys_RoleAuthorizeInfo>
	{
        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="USERID">用户ID</param>
        /// <returns></returns>
        DataSet GetUserMenu(string USERID);

        /// <summary>
        /// 获取用户按钮
        /// </summary>
        /// <param name="USERID">用户ID</param>
        /// <returns></returns>
        DataSet GetUserButton(string USERID);
    }
}
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
    /// 角色授权表
    /// </summary>
    public class Sys_RoleAuthorize : BaseBLL<Sys_RoleAuthorizeInfo>
    {
        public Sys_RoleAuthorize()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }


        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="USERID">用户ID</param>
        /// <returns></returns>
        public List<Sys_ModuleInfo> GetUserMenu(string USERID)
        {
            List<Sys_ModuleInfo> data = new List<Sys_ModuleInfo>();

            ISys_RoleAuthorize dal = baseDal as ISys_RoleAuthorize;
            DataTable dt = dal.GetUserMenu(USERID).Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                Sys_ModuleInfo info = new Sys_ModuleInfo();
                info.F_Id = dr["F_ID"].ToString();
                info.F_Layers = dr["F_Layers"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["F_Layers"]);
                info.F_IsMenu = dr["F_IsMenu"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_IsMenu"]);
                info.F_IsExpand = dr["F_IsExpand"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_IsExpand"]);
                info.F_IsPublic = dr["F_IsPublic"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_IsPublic"]);
                info.F_AllowEdit = dr["F_AllowEdit"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_AllowEdit"]);
                info.F_AllowDelete = dr["F_AllowDelete"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_AllowDelete"]);
                info.F_SortCode = dr["F_SortCode"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["F_SortCode"]); ;
                info.F_DeleteMark = dr["F_DeleteMark"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_DeleteMark"]);
                info.F_EnabledMark = dr["F_EnabledMark"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_EnabledMark"]);
                info.F_ParentId = dr["F_ParentId"].ToString();
                info.F_EnCode = dr["F_EnCode"].ToString();
                info.F_FullName = dr["F_FullName"].ToString();
                info.F_Icon = dr["F_Icon"].ToString();
                info.F_Target = dr["F_Target"].ToString();
                info.F_UrlAddress = dr["F_UrlAddress"].ToString();

                data.Add(info);
            }

            return data;
        }


        /// <summary>
        /// 获取用户按钮
        /// </summary>
        /// <param name="USERID">用户ID</param>
        /// <returns></returns>
        public List<Sys_ModuleButtonInfo> GetUserButton(string USERID)
        {
            List<Sys_ModuleButtonInfo> data = new List<Sys_ModuleButtonInfo>();

            ISys_RoleAuthorize dal = baseDal as ISys_RoleAuthorize;
            DataTable dt = dal.GetUserButton(USERID).Tables[0];
 
            foreach (DataRow dr in dt.Rows)
            {
                Sys_ModuleButtonInfo info = new Sys_ModuleButtonInfo();
                info.F_Id = dr["F_ID"].ToString();
                info.F_Layers = dr["F_Layers"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["F_Layers"]);
                info.F_JsEvent = dr["F_JsEvent"].ToString();
                info.F_Location = dr["F_Location"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["F_Location"]);
                info.F_Split = dr["F_Split"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_Split"]);
                info.F_IsPublic = dr["F_IsPublic"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_IsPublic"]);
                info.F_AllowEdit = dr["F_AllowEdit"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_AllowEdit"]);
                info.F_AllowDelete = dr["F_AllowDelete"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_AllowDelete"]);
                info.F_SortCode = dr["F_SortCode"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["F_SortCode"]); ;
                info.F_DeleteMark = dr["F_DeleteMark"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_DeleteMark"]);
                info.F_EnabledMark = dr["F_EnabledMark"].ToString() == string.Empty ? false : Convert.ToBoolean(dr["F_EnabledMark"]);
                info.F_ParentId = dr["F_ParentId"].ToString();
                info.F_EnCode = dr["F_EnCode"].ToString();
                info.F_FullName = dr["F_FullName"].ToString();
                info.F_Icon = dr["F_Icon"].ToString();
                info.F_UrlAddress = dr["F_UrlAddress"].ToString();
                info.F_ModuleId = dr["F_ModuleId"].ToString();

                data.Add(info); 
            }

            return data;
        }
    }
}

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGM.Pager.Entity;
using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;

namespace KGMFramework.WebApp.DALSQL
{
    /// <summary>
    /// 角色授权表
    /// </summary>
    public class Sys_RoleAuthorize : BaseDALSQL<Sys_RoleAuthorizeInfo>, ISys_RoleAuthorize
    {
        #region 对象实例及构造函数

        public static Sys_RoleAuthorize Instance
        {
            get
            {
                return new Sys_RoleAuthorize();
            }
        }
        public Sys_RoleAuthorize()
            : base("Sys_RoleAuthorize", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_RoleAuthorizeInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_RoleAuthorizeInfo info = new Sys_RoleAuthorizeInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_ItemType = reader.GetInt32Nullable("F_ItemType");
            info.F_ItemId = reader.GetString("F_ItemId");
            info.F_ObjectType = reader.GetInt32Nullable("F_ObjectType");
            info.F_ObjectId = reader.GetString("F_ObjectId");
            info.F_SortCode = reader.GetInt32Nullable("F_SortCode");
            info.F_CreatorTime = reader.GetDateTimeNullable("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_RoleAuthorizeInfo obj)
        {
            Sys_RoleAuthorizeInfo info = obj as Sys_RoleAuthorizeInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_ItemType", info.F_ItemType);
            hash.Add("F_ItemId", info.F_ItemId);
            hash.Add("F_ObjectType", info.F_ObjectType);
            hash.Add("F_ObjectId", info.F_ObjectId);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);

            return hash;
        }

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
            dict.Add("F_Id", "角色授权主键");
            dict.Add("F_ItemType", "项目类型1-模块2-按钮3-列表");
            dict.Add("F_ItemId", "项目主键");
            dict.Add("F_ObjectType", "对象分类1-角色2-部门-3用户");
            dict.Add("F_ObjectId", "对象主键");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_CreatorTime", "创建时间");
            dict.Add("F_CreatorUserId", "创建用户");
            #endregion

            return dict;
        }

        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="USERID">用户ID</param>
        /// <returns></returns>
        public DataSet GetUserMenu(string USERID)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("USERID", DbType.String, USERID));

            return base.ExecuteDataSetByProc("[SYS_GETUSERMENU]", paramList);
        }

        /// <summary>
        /// 获取用户按钮权限
        /// </summary>
        /// <param name="USERID">用户ID</param>
        /// <returns></returns>
        public DataSet GetUserButton(string USERID)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("USERID", DbType.String, USERID));

            return base.ExecuteDataSetByProc("[SYS_GETUSERBUTTON]", paramList);
        }
    }
}
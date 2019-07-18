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
    /// 角色表
    /// </summary>
    public class Sys_Role : BaseDALSQL<Sys_RoleInfo>, ISys_Role
    {
        #region 对象实例及构造函数

        public static Sys_Role Instance
        {
            get
            {
                return new Sys_Role();
            }
        }
        public Sys_Role()
            : base("Sys_Role", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_RoleInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_RoleInfo info = new Sys_RoleInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_OrganizeId = reader.GetString("F_OrganizeId");
            info.F_Category = reader.GetInt32Nullable("F_Category");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_Type = reader.GetString("F_Type");
            info.F_AllowEdit = reader.GetBooleanNullable("F_AllowEdit");
            info.F_AllowDelete = reader.GetBooleanNullable("F_AllowDelete");
            info.F_SortCode = reader.GetInt32Nullable("F_SortCode");
            info.F_DeleteMark = reader.GetBooleanNullable("F_DeleteMark");
            info.F_EnabledMark = reader.GetBooleanNullable("F_EnabledMark");
            info.F_Description = reader.GetString("F_Description");
            info.F_CreatorTime = reader.GetDateTimeNullable("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyTime = reader.GetDateTimeNullable("F_LastModifyTime");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_DeleteTime = reader.GetDateTimeNullable("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_RoleInfo obj)
        {
            Sys_RoleInfo info = obj as Sys_RoleInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_OrganizeId", info.F_OrganizeId);
            hash.Add("F_Category", info.F_Category);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_Type", info.F_Type);
            hash.Add("F_AllowEdit", info.F_AllowEdit);
            hash.Add("F_AllowDelete", info.F_AllowDelete);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_DeleteTime", info.F_DeleteTime);
            hash.Add("F_DeleteUserId", info.F_DeleteUserId);

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
            dict.Add("F_Id", "角色主键");
            dict.Add("F_OrganizeId", "组织主键");
            dict.Add("F_Category", "分类:1-角色2-岗位");
            dict.Add("F_EnCode", "编号");
            dict.Add("F_FullName", "名称");
            dict.Add("F_Type", "类型");
            dict.Add("F_AllowEdit", "允许编辑");
            dict.Add("F_AllowDelete", "允许删除");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_Description", "描述");
            dict.Add("F_CreatorTime", "创建时间");
            dict.Add("F_CreatorUserId", "创建用户");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            #endregion

            return dict;
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="info"></param>
        /// <param name="permissionIds"></param>
        /// <param name="keyValue"></param>
        public void Save(Sys_RoleInfo info, List<Sys_RoleAuthorizeInfo> permissionIds, string keyValue)
        {
            using (DbTransactionScope<Sys_RoleInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //增加角色
                    this.InsertUpdate(info, keyValue, dbtran.Transaction);
                    //删除角色对应权限
                    SearchCondition condtion = new SearchCondition();
                    condtion.AddCondition("F_ObjectId", info.F_Id, SqlOperator.Equal);
                    Sys_RoleAuthorize.Instance.DeleteByCondition(condtion.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty),dbtran.Transaction);
                    //增加角色权限
                    foreach (Sys_RoleAuthorizeInfo model in permissionIds)
                    {
                        Sys_RoleAuthorize.Instance.Insert(model, dbtran.Transaction);
                    }
                    //提交事务
                    dbtran.Commit();
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }

            }

        }

    }
}
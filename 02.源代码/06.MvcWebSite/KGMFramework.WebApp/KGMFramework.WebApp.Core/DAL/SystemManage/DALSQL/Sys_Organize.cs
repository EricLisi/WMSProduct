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
    /// 组织表
    /// </summary>
	public class Sys_Organize : BaseDALSQL<Sys_OrganizeInfo>, ISys_Organize
	{
		#region 对象实例及构造函数

		public static Sys_Organize Instance
		{
			get
			{
				return new Sys_Organize();
			}
		}
		public Sys_Organize() : base("Sys_Organize","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Sys_OrganizeInfo DataReaderToEntity(IDataReader dataReader)
		{
			Sys_OrganizeInfo info = new Sys_OrganizeInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_ParentId = reader.GetString("F_ParentId");
			info.F_Layers = reader.GetInt32Nullable("F_Layers");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_FullName = reader.GetString("F_FullName");
			info.F_ShortName = reader.GetString("F_ShortName");
			info.F_CategoryId = reader.GetString("F_CategoryId");
			info.F_ManagerId = reader.GetString("F_ManagerId");
			info.F_TelePhone = reader.GetString("F_TelePhone");
			info.F_MobilePhone = reader.GetString("F_MobilePhone");
			info.F_WeChat = reader.GetString("F_WeChat");
			info.F_Fax = reader.GetString("F_Fax");
			info.F_Email = reader.GetString("F_Email");
			info.F_AreaId = reader.GetString("F_AreaId");
			info.F_Address = reader.GetString("F_Address");
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
        protected override Hashtable GetHashByEntity(Sys_OrganizeInfo obj)
		{
		    Sys_OrganizeInfo info = obj as Sys_OrganizeInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_ParentId", info.F_ParentId);
 			hash.Add("F_Layers", info.F_Layers);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_FullName", info.F_FullName);
 			hash.Add("F_ShortName", info.F_ShortName);
 			hash.Add("F_CategoryId", info.F_CategoryId);
 			hash.Add("F_ManagerId", info.F_ManagerId);
 			hash.Add("F_TelePhone", info.F_TelePhone);
 			hash.Add("F_MobilePhone", info.F_MobilePhone);
 			hash.Add("F_WeChat", info.F_WeChat);
 			hash.Add("F_Fax", info.F_Fax);
 			hash.Add("F_Email", info.F_Email);
 			hash.Add("F_AreaId", info.F_AreaId);
 			hash.Add("F_Address", info.F_Address);
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
            dict.Add("F_Id", "组织主键");
             dict.Add("F_ParentId", "父级");
             dict.Add("F_Layers", "层次");
             dict.Add("F_EnCode", "编码");
             dict.Add("F_FullName", "名称");
             dict.Add("F_ShortName", "简称");
             dict.Add("F_CategoryId", "分类");
             dict.Add("F_ManagerId", "负责人");
             dict.Add("F_TelePhone", "电话");
             dict.Add("F_MobilePhone", "手机");
             dict.Add("F_WeChat", "微信");
             dict.Add("F_Fax", "传真");
             dict.Add("F_Email", "邮箱");
             dict.Add("F_AreaId", "归属区域");
             dict.Add("F_Address", "联系地址");
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
		
     
    }
}
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
    /// 模块按钮
    /// </summary>
	public class Sys_ModuleButton : BaseDALSQL<Sys_ModuleButtonInfo>, ISys_ModuleButton
	{
		#region 对象实例及构造函数

		public static Sys_ModuleButton Instance
		{
			get
			{
				return new Sys_ModuleButton();
			}
		}
		public Sys_ModuleButton() : base("Sys_ModuleButton","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Sys_ModuleButtonInfo DataReaderToEntity(IDataReader dataReader)
		{
			Sys_ModuleButtonInfo info = new Sys_ModuleButtonInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_ModuleId = reader.GetString("F_ModuleId");
			info.F_ParentId = reader.GetString("F_ParentId");
			info.F_Layers = reader.GetInt32Nullable("F_Layers");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_FullName = reader.GetString("F_FullName");
			info.F_Icon = reader.GetString("F_Icon");
			info.F_Location = reader.GetInt32Nullable("F_Location");
			info.F_JsEvent = reader.GetString("F_JsEvent");
			info.F_UrlAddress = reader.GetString("F_UrlAddress");
			info.F_Split = reader.GetBooleanNullable("F_Split");
			info.F_IsPublic = reader.GetBooleanNullable("F_IsPublic");
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
        protected override Hashtable GetHashByEntity(Sys_ModuleButtonInfo obj)
		{
		    Sys_ModuleButtonInfo info = obj as Sys_ModuleButtonInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_ModuleId", info.F_ModuleId);
 			hash.Add("F_ParentId", info.F_ParentId);
 			hash.Add("F_Layers", info.F_Layers);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_FullName", info.F_FullName);
 			hash.Add("F_Icon", info.F_Icon);
 			hash.Add("F_Location", info.F_Location);
 			hash.Add("F_JsEvent", info.F_JsEvent);
 			hash.Add("F_UrlAddress", info.F_UrlAddress);
 			hash.Add("F_Split", info.F_Split);
 			hash.Add("F_IsPublic", info.F_IsPublic);
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
            dict.Add("F_Id", "按钮主键");
             dict.Add("F_ModuleId", "模块主键");
             dict.Add("F_ParentId", "父级");
             dict.Add("F_Layers", "层次");
             dict.Add("F_EnCode", "编码");
             dict.Add("F_FullName", "名称");
             dict.Add("F_Icon", "图标");
             dict.Add("F_Location", "位置");
             dict.Add("F_JsEvent", "事件");
             dict.Add("F_UrlAddress", "连接");
             dict.Add("F_Split", "分开线");
             dict.Add("F_IsPublic", "公共");
             dict.Add("F_AllowEdit", "允许编辑");
             dict.Add("F_AllowDelete", "允许删除");
             dict.Add("F_SortCode", "排序码");
             dict.Add("F_DeleteMark", "删除标志");
             dict.Add("F_EnabledMark", "有效标志");
             dict.Add("F_Description", "描述");
             dict.Add("F_CreatorTime", "创建日期");
             dict.Add("F_CreatorUserId", "创建用户主键");
             dict.Add("F_LastModifyTime", "最后修改时间");
             dict.Add("F_LastModifyUserId", "最后修改用户");
             dict.Add("F_DeleteTime", "删除时间");
             dict.Add("F_DeleteUserId", "删除用户");
             #endregion

            return dict;
        }
		
     
    }
}
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
    /// 模块表单实例
    /// </summary>
	public class Sys_ModuleFormInstance : BaseDALSQL<Sys_ModuleFormInstanceInfo>, ISys_ModuleFormInstance
	{
		#region 对象实例及构造函数

		public static Sys_ModuleFormInstance Instance
		{
			get
			{
				return new Sys_ModuleFormInstance();
			}
		}
		public Sys_ModuleFormInstance() : base("Sys_ModuleFormInstance","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Sys_ModuleFormInstanceInfo DataReaderToEntity(IDataReader dataReader)
		{
			Sys_ModuleFormInstanceInfo info = new Sys_ModuleFormInstanceInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_FormId = reader.GetString("F_FormId");
			info.F_ObjectId = reader.GetString("F_ObjectId");
			info.F_InstanceJson = reader.GetString("F_InstanceJson");
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
        protected override Hashtable GetHashByEntity(Sys_ModuleFormInstanceInfo obj)
		{
		    Sys_ModuleFormInstanceInfo info = obj as Sys_ModuleFormInstanceInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_FormId", info.F_FormId);
 			hash.Add("F_ObjectId", info.F_ObjectId);
 			hash.Add("F_InstanceJson", info.F_InstanceJson);
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
            dict.Add("F_Id", "表单实例主键");
             dict.Add("F_FormId", "表单主键");
             dict.Add("F_ObjectId", "对象主键");
             dict.Add("F_InstanceJson", "表单实例Json");
             dict.Add("F_SortCode", "排序码");
             dict.Add("F_CreatorTime", "创建时间");
             dict.Add("F_CreatorUserId", "创建用户");
             #endregion

            return dict;
        }
		
     
    }
}
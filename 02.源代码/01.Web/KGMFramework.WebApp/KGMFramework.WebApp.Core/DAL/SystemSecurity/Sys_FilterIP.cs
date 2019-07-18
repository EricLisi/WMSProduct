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
    /// 过滤IP
    /// </summary>
	public class Sys_FilterIP : BaseDALSQL<Sys_FilterIPInfo>, ISys_FilterIP
	{
		#region 对象实例及构造函数

		public static Sys_FilterIP Instance
		{
			get
			{
				return new Sys_FilterIP();
			}
		}
		public Sys_FilterIP() : base("Sys_FilterIP","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Sys_FilterIPInfo DataReaderToEntity(IDataReader dataReader)
		{
			Sys_FilterIPInfo info = new Sys_FilterIPInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_Type = reader.GetBooleanNullable("F_Type");
			info.F_StartIP = reader.GetString("F_StartIP");
			info.F_EndIP = reader.GetString("F_EndIP");
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
        protected override Hashtable GetHashByEntity(Sys_FilterIPInfo obj)
		{
		    Sys_FilterIPInfo info = obj as Sys_FilterIPInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_Type", info.F_Type);
 			hash.Add("F_StartIP", info.F_StartIP);
 			hash.Add("F_EndIP", info.F_EndIP);
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
            dict.Add("F_Id", "过滤主键");
             dict.Add("F_Type", "类型");
             dict.Add("F_StartIP", "开始IP");
             dict.Add("F_EndIP", "结束IP");
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
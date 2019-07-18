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
    /// 业务类型默认值表
    /// </summary>
	public class Sys_VouchTypeDefault : BaseDALSQL<Sys_VouchTypeDefaultInfo>, ISys_VouchTypeDefault
	{
		#region 对象实例及构造函数

		public static Sys_VouchTypeDefault Instance
		{
			get
			{
				return new Sys_VouchTypeDefault();
			}
		}
		public Sys_VouchTypeDefault() : base("Sys_VouchTypeDefault","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Sys_VouchTypeDefaultInfo DataReaderToEntity(IDataReader dataReader)
		{
			Sys_VouchTypeDefaultInfo info = new Sys_VouchTypeDefaultInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_FullName = reader.GetString("F_FullName");
			info.F_VouchId = reader.GetString("F_VouchId");
			info.F_VouchDefaultItemId = reader.GetString("F_VouchDefaultItemId");
			info.F_DefaultValue = reader.GetString("F_DefaultValue");
			info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
			info.F_SortCode = reader.GetInt32("F_SortCode");
			info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
			info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
			info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
			info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
			info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
			info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
			info.F_DeleteUserId = reader.GetString("F_DeleteUserId");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_VouchTypeDefaultInfo obj)
		{
		    Sys_VouchTypeDefaultInfo info = obj as Sys_VouchTypeDefaultInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_FullName", info.F_FullName);
 			hash.Add("F_VouchId", info.F_VouchId);
 			hash.Add("F_VouchDefaultItemId", info.F_VouchDefaultItemId);
 			hash.Add("F_DefaultValue", info.F_DefaultValue);
 			hash.Add("F_DeleteMark", info.F_DeleteMark);
 			hash.Add("F_SortCode", info.F_SortCode);
 			hash.Add("F_EnabledMark", info.F_EnabledMark);
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
            dict.Add("F_Id", "主键  ");
             dict.Add("F_EnCode", "编码  ");
             dict.Add("F_FullName", "名称");
             dict.Add("F_VouchId", "业务类型Id");
             dict.Add("F_VouchDefaultItemId", "默认值项Id");
             dict.Add("F_DefaultValue", "默认值");
             dict.Add("F_DeleteMark", "删除标志");
             dict.Add("F_SortCode", "排序码");
             dict.Add("F_EnabledMark", "有效标志");
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
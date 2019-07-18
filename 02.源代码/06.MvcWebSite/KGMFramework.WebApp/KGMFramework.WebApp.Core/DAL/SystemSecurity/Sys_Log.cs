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
    /// 系统日志
    /// </summary>
	public class Sys_Log : BaseDALSQL<Sys_LogInfo>, ISys_Log
	{
		#region 对象实例及构造函数

		public static Sys_Log Instance
		{
			get
			{
				return new Sys_Log();
			}
		}
		public Sys_Log() : base("Sys_Log","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Sys_LogInfo DataReaderToEntity(IDataReader dataReader)
		{
			Sys_LogInfo info = new Sys_LogInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_Date = reader.GetDateTimeNullable("F_Date");
			info.F_Account = reader.GetString("F_Account");
			info.F_NickName = reader.GetString("F_NickName");
			info.F_Type = reader.GetString("F_Type");
			info.F_IPAddress = reader.GetString("F_IPAddress");
			info.F_IPAddressName = reader.GetString("F_IPAddressName");
			info.F_ModuleId = reader.GetString("F_ModuleId");
			info.F_ModuleName = reader.GetString("F_ModuleName");
			info.F_Result = reader.GetBooleanNullable("F_Result");
			info.F_Description = reader.GetString("F_Description");
			info.F_CreatorTime = reader.GetDateTimeNullable("F_CreatorTime");
			info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_LogInfo obj)
		{
		    Sys_LogInfo info = obj as Sys_LogInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_Date", info.F_Date);
 			hash.Add("F_Account", info.F_Account);
 			hash.Add("F_NickName", info.F_NickName);
 			hash.Add("F_Type", info.F_Type);
 			hash.Add("F_IPAddress", info.F_IPAddress);
 			hash.Add("F_IPAddressName", info.F_IPAddressName);
 			hash.Add("F_ModuleId", info.F_ModuleId);
 			hash.Add("F_ModuleName", info.F_ModuleName);
 			hash.Add("F_Result", info.F_Result);
 			hash.Add("F_Description", info.F_Description);
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
            dict.Add("F_Id", "日志主键");
             dict.Add("F_Date", "日期");
             dict.Add("F_Account", "用户名");
             dict.Add("F_NickName", "姓名");
             dict.Add("F_Type", "类型");
             dict.Add("F_IPAddress", "IP地址");
             dict.Add("F_IPAddressName", "IP所在城市");
             dict.Add("F_ModuleId", "系统模块Id");
             dict.Add("F_ModuleName", "系统模块");
             dict.Add("F_Result", "结果");
             dict.Add("F_Description", "描述");
             dict.Add("F_CreatorTime", "创建时间");
             dict.Add("F_CreatorUserId", "创建用户");
             #endregion

            return dict;
        }
		
     
    }
}
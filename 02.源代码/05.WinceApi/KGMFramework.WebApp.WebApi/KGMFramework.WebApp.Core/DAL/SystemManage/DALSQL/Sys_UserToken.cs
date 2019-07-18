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
    /// 用户令牌
    /// </summary>
	public class Sys_UserToken : BaseDALSQL<Sys_UserTokenInfo>, ISys_UserToken
	{
		#region 对象实例及构造函数

		public static Sys_UserToken Instance
		{
			get
			{
				return new Sys_UserToken();
			}
		}
		public Sys_UserToken() : base("Sys_UserToken","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Sys_UserTokenInfo DataReaderToEntity(IDataReader dataReader)
		{
			Sys_UserTokenInfo info = new Sys_UserTokenInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_FullName = reader.GetString("F_FullName");
			info.F_UserId = reader.GetString("F_UserId");
			info.F_Token = reader.GetString("F_Token");
			info.F_Sortid = reader.GetDouble("F_Sortid");
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
        protected override Hashtable GetHashByEntity(Sys_UserTokenInfo obj)
		{
		    Sys_UserTokenInfo info = obj as Sys_UserTokenInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_FullName", info.F_FullName);
 			hash.Add("F_UserId", info.F_UserId);
 			hash.Add("F_Token", info.F_Token);
 			hash.Add("F_Sortid", info.F_Sortid);
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
            dict.Add("F_Id", "模块主键  ");
             dict.Add("F_EnCode", "编码");
             dict.Add("F_FullName", "名称");
             dict.Add("F_UserId", "用户Id");
             dict.Add("F_Token", "令牌");
             dict.Add("F_Sortid", "排序号");
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
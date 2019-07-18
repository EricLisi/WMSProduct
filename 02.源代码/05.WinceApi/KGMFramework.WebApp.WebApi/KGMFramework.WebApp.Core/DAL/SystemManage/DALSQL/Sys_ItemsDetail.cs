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
    /// 选项明细表
    /// </summary>
	public class Sys_ItemsDetail : BaseDALSQL<Sys_ItemsDetailInfo>, ISys_ItemsDetail
	{
		#region 对象实例及构造函数

		public static Sys_ItemsDetail Instance
		{
			get
			{
				return new Sys_ItemsDetail();
			}
		}
		public Sys_ItemsDetail() : base("Sys_ItemsDetail","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Sys_ItemsDetailInfo DataReaderToEntity(IDataReader dataReader)
		{
			Sys_ItemsDetailInfo info = new Sys_ItemsDetailInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_ItemId = reader.GetString("F_ItemId");
			info.F_ParentId = reader.GetString("F_ParentId");
			info.F_ItemCode = reader.GetString("F_ItemCode");
			info.F_ItemName = reader.GetString("F_ItemName");
			info.F_SimpleSpelling = reader.GetString("F_SimpleSpelling");
			info.F_IsDefault = reader.GetBooleanNullable("F_IsDefault");
			info.F_Layers = reader.GetInt32Nullable("F_Layers");
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
        protected override Hashtable GetHashByEntity(Sys_ItemsDetailInfo obj)
		{
		    Sys_ItemsDetailInfo info = obj as Sys_ItemsDetailInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_ItemId", info.F_ItemId);
 			hash.Add("F_ParentId", info.F_ParentId);
 			hash.Add("F_ItemCode", info.F_ItemCode);
 			hash.Add("F_ItemName", info.F_ItemName);
 			hash.Add("F_SimpleSpelling", info.F_SimpleSpelling);
 			hash.Add("F_IsDefault", info.F_IsDefault);
 			hash.Add("F_Layers", info.F_Layers);
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
            dict.Add("F_Id", "明细主键");
             dict.Add("F_ItemId", "主表主键");
             dict.Add("F_ParentId", "父级");
             dict.Add("F_ItemCode", "编码");
             dict.Add("F_ItemName", "名称");
             dict.Add("F_SimpleSpelling", "简拼");
             dict.Add("F_IsDefault", "默认");
             dict.Add("F_Layers", "层次");
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
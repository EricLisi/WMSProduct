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
    /// 客户信息表
    /// </summary>
	public class Mst_Customer : BaseDALSQL<Mst_CustomerInfo>, IMst_Customer
	{
		#region 对象实例及构造函数

		public static Mst_Customer Instance
		{
			get
			{
				return new Mst_Customer();
			}
		}
		public Mst_Customer() : base("Mst_Customer","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Mst_CustomerInfo DataReaderToEntity(IDataReader dataReader)
		{
			Mst_CustomerInfo info = new Mst_CustomerInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_FullName = reader.GetString("F_FullName");
			info.F_OrganizationId = reader.GetString("F_OrganizationId");
			info.F_ClassId = reader.GetString("F_ClassId");
			info.F_Contacts = reader.GetString("F_Contacts");
			info.F_TelePhone = reader.GetString("F_TelePhone");
			info.F_MobilePhone = reader.GetString("F_MobilePhone");
			info.F_Email = reader.GetString("F_Email");
			info.F_WeChat = reader.GetString("F_WeChat");
			info.F_Fax = reader.GetString("F_Fax");
			info.F_Address = reader.GetString("F_Address");
			info.F_Define1 = reader.GetString("F_Define1");
			info.F_Define2 = reader.GetString("F_Define2");
			info.F_Define3 = reader.GetString("F_Define3");
			info.F_Define4 = reader.GetString("F_Define4");
			info.F_Define5 = reader.GetString("F_Define5");
			info.F_Define6 = reader.GetString("F_Define6");
			info.F_Define7 = reader.GetString("F_Define7");
			info.F_Define8 = reader.GetString("F_Define8");
			info.F_Define9 = reader.GetString("F_Define9");
			info.F_Define10 = reader.GetString("F_Define10");
			info.F_Description = reader.GetString("F_Description");
			info.F_SortCode = reader.GetInt32("F_SortCode");
			info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
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
        protected override Hashtable GetHashByEntity(Mst_CustomerInfo obj)
		{
		    Mst_CustomerInfo info = obj as Mst_CustomerInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_FullName", info.F_FullName);
 			hash.Add("F_OrganizationId", info.F_OrganizationId);
 			hash.Add("F_ClassId", info.F_ClassId);
 			hash.Add("F_Contacts", info.F_Contacts);
 			hash.Add("F_TelePhone", info.F_TelePhone);
 			hash.Add("F_MobilePhone", info.F_MobilePhone);
 			hash.Add("F_Email", info.F_Email);
 			hash.Add("F_WeChat", info.F_WeChat);
 			hash.Add("F_Fax", info.F_Fax);
 			hash.Add("F_Address", info.F_Address);
 			hash.Add("F_Define1", info.F_Define1);
 			hash.Add("F_Define2", info.F_Define2);
 			hash.Add("F_Define3", info.F_Define3);
 			hash.Add("F_Define4", info.F_Define4);
 			hash.Add("F_Define5", info.F_Define5);
 			hash.Add("F_Define6", info.F_Define6);
 			hash.Add("F_Define7", info.F_Define7);
 			hash.Add("F_Define8", info.F_Define8);
 			hash.Add("F_Define9", info.F_Define9);
 			hash.Add("F_Define10", info.F_Define10);
 			hash.Add("F_Description", info.F_Description);
 			hash.Add("F_SortCode", info.F_SortCode);
 			hash.Add("F_DeleteMark", info.F_DeleteMark);
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
            dict.Add("F_Id", "主键");
             dict.Add("F_EnCode", "客户编号");
             dict.Add("F_FullName", "客户名称");
             dict.Add("F_OrganizationId", "所属机构Id");
             dict.Add("F_ClassId", "客户分类Id");
             dict.Add("F_Contacts", "联系人");
             dict.Add("F_TelePhone", "电话");
             dict.Add("F_MobilePhone", "手机号码");
             dict.Add("F_Email", "邮箱");
             dict.Add("F_WeChat", "微信");
             dict.Add("F_Fax", "传真");
             dict.Add("F_Address", "地址");
             dict.Add("F_Define1", "自定义项1");
             dict.Add("F_Define2", "自定义项2");
             dict.Add("F_Define3", "自定义项3");
             dict.Add("F_Define4", "自定义项4");
             dict.Add("F_Define5", "自定义项5");
             dict.Add("F_Define6", "自定义项6");
             dict.Add("F_Define7", "自定义项7");
             dict.Add("F_Define8", "自定义项8");
             dict.Add("F_Define9", "自定义项9");
             dict.Add("F_Define10", "自定义项10");
             dict.Add("F_Description", "备注");
             dict.Add("F_SortCode", "排序号");
             dict.Add("F_DeleteMark", "删除标记");
             dict.Add("F_EnabledMark", "有效标记");
             dict.Add("F_CreatorTime", "创建时间");
             dict.Add("F_CreatorUserId", "创建人");
             dict.Add("F_LastModifyTime", "最后修改时间");
             dict.Add("F_LastModifyUserId", "最后修改人");
             dict.Add("F_DeleteTime", "删除时间");
             dict.Add("F_DeleteUserId", "删除操作人");
             #endregion

            return dict;
        }
		
     
    }
}
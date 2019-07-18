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
    /// 资产调拨子表
    /// </summary>
    public class Mst_Suppliers : BaseDALSQL<Mst_SuppliersInfo>,IMst_Suppliers
	{
		#region 对象实例及构造函数

		public static Mst_Suppliers Instance
		{
			get
			{
				return new Mst_Suppliers();
			}
		}
        public Mst_Suppliers()
            : base("Mst_Suppliers", "F_Id")
		{
		}

		#endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Mst_SuppliersInfo DataReaderToEntity(IDataReader dataReader)
        {
            Mst_SuppliersInfo info = new Mst_SuppliersInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_ParentId = reader.GetString("F_ParentId");
            info.F_SperCategoryId = reader.GetString("F_SperCategoryId");
            info.F_Contacts = reader.GetString("F_Contacts");
            info.F_TelePhone = reader.GetString("F_TelePhone");
            info.F_MobilePhone = reader.GetString("F_MobilePhone");
            info.F_WeChat = reader.GetString("F_WeChat");
            info.F_Fax = reader.GetString("F_Fax");
            info.F_Address = reader.GetString("F_Address");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_Description = reader.GetString("F_Description");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Mst_SuppliersInfo obj)
        {
            Mst_SuppliersInfo info = obj as Mst_SuppliersInfo;
            Hashtable hash = new Hashtable();
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_ParentId", info.F_ParentId);
            hash.Add("F_SperCategoryId", info.F_SperCategoryId);
            hash.Add("F_Contacts", info.F_Contacts);
            hash.Add("F_TelePhone", info.F_TelePhone);
            hash.Add("F_MobilePhone", info.F_MobilePhone);
            hash.Add("F_WeChat", info.F_WeChat);
            hash.Add("F_Fax", info.F_Fax);
            hash.Add("F_Address", info.F_Address);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
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
            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "客户编码");
            dict.Add("F_FullName", "客户名称");
            dict.Add("F_ParentId", "父节点");
            dict.Add("F_CusterCategoryId", "客户类型");
            dict.Add("F_Contacts", "联系人");
            dict.Add("F_TelePhone", "电话");
            dict.Add("F_MobilePhone", "手机");
            dict.Add("F_WeChat", "微信");
            dict.Add("F_Fax", "传真");
            dict.Add("F_Address", "地址");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_Description", "备注");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_CreatorTime", "创建日期");
            #endregion

            return dict;
        }
     
    }
}
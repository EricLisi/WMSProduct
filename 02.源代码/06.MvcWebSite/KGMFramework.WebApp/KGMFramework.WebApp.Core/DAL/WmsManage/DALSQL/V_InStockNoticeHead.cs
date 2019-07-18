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
    /// V_InStockNoticeHead
    /// </summary>
	public class V_InStockNoticeHead : BaseDALSQL<V_InStockNoticeHeadInfo>, IV_InStockNoticeHead
	{
		#region 对象实例及构造函数

		public static V_InStockNoticeHead Instance
		{
			get
			{
				return new V_InStockNoticeHead();
			}
		}
		public V_InStockNoticeHead() : base("V_InStockNoticeHead","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override V_InStockNoticeHeadInfo DataReaderToEntity(IDataReader dataReader)
		{
			V_InStockNoticeHeadInfo info = new V_InStockNoticeHeadInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_OrganizationId = reader.GetString("F_OrganizationId");
			info.F_SupplierId = reader.GetString("F_SupplierId");
			info.F_SrTypeId = reader.GetString("F_SrTypeId");
			info.F_OwnershipId = reader.GetString("F_OwnershipId");
			info.F_Maker = reader.GetString("F_Maker");
			info.F_Date = reader.GetDateTime("F_Date");
			info.F_Verifier = reader.GetString("F_Verifier");
			info.F_Veridate = reader.GetDateTime("F_Veridate");
			info.F_Status = reader.GetInt32("F_Status");
			info.F_SourceId = reader.GetString("F_SourceId");
			info.F_SourceType = reader.GetString("F_SourceType");
			info.F_SourceNo = reader.GetString("F_SourceNo");
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
			info.F_SupplierCode = reader.GetString("F_SupplierCode");
			info.F_SupplierName = reader.GetString("F_SupplierName");
			info.F_SupplierClassId = reader.GetString("F_SupplierClassId");
			info.F_SupplierContacts = reader.GetString("F_SupplierContacts");
			info.F_SupplierTelePhone = reader.GetString("F_SupplierTelePhone");
			info.F_SupplierMobilePhone = reader.GetString("F_SupplierMobilePhone");
			info.F_SupplierEmail = reader.GetString("F_SupplierEmail");
			info.F_SupplierWeChat = reader.GetString("F_SupplierWeChat");
			info.F_SupplierFax = reader.GetString("F_SupplierFax");
			info.F_SupplierAddress = reader.GetString("F_SupplierAddress");
			info.F_SupplierDefine1 = reader.GetString("F_SupplierDefine1");
			info.F_SupplierDefine2 = reader.GetString("F_SupplierDefine2");
			info.F_SupplierDefine3 = reader.GetString("F_SupplierDefine3");
			info.F_SupplierDefine4 = reader.GetString("F_SupplierDefine4");
			info.F_SupplierDefine5 = reader.GetString("F_SupplierDefine5");
			info.F_SupplierDefine6 = reader.GetString("F_SupplierDefine6");
			info.F_SupplierDefine7 = reader.GetString("F_SupplierDefine7");
			info.F_SupplierDefine8 = reader.GetString("F_SupplierDefine8");
			info.F_SupplierDefine9 = reader.GetString("F_SupplierDefine9");
			info.F_SupplierDefine10 = reader.GetString("F_SupplierDefine10");
			info.F_SupplierDescription = reader.GetString("F_SupplierDescription");
			info.F_SrTypeCode = reader.GetString("F_SrTypeCode");
			info.F_SrTypeName = reader.GetString("F_SrTypeName");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(V_InStockNoticeHeadInfo obj)
		{
		    V_InStockNoticeHeadInfo info = obj as V_InStockNoticeHeadInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_OrganizationId", info.F_OrganizationId);
 			hash.Add("F_SupplierId", info.F_SupplierId);
 			hash.Add("F_SrTypeId", info.F_SrTypeId);
 			hash.Add("F_OwnershipId", info.F_OwnershipId);
 			hash.Add("F_Maker", info.F_Maker);
 			hash.Add("F_Date", info.F_Date);
 			hash.Add("F_Verifier", info.F_Verifier);
 			hash.Add("F_Veridate", info.F_Veridate);
 			hash.Add("F_Status", info.F_Status);
 			hash.Add("F_SourceId", info.F_SourceId);
 			hash.Add("F_SourceType", info.F_SourceType);
 			hash.Add("F_SourceNo", info.F_SourceNo);
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
 			hash.Add("F_SupplierCode", info.F_SupplierCode);
 			hash.Add("F_SupplierName", info.F_SupplierName);
 			hash.Add("F_SupplierClassId", info.F_SupplierClassId);
 			hash.Add("F_SupplierContacts", info.F_SupplierContacts);
 			hash.Add("F_SupplierTelePhone", info.F_SupplierTelePhone);
 			hash.Add("F_SupplierMobilePhone", info.F_SupplierMobilePhone);
 			hash.Add("F_SupplierEmail", info.F_SupplierEmail);
 			hash.Add("F_SupplierWeChat", info.F_SupplierWeChat);
 			hash.Add("F_SupplierFax", info.F_SupplierFax);
 			hash.Add("F_SupplierAddress", info.F_SupplierAddress);
 			hash.Add("F_SupplierDefine1", info.F_SupplierDefine1);
 			hash.Add("F_SupplierDefine2", info.F_SupplierDefine2);
 			hash.Add("F_SupplierDefine3", info.F_SupplierDefine3);
 			hash.Add("F_SupplierDefine4", info.F_SupplierDefine4);
 			hash.Add("F_SupplierDefine5", info.F_SupplierDefine5);
 			hash.Add("F_SupplierDefine6", info.F_SupplierDefine6);
 			hash.Add("F_SupplierDefine7", info.F_SupplierDefine7);
 			hash.Add("F_SupplierDefine8", info.F_SupplierDefine8);
 			hash.Add("F_SupplierDefine9", info.F_SupplierDefine9);
 			hash.Add("F_SupplierDefine10", info.F_SupplierDefine10);
 			hash.Add("F_SupplierDescription", info.F_SupplierDescription);
 			hash.Add("F_SrTypeCode", info.F_SrTypeCode);
 			hash.Add("F_SrTypeName", info.F_SrTypeName);
 				
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
            dict.Add("F_Id", "");
             dict.Add("F_EnCode", "");
             dict.Add("F_OrganizationId", "");
             dict.Add("F_SupplierId", "");
             dict.Add("F_SrTypeId", "");
             dict.Add("F_OwnershipId", "");
             dict.Add("F_Maker", "");
             dict.Add("F_Date", "");
             dict.Add("F_Verifier", "");
             dict.Add("F_Veridate", "");
             dict.Add("F_Status", "");
             dict.Add("F_SourceId", "");
             dict.Add("F_SourceType", "");
             dict.Add("F_SourceNo", "");
             dict.Add("F_Define1", "");
             dict.Add("F_Define2", "");
             dict.Add("F_Define3", "");
             dict.Add("F_Define4", "");
             dict.Add("F_Define5", "");
             dict.Add("F_Define6", "");
             dict.Add("F_Define7", "");
             dict.Add("F_Define8", "");
             dict.Add("F_Define9", "");
             dict.Add("F_Define10", "");
             dict.Add("F_Description", "");
             dict.Add("F_SortCode", "");
             dict.Add("F_DeleteMark", "");
             dict.Add("F_EnabledMark", "");
             dict.Add("F_CreatorTime", "");
             dict.Add("F_CreatorUserId", "");
             dict.Add("F_LastModifyTime", "");
             dict.Add("F_LastModifyUserId", "");
             dict.Add("F_DeleteTime", "");
             dict.Add("F_DeleteUserId", "");
             dict.Add("F_SupplierCode", "");
             dict.Add("F_SupplierName", "");
             dict.Add("F_SupplierClassId", "");
             dict.Add("F_SupplierContacts", "");
             dict.Add("F_SupplierTelePhone", "");
             dict.Add("F_SupplierMobilePhone", "");
             dict.Add("F_SupplierEmail", "");
             dict.Add("F_SupplierWeChat", "");
             dict.Add("F_SupplierFax", "");
             dict.Add("F_SupplierAddress", "");
             dict.Add("F_SupplierDefine1", "");
             dict.Add("F_SupplierDefine2", "");
             dict.Add("F_SupplierDefine3", "");
             dict.Add("F_SupplierDefine4", "");
             dict.Add("F_SupplierDefine5", "");
             dict.Add("F_SupplierDefine6", "");
             dict.Add("F_SupplierDefine7", "");
             dict.Add("F_SupplierDefine8", "");
             dict.Add("F_SupplierDefine9", "");
             dict.Add("F_SupplierDefine10", "");
             dict.Add("F_SupplierDescription", "");
             dict.Add("F_SrTypeCode", "");
             dict.Add("F_SrTypeName", "");
             #endregion

            return dict;
        }
		
     
    }
}
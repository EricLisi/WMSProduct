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
    /// V_OutStockNoticeHead
    /// </summary>
	public class V_OutStockNoticeHead : BaseDALSQL<V_OutStockNoticeHeadInfo>, IV_OutStockNoticeHead
	{
		#region 对象实例及构造函数

		public static V_OutStockNoticeHead Instance
		{
			get
			{
				return new V_OutStockNoticeHead();
			}
		}
		public V_OutStockNoticeHead() : base("V_OutStockNoticeHead","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override V_OutStockNoticeHeadInfo DataReaderToEntity(IDataReader dataReader)
		{
			V_OutStockNoticeHeadInfo info = new V_OutStockNoticeHeadInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_OrganizationId = reader.GetString("F_OrganizationId");
			info.F_CustomerId = reader.GetString("F_CustomerId");
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
			info.F_CustomerCode = reader.GetString("F_CustomerCode");
			info.F_CustomerName = reader.GetString("F_CustomerName");
			info.F_CustomerClassId = reader.GetString("F_CustomerClassId");
			info.F_CustomerContacts = reader.GetString("F_CustomerContacts");
			info.F_CustomerTelePhone = reader.GetString("F_CustomerTelePhone");
			info.F_CustomerMobilePhone = reader.GetString("F_CustomerMobilePhone");
			info.F_CustomerEmail = reader.GetString("F_CustomerEmail");
			info.F_CustomerWeChat = reader.GetString("F_CustomerWeChat");
			info.F_CustomerFax = reader.GetString("F_CustomerFax");
			info.F_CustomerAddress = reader.GetString("F_CustomerAddress");
			info.F_CustomerDefine1 = reader.GetString("F_CustomerDefine1");
			info.F_CustomerDefine2 = reader.GetString("F_CustomerDefine2");
			info.F_CustomerDefine3 = reader.GetString("F_CustomerDefine3");
			info.F_CustomerDefine4 = reader.GetString("F_CustomerDefine4");
			info.F_CustomerDefine5 = reader.GetString("F_CustomerDefine5");
			info.F_CustomerDefine6 = reader.GetString("F_CustomerDefine6");
			info.F_CustomerDefine7 = reader.GetString("F_CustomerDefine7");
			info.F_CustomerDefine8 = reader.GetString("F_CustomerDefine8");
			info.F_CustomerDefine9 = reader.GetString("F_CustomerDefine9");
			info.F_CustomerDefine10 = reader.GetString("F_CustomerDefine10");
			info.F_CustomerDescription = reader.GetString("F_CustomerDescription");
			info.F_SrTypeCode = reader.GetString("F_SrTypeCode");
			info.F_SrTypeName = reader.GetString("F_SrTypeName");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(V_OutStockNoticeHeadInfo obj)
		{
		    V_OutStockNoticeHeadInfo info = obj as V_OutStockNoticeHeadInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_OrganizationId", info.F_OrganizationId);
 			hash.Add("F_CustomerId", info.F_CustomerId);
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
 			hash.Add("F_CustomerCode", info.F_CustomerCode);
 			hash.Add("F_CustomerName", info.F_CustomerName);
 			hash.Add("F_CustomerClassId", info.F_CustomerClassId);
 			hash.Add("F_CustomerContacts", info.F_CustomerContacts);
 			hash.Add("F_CustomerTelePhone", info.F_CustomerTelePhone);
 			hash.Add("F_CustomerMobilePhone", info.F_CustomerMobilePhone);
 			hash.Add("F_CustomerEmail", info.F_CustomerEmail);
 			hash.Add("F_CustomerWeChat", info.F_CustomerWeChat);
 			hash.Add("F_CustomerFax", info.F_CustomerFax);
 			hash.Add("F_CustomerAddress", info.F_CustomerAddress);
 			hash.Add("F_CustomerDefine1", info.F_CustomerDefine1);
 			hash.Add("F_CustomerDefine2", info.F_CustomerDefine2);
 			hash.Add("F_CustomerDefine3", info.F_CustomerDefine3);
 			hash.Add("F_CustomerDefine4", info.F_CustomerDefine4);
 			hash.Add("F_CustomerDefine5", info.F_CustomerDefine5);
 			hash.Add("F_CustomerDefine6", info.F_CustomerDefine6);
 			hash.Add("F_CustomerDefine7", info.F_CustomerDefine7);
 			hash.Add("F_CustomerDefine8", info.F_CustomerDefine8);
 			hash.Add("F_CustomerDefine9", info.F_CustomerDefine9);
 			hash.Add("F_CustomerDefine10", info.F_CustomerDefine10);
 			hash.Add("F_CustomerDescription", info.F_CustomerDescription);
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
             dict.Add("F_CustomerId", "");
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
             dict.Add("F_CustomerCode", "");
             dict.Add("F_CustomerName", "");
             dict.Add("F_CustomerClassId", "");
             dict.Add("F_CustomerContacts", "");
             dict.Add("F_CustomerTelePhone", "");
             dict.Add("F_CustomerMobilePhone", "");
             dict.Add("F_CustomerEmail", "");
             dict.Add("F_CustomerWeChat", "");
             dict.Add("F_CustomerFax", "");
             dict.Add("F_CustomerAddress", "");
             dict.Add("F_CustomerDefine1", "");
             dict.Add("F_CustomerDefine2", "");
             dict.Add("F_CustomerDefine3", "");
             dict.Add("F_CustomerDefine4", "");
             dict.Add("F_CustomerDefine5", "");
             dict.Add("F_CustomerDefine6", "");
             dict.Add("F_CustomerDefine7", "");
             dict.Add("F_CustomerDefine8", "");
             dict.Add("F_CustomerDefine9", "");
             dict.Add("F_CustomerDefine10", "");
             dict.Add("F_CustomerDescription", "");
             dict.Add("F_SrTypeCode", "");
             dict.Add("F_SrTypeName", "");
             #endregion

            return dict;
        }
		
     
    }
}
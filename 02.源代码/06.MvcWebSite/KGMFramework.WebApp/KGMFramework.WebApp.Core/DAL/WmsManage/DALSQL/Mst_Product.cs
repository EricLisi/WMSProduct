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
    /// 商品信息表
    /// </summary>
	public class Mst_Product : BaseDALSQL<Mst_ProductInfo>, IMst_Product
	{
		#region 对象实例及构造函数

		public static Mst_Product Instance
		{
			get
			{
				return new Mst_Product();
			}
		}
		public Mst_Product() : base("Mst_Product","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Mst_ProductInfo DataReaderToEntity(IDataReader dataReader)
		{
			Mst_ProductInfo info = new Mst_ProductInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_FullName = reader.GetString("F_FullName");
			info.F_ShortCode = reader.GetString("F_ShortCode");
			info.F_ShortName = reader.GetString("F_ShortName");
			info.F_ProductClassId = reader.GetString("F_ProductClassId");
			info.F_OwnershipId = reader.GetString("F_OwnershipId");
			info.F_Standard = reader.GetString("F_Standard");
			info.F_Brand = reader.GetString("F_Brand");
			info.F_Color = reader.GetString("F_Color");
			info.F_Length = reader.GetDecimal("F_Length");
			info.F_Height = reader.GetDecimal("F_Height");
			info.F_Width = reader.GetDecimal("F_Width");
			info.F_NetWeight = reader.GetDecimal("F_NetWeight");
			info.F_Weight = reader.GetDecimal("F_Weight");
			info.F_PurchasePrice = reader.GetDecimal("F_PurchasePrice");
			info.F_SalesPrice = reader.GetDecimal("F_SalesPrice");
			info.F_Unit = reader.GetString("F_Unit");
			info.F_BatchManagement = reader.GetBoolean("F_BatchManagement");
			info.F_SnManagement = reader.GetBoolean("F_SnManagement");
			info.F_EffectiveManagement = reader.GetBoolean("F_EffectiveManagement");
			info.F_EffectiveDays = reader.GetInt32("F_EffectiveDays");
			info.F_EffectiveUnit = reader.GetInt32("F_EffectiveUnit");
			info.F_Package = reader.GetInt32("F_Package");
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
        protected override Hashtable GetHashByEntity(Mst_ProductInfo obj)
		{
		    Mst_ProductInfo info = obj as Mst_ProductInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_FullName", info.F_FullName);
 			hash.Add("F_ShortCode", info.F_ShortCode);
 			hash.Add("F_ShortName", info.F_ShortName);
 			hash.Add("F_ProductClassId", info.F_ProductClassId);
 			hash.Add("F_OwnershipId", info.F_OwnershipId);
 			hash.Add("F_Standard", info.F_Standard);
 			hash.Add("F_Brand", info.F_Brand);
 			hash.Add("F_Color", info.F_Color);
 			hash.Add("F_Length", info.F_Length);
 			hash.Add("F_Height", info.F_Height);
 			hash.Add("F_Width", info.F_Width);
 			hash.Add("F_NetWeight", info.F_NetWeight);
 			hash.Add("F_Weight", info.F_Weight);
 			hash.Add("F_PurchasePrice", info.F_PurchasePrice);
 			hash.Add("F_SalesPrice", info.F_SalesPrice);
 			hash.Add("F_Unit", info.F_Unit);
 			hash.Add("F_BatchManagement", info.F_BatchManagement);
 			hash.Add("F_SnManagement", info.F_SnManagement);
 			hash.Add("F_EffectiveManagement", info.F_EffectiveManagement);
 			hash.Add("F_EffectiveDays", info.F_EffectiveDays);
 			hash.Add("F_EffectiveUnit", info.F_EffectiveUnit);
 			hash.Add("F_Package", info.F_Package);
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
             dict.Add("F_EnCode", "商品编号");
             dict.Add("F_FullName", "商品名称");
             dict.Add("F_ShortCode", "商品简码");
             dict.Add("F_ShortName", "商品简称");
             dict.Add("F_ProductClassId", "商品分类Id");
             dict.Add("F_OwnershipId", "商品权属Id");
             dict.Add("F_Standard", "规格");
             dict.Add("F_Brand", "品牌");
             dict.Add("F_Color", "颜色");
             dict.Add("F_Length", "长");
             dict.Add("F_Height", "高");
             dict.Add("F_Width", "宽");
             dict.Add("F_NetWeight", "净重");
             dict.Add("F_Weight", "毛重");
             dict.Add("F_PurchasePrice", "采购单价");
             dict.Add("F_SalesPrice", "销售单价");
             dict.Add("F_Unit", "单位");
             dict.Add("F_BatchManagement", "批次管理");
             dict.Add("F_SnManagement", "序列号管理");
             dict.Add("F_EffectiveManagement", "效期管理");
             dict.Add("F_EffectiveDays", "保质期");
             dict.Add("F_EffectiveUnit", "保质期单位(0 日 1 月 2 年)");
             dict.Add("F_Package", "包装规格");
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
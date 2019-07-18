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
    /// 商品视图信息表
    /// </summary>
	public class V_PACKLISTSEL : BaseDALSQL<V_PACKLISTSELInfo>, IV_PACKLISTSEL	{
		#region 对象实例及构造函数

		public static V_PACKLISTSEL Instance
		{
			get
			{
                return new V_PACKLISTSEL();
			}
		}
        public V_PACKLISTSEL()
            : base("V_PACKLISTSEL", "F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
        protected override V_PACKLISTSELInfo DataReaderToEntity(IDataReader dataReader)
		{
            V_PACKLISTSELInfo info = new V_PACKLISTSELInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			//info.F_Id = reader.GetString("F_Id");
			//info.F_EnCode = reader.GetString("F_EnCode");
			//info.F_FullName = reader.GetString("F_FullName");


            info.F_ProductCode = reader.GetString("F_ProductCode");
            info.F_ProductName = reader.GetString("F_ProductName");
            info.F_ProductStandard = reader.GetString("F_ProductStandard");
            info.F_ProdcuntBatchManagement = reader.GetString("F_ProdcuntBatchManagement");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_Batch = reader.GetString("F_Batch");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_WarehouseCode = reader.GetString("F_WarehouseCode");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_PositionId = reader.GetString("F_PositionId");
            info.F_PositionCode = reader.GetString("F_PositionCode");
            info.F_PositionName = reader.GetString("F_PositionName");
            info.F_ExpiryDate = reader.GetDateTime("F_ExpiryDate");
            info.F_MadeDate = reader.GetDateTime("F_MadeDate");
            info.F_HeadId = reader.GetString("F_HeadId");
            info.F_Quantity = reader.GetDecimal("F_Quantity");
            info.F_ProductId = reader.GetString("F_ProductId");
            


            //info.F_Description = reader.GetString("F_Description");
			//info.F_SortCode = reader.GetInt32("F_SortCode");
			//info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
			//info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
			//info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
			//info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
			//info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
			//info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
			//info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
			//info.F_DeleteUserId = reader.GetString("F_DeleteUserId");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(V_PACKLISTSELInfo obj)
		{
            V_PACKLISTSELInfo info = obj as V_PACKLISTSELInfo;
			Hashtable hash = new Hashtable();
            hash.Add("F_ProductId", info.F_ProductId);
            hash.Add("F_ProductCode", info.F_ProductCode);
            hash.Add("F_ProductName", info.F_ProductName);
            hash.Add("F_ProductStandard", info.F_ProductStandard);
            hash.Add("F_ProdcuntBatchManagement", info.F_ProdcuntBatchManagement);
            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_Batch", info.F_Batch);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_PositionId", info.F_PositionId);
            hash.Add("F_ExpiryDate", info.F_ExpiryDate);
            hash.Add("F_MadeDate", info.F_MadeDate);
            hash.Add("F_HeadId", info.F_HeadId);
            hash.Add("F_Quantity", info.F_Quantity);

 			
 				
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
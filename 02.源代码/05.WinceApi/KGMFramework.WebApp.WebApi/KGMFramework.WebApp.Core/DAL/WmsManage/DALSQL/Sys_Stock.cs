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
    public class Sys_Stock : BaseDALSQL<Sys_StockInfo>,ISys_Stock
	{
		#region 对象实例及构造函数

		public static Sys_Stock Instance
		{
			get
			{
				return new Sys_Stock();
			}
		}
        public Sys_Stock()
            : base("Sys_Stock", "F_Id")
		{
		}

		#endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_StockInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_StockInfo info = new Sys_StockInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_Batch = reader.GetString("F_Batch");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_Number = reader.GetInt32("F_Number");
            info.F_CargoPositionId = reader.GetString("F_CargoPositionId");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_ProDate = reader.GetString("F_ProDate");
            info.F_ExpiratDate = reader.GetString("F_ExpiratDate");
            info.F_CategoryID = reader.GetString("F_CategoryID");
            info.F_SpecifModel = reader.GetString("F_SpecifModel");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_Pic = reader.GetString("F_Pic");
            info.F_TradePrice = reader.GetString("F_TradePrice");
            info.F_RetailPrice = reader.GetString("F_RetailPrice");
            info.F_ShelfLife = reader.GetString("F_ShelfLife");
            info.F_SellingPrice = reader.GetString("F_SellingPrice");
            info.F_SerialNum = reader.GetString("F_SerialNum");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_Description = reader.GetString("F_Description");
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
        protected override Hashtable GetHashByEntity(Sys_StockInfo obj)
        {
            Sys_StockInfo info = obj as Sys_StockInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_Batch", info.F_Batch);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_GoodsId", info.F_GoodsId);
            hash.Add("F_GoodsName", info.F_GoodsName);
            hash.Add("F_Number", info.F_Number);
            hash.Add("F_CargoPositionId", info.F_CargoPositionId);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
            hash.Add("F_ProDate", info.F_ProDate);
            hash.Add("F_ExpiratDate", info.F_ExpiratDate);
            hash.Add("F_CategoryID", info.F_CategoryID);
            hash.Add("F_SpecifModel", info.F_SpecifModel);
            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_Pic", info.F_Pic);
            hash.Add("F_TradePrice", info.F_TradePrice);
            hash.Add("F_RetailPrice", info.F_RetailPrice);
            hash.Add("F_ShelfLife", info.F_ShelfLife);
            hash.Add("F_SellingPrice", info.F_SellingPrice);
            hash.Add("F_SerialNum", info.F_SerialNum);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_Description", info.F_Description);
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
            dict.Add("F_EnCode", "库存编码");
            dict.Add("F_Batch", "批次");
            dict.Add("F_WarehouseId", "仓库ID");
            dict.Add("F_WarehouseName", "仓库名称");
            dict.Add("F_GoodsId", "产品ID");
            dict.Add("F_GoodsName", "产品名称");
            dict.Add("F_Number", "库存数");
            dict.Add("F_CargoPositionId", "货位ID");
            dict.Add("F_CargoPositionName", "货物名称");
            dict.Add("F_ProDate", "生产日期");
            dict.Add("F_ExpiratDate", "失效日期");
            dict.Add("F_CategoryID", "产品类别");
            dict.Add("F_SpecifModel", "规格型号");
            dict.Add("F_Unit", "单位");
            dict.Add("F_TradePrice", "批发价");
            dict.Add("F_RetailPrice", "零售价");
            dict.Add("F_ShelfLife", "保质期");
            dict.Add("F_SellingPrice", "销售价格");
            dict.Add("F_SerialNum", "序列号");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_Description", "备注");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_CreatorTime", "创建日期");
            dict.Add("F_CreatorUserId", "创建用户主键");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            #endregion

            return dict;
        }
    }
}
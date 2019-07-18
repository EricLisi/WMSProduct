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
    /// 货位表
    /// </summary>
    public class Sys_InReturnHistory : BaseDALSQL<Sys_InReturnHistoryInfo>, ISys_InReturnHistory
	{
		#region 对象实例及构造函数

        public static Sys_InReturnHistory Instance
		{
			get
			{
                return new Sys_InReturnHistory();
			}
		}
        public Sys_InReturnHistory()
            : base("Sys_InReturnHistory", "F_Id")
		{
		}

		#endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_InReturnHistoryInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_InReturnHistoryInfo info = new Sys_InReturnHistoryInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.F_BllCategory = reader.GetString("F_BllCategory");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_SellingPrice = reader.GetString("F_SellingPrice");
            info.F_PurchasePrice = reader.GetString("F_PurchasePrice");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_SpecifModel = reader.GetString("F_SpecifModel");
            info.F_TradePrice = reader.GetString("F_TradePrice");
            info.F_Batch = reader.GetString("F_Batch");
            info.F_Vendor = reader.GetString("F_Vendor");
            info.F_VendorName = reader.GetString("F_VendorName");
            info.F_Date = reader.GetString("F_Date");
            info.F_Contacts = reader.GetString("F_Contacts");
            info.F_TelePhone = reader.GetString("F_TelePhone");
            info.F_Verify = reader.GetString("F_Verify");
            info.F_Maker = reader.GetString("F_Maker");
            info.F_Address = reader.GetString("F_Address");
            info.F_VeriDate = reader.GetDateTime("F_VeriDate");
            info.F_ProDate = reader.GetString("F_ProDate");
            info.F_InStockNum = reader.GetInt32("F_InStockNum");
            info.F_ReturnNum = reader.GetInt32("F_ReturnNum");
            info.F_ExpiratDate = reader.GetString("F_ExpiratDate");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_CargoPositionId = reader.GetString("F_CargoPositionId");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");
            info.F_FreeTerm1 = reader.GetString("F_FreeTerm1");
            info.F_FreeTerm2 = reader.GetString("F_FreeTerm2");
            info.F_FreeTerm3 = reader.GetString("F_FreeTerm3");
            info.F_FreeTerm4 = reader.GetString("F_FreeTerm4");
            info.F_FreeTerm5 = reader.GetString("F_FreeTerm5");
            info.F_FreeTerm6 = reader.GetString("F_FreeTerm6");
            info.F_FreeTerm7 = reader.GetString("F_FreeTerm7");
            info.F_FreeTerm8 = reader.GetString("F_FreeTerm8");
            info.F_FreeTerm9 = reader.GetString("F_FreeTerm9");
            info.F_FreeTerm10 = reader.GetString("F_FreeTerm10");
            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_InReturnHistoryInfo obj)
        {
            Sys_InReturnHistoryInfo info = obj as Sys_InReturnHistoryInfo;
            Hashtable hash = new Hashtable();
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_BllCategory", info.F_BllCategory);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_GoodsId", info.F_GoodsId);
            hash.Add("F_PurchasePrice", info.F_PurchasePrice);
            hash.Add("F_SellingPrice", info.F_SellingPrice);
            hash.Add("F_GoodsName", info.F_GoodsName);
            hash.Add("F_SpecifModel", info.F_SpecifModel);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_TradePrice", info.F_TradePrice);
            hash.Add("F_InStockNum", info.F_InStockNum);
            hash.Add("F_ReturnNum", info.F_ReturnNum);
            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_Batch", info.F_Batch);
            hash.Add("F_Vendor", info.F_Vendor);
            hash.Add("F_VendorName", info.F_VendorName);
            hash.Add("F_Date", info.F_Date);
            hash.Add("F_Contacts", info.F_Contacts);
            hash.Add("F_TelePhone", info.F_TelePhone);
            hash.Add("F_Verify", info.F_Verify);
            hash.Add("F_Maker", info.F_Maker);
            hash.Add("F_Address", info.F_Address);
            hash.Add("F_VeriDate", info.F_VeriDate);
            hash.Add("F_ExpiratDate", info.F_ExpiratDate);
            hash.Add("F_CargoPositionId", info.F_CargoPositionId);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
            hash.Add("F_FreeTerm1", info.F_FreeTerm1);
            hash.Add("F_FreeTerm2", info.F_FreeTerm2);
            hash.Add("F_FreeTerm3", info.F_FreeTerm3);
            hash.Add("F_FreeTerm4", info.F_FreeTerm4);
            hash.Add("F_FreeTerm5", info.F_FreeTerm5);
            hash.Add("F_FreeTerm6", info.F_FreeTerm6);
            hash.Add("F_FreeTerm7", info.F_FreeTerm7);
            hash.Add("F_FreeTerm8", info.F_FreeTerm8);
            hash.Add("F_FreeTerm9", info.F_FreeTerm9);
            hash.Add("F_FreeTerm10", info.F_FreeTerm10);
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
            dict.Add("F_EnCode", "入库编号");
            dict.Add("F_GoodsId", "产品Id");
            dict.Add("F_GoodsName", "产品名称");
            dict.Add("F_FullName", "产品名称");
            dict.Add("F_CategoryID", "产品类型");
            dict.Add("F_SpecifModel", "规格型号");
            dict.Add("F_WarehouseId", "仓库Id");
            dict.Add("F_WarehouseName", "仓库名称");
            dict.Add("F_Unit", "单位");
            dict.Add("F_InStockNum", "入库数量");
            dict.Add("F_Pic", "图片");
            dict.Add("F_ShelfLife", "保质期");
            dict.Add("F_PurchasePrice", "采购价格");
            dict.Add("F_SellingPrice", "销售价格");
            dict.Add("F_BasicRate", "基本税率");
            dict.Add("F_CargoPositionId", "货位号");
            dict.Add("F_CargoPositionName", "货位名称");
            dict.Add("F_FreeTerm1", "自定义项1");
            dict.Add("F_FreeTerm2", "自定义项1");
            dict.Add("F_FreeTerm3", "自定义项1");
            dict.Add("F_FreeTerm4", "自定义项1");
            dict.Add("F_FreeTerm5", "自定义项1");
            dict.Add("F_FreeTerm6", "自定义项1");
            dict.Add("F_FreeTerm7", "自定义项1");
            dict.Add("F_FreeTerm8", "自定义项1");
            dict.Add("F_FreeTerm9", "自定义项1");
            dict.Add("F_FreeTerm10", "自定义项1");
            dict.Add("F_SortCode", "排序码");
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
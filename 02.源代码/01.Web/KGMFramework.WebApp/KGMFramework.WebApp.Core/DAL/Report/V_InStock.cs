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
    /// 产品信息表
    /// </summary>
    public class V_InStock : BaseDALSQL<V_InStockInfo>, IV_InStock
    {
        #region 对象实例及构造函数

        public static V_InStock Instance
        {
            get
            {
                return new V_InStock();
            }
        }
        public V_InStock()
            : base("V_InStock", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override V_InStockInfo DataReaderToEntity(IDataReader dataReader)
        {
            V_InStockInfo info = new V_InStockInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_HId = reader.GetString("F_HId");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_SpecifModel = reader.GetString("F_SpecifModel");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_Pic = reader.GetString("F_Pic");
            info.F_ShelfLife = reader.GetString("F_ShelfLife");
            info.F_Supplier = reader.GetString("F_Supplier");
            info.F_SellingPrice = reader.GetString("F_SellingPrice");
            info.F_PurchasePrice = reader.GetString("F_PurchasePrice");
            info.F_BasicRate = reader.GetString("F_BasicRate");
            info.F_InStockNum = reader.GetInt32("F_InStockNum");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_AlreadyOperatedNum = reader.GetString("F_AlreadyOperatedNum");
            info.F_CargoPositionId = reader.GetString("F_CargoPositionId");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_SpecifiedDate = reader.GetDateTime("F_SpecifiedDate");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_OrderNo = reader.GetString("F_OrderNo");
            info.F_TradePrice = reader.GetDecimal("F_TradePrice");
            info.F_AllAmount = reader.GetDecimal("F_AllAmount");
            info.F_SerialNum = reader.GetString("F_SerialNum");
            info.F_InCode = reader.GetString("F_InCode");
            info.F_VendorName = reader.GetString("F_VendorName");
            info.F_Vendor = reader.GetString("F_Vendor");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(V_InStockInfo obj)
        {
            V_InStockInfo info = obj as V_InStockInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_HId", info.F_HId);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_CategoryID", info.F_CategoryID);
            hash.Add("F_GoodsId", info.F_GoodsId);
            hash.Add("F_GoodsName", info.F_GoodsName);
            hash.Add("F_SpecifModel", info.F_SpecifModel);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_Supplier", info.F_Supplier);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_Pic", info.F_Pic);
            hash.Add("F_ShelfLife", info.F_ShelfLife);
            hash.Add("F_PurchasePrice", info.F_PurchasePrice);
            hash.Add("F_SellingPrice", info.F_SellingPrice);
            hash.Add("F_BasicRate", info.F_BasicRate);
            hash.Add("F_InStockNum", info.F_InStockNum);
            hash.Add("F_AlreadyOperatedNum", info.F_AlreadyOperatedNum);
            hash.Add("F_CargoPositionId", info.F_CargoPositionId);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
            hash.Add("F_SpecifiedDate", info.F_SpecifiedDate);
            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_OrderNo", info.F_OrderNo);
            hash.Add("F_TradePrice", info.F_TradePrice);
            hash.Add("F_AllAmount", info.F_AllAmount);
            hash.Add("F_SerialNum", info.F_SerialNum);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_VendorName", info.F_VendorName);
            hash.Add("F_Vendor", info.F_Vendor);
            hash.Add("F_InCode", info.F_InCode);

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
            dict.Add("F_EnCode", "编码");
            dict.Add("F_FullName", "名称");
            dict.Add("FProtocolId", "项目号");
            dict.Add("FLabelId", "标签号");
            dict.Add("FVersion", "版本号");
            dict.Add("FCountry", "语言版本");
            dict.Add("FContent1", "");
            dict.Add("FContent2", "");
            dict.Add("FContent3", "");
            dict.Add("FContent4", "");
            dict.Add("FContent5", "");
            dict.Add("FContent6", "");
            dict.Add("FContent7", "");
            dict.Add("FContent8", "");
            dict.Add("FContent9", "");
            dict.Add("FContent10", "");
            dict.Add("FContent11", "");
            dict.Add("FContent12", "");
            dict.Add("FContent13", "");
            dict.Add("FContent14", "");
            dict.Add("FContent15", "");
            dict.Add("FContent16", "");
            dict.Add("FContent17", "");
            dict.Add("FContent18", "");
            dict.Add("FContent19", "");
            dict.Add("FContent20", "");
            dict.Add("FContent21", "");
            dict.Add("FContent22", "");
            dict.Add("FContent23", "");
            dict.Add("FContent24", "");
            dict.Add("FContent25", "");
            #endregion

            return dict;
        }

    }
}
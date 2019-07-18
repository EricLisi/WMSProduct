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
    public class V_OutStock : BaseDALSQL<V_OutStockInfo>, IV_OutStock
    {
        #region 对象实例及构造函数

        public static V_OutStock Instance
        {
            get
            {
                return new V_OutStock();
            }
        }
        public V_OutStock()
            : base("V_OutStock", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override V_OutStockInfo DataReaderToEntity(IDataReader dataReader)
        {
            V_OutStockInfo info = new V_OutStockInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.F_HeadBatch = reader.GetString("F_HeadBatch");
            info.F_CustomerId = reader.GetString("F_CustomerId");
              info.F_CustomerName = reader.GetString("F_CustomerName");
            info.F_Batch = reader.GetString("F_Batch");
            info.F_Id = reader.GetString("F_Id");
            info.F_SellingPrice = reader.GetDecimal("F_SellingPrice");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_HId = reader.GetString("F_HId");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_Description = reader.GetString("F_Description");
            info.F_ShelfLife = reader.GetString("F_ShelfLife");
            info.F_OutStockNum = reader.GetInt32("F_OutStockNum");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_CargoPositionId = reader.GetString("F_CargoPositionId");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_Num = reader.GetString("F_Num");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_SpecifModel = reader.GetString("F_SpecifModel");
            info.F_SortCode = reader.GetInt32("F_SortCode");

            info.F_Contacts = reader.GetString("F_Contacts");
            info.F_TelePhone = reader.GetString("F_TelePhone");
            info.F_Address = reader.GetString("F_Address");
  
     

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(V_OutStockInfo obj)
        {
            V_OutStockInfo info = obj as V_OutStockInfo;
            Hashtable hash = new Hashtable();
            hash.Add("F_Contacts", info.F_Contacts);
            hash.Add("F_TelePhone", info.F_TelePhone);
            hash.Add("F_Address", info.F_Address);
            hash.Add("F_Batch", info.F_Batch);
            hash.Add("F_HeadBatch", info.F_HeadBatch);
            hash.Add("F_CustomerId", info.F_CustomerId);
            hash.Add("F_CustomerName", info.F_CustomerName);
            hash.Add("F_SellingPrice", info.F_SellingPrice);
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_HId", info.F_HId);
            hash.Add("F_GoodsId", info.F_GoodsId);
            hash.Add("F_GoodsName", info.F_GoodsName);
            hash.Add("F_OutStockNum", info.F_OutStockNum);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_Num", info.F_Num);
            hash.Add("F_ShelfLife", info.F_ShelfLife);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_CargoPositionId", info.F_CargoPositionId);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
            hash.Add("F_SortCode", info.F_SortCode);
            //hash.Add("F_DeleteMark", info.F_DeleteMark);
            //hash.Add("F_EnabledMark", info.F_EnabledMark);
            //hash.Add("F_CreatorTime", info.F_CreatorTime);
            //hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            //hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            //hash.Add("F_LastModifyTime", info.F_LastModifyTime);
            //hash.Add("F_DeleteTime", info.F_DeleteTime);
            //hash.Add("F_DeleteUserId", info.F_DeleteUserId);

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
            dict.Add("F_WarehouseName", "仓库名称");
            dict.Add("F_Acreage", "面积");
            dict.Add("F_Unit", "计量单位");
            dict.Add("F_Regionally", "区域性");
            dict.Add("F_Capacity", "容量");
            dict.Add("F_Layers", "层");
            dict.Add("F_WhatIs", "存放物料描述");
            dict.Add("F_SpecificatModel", "规格型号");
            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "货位编码");
            dict.Add("F_FullName", "货位名称");
            dict.Add("F_ParentId", "父节点");
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
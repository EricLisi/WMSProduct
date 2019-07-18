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
    public class SO_StockMakeBody : BaseDALSQL<SO_StockMakeBodyInfo>, ISO_StockMakeBody
    {
        #region 对象实例及构造函数

        public static SO_StockMakeBody Instance
        {
            get
            {
                return new SO_StockMakeBody();
            }
        }
        public SO_StockMakeBody()
            : base("SO_StockMakeBody", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override SO_StockMakeBodyInfo DataReaderToEntity(IDataReader dataReader)
        {
            SO_StockMakeBodyInfo info = new SO_StockMakeBodyInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
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
            info.F_HId = reader.GetString("F_HId");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_CargoPositionId = reader.GetString("F_CargoPositionId");
            info.F_Batch = reader.GetString("F_Batch");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_Description = reader.GetString("F_Description");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_ProDate = reader.GetString("F_ProDate");
            info.F_ExpiratDate = reader.GetString("F_ExpiratDate");
            info.F_SpecifModel = reader.GetString("F_SpecifModel");
            info.F_RealNumber = reader.GetString("F_RealNumber");
            info.F_SpecifiedDate = reader.GetString("F_SpecifiedDate");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_ExpiratDate = reader.GetString("F_ExpiratDate");
            info.F_Number = reader.GetInt32("F_Number");
            info.F_PurchasePrice = reader.GetDecimal("F_PurchasePrice");
            info.F_SellingPrice = reader.GetDecimal("F_SellingPrice");
            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(SO_StockMakeBodyInfo obj)
        {
            SO_StockMakeBodyInfo info = obj as SO_StockMakeBodyInfo;
            Hashtable hash = new Hashtable();
            hash.Add("F_PurchasePrice", info.F_PurchasePrice);
            hash.Add("F_SellingPrice", info.F_SellingPrice);
            hash.Add("F_HId", info.F_HId);
            hash.Add("F_GoodsName", info.F_GoodsName);
            hash.Add("F_SpecifiedDate", info.F_SpecifiedDate);
            hash.Add("F_Batch", info.F_Batch);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_GoodsId", info.F_GoodsId);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_CargoPositionId", info.F_CargoPositionId);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
            hash.Add("F_ProDate", info.F_ProDate);
            hash.Add("F_Number", info.F_Number);
            hash.Add("F_ExpiratDate", info.F_ExpiratDate);
            hash.Add("F_SpecifModel", info.F_SpecifModel);

            hash.Add("F_RealNumber", info.F_RealNumber);


            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);

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
        /// <summary>
        /// 更改盘点数量
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public string UpMaskNum(DataTable dt, List<SO_StockMakeBodyInfo> list)
        {
            using (DbTransactionScope<SO_StockMakeBodyInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    List<SO_StockMakeBodyInfo> bodyList = BLLFactory<SO_StockMakeBody>.Instance.GetAll();
                    //找出对应的数据，再进行更改
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                          SO_StockMakeBodyInfo bodyInfo = bodyList.Find(u =>
                           u.F_Batch == dt.Rows[i]["批次"].ToString() &&
                          u.F_GoodsName == dt.Rows[i]["产品名称"].ToString() &&
                          u.F_Number == int.Parse(dt.Rows[i]["账面数量"].ToString()) &&
                          u.F_SellingPrice == decimal.Parse(dt.Rows[i]["销售价格"].ToString()) &&
                          u.F_Unit == dt.Rows[i]["单位"].ToString() &&
                          u.F_WarehouseName == dt.Rows[i]["所属仓库"].ToString() &&
                          u.F_CargoPositionName == dt.Rows[i]["所属货位"].ToString());
                         Hashtable hash = new Hashtable();
                         hash.Add("F_RealNumber", dt.Rows[i]["实盘数量"].ToString());
                        SO_StockMakeBody.Instance.Update(bodyInfo.F_Id, hash, dbtran.Transaction);

                    }
                   
                    dbtran.Commit();
                    return "操作成功";
                }
                catch (Exception)
                {
                    dbtran.RollBack();
                    return "操作失败";
                }
            }
        }

    }
}
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
    /// 入库子表
    /// </summary>
    public class PI_ReturnBody : BaseDALSQL<PI_ReturnBodyInfo>, IPI_ReturnBody
    {
        #region 对象实例及构造函数

        public static PI_ReturnBody Instance
        {
            get
            {
                return new PI_ReturnBody();
            }
        }
        public PI_ReturnBody()
            : base("PI_ReturnBody", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override PI_ReturnBodyInfo DataReaderToEntity(IDataReader dataReader)
        {
            PI_ReturnBodyInfo info = new PI_ReturnBodyInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_HId = reader.GetString("F_HId");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_CategoryID = reader.GetString("F_CategoryID");
            info.F_SpecifModel = reader.GetString("F_SpecifModel");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_Pic = reader.GetString("F_Pic");
            info.F_ShelfLife = reader.GetString("F_ShelfLife");
            info.F_VendorName = reader.GetString("F_VendorName");
            info.F_Vendor = reader.GetString("F_Vendor");
            info.F_SellingPrice = reader.GetString("F_SellingPrice");
            info.F_PurchasePrice = reader.GetString("F_PurchasePrice");
            info.F_BasicRate = reader.GetString("F_BasicRate");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");
            info.F_InStockNum = reader.GetInt32("F_InStockNum");
            info.F_ReturnNum = reader.GetInt32("F_ReturnNum");
            info.F_Num = reader.GetInt32("F_Num");
            info.F_AlreadyOperatedNum = reader.GetString("F_AlreadyOperatedNum");
            info.F_CargoPositionId = reader.GetString("F_CargoPositionId");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_SpecifiedDate = reader.GetDateTime("F_SpecifiedDate");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_OrderNo = reader.GetString("F_OrderNo");
            info.F_TradePrice = reader.GetDecimal("F_TradePrice");
            info.F_AllAmount = reader.GetDecimal("F_AllAmount");
            info.F_SerialNum = reader.GetString("F_SerialNum");
            info.F_Description = reader.GetString("F_Description");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(PI_ReturnBodyInfo obj)
        {
            PI_ReturnBodyInfo info = obj as PI_ReturnBodyInfo;
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
            hash.Add("F_Vendor", info.F_Vendor);
            hash.Add("F_VendorName", info.F_VendorName);
            hash.Add("F_Pic", info.F_Pic);
            hash.Add("F_ShelfLife", info.F_ShelfLife);
            hash.Add("F_PurchasePrice", info.F_PurchasePrice);
            hash.Add("F_SellingPrice", info.F_SellingPrice);
            hash.Add("F_BasicRate", info.F_BasicRate);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
            hash.Add("F_DeleteTime", info.F_DeleteTime);
            hash.Add("F_DeleteUserId", info.F_DeleteUserId);
            hash.Add("F_Num", info.F_Num);
            hash.Add("F_InStockNum", info.F_InStockNum);
            hash.Add("F_ReturnNum", info.F_ReturnNum);
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
            dict.Add("F_HId", "主表Id");
            dict.Add("F_EnCode", "产品编码");
            dict.Add("F_GoodsId", "产品Id");
            dict.Add("F_GoodsName", "产品名称");
            dict.Add("F_FullName", "产品名称");
            dict.Add("F_CategoryID", "产品类型");
            dict.Add("F_SpecifModel", "规格型号");
            dict.Add("F_WarehouseId", "仓库Id");
            dict.Add("F_WarehouseName", "仓库名称");
            dict.Add("F_Supplier", "供应商");
            dict.Add("F_Unit", "单位");
            dict.Add("F_Pic", "图片");
            dict.Add("F_ShelfLife", "保质期");
            dict.Add("F_PurchasePrice", "采购价格");
            dict.Add("F_SellingPrice", "销售价格");
            dict.Add("F_BasicRate", "基本税率");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_CreatorTime", "创建日期");
            dict.Add("F_CreatorUserId", "创建用户主键");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            dict.Add("F_InStockNum", "入库数");
            dict.Add("F_AlreadyOperatedNum", "已操作数");
            dict.Add("F_CargoPositionId", "货位号");
            dict.Add("F_CargoPositionName", "货位名称");
            dict.Add("F_SpecifiedDate", "指定日期");
            dict.Add("F_OrderNo", "单据号");
            dict.Add("F_TradePrice", "单价");
            dict.Add("F_AllAmount", "总量");
            dict.Add("F_SerialNum", "序列号");
            dict.Add("F_Description", "描述");
            dict.Add("F_CreatorUserId", "创建用户主键");
            #endregion

            return dict;
        }

        public DataTable SelReturnStock()
        {
            string sql = "select * from PI_Body a,PI_Head b where a.F_HId=b.F_Id";
            DataTable dt = base.GetDataTableBySql(sql);
            return dt;
        }


        /// <summary>
        /// 产品入库操作
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="stockinfo"></param>
        /// <returns></returns>
        public string InStock(string Batch, List<PI_ReturnBodyInfo> stockinfo)
        {
            using (DbTransactionScope<PI_ReturnBodyInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //查询入库单是否审核
                    string SqlAuditSel = "select F_Status from PI_Head where F_Id='" + stockinfo[0].F_HId + "'";
                    string AuditState = this.GetDataTableBySql(SqlAuditSel).Rows[0][0].ToString();
                    if (AuditState == "0")
                    {
                        return "该入库单未审核，不能进行入库操作";
                    }

                    //查询库存表是否存在该仓库中的产品
                    foreach (PI_ReturnBodyInfo item in stockinfo)
                    {
                        SearchCondition condtion = new SearchCondition();
                        condtion.AddCondition("F_GoodsId", item.F_GoodsId, SqlOperator.Equal);
                        condtion.AddCondition("F_WarehouseId", item.F_WarehouseId, SqlOperator.Equal);
                        List<Sys_StockInfo> stock = BLLFactory<Sys_Stock>.Instance.Find(condtion.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
                        if (stock == null)
                        {
                            item.IsHave = false;
                        }
                        else
                        {
                            item.IsHave = true;
                            item.StockID = stock[0].F_Id;
                            item.StockNumber = stock[0].F_Number;
                        }
                    }
                    foreach (PI_ReturnBodyInfo item in stockinfo)
                    {
                        //判断是否入库
                        PI_ReturnBodyInfo binfo = BLLFactory<PI_ReturnBody>.Instance.FindByID(item.F_Id);
                        if (binfo.F_AlreadyOperatedNum == "")
                        {
                            binfo.F_AlreadyOperatedNum = "0";
                        }
                        if (int.Parse(binfo.F_AlreadyOperatedNum) > 0)
                        {
                            return "该单据已入库，不能重复执行入库操作";
                        }
                        //查询库存表是否存在该仓库中的产品
                        //没有
                        if (!item.IsHave)
                        {
                            //新添加一条数据
                            Sys_StockInfo entity = new Sys_StockInfo();
                            entity.F_Id = Guid.NewGuid().ToString();
                            entity.F_Batch = item.F_OrderNo;
                            entity.F_CargoPositionId = item.F_CargoPositionId;
                            entity.F_CargoPositionName = item.F_CargoPositionName;
                            entity.F_WarehouseId = item.F_WarehouseId;
                            entity.F_WarehouseName = item.F_WarehouseName;
                            entity.F_GoodsName = item.F_GoodsName;
                            entity.F_GoodsId = item.F_GoodsId;
                            entity.F_SpecifModel = item.F_SpecifModel;
                            entity.F_SellingPrice = item.F_SellingPrice;
                            entity.F_PurchasePrice = item.F_PurchasePrice;
                            entity.F_Unit = item.F_Unit;
                            entity.F_Number = item.F_InStockNum;
                            Sys_Stock.Instance.Insert(entity, dbtran.Transaction);

                            //添加履历
                            Sys_InRecordsInfo inRec = new Sys_InRecordsInfo();
                            inRec.F_Id = Guid.NewGuid().ToString();
                            inRec.F_WarehouseId = item.F_WarehouseId;
                            inRec.F_WarehouseName = item.F_WarehouseName;
                            inRec.F_GoodsName = item.F_GoodsName;
                            inRec.F_GoodsId = item.F_GoodsId;
                            inRec.F_CargoPositionId = item.F_CargoPositionId;
                            inRec.F_CargoPositionName = item.F_CargoPositionName;
                            inRec.F_SpecifModel = item.F_SpecifModel;
                            inRec.F_SellingPrice = item.F_SellingPrice;
                            inRec.F_PurchasePrice = item.F_PurchasePrice;
                            inRec.F_Unit = item.F_Unit;
                            inRec.F_InStockNum = item.F_InStockNum;
                            inRec.F_CreatorTime = DateTime.Now;
                            Sys_InRecords.Instance.Insert(inRec, dbtran.Transaction);


                            //更新子表入库状态
                            Hashtable hash = new Hashtable();
                            hash.Add("F_AlreadyOperatedNum", 1);
                            PI_ReturnBody.Instance.Update(item.F_Id, hash, dbtran.Transaction);

                            //更新主表入库状态
                            hash = new Hashtable();
                            hash.Add("F_State", 1);
                            PI_Head.Instance.Update(item.F_HId, hash, dbtran.Transaction);
                        }
                        else
                        {
                            //更新前库存数量
                            Hashtable hash = new Hashtable();
                            hash.Add("F_Number", item.StockNumber + item.F_InStockNum);
                            Sys_Stock.Instance.Update(item.StockID, hash, dbtran.Transaction);
                            for (int i = 0; i < stockinfo.Count; i++)
                            {
                                if (stockinfo[i].StockID == item.StockID)
                                {
                                    stockinfo[i].StockNumber += item.F_InStockNum;
                                }
                            }

                            //更新子表入库状态
                            hash = new Hashtable();
                            hash.Add("F_AlreadyOperatedNum", 1);
                            PI_ReturnBody.Instance.Update(item.F_Id, hash, dbtran.Transaction);

                            //更新主表入库状态
                            hash = new Hashtable();
                            hash.Add("F_State", 1);
                            PI_Head.Instance.Update(item.F_HId, hash, dbtran.Transaction);


                            //添加履历
                            Sys_InRecordsInfo inRec = new Sys_InRecordsInfo();
                            inRec.F_Id = Guid.NewGuid().ToString();
                            inRec.F_WarehouseId = item.F_WarehouseId;
                            inRec.F_WarehouseName = item.F_WarehouseName;
                            inRec.F_GoodsName = item.F_GoodsName;
                            inRec.F_GoodsId = item.F_GoodsId;
                            inRec.F_CargoPositionId = item.F_CargoPositionId;
                            inRec.F_CargoPositionName = item.F_CargoPositionName;
                            inRec.F_SpecifModel = item.F_SpecifModel;
                            inRec.F_SellingPrice = item.F_SellingPrice;
                            inRec.F_PurchasePrice = item.F_PurchasePrice;
                            inRec.F_Unit = item.F_Unit;
                            inRec.F_InStockNum = item.F_InStockNum;
                            inRec.F_CreatorTime = DateTime.Now;
                            Sys_InRecords.Instance.Insert(inRec, dbtran.Transaction);
                        }
                    }
                    dbtran.Commit();
                    return "操作成功";
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    return "操作失败";
                    throw ex;
                }
            }

            //try
            //{
            //    //循环获取子表信息
            //    for (int i = 0; i < stockinfo.Count; i++)
            //    {
            //        string SqlAuditSel = "select F_Status from PI_Head where F_Id='" + stockinfo[i].F_HId + "'";
            //        string AuditState = this.GetDataTableBySql(SqlAuditSel).Rows[0][0].ToString();
            //        if (AuditState == "0")
            //        {
            //            return "该入库单未审核，不能进行入库操作";
            //        }

            //        string state = "select F_AlreadyOperatedNum from PI_ReturnBody where F_Id='" + stockinfo[i].F_Id + "'";
            //        DataTable dt = this.GetDataTableBySql(state);
            //        //判断是否已入库
            //        string AoNum = dt.Rows[0][0].ToString();
            //        if (AoNum == "")
            //        {
            //            AoNum = "0";
            //        }
            //        if (int.Parse(AoNum) > 0)
            //        {
            //            return "该单据已入库，不能重复执行入库操作";
            //        }

            //        //查询库存表是否存在该仓库中的产品
            //        string sql = "select F_Id,F_Number from Sys_Stock where F_GoodsId='" + stockinfo[i].F_GoodsId + "' and F_WarehouseId='" + stockinfo[i].F_WarehouseId + "'";

            //        //如果没有则添加一条数据
            //        if (this.GetDataTableBySql(sql).Rows.Count == 0)
            //        {
            //            //新添加一条数据
            //            Sys_StockInfo entity = new Sys_StockInfo();
            //            entity.F_Id = Guid.NewGuid().ToString();
            //            entity.F_Batch = stockinfo[i].F_OrderNo;
            //            entity.F_CargoPositionId = stockinfo[i].F_CargoPositionId;
            //            entity.F_CargoPositionName = stockinfo[i].F_CargoPositionName;
            //            entity.F_WarehouseId = stockinfo[i].F_WarehouseId;
            //            entity.F_WarehouseName = stockinfo[i].F_WarehouseName;
            //            entity.F_GoodsName = stockinfo[i].F_GoodsName;
            //            entity.F_GoodsId = stockinfo[i].F_GoodsId;
            //            entity.F_SpecifModel = stockinfo[i].F_SpecifModel;
            //            entity.F_SellingPrice = stockinfo[i].F_SellingPrice;
            //            entity.F_PurchasePrice = stockinfo[i].F_PurchasePrice;
            //            entity.F_Unit = stockinfo[i].F_Unit;
            //            entity.F_Number = stockinfo[i].F_InStockNum;
            //            Sys_Stock.Instance.Insert(entity);

            //            //添加履历
            //            Sys_InRecordsInfo inRec = new Sys_InRecordsInfo();
            //            inRec.F_Id = Guid.NewGuid().ToString();
            //            inRec.F_WarehouseId = stockinfo[i].F_WarehouseId;
            //            inRec.F_WarehouseName = stockinfo[i].F_WarehouseName;
            //            inRec.F_GoodsName = stockinfo[i].F_GoodsName;
            //            inRec.F_GoodsId = stockinfo[i].F_GoodsId;
            //            inRec.F_CargoPositionId = stockinfo[i].F_CargoPositionId;
            //            inRec.F_CargoPositionName = stockinfo[i].F_CargoPositionName;
            //            inRec.F_SpecifModel = stockinfo[i].F_SpecifModel;
            //            inRec.F_SellingPrice = stockinfo[i].F_SellingPrice;
            //            inRec.F_PurchasePrice = stockinfo[i].F_PurchasePrice;
            //            inRec.F_Unit = stockinfo[i].F_Unit;
            //            inRec.F_InStockNum = stockinfo[i].F_InStockNum;
            //            inRec.F_CreatorTime = DateTime.Now;

            //            Sys_InRecords.Instance.Insert(inRec);

            //            //更新子表入库状态
            //            string upState = "update PI_ReturnBody set F_AlreadyOperatedNum='1' where F_Id='" + stockinfo[i].F_Id + "'";
            //            Hashtable hash = new Hashtable();
            //            base.ExecuteNonQuery(upState, hash);

            //            //更新主表入库状态
            //            string upStateH = "update PI_Head set F_State='1' where F_Id='" + stockinfo[i].F_HId + "'";
            //            Hashtable hash1 = new Hashtable();
            //            base.ExecuteNonQuery(upStateH, hash1);
            //        }
            //        //存在就更新库存
            //        else
            //        {
            //            //更新前库存数量
            //            int oldnum = int.Parse(this.GetDataTableBySql(sql).Rows[0][1].ToString());
            //            //要入库的数量
            //            int instockNum = stockinfo[i].F_InStockNum;
            //            //更新后库存数量
            //            int num = oldnum + instockNum;
            //            string Str = "update Sys_Stock set F_Number='" + num + "' where F_Id='" + this.GetDataTableBySql(sql).Rows[0][0].ToString() + "'";
            //            Hashtable hash = new Hashtable();
            //            base.ExecuteNonQuery(Str, hash);

            //            //更新子表入库状态
            //            string upState = "update PI_ReturnBody set F_AlreadyOperatedNum='1' where F_Id='" + stockinfo[i].F_Id + "'";
            //            Hashtable hash1 = new Hashtable();
            //            base.ExecuteNonQuery(upState, hash1);

            //            //更新主表入库状态
            //            string upStateH = "update PI_Head set F_State='1' where F_Id='" + stockinfo[i].F_HId + "'";
            //            Hashtable hash2 = new Hashtable();
            //            base.ExecuteNonQuery(upStateH, hash2);

            //            //添加履历
            //            Sys_InRecordsInfo inRec = new Sys_InRecordsInfo();
            //            inRec.F_Id = Guid.NewGuid().ToString();
            //            inRec.F_WarehouseId = stockinfo[i].F_WarehouseId;
            //            inRec.F_WarehouseName = stockinfo[i].F_WarehouseName;
            //            inRec.F_GoodsName = stockinfo[i].F_GoodsName;
            //            inRec.F_GoodsId = stockinfo[i].F_GoodsId;
            //            inRec.F_CargoPositionId = stockinfo[i].F_CargoPositionId;
            //            inRec.F_CargoPositionName = stockinfo[i].F_CargoPositionName;
            //            inRec.F_SpecifModel = stockinfo[i].F_SpecifModel;
            //            inRec.F_SellingPrice = stockinfo[i].F_SellingPrice;
            //            inRec.F_PurchasePrice = stockinfo[i].F_PurchasePrice;
            //            inRec.F_Unit = stockinfo[i].F_Unit;
            //            inRec.F_InStockNum = stockinfo[i].F_InStockNum;
            //            inRec.F_CreatorTime = DateTime.Now;
            //            Sys_InRecords.Instance.Insert(inRec);
            //        }
            //    }
            //    return "操作成功";
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
          
        }

    }
}
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
using KGMFramework.WebApp.Library;

namespace KGMFramework.WebApp.DALSQL
{
    /// <summary>
    /// 入库主表
    /// </summary>
    public class PI_Head : BaseDALSQL<PI_HeadInfo>, IPI_Head
    {
        #region 对象实例及构造函数

        public static PI_Head Instance
        {
            get
            {
                return new PI_Head();
            }
        }
        public PI_Head()
            : base("PI_Head", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override PI_HeadInfo DataReaderToEntity(IDataReader dataReader)
        {
            PI_HeadInfo info = new PI_HeadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_DocumentNum = reader.GetString("F_DocumentNum");
            info.F_Vendor = reader.GetString("F_Vendor");
            info.F_VendorName = reader.GetString("F_VendorName");
            info.F_Status = reader.GetInt32("F_Status");
            info.F_Operator = reader.GetString("F_Operator");
            info.F_Contacts = reader.GetString("F_Contacts");
            info.F_TelePhone = reader.GetString("F_TelePhone");
            info.F_Date = reader.GetDateTime("F_Date");
            info.F_VeriDate = reader.GetDateTime("F_VeriDate");
            info.F_State = reader.GetInt32("F_State");
            info.F_Auditing = reader.GetString("F_Auditing");
            info.F_TotalAmount = reader.GetDecimal("F_TotalAmount");
            info.F_Verify = reader.GetString("F_Verify");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_CargoPositionId = reader.GetString("F_CargoPositionId");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_Invoice = reader.GetString("F_Invoice");
            info.F_Maker = reader.GetString("F_Maker");
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
        protected override Hashtable GetHashByEntity(PI_HeadInfo obj)
        {
            PI_HeadInfo info = obj as PI_HeadInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_DocumentNum", info.F_DocumentNum);
            hash.Add("F_Contacts", info.F_Contacts);
            hash.Add("F_TelePhone", info.F_TelePhone);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_Vendor", info.F_Vendor);
            hash.Add("F_VendorName", info.F_VendorName);
            hash.Add("F_Operator", info.F_Operator);
            hash.Add("F_Status", info.F_Status);
            hash.Add("F_State", info.F_State);
            hash.Add("F_Date", info.F_Date);
            hash.Add("F_VeriDate", info.F_VeriDate);
            hash.Add("F_Auditing", info.F_Auditing);
            hash.Add("F_TotalAmount", info.F_TotalAmount);
            hash.Add("F_Verify", info.F_Verify);
            hash.Add("F_Maker", info.F_Maker);
            hash.Add("F_Invoice", info.F_Invoice);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_CargoPositionId", info.F_CargoPositionId);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
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
            //dict.Add("ID", "编号");
            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "编码");
            dict.Add("F_DocumentNum", "单据号码");
            dict.Add("F_Vendor", "供应商");
            dict.Add("F_Operator", "操作人");
            dict.Add("F_Date", "单据日期");
            dict.Add("F_VeriDate", "审核日期");
            dict.Add("F_Auditing", "审核");
            dict.Add("F_TotalAmount", "总金额");
            dict.Add("F_Verify", "审核人");
            dict.Add("F_Invoice", "发票号");
            dict.Add("F_Maker", "制单人");
            dict.Add("F_WarehouseId", "仓库Id");
            dict.Add("F_WarehouseName", "仓库名称");
            dict.Add("F_CargoPositionId", "货位号");
            dict.Add("F_CargoPositionName", "货位名称");
            dict.Add("F_Description", "描述");
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

        public PI_HeadInfo Save(PI_HeadInfo info, List<PI_BodyInfo> dInfo)
        {
            using (DbTransactionScope<PI_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(info.F_EnCode))
                    {
                        string orderNo = "IN" + DateTime.Now.ToString("yyyyMMdd");
                        Hashtable hash = new Hashtable();
                        hash.Add("Prefix", orderNo);
                        DataTable dt = base.StorePorcToDataTable("SYS_CREATESN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString().PadLeft(6, '0');
                        info.F_EnCode = orderNo + SN;
                    }
                    else
                    {
                        //判断当前单据是否已经审核
                        var head = this.FindByID(info.F_Id, dbtran.Transaction);
                        if (head != null && head.F_Status > 0)
                        {
                            throw new ApplicationException("单据已经审核!");
                        }
                    }
                    //添加主表
                    PI_Head.Instance.InsertUpdate(info, info.F_Id, dbtran.Transaction);
                    //删除子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", info.F_Id, SqlOperator.Equal);
                    PI_Body.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //循环添加子表
                    foreach (PI_BodyInfo item in dInfo)
                    {
                        item.F_CreatorTime = DateTime.Now;
                        item.F_CreatorUserId = info.F_CreatorUserId;
                        item.F_Id = Guid.NewGuid().ToString();
                        item.F_HId = info.F_Id;
                        item.F_Supplier = info.F_VendorName;
                        item.F_OrderNo = info.F_EnCode;
                        //PI_Body.Instance.Insert(item, dbtran.Transaction);
                    }
                    PI_Body.Instance.InsertRange(dInfo, dbtran.Transaction);

                    dbtran.Commit();

                    return info;
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }
        }

        public void DeleteAll(string keyValue, bool bLogicDelete = false)
        {
            using (DbTransactionScope<PI_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    PI_Head.Instance.Delete(keyValue, dbtran.Transaction);
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", keyValue, SqlOperator.Equal);
                    PI_Body.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    dbtran.Commit();
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }
        }

        public void Status(string F_Id, string userName)
        {
            using (DbTransactionScope<PI_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //更新登记单主表审核状态，审核人，审核时间
                    PI_HeadInfo head = PI_Head.Instance.FindByID(F_Id, dbtran.Transaction);
                    head.F_Status = 1;
                    head.F_Verify = userName;
                    head.F_VeriDate = DateTime.Now;
                    PI_Head.Instance.Update(head, F_Id, dbtran.Transaction);
                    //找到登记单子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", F_Id, SqlOperator.Equal);
                    List<PI_BodyInfo> list = PI_Body.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //资产编号
                    foreach (PI_BodyInfo item in list)
                    {
                        for (int i = 0; i < item.F_InStockNum; i++)
                        {
                            PI_BodyInfo entity = new PI_BodyInfo();
                            entity.F_Id = Guid.NewGuid().ToString();
                            entity.F_EnCode = item.F_EnCode;
                            entity.F_FullName = item.F_FullName;
                            entity.F_OrderNo = item.F_OrderNo;
                            entity.F_Supplier = item.F_Supplier;
                            entity.F_Unit = item.F_Unit;
                            entity.F_Description = item.F_Description;
                            PI_Body.Instance.Insert(entity, dbtran.Transaction);
                        }
                    }
                    dbtran.Commit();
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }
        }

        public DataTable GetPrint(string sourceData)
        {
            DataTable dt = null;
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_Id", sourceData, SqlOperator.Equal);
            List<PI_HeadInfo> hinfo = BLLFactory<PI_Head>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));

            condition = new SearchCondition();
            condition.AddCondition("F_HId", sourceData, SqlOperator.Equal);
            List<PI_BodyInfo> binfo = PI_Body.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));

            dt = new DataTable();
            dt.Columns.Add("CINVCODE");
            dt.Columns.Add("CINVNAME");
            dt.Columns.Add("CINVSTD");
            dt.Columns.Add("QTY");
            dt.Columns.Add("NOTES");
            dt.Columns.Add("UNIT");
            dt.Columns.Add("PRICE");
            dt.Columns.Add("TOTALPRICE");
            dt.Columns.Add("ORDERNO");
            dt.Columns.Add("CVCNAME");
            dt.Columns.Add("WAREHOUSE");
            dt.Columns.Add("CONTRACTNO");
            dt.Columns.Add("MAKER");
            dt.Columns.Add("LDATE");


            for (int i = 0; i < binfo.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ORDERNO"] = hinfo[0].F_EnCode;
                dr["CVCNAME"] = hinfo[0].F_VendorName;
                dr["NOTES"] = hinfo[0].F_Description;
                dr["WAREHOUSE"] = hinfo[0].F_WarehouseName;
                dr["CONTRACTNO"] = hinfo[0].F_Contacts;
                dr["MAKER"] = hinfo[0].F_Maker;
                dr["LDATE"] = hinfo[0].F_Date;

                dr["CINVCODE"] = binfo[i].F_EnCode;
                dr["CINVNAME"] = binfo[i].F_GoodsName;
                dr["CINVSTD"] = binfo[i].F_SpecifModel;
                dr["QTY"] = binfo[i].F_InStockNum;
                dr["NOTES"] = binfo[i].F_Description;
                dr["UNIT"] = binfo[i].F_Unit ;
                dr["PRICE"] = binfo[i].F_PurchasePrice;
                dr["TOTALPRICE"] = binfo[i].F_AllAmount;

                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable GetAssetPicture(string id)
        {
            string sql = (@"SELECT P.F_EnCode,P.F_PhotoUrl FROM PI_Body B
                            INNER JOIN PI_Body I on B.F_Id=I.F_OrderDetailedId
                            INNER JOIN Asset_InfoPhoto P on I.F_EnCode=P.F_EnCode
                            WHERE B.F_Id=@id ORDER BY F_EnCode");
            Hashtable hash = new Hashtable();
            hash.Add("id", id);
            return base.ExecuteTable(sql, hash);
        }

        public string createCode(string F_Id)
        {
            using (DbTransactionScope<PI_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_OrderDetailedId", F_Id, SqlOperator.Equal);
                    List<PI_BodyInfo> list = PI_Body.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    if (!string.IsNullOrEmpty(list[0].F_EnCode))
                    {
                        return "生成失败，该资产已经生成条码！";
                    }
                    string orderNo = "In" + DateTime.Now.ToString("yyyyMMdd");
                    Hashtable hash = new Hashtable();
                    hash.Add("Prefix", orderNo);
                    foreach (PI_BodyInfo item in list)
                    {
                        DataTable dt = base.StorePorcToDataTable("SYS_CREATESN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString().PadLeft(6, '0');
                        item.F_EnCode = orderNo + SN;
                        PI_Body.Instance.Update(item, dbtran.Transaction);
                    }
                    dbtran.Commit();
                    return "生成成功！";
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }
        }

        public bool Check2(string F_Id)
        {
            bool a = false;
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_HId", F_Id, SqlOperator.Equal);
            List<PI_BodyInfo> list = PI_Body.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            foreach (var item in list)
            {
                SearchCondition condition2 = new SearchCondition();
                condition2.AddCondition("F_OrderDetailedId", item.F_Id, SqlOperator.Equal);
                List<PI_BodyInfo> list2 = PI_Body.Instance.Find(condition2.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
                if (list2[0].F_EnCode == "")
                {
                    return true;
                }
            }
            return a;
        }


        /// <summary>
        ///审核单据 
        /// </summary>
        /// <param name="date">审核日期</param>
        /// <param name="Id">审核单据</param>
        /// <param name="user">审核人</param>
        public string Audit(string date, string user, string Id, List<PI_BodyInfo> stockinfo)
        {
            string SqlAuditSel = "select F_Status from PI_Head where F_Id='" + Id + "'";
            string AuditState = this.GetDataTableBySql(SqlAuditSel).Rows[0][0].ToString();
            if (AuditState == "1")
            {
                return "单据已被审核";
            }
            else
            {
                using (DbTransactionScope<PI_HeadInfo> dbtran = base.CreateTransactionScope())
                {
                    try
                    {
                        //查询所有库存信息
                        List<Sys_StockInfo> stockList = BLLFactory<Sys_Stock>.Instance.GetAll();
                        //查询主表信息
                        PI_HeadInfo hinfo = BLLFactory<PI_Head>.Instance.FindByID(Id);
                        

                        foreach (PI_BodyInfo item in stockinfo)
                        {
                            //判断是否入库
                            PI_BodyInfo binfo = BLLFactory<PI_Body>.Instance.FindByID(item.F_Id);
                            if (binfo.F_AlreadyOperatedNum == "")
                            {
                                binfo.F_AlreadyOperatedNum = "0";
                            }
                            if (int.Parse(binfo.F_AlreadyOperatedNum) > 0)
                            {
                                return "该单据已入库，不能重复执行入库操作";
                            }

                            if (binfo.F_WarehouseId==""||binfo.F_CargoPositionId=="")
                            {
                                return "该单据中仓库或仓位为空，审核未通过";
                            }

                            Sys_StockInfo stock = stockList.Find(u => u.F_WarehouseId == binfo.F_WarehouseId && u.F_CargoPositionId == binfo.F_CargoPositionId && u.F_GoodsId == binfo.F_GoodsId&&u.F_Batch==binfo.F_SerialNum);
                            if (stock == null)
                            {
                                item.IsHave = false;
                            }
                            else
                            {
                                item.IsHave = true;
                                item.StockID = stock.F_Id;
                                item.StockNumber = stock.F_Number;
                            }

                            //查询库存表是否存在该仓库中的产品
                            //没有
                            if (!item.IsHave)
                            {
                                //新添加一条数据 库存表
                                Sys_StockInfo entity = new Sys_StockInfo();
                                entity.F_Id = Guid.NewGuid().ToString();
                                entity.F_CargoPositionId = item.F_CargoPositionId;
                                entity.F_CargoPositionName = item.F_CargoPositionName;
                                entity.F_WarehouseId = item.F_WarehouseId;
                                entity.F_WarehouseName = item.F_WarehouseName;
                                entity.F_GoodsName = item.F_FullName;
                                entity.F_Batch = item.F_SerialNum;
                                entity.F_GoodsId = item.F_GoodsId;
                                entity.F_SpecifModel = item.F_SpecifModel;
                                entity.F_SellingPrice = item.F_SellingPrice;
                                entity.F_PurchasePrice = item.F_PurchasePrice;
                                entity.F_Unit = item.F_Unit;
                                entity.F_Number = item.F_InStockNum;
                                Sys_Stock.Instance.Insert(entity, dbtran.Transaction);

                                //更新审核状态
                                string sql = string.Format("update PI_Head set F_Status=1,F_VeriDate='{0}',F_Verify='{1}' where F_Id='{2}'", date, user, Id);
                                Hashtable hash = new Hashtable();
                                base.ExecuteNonQuery(sql, hash, dbtran.Transaction);

                                //添加入库履历 入库履历
                                Sys_InRecordsInfo inRec = new Sys_InRecordsInfo();
                                inRec.F_Id = Guid.NewGuid().ToString();
                                inRec.F_WarehouseId = item.F_WarehouseId;
                                inRec.F_Vendor = hinfo.F_Vendor;
                                inRec.F_VendorName = hinfo.F_VendorName;
                                inRec.F_Contacts = hinfo.F_Contacts;
                                inRec.F_TelePhone = hinfo.F_TelePhone;
                                inRec.F_Verify = user;
                                inRec.F_Maker = hinfo.F_Maker;
                                inRec.F_VeriDate = DateTime.Now;
                                inRec.F_EnCode = item.F_OrderNo;
                                inRec.F_Batch = item.F_SerialNum;
                                inRec.F_WarehouseName = item.F_WarehouseName;
                                inRec.F_GoodsName = item.F_FullName;
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



                                //添加  库存履历
                                Sys_StockHistoryInfo instock = new Sys_StockHistoryInfo();
                                instock.F_Id = Guid.NewGuid().ToString();
                                instock.F_WarehouseId = item.F_WarehouseId;
                                instock.F_Vendor = hinfo.F_Vendor;
                                instock.F_VendorName = hinfo.F_VendorName;
                                instock.F_Contacts = hinfo.F_Contacts;
                                instock.F_TelePhone = hinfo.F_TelePhone;
                                instock.F_Verify = user;
                                instock.F_Maker = hinfo.F_Maker;
                                instock.F_VeriDate = DateTime.Now;
                                instock.F_EnCode = item.F_OrderNo;
                                instock.F_Batch = item.F_SerialNum;
                                instock.F_WarehouseName = item.F_WarehouseName;
                                instock.F_BllCategory = "入库";
                                instock.F_GoodsName = item.F_FullName;
                                instock.F_GoodsId = item.F_GoodsId;
                                instock.F_CargoPositionId = item.F_CargoPositionId;
                                instock.F_CargoPositionName = item.F_CargoPositionName;
                                instock.F_SpecifModel = item.F_SpecifModel;
                                instock.F_SellingPrice = item.F_SellingPrice;
                                instock.F_PurchasePrice = item.F_PurchasePrice;
                                instock.F_Unit = item.F_Unit;
                                instock.F_OperationNum = item.F_InStockNum;
                                instock.F_CreatorTime = DateTime.Now;
                                Sys_StockHistory.Instance.Insert(instock, dbtran.Transaction);

                                

                                //更新子表入库状态
                                hash = new Hashtable();
                                hash.Add("F_AlreadyOperatedNum", 1);
                                PI_Body.Instance.Update(item.F_Id, hash, dbtran.Transaction);

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

                                //更新审核状态
                                string sql = string.Format("update PI_Head set F_Status=1,F_VeriDate='{0}',F_Verify='{1}' where F_Id='{2}'", date, user, Id);
                                hash = new Hashtable();
                                base.ExecuteNonQuery(sql, hash, dbtran.Transaction);

                                //更新子表入库状态
                                hash = new Hashtable();
                                hash.Add("F_AlreadyOperatedNum", 1);
                                PI_Body.Instance.Update(item.F_Id, hash, dbtran.Transaction);

                                //更新主表入库状态
                                hash = new Hashtable();
                                hash.Add("F_State", 1);
                                PI_Head.Instance.Update(item.F_HId, hash, dbtran.Transaction);


                                //添加履历
                                Sys_InRecordsInfo inRec = new Sys_InRecordsInfo();
                                inRec.F_Id = Guid.NewGuid().ToString();
                                inRec.F_WarehouseId = item.F_WarehouseId;
                                inRec.F_EnCode = item.F_OrderNo;
                                inRec.F_Batch = item.F_SerialNum;
                                inRec.F_Vendor = hinfo.F_Vendor;
                                inRec.F_VendorName = hinfo.F_VendorName;
                                inRec.F_Contacts = hinfo.F_Contacts;
                                inRec.F_TelePhone = hinfo.F_TelePhone;
                                inRec.F_Verify = user;
                                inRec.F_Maker = hinfo.F_Maker;
                                inRec.F_VeriDate = DateTime.Now; 
                                inRec.F_WarehouseName = item.F_WarehouseName;
                                inRec.F_GoodsName = item.F_FullName;
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

                                //添加库存履历
                                Sys_StockHistoryInfo instock = new Sys_StockHistoryInfo();
                                instock.F_Id = Guid.NewGuid().ToString();
                                instock.F_WarehouseId = item.F_WarehouseId;
                                instock.F_EnCode = item.F_OrderNo;
                                instock.F_Batch = item.F_SerialNum;
                                instock.F_Vendor = hinfo.F_Vendor;
                                instock.F_VendorName = hinfo.F_VendorName;
                                instock.F_Contacts = hinfo.F_Contacts;
                                instock.F_TelePhone = hinfo.F_TelePhone;
                                instock.F_Verify = user;
                                instock.F_Maker = hinfo.F_Maker;
                                instock.F_VeriDate = DateTime.Now;
                                instock.F_WarehouseName = item.F_WarehouseName;
                                instock.F_BllCategory = "入库";
                                instock.F_GoodsName = item.F_FullName;
                                instock.F_GoodsId = item.F_GoodsId;
                                instock.F_CargoPositionId = item.F_CargoPositionId;
                                instock.F_CargoPositionName = item.F_CargoPositionName;
                                instock.F_SpecifModel = item.F_SpecifModel;
                                instock.F_SellingPrice = item.F_SellingPrice;
                                instock.F_PurchasePrice = item.F_PurchasePrice;
                                instock.F_Unit = item.F_Unit;
                                instock.F_OperationNum = item.F_InStockNum;
                                instock.F_CreatorTime = DateTime.Now;
                                Sys_StockHistory.Instance.Insert(instock, dbtran.Transaction);
                            }
                        }
                        dbtran.Commit();
                        return "单据审核成功";
                    }
                    catch (Exception ex)
                    {
                        dbtran.RollBack();
                        return "操作失败";
                        throw ex;
                    }
                }
            }

            
        }


        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user"></param>
        /// <param name="Id"></param>
        public string NoAudit(string date, string user, string Id)
        {
            string state = "select F_AlreadyOperatedNum from PI_Body where F_HId='" + Id + "'";
            DataTable dt = this.GetDataTableBySql(state);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string AoNum = dt.Rows[i][0].ToString();
                if (AoNum == "")
                {
                    AoNum = "0";
                }
                if (int.Parse(AoNum) > 0)
                {
                    return "该单据已有产品入库，不能执行反审核操作";
                }
            }

            string sql = "select F_Status from PI_Head where F_Id='" + Id + "'";
            if (this.GetDataTableBySql(sql).Rows[0][0].ToString() == "1")
            {
                string updatesql = string.Format("update PI_Head set F_Status=0,F_VeriDate='{0}',F_Verify='{1}' where F_Id='{2}'", date, user, Id);
                Hashtable hash = new Hashtable();
                base.ExecuteNonQuery(updatesql, hash);
                return "反审核成功";
            }
            else
            {
                return "该单据未被审核";
            }

        }



        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public KgmApiResultEntity DeleteOrder(string ID)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ID", DbType.String, ID));
            KgmApiResultEntity entity = new KgmApiResultEntity();
            return entity;
        }
    }
}
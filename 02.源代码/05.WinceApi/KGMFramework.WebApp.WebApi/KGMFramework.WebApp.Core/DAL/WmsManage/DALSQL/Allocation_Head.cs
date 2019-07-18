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
    /// 调拨主表
    /// </summary>
    public class Allocation_Head : BaseDALSQL<Allocation_HeadInfo>, IAllocation_Head
    {
        #region 对象实例及构造函数

        public static Allocation_Head Instance
        {
            get
            {
                return new Allocation_Head();
            }
        }
        public Allocation_Head()
            : base("Allocation_Head", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Allocation_HeadInfo DataReaderToEntity(IDataReader dataReader)
        {
            Allocation_HeadInfo info = new Allocation_HeadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_Date = reader.GetDateTime("F_Date");
            info.F_Operator = reader.GetString("F_Operator");
            info.F_Maker = reader.GetString("F_Maker");
            info.F_Invoice = reader.GetString("F_Invoice");
            info.F_AccountDate = reader.GetDateTime("F_AccountDate");
            info.F_Verify = reader.GetString("F_Verify");
            info.F_Status = reader.GetInt32("F_Status");
            info.F_State = reader.GetInt32("F_State");
            info.F_Description = reader.GetString("F_Description");
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
        protected override Hashtable GetHashByEntity(Allocation_HeadInfo obj)
        {
            Allocation_HeadInfo info = obj as Allocation_HeadInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_Operator", info.F_Operator);
            hash.Add("F_Status", info.F_Status);
            hash.Add("F_Date", info.F_Date);
            hash.Add("F_Verify", info.F_Verify);
            hash.Add("F_Maker", info.F_Maker);
            hash.Add("F_Invoice", info.F_Invoice);
            hash.Add("F_AccountDate", info.F_AccountDate);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
            hash.Add("F_DeleteTime", info.F_DeleteTime);
            hash.Add("F_DeleteUserId", info.F_DeleteUserId);
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
            dict.Add("F_EnCode", "调拨编码");
            dict.Add("F_Date", "单据日期");
            dict.Add("F_Operator", "操作人");
            dict.Add("F_Maker", "制单人");
            dict.Add("F_Invoice", "发票号");
            dict.Add("F_AccountDate", "审核日期");
            dict.Add("F_Verify", "审核人");
            dict.Add("F_Status", "审核状态");
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

        public Allocation_HeadInfo Save(Allocation_HeadInfo info, List<Allocation_BodyInfo> dInfo)
        {
            using (DbTransactionScope<Allocation_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(info.F_EnCode))
                    {
                        string orderNo = "DB" + DateTime.Now.ToString("yyyyMMdd");
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
                    Allocation_Head.Instance.InsertUpdate(info, info.F_Id, dbtran.Transaction);
                    //删除子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", info.F_Id, SqlOperator.Equal);
                    Allocation_Body.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //循环添加子表
                    foreach (Allocation_BodyInfo item in dInfo)
                    {
                        item.F_CreatorTime = DateTime.Now;
                        item.F_CreatorUserId = info.F_CreatorUserId;
                        item.F_Id = Guid.NewGuid().ToString();
                        item.F_HId = info.F_Id;
                        item.F_OrderNo = info.F_EnCode;
                    }
                    Allocation_Body.Instance.InsertRange(dInfo, dbtran.Transaction);

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
            using (DbTransactionScope<Allocation_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    Allocation_Head.Instance.Delete(keyValue, dbtran.Transaction);
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", keyValue, SqlOperator.Equal);
                    Allocation_Body.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
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
            using (DbTransactionScope<Allocation_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //更新登记单主表审核状态，审核人，审核时间
                    Allocation_HeadInfo head = Allocation_Head.Instance.FindByID(F_Id, dbtran.Transaction);
                    head.F_Status = 1;
                    head.F_Verify = userName;
                    Allocation_Head.Instance.Update(head, F_Id, dbtran.Transaction);
                    //找到登记单子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", F_Id, SqlOperator.Equal);
                    List<Allocation_BodyInfo> list = Allocation_Body.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //资产编号
                    foreach (Allocation_BodyInfo item in list)
                    {
                        //for (int i = 0; i < item.F_InStockNum; i++)
                        //{
                        //    Allocation_BodyInfo entity = new Allocation_BodyInfo();
                        //    entity.F_Id = Guid.NewGuid().ToString();
                        //    entity.F_EnCode = item.F_EnCode;
                        //    entity.F_FullName = item.F_FullName;
                        //    entity.F_Unit = item.F_Unit;
                        //    Allocation_Body.Instance.Insert(entity, dbtran.Transaction);
                        //}
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
            string sql = string.Format(@"SELECT H.*,B.*,O.F_FullName OrganizeName,S.F_FullName VendorName
                FROM Allocation_Head H
                INNER JOIN Allocation_Body B on H.F_Id=b.F_HId
                INNER JOIN Sys_Organize O on H.F_Orgnization=O.F_Id
				INNER JOIN MST_SupplierInfo S on H.F_Vendor=S.F_Id
                WHERE H.F_Id=@F_Id");
            Hashtable hash = new Hashtable();
            hash.Add("F_Id", sourceData);
            return base.ExecuteTable(sql, hash);
        }

        public DataTable GetAssetAllocationcture(string id)
        {
            string sql = (@"SELECT P.F_EnCode,P.F_PhotoUrl FROM Allocation_Body B
                            INNER JOIN Allocation_Body I on B.F_Id=I.F_OrderDetailedId
                            INNER JOIN Asset_InfoPhoto P on I.F_EnCode=P.F_EnCode
                            WHERE B.F_Id=@id ORDER BY F_EnCode");
            Hashtable hash = new Hashtable();
            hash.Add("id", id);
            return base.ExecuteTable(sql, hash);
        }

        public string createCode(string F_Id)
        {
            using (DbTransactionScope<Allocation_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_OrderDetailedId", F_Id, SqlOperator.Equal);
                    List<Allocation_BodyInfo> list = Allocation_Body.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    if (!string.IsNullOrEmpty(list[0].F_EnCode))
                    {
                        return "生成失败，该资产已经生成条码！";
                    }
                    string orderNo = "In" + DateTime.Now.ToString("yyyyMMdd");
                    Hashtable hash = new Hashtable();
                    hash.Add("Prefix", orderNo);
                    foreach (Allocation_BodyInfo item in list)
                    {
                        DataTable dt = base.StorePorcToDataTable("SYS_CREATESN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString().PadLeft(6, '0');
                        item.F_EnCode = orderNo + SN;
                        Allocation_Body.Instance.Update(item, dbtran.Transaction);
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
            List<Allocation_BodyInfo> list = Allocation_Body.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            foreach (var item in list)
            {
                SearchCondition condition2 = new SearchCondition();
                condition2.AddCondition("F_OrderDetailedId", item.F_Id, SqlOperator.Equal);
                List<Allocation_BodyInfo> list2 = Allocation_Body.Instance.Find(condition2.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
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
        public string Audit(string date, string user, string Id, List<Allocation_BodyInfo> DbInfo)
        {
            string SqlAuditSel = "select F_Status from Allocation_Head where F_Id='" + Id + "'";
            string AuditState = this.GetDataTableBySql(SqlAuditSel).Rows[0][0].ToString();
            if (AuditState == "1")
            {
                return "单据已被审核";
            }
            else
            {
                using (DbTransactionScope<Allocation_HeadInfo> dbtran = base.CreateTransactionScope())
                {
                    try
                    {
                        Hashtable hash = new Hashtable();
                        List<Sys_StockInfo> StockList = BLLFactory<Sys_Stock>.Instance.GetAll();

                        //查询主表信息
                        Allocation_HeadInfo hinfo = BLLFactory<Allocation_Head>.Instance.FindByID(Id);
                        
                        for (int i = 0; i < DbInfo.Count; i++)
                        {
                            //查询子表信息
                            SearchCondition condition = new SearchCondition();
                            condition.AddCondition("F_Id", DbInfo[i].F_Id, SqlOperator.Equal);
                            Allocation_BodyInfo bodyinfo = BLLFactory<Allocation_Body>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty))[0];

                            //判断是否出库 
                            if (bodyinfo.F_FreeTerm1 == "") //F_FreeTerm1--0未出库  1已出库
                            {
                                bodyinfo.F_FreeTerm1 = "0";
                            }
                            if (int.Parse(bodyinfo.F_FreeTerm1) > 0)
                            {
                                return "该单据已出库，不能重复执行出库操作";
                            }

                            if (bodyinfo.F_OutWareId == "" || bodyinfo.F_OutCargoPositionId == "" || bodyinfo.F_InWareId == "" || bodyinfo.F_InCargoPositionId == "")
                            {
                                return "该单据中仓库或仓位为空，审核未通过";
                            }

                            //查询库存表是否存在该仓库中的产品
                            Sys_StockInfo stock = StockList.Find(u => u.F_WarehouseId == bodyinfo.F_OutWareId && u.F_CargoPositionId == bodyinfo.F_OutCargoPositionId && u.F_GoodsId == bodyinfo.F_GoodsId&&u.F_Batch==bodyinfo.F_SerialNum);

                            if (stock == null)
                            {
                                dbtran.RollBack();
                                return "该仓库无此产品";
                            }

                            //判断库存数量是否足够
                            if (stock.F_Number > bodyinfo.F_DbNum)
                            {
                                //扣减库存
                                hash = new Hashtable();
                                hash.Add("F_Number", stock.F_Number - bodyinfo.F_DbNum);
                                Sys_Stock.Instance.Update(stock.F_Id, hash, dbtran.Transaction);

                                //添加库存履历
                                Sys_StockHistoryInfo instockHistory = new Sys_StockHistoryInfo();
                                instockHistory.F_Id = Guid.NewGuid().ToString();
                                instockHistory.F_WarehouseId = bodyinfo.F_OutWareId;
                                instockHistory.F_EnCode = bodyinfo.F_OrderNo;
                                instockHistory.F_Batch = bodyinfo.F_SerialNum;
                                instockHistory.F_Verify = user;
                                instockHistory.F_Maker = hinfo.F_Maker;
                                instockHistory.F_VeriDate = DateTime.Now;
                                instockHistory.F_WarehouseName = bodyinfo.F_OutWareName;
                                instockHistory.F_BllCategory = "调出";
                                instockHistory.F_GoodsName = bodyinfo.F_GoodsName;
                                instockHistory.F_GoodsId = bodyinfo.F_GoodsId;
                                instockHistory.F_CargoPositionId = bodyinfo.F_OutCargoPositionId;
                                instockHistory.F_CargoPositionName = bodyinfo.F_OutCargoPositionName;
                                instockHistory.F_SpecifModel = bodyinfo.F_SpecifModel;
                                instockHistory.F_Unit = bodyinfo.F_Unit;
                                instockHistory.F_OperationNum = 0 - bodyinfo.F_DbNum;
                                instockHistory.F_CreatorTime = DateTime.Now;
                                Sys_StockHistory.Instance.Insert(instockHistory, dbtran.Transaction);

                                //更新出库状态
                                hash = new Hashtable();
                                hash.Add("F_FreeTerm1", 1);
                                Allocation_Body.Instance.Update(bodyinfo.F_Id, hash, dbtran.Transaction);
                            }
                            else
                            {
                                return bodyinfo.F_OutWareName + "仓库库存不足，当前产品" + bodyinfo.F_GoodsName + "库存为" + stock.F_Number;
                            }

                            Sys_StockInfo instock = StockList.Find(u => u.F_WarehouseId == bodyinfo.F_InWareId && u.F_CargoPositionId == bodyinfo.F_InCargoPositionId && u.F_GoodsId == bodyinfo.F_GoodsId);
                            //如果不存在
                            if (instock == null)
                            {
                                //新添加一条数据
                                Sys_StockInfo entity = new Sys_StockInfo();
                                entity.F_Id = Guid.NewGuid().ToString();
                                entity.F_GoodsId = bodyinfo.F_GoodsId;
                                entity.F_GoodsName = bodyinfo.F_GoodsName;
                                entity.F_WarehouseId = bodyinfo.F_InWareId;
                                entity.F_WarehouseName = bodyinfo.F_InWareName;
                                entity.F_CargoPositionId = bodyinfo.F_InCargoPositionId;
                                entity.F_CargoPositionName = bodyinfo.F_InCargoPositionName;
                                entity.F_Batch = bodyinfo.F_SerialNum;
                                entity.F_Unit = bodyinfo.F_Unit;
                                entity.F_Number = bodyinfo.F_DbNum;
                                Sys_Stock.Instance.Insert(entity, dbtran.Transaction);

                                //添加履历
                                Sys_AllocationHistoryInfo Dbinfo = new Sys_AllocationHistoryInfo();
                                Dbinfo.F_Id = Guid.NewGuid().ToString();
                                Dbinfo.F_GoodsId = bodyinfo.F_GoodsId;
                                Dbinfo.F_InWareName = bodyinfo.F_InWareName;
                                Dbinfo.F_EnCode = bodyinfo.F_OrderNo;
                                Dbinfo.F_Batch = bodyinfo.F_SerialNum;
                                Dbinfo.F_GoodsName = bodyinfo.F_GoodsName;
                                Dbinfo.F_Verify = user;
                                Dbinfo.F_Maker = hinfo.F_Maker;
                                Dbinfo.F_VeriDate = DateTime.Now;
                                Dbinfo.F_OutWareId = bodyinfo.F_OutWareId;
                                Dbinfo.F_InWareId = bodyinfo.F_InWareId;
                                Dbinfo.F_OutWareName = bodyinfo.F_OutWareName;
                                Dbinfo.F_InCargoPositionId = bodyinfo.F_InCargoPositionId;
                                Dbinfo.F_InCargoPositionName = bodyinfo.F_InCargoPositionName;
                                Dbinfo.F_OutCargoPositionId = bodyinfo.F_OutCargoPositionId;
                                Dbinfo.F_OutCargoPositionName = bodyinfo.F_OutCargoPositionName;
                                Dbinfo.F_Unit = bodyinfo.F_Unit;
                                Dbinfo.F_DBNum = bodyinfo.F_DbNum;
                                Dbinfo.F_SpecifModel = bodyinfo.F_SpecifModel;
                                Dbinfo.F_CreatorTime = DateTime.Now;
                                Sys_AllocationHistory.Instance.Insert(Dbinfo, dbtran.Transaction);

                                //添加库存履历
                                Sys_StockHistoryInfo instockHistory = new Sys_StockHistoryInfo();
                                instockHistory.F_Id = Guid.NewGuid().ToString();
                                instockHistory.F_WarehouseId = bodyinfo.F_OutWareId;
                                instockHistory.F_EnCode = bodyinfo.F_OrderNo;
                                instockHistory.F_Batch = bodyinfo.F_SerialNum;
                                instockHistory.F_Verify = user;
                                instockHistory.F_Maker = hinfo.F_Maker;
                                instockHistory.F_VeriDate = DateTime.Now;
                                instockHistory.F_WarehouseName = bodyinfo.F_InWareName;
                                instockHistory.F_BllCategory = "调入";
                                instockHistory.F_GoodsName = bodyinfo.F_GoodsName;
                                instockHistory.F_GoodsId = bodyinfo.F_GoodsId;
                                instockHistory.F_CargoPositionId = bodyinfo.F_InCargoPositionName;
                                instockHistory.F_CargoPositionName = bodyinfo.F_InCargoPositionId;
                                instockHistory.F_SpecifModel = bodyinfo.F_SpecifModel;
                                instockHistory.F_Unit = bodyinfo.F_Unit;
                                instockHistory.F_OperationNum = bodyinfo.F_DbNum;
                                instockHistory.F_CreatorTime = DateTime.Now;
                                Sys_StockHistory.Instance.Insert(instockHistory, dbtran.Transaction);

                                //更新入库状态
                                hash = new Hashtable();
                                hash.Add("F_AlreadyOperatedNum", 1);
                                Allocation_Body.Instance.Update(bodyinfo.F_Id, hash, dbtran.Transaction);

                                
                            }
                            //如果存在
                            else
                            {
                                //增加库存
                                hash = new Hashtable();
                                hash.Add("F_Number", instock.F_Number + bodyinfo.F_DbNum);
                                Sys_Stock.Instance.Update(instock.F_Id, hash, dbtran.Transaction);

                                //更新入库状态
                                hash = new Hashtable();
                                hash.Add("F_AlreadyOperatedNum", 1);
                                Allocation_Body.Instance.Update(bodyinfo.F_Id, hash, dbtran.Transaction);

                                //添加履历
                                Sys_AllocationHistoryInfo Dbinfo = new Sys_AllocationHistoryInfo();
                                Dbinfo.F_Id = Guid.NewGuid().ToString();
                                Dbinfo.F_GoodsId = bodyinfo.F_GoodsId;
                                Dbinfo.F_Verify = user;
                                Dbinfo.F_Maker = hinfo.F_Maker;
                                Dbinfo.F_VeriDate = DateTime.Now;
                                Dbinfo.F_EnCode = bodyinfo.F_OrderNo;
                                Dbinfo.F_Batch = bodyinfo.F_SerialNum;
                                Dbinfo.F_InWareName = bodyinfo.F_InWareName;
                                Dbinfo.F_GoodsName = bodyinfo.F_GoodsName;
                                Dbinfo.F_OutWareId = bodyinfo.F_OutWareId;
                                Dbinfo.F_InWareId = bodyinfo.F_InWareId;
                                Dbinfo.F_OutWareName = bodyinfo.F_OutWareName;
                                Dbinfo.F_InCargoPositionId = bodyinfo.F_InCargoPositionId;
                                Dbinfo.F_InCargoPositionName = bodyinfo.F_InCargoPositionName;
                                Dbinfo.F_OutCargoPositionId = bodyinfo.F_OutCargoPositionId;
                                Dbinfo.F_OutCargoPositionName = bodyinfo.F_OutCargoPositionName;
                                Dbinfo.F_Unit = bodyinfo.F_Unit;
                                Dbinfo.F_DBNum = bodyinfo.F_DbNum;
                                Dbinfo.F_SpecifModel = bodyinfo.F_SpecifModel;
                                Dbinfo.F_CreatorTime = DateTime.Now;
                                Sys_AllocationHistory.Instance.Insert(Dbinfo, dbtran.Transaction);


                                //添加库存履历
                                Sys_StockHistoryInfo instockHistory = new Sys_StockHistoryInfo();
                                instockHistory.F_Id = Guid.NewGuid().ToString();
                                instockHistory.F_WarehouseId = bodyinfo.F_InWareId;
                                instockHistory.F_WarehouseName = bodyinfo.F_InWareName;
                                instockHistory.F_EnCode = bodyinfo.F_OrderNo;
                                instockHistory.F_Batch = bodyinfo.F_SerialNum;
                                instockHistory.F_Verify = user;
                                instockHistory.F_Maker = hinfo.F_Maker;
                                instockHistory.F_VeriDate = DateTime.Now;
                                instockHistory.F_BllCategory = "调入";
                                instockHistory.F_GoodsName = bodyinfo.F_GoodsName;
                                instockHistory.F_GoodsId = bodyinfo.F_GoodsId;
                                instockHistory.F_CargoPositionId = bodyinfo.F_InCargoPositionId;
                                instockHistory.F_CargoPositionName = bodyinfo.F_InCargoPositionName;
                                instockHistory.F_SpecifModel = bodyinfo.F_SpecifModel;
                                instockHistory.F_Unit = bodyinfo.F_Unit;
                                instockHistory.F_OperationNum = bodyinfo.F_DbNum;
                                instockHistory.F_CreatorTime = DateTime.Now;
                                Sys_StockHistory.Instance.Insert(instockHistory, dbtran.Transaction);
                            }
                        }

                        //更新审核状态
                        string sql = string.Format("update Allocation_Head set F_Status=1,F_AccountDate='{0}',F_Verify='{1}' where F_Id='{2}'", date, user, Id);
                        hash = new Hashtable();
                        base.ExecuteNonQuery(sql, hash, dbtran.Transaction);

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
            string state = "select F_AlreadyOperatedNum from Allocation_Body where F_HId='" + Id + "'";
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
                    return "该单据已有产品出库，不能执行反审核操作";
                }
            }

            string sql = "select F_Status from Allocation_Head where F_Id='" + Id + "'";
            if (this.GetDataTableBySql(sql).Rows[0][0].ToString() == "1")
            {
                string updatesql = string.Format("update Allocation_Head set F_Status=0,F_AccountDate='{0}',F_Verify='{1}' where F_Id='{2}'", date, user, Id);
                Hashtable hash = new Hashtable();
                base.ExecuteNonQuery(updatesql, hash);
                return "反审核成功";
            }
            else
            {
                return "该单据未被审核";
            }

        }
    }
}
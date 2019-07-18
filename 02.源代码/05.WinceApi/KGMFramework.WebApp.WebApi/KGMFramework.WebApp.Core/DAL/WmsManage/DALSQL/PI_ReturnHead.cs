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
    /// 入库主表
    /// </summary>
    public class PI_ReturnHead : BaseDALSQL<PI_ReturnHeadInfo>, IPI_ReturnHead
    {
        #region 对象实例及构造函数

        public static PI_ReturnHead Instance
        {
            get
            {
                return new PI_ReturnHead();
            }
        }
        public PI_ReturnHead()
            : base("PI_ReturnHead", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override PI_ReturnHeadInfo DataReaderToEntity(IDataReader dataReader)
        {
            PI_ReturnHeadInfo info = new PI_ReturnHeadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_DocumentNum = reader.GetString("F_DocumentNum");
            info.F_Vendor = reader.GetString("F_Vendor");
            info.F_VendorName = reader.GetString("F_VendorName");
            info.F_Status = reader.GetInt32("F_Status");
            info.F_InStockCode = reader.GetString("F_InStockCode");
            info.F_Operator = reader.GetString("F_Operator");
            info.F_Date = reader.GetDateTime("F_Date");
            info.F_VeriDate = reader.GetDateTime("F_VeriDate");
            info.F_Address = reader.GetString("F_Address");
            info.F_Contacts = reader.GetString("F_Contacts");
            info.F_TelePhone = reader.GetString("F_TelePhone"); 
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
        protected override Hashtable GetHashByEntity(PI_ReturnHeadInfo obj)
        {
            PI_ReturnHeadInfo info = obj as PI_ReturnHeadInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_DocumentNum", info.F_DocumentNum);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_Vendor", info.F_Vendor);
            hash.Add("F_VendorName", info.F_VendorName);
            hash.Add("F_InStockCode", info.F_InStockCode);
            hash.Add("F_Operator", info.F_Operator);
            hash.Add("F_Status", info.F_Status);
            hash.Add("F_State", info.F_State);
            hash.Add("F_Date", info.F_Date);
            hash.Add("F_Contacts", info.F_Contacts);
            hash.Add("F_TelePhone", info.F_TelePhone);
            hash.Add("F_Address", info.F_Address);
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

        public PI_ReturnHeadInfo Save(PI_ReturnHeadInfo info, List<PI_ReturnBodyInfo> dInfo)
        {
            using (DbTransactionScope<PI_ReturnHeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(info.F_EnCode))
                    {
                        string orderNo = "INRE" + DateTime.Now.ToString("yyyyMMdd");
                        Hashtable hash = new Hashtable();
                        hash.Add("Prefix", orderNo);
                        DataTable dt = base.StorePorcToDataTable("SYS_CREATESN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString().PadLeft(4, '0');
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
                    PI_ReturnHead.Instance.InsertUpdate(info, info.F_Id, dbtran.Transaction);
                    //删除子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", info.F_Id, SqlOperator.Equal);
                    PI_ReturnBody.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //循环添加子表
                    foreach (PI_ReturnBodyInfo item in dInfo)
                    {
                        item.F_CreatorTime = DateTime.Now;
                        item.F_CreatorUserId = info.F_CreatorUserId;
                        item.F_Id = Guid.NewGuid().ToString();
                        item.F_HId = info.F_Id;
                        item.F_OrderNo = info.F_EnCode;
                        //PI_ReturnBody.Instance.Insert(item, dbtran.Transaction);
                    }
                    PI_ReturnBody.Instance.InsertRange(dInfo, dbtran.Transaction);

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
            using (DbTransactionScope<PI_ReturnHeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    PI_ReturnHead.Instance.Delete(keyValue, dbtran.Transaction);
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", keyValue, SqlOperator.Equal);
                    PI_ReturnBody.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
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
            using (DbTransactionScope<PI_ReturnHeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //更新登记单主表审核状态，审核人，审核时间
                    PI_ReturnHeadInfo head = PI_ReturnHead.Instance.FindByID(F_Id, dbtran.Transaction);
                    head.F_Status = 1;
                    head.F_Verify = userName;
                    head.F_VeriDate = DateTime.Now;
                    PI_ReturnHead.Instance.Update(head, F_Id, dbtran.Transaction);
                    //找到登记单子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", F_Id, SqlOperator.Equal);
                    List<PI_ReturnBodyInfo> list = PI_ReturnBody.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //资产编号
                    foreach (PI_ReturnBodyInfo item in list)
                    {
                        for (int i = 0; i < item.F_InStockNum; i++)
                        {
                            PI_ReturnBodyInfo entity = new PI_ReturnBodyInfo();
                            entity.F_Id = Guid.NewGuid().ToString();
                            entity.F_EnCode = item.F_EnCode;
                            entity.F_FullName = item.F_FullName;
                            entity.F_OrderNo = item.F_OrderNo;
                            entity.F_Unit = item.F_Unit;
                            entity.F_Description = item.F_Description;
                            PI_ReturnBody.Instance.Insert(entity, dbtran.Transaction);
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
            string sql = string.Format(@"SELECT H.*,B.*,O.F_FullName OrganizeName,S.F_FullName VendorName
                FROM PI_ReturnHead H
                INNER JOIN PI_ReturnBody B on H.F_Id=b.F_HId
                INNER JOIN Sys_Organize O on H.F_Orgnization=O.F_Id
				INNER JOIN MST_SupplierInfo S on H.F_Vendor=S.F_Id
                WHERE H.F_Id=@F_Id");
            Hashtable hash = new Hashtable();
            hash.Add("F_Id", sourceData);
            return base.ExecuteTable(sql, hash);
        }

        public DataTable GetAssetPicture(string id)
        {
            string sql = (@"SELECT P.F_EnCode,P.F_PhotoUrl FROM PI_ReturnBody B
                            INNER JOIN PI_ReturnBody I on B.F_Id=I.F_OrderDetailedId
                            INNER JOIN Asset_InfoPhoto P on I.F_EnCode=P.F_EnCode
                            WHERE B.F_Id=@id ORDER BY F_EnCode");
            Hashtable hash = new Hashtable();
            hash.Add("id", id);
            return base.ExecuteTable(sql, hash);
        }

        public string createCode(string F_Id)
        {
            using (DbTransactionScope<PI_ReturnHeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_OrderDetailedId", F_Id, SqlOperator.Equal);
                    List<PI_ReturnBodyInfo> list = PI_ReturnBody.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    if (!string.IsNullOrEmpty(list[0].F_EnCode))
                    {
                        return "生成失败，该资产已经生成条码！";
                    }
                    string orderNo = "In" + DateTime.Now.ToString("yyyyMMdd");
                    Hashtable hash = new Hashtable();
                    hash.Add("Prefix", orderNo);
                    foreach (PI_ReturnBodyInfo item in list)
                    {
                        DataTable dt = base.StorePorcToDataTable("SYS_CREATESN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString().PadLeft(6, '0');
                        item.F_EnCode = orderNo + SN;
                        PI_ReturnBody.Instance.Update(item, dbtran.Transaction);
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
            List<PI_ReturnBodyInfo> list = PI_ReturnBody.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            foreach (var item in list)
            {
                SearchCondition condition2 = new SearchCondition();
                condition2.AddCondition("F_OrderDetailedId", item.F_Id, SqlOperator.Equal);
                List<PI_ReturnBodyInfo> list2 = PI_ReturnBody.Instance.Find(condition2.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
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
        public string Audit(string date, string user, string Id, List<PI_ReturnBodyInfo> stockinfo)
        {
            string SqlAuditSel = "select F_Status from PI_ReturnHead where F_Id='" + Id + "'";
            string AuditState = this.GetDataTableBySql(SqlAuditSel).Rows[0][0].ToString();
            if (AuditState == "1")
            {
                return "单据已被审核";
            }
            else
            {
                using (DbTransactionScope<PI_ReturnHeadInfo> dbtran = base.CreateTransactionScope())
                {
                    try
                    {
                        Hashtable hash = new Hashtable();
                        //查询所有库存信息
                        List<Sys_StockInfo> StockList = BLLFactory<Sys_Stock>.Instance.GetAll();
                        PI_ReturnHeadInfo hinfo = BLLFactory<PI_ReturnHead>.Instance.FindByID(Id);

                        SearchCondition condition = new SearchCondition();
                        //condition.AddCondition("F_EnCode", hinfo.F_InStockCode, SqlOperator.Equal);
                        //PI_HeadInfo pih = BLLFactory<PI_Head>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty))[0];


                        for (int i = 0; i < stockinfo.Count; i++)
                        {
                            //查询子表信息
                            condition = new SearchCondition();
                            condition.AddCondition("F_Id", stockinfo[i].F_Id, SqlOperator.Equal);
                            PI_ReturnBodyInfo bodyinfo = BLLFactory<PI_ReturnBody>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty))[0];

                            if (bodyinfo.F_WarehouseId == "" || bodyinfo.F_CargoPositionId == "")
                            {
                                return "该单据中仓库或仓位为空，审核未通过";
                            }

                            Sys_StockInfo stock = StockList.Find(u => u.F_WarehouseId == bodyinfo.F_WarehouseId && u.F_CargoPositionId == bodyinfo.F_CargoPositionId && u.F_GoodsId == bodyinfo.F_GoodsId&&u.F_Batch==bodyinfo.F_SerialNum);

                            //查询库存表是否存在该仓库中的产品

                            if (stock == null)
                            {
                                dbtran.RollBack();
                                return "该仓库无此产品";
                            }

                            if (stock.F_Number - bodyinfo.F_ReturnNum < 0)
                            {
                                return "产品数量发生了变化，请重新选择审核退回";
                            }

                            //判断库存数量是否足够
                            if (stock.F_Number >= bodyinfo.F_ReturnNum)
                            {
                                //扣减库存
                                hash = new Hashtable();
                                hash.Add("F_Number", stock.F_Number - bodyinfo.F_ReturnNum);
                                Sys_Stock.Instance.Update(stock.F_Id, hash, dbtran.Transaction);

                                //标记为已退货
                                //hash = new Hashtable();
                                //hash.Add("F_DocumentNum", 1);
                                //PI_Head.Instance.Update(pih.F_Id, hash, dbtran.Transaction);

                                //添加履历
                                Sys_InReturnHistoryInfo inRec = new Sys_InReturnHistoryInfo();
                                inRec.F_Id = Guid.NewGuid().ToString();
                                inRec.F_EnCode = bodyinfo.F_OrderNo;
                                inRec.F_Batch = bodyinfo.F_SerialNum;
                                inRec.F_Vendor = bodyinfo.F_Vendor;
                                inRec.F_VendorName = bodyinfo.F_VendorName;
                                inRec.F_Verify = user;
                                inRec.F_Maker = hinfo.F_Maker;
                                inRec.F_Contacts = hinfo.F_Contacts;
                                inRec.F_TelePhone = hinfo.F_TelePhone;
                                inRec.F_Address = hinfo.F_Address;
                                inRec.F_VeriDate = DateTime.Now;
                                inRec.F_WarehouseId = bodyinfo.F_WarehouseId;
                                inRec.F_WarehouseName = bodyinfo.F_WarehouseName;
                                inRec.F_GoodsName = bodyinfo.F_GoodsName;
                                inRec.F_GoodsId = bodyinfo.F_GoodsId;
                                inRec.F_CargoPositionId = bodyinfo.F_CargoPositionId;
                                inRec.F_CargoPositionName = bodyinfo.F_CargoPositionName;
                                inRec.F_SpecifModel = bodyinfo.F_SpecifModel;
                                inRec.F_SellingPrice = bodyinfo.F_SellingPrice;
                                inRec.F_PurchasePrice = bodyinfo.F_PurchasePrice;
                                inRec.F_Unit = bodyinfo.F_Unit;
                                inRec.F_InStockNum = bodyinfo.F_InStockNum;
                                inRec.F_ReturnNum = bodyinfo.F_ReturnNum;
                                inRec.F_CreatorTime = DateTime.Now;
                                Sys_InReturnHistory.Instance.Insert(inRec, dbtran.Transaction);


                                //添加库存履历
                                Sys_StockHistoryInfo instockHistory = new Sys_StockHistoryInfo();
                                instockHistory.F_Id = Guid.NewGuid().ToString();
                                instockHistory.F_EnCode = bodyinfo.F_OrderNo;
                                instockHistory.F_Batch = bodyinfo.F_SerialNum;
                                instockHistory.F_Vendor = hinfo.F_Vendor;
                                instockHistory.F_VendorName = bodyinfo.F_VendorName;
                                instockHistory.F_Verify =user;
                                instockHistory.F_Maker = hinfo.F_Maker;
                                instockHistory.F_Contacts = hinfo.F_Contacts;
                                instockHistory.F_TelePhone = hinfo.F_TelePhone;
                                instockHistory.F_Address = hinfo.F_Address;
                                instockHistory.F_VeriDate = DateTime.Now;
                                instockHistory.F_WarehouseId = bodyinfo.F_WarehouseId;
                                instockHistory.F_WarehouseName = bodyinfo.F_WarehouseName;
                                instockHistory.F_BllCategory = "入库退货";
                                instockHistory.F_GoodsName = bodyinfo.F_GoodsName;
                                instockHistory.F_GoodsId = bodyinfo.F_GoodsId;
                                instockHistory.F_CargoPositionId = bodyinfo.F_CargoPositionId;
                                instockHistory.F_CargoPositionName = bodyinfo.F_CargoPositionName;
                                instockHistory.F_SpecifModel = bodyinfo.F_SpecifModel;
                                instockHistory.F_Unit = bodyinfo.F_Unit;
                                instockHistory.F_OperationNum = 0 - bodyinfo.F_ReturnNum;
                                instockHistory.F_CreatorTime = DateTime.Now;
                                Sys_StockHistory.Instance.Insert(instockHistory, dbtran.Transaction);


                                //更新主表入库状态
                                hash = new Hashtable();
                                hash.Add("F_State", 1);
                                PI_ReturnHead.Instance.Update(bodyinfo.F_HId, hash, dbtran.Transaction);
                            }
                            else
                            {
                                return bodyinfo.F_WarehouseName + "仓库库存不足，产品：" + bodyinfo.F_GoodsName + "库存为：" + stock.F_Number;
                            }

                            //更新审核状态
                            string sql = string.Format("update PI_ReturnHead set F_Status=1,F_VeriDate='{0}',F_Verify='{1}' where F_Id='{2}'", date, user, Id);
                            hash = new Hashtable();
                            base.ExecuteNonQuery(sql, hash, dbtran.Transaction);

                            
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
            string state = "select F_AlreadyOperatedNum from PI_ReturnBody where F_HId='" + Id + "'";
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

            string sql = "select F_Status from PI_ReturnHead where F_Id='" + Id + "'";
            if (this.GetDataTableBySql(sql).Rows[0][0].ToString() == "1")
            {
                string updatesql = string.Format("update PI_ReturnHead set F_Status=0,F_VeriDate='{0}',F_Verify='{1}' where F_Id='{2}'", date, user, Id);
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
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
    public class SO_ReturnedStockHead : BaseDALSQL<SO_ReturnedStockHeadInfo>, ISO_ReturnedStockHead
    {
        #region 对象实例及构造函数

        public static SO_ReturnedStockHead Instance
        {
            get
            {
                return new SO_ReturnedStockHead();
            }
        }
        public SO_ReturnedStockHead()
            : base("SO_ReturnedStockHead", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override SO_ReturnedStockHeadInfo DataReaderToEntity(IDataReader dataReader)
        {
            SO_ReturnedStockHeadInfo info = new SO_ReturnedStockHeadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.F_AuditingUser = reader.GetString("F_AuditingUser");
            info.F_OutBatch = reader.GetString("F_OutBatch");
            info.F_Description = reader.GetString("F_Description");
            info.F_VeriDate = reader.GetString("F_VeriDate");
            info.F_CustomerId = reader.GetString("F_CustomerId");
            info.F_Address = reader.GetString("F_Address");
            info.F_Operator = reader.GetString("F_Operator");
            info.F_Status = reader.GetString("F_Status");
            info.F_Date = reader.GetDateTime("F_Date");
            info.F_TelePhone = reader.GetString("F_TelePhone");
            info.F_Contacts = reader.GetString("F_Contacts");
            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_OutSMark = reader.GetString("F_OutSMark");
            info.F_CustomerName = reader.GetString("F_CustomerName");
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
        protected override Hashtable GetHashByEntity(SO_ReturnedStockHeadInfo obj)
        {

            SO_ReturnedStockHeadInfo info = obj as SO_ReturnedStockHeadInfo;
            Hashtable hash = new Hashtable();
            hash.Add("F_AuditingUser", info.F_AuditingUser);
            hash.Add("F_OutBatch", info.F_OutBatch);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_Status", info.F_Status);
            hash.Add("F_Operator", info.F_Operator);
            hash.Add("F_VeriDate", info.F_VeriDate);
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_Date", info.F_Date);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_Contacts", info.F_Contacts);
            hash.Add("F_CustomerId", info.F_CustomerId);
            hash.Add("F_OutSMark", info.F_OutSMark);
            hash.Add("F_CustomerName", info.F_CustomerName);
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
            hash.Add("F_TelePhone", info.F_TelePhone);
            hash.Add("F_Address", info.F_Address);

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
        /// 退货单保存
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public SO_ReturnedStockHeadInfo Save(SO_ReturnedStockHeadInfo info, List<SO_ReturnedStockBodyInfo> dInfo)
        {
            using (DbTransactionScope<SO_ReturnedStockHeadInfo> dbtran = base.CreateTransactionScope())
            {

                try
                {
                    if (string.IsNullOrEmpty(info.F_EnCode))
                    {
                        string orderNo = "RE" + DateTime.Now.ToString("yyyyMMdd");
                        Hashtable hash = new Hashtable();
                        hash.Add("Prefix", orderNo);
                        DataTable dt = base.StorePorcToDataTable("SYS_CREATESN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString().PadLeft(6, '0');
                        info.F_EnCode = orderNo + SN;
                        info.F_Id = Guid.NewGuid().ToString();
                    }
                    else
                    {
                        //判断当前单据是否已经审核
                        var head = this.FindByID(info.F_Id, dbtran.Transaction);
                        if (head != null && head.F_Status == "True")
                        {
                            throw new ApplicationException("单据已经审核!");
                        }
                    }


                    info.F_Status = "0";
                    //添加主表
                    info.F_Date = info.F_Date;
                  
                    SO_ReturnedStockHead.Instance.InsertUpdate(info, info.F_Id, dbtran.Transaction);
                    //删除子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", info.F_Id, SqlOperator.Equal);
                    SO_ReturnedStockBody.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                     //循环添加子表
                    foreach (SO_ReturnedStockBodyInfo item in dInfo)
                    {
                        item.F_CreatorTime = DateTime.Now;
                        item.F_CreatorUserId = info.F_CreatorUserId;
                        item.F_Id = Guid.NewGuid().ToString();
                        item.F_HId = info.F_Id;
                      

                    }
                 
                    SO_ReturnedStockBody.Instance.InsertRange(dInfo, dbtran.Transaction);
                    dbtran.Commit();
                    return info;
                }
                catch (Exception)
                {
                    dbtran.RollBack();
                    return null;
                    throw;
                }

            }

        }

        public string VerifyReturnGoods(string Id, string user)
        {
            using (DbTransactionScope<SO_ReturnedStockHeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    DateTime time = DateTime.Now;
                    //查询到退货子表单据
                    SO_ReturnedStockHeadInfo HeadInfo = BLLFactory<SO_ReturnedStockHead>.Instance.FindByID(Id);
                    SearchCondition search = new SearchCondition();
                    search.AddCondition("F_Hid", Id, SqlOperator.Equal);
                    List<SO_ReturnedStockBodyInfo> ReBodyinfo = BLLFactory<SO_ReturnedStockBody>.Instance.Find(search.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty).Replace("Where (1=1)", " ( 1 = 1 ) "));
                    //查询出所有产品的库存
                    List<Sys_StockInfo> StockList = BLLFactory<Sys_Stock>.Instance.GetAll();
                    //添加库存记录
                    List<Sys_StockHistoryInfo> HisList = new List<Sys_StockHistoryInfo>();
                    //添加出库记录
                    List<Sys_OutReturnInfo> list = new List<Sys_OutReturnInfo>();
                    //更新 产品库存
                    foreach (SO_ReturnedStockBodyInfo item in ReBodyinfo)
                    {
                        Sys_StockInfo StockInfo = StockList.Find(u => u.F_WarehouseId == item.F_WarehouseId && u.F_CargoPositionId == item.F_CargoPositionId && u.F_GoodsId == item.F_GoodsId);
                        Hashtable hash = new Hashtable();
                        hash.Add("F_Number", StockInfo.F_Number + item.F_ReturnNum);
                        Sys_Stock.Instance.Update(StockInfo.F_Id, hash, dbtran.Transaction);


                        Sys_OutReturnInfo outRec = new Sys_OutReturnInfo();
                        outRec.F_Id = Guid.NewGuid().ToString();
                        outRec.F_EnCode = HeadInfo.F_EnCode;
                        outRec.F_Batch = item.F_EnCode;
                        outRec.F_Vendor = HeadInfo.F_CustomerId;
                        outRec.F_VendorName = HeadInfo.F_CustomerName;
                        outRec.F_Verify = user;
                        outRec.F_Maker = HeadInfo.F_Operator;
                        outRec.F_Contacts = HeadInfo.F_Contacts;
                        outRec.F_TelePhone = HeadInfo.F_TelePhone;
                        outRec.F_Address = HeadInfo.F_Address;
                        outRec.F_VeriDate = time;
                        outRec.F_WarehouseId = item.F_WarehouseId;
                        outRec.F_WarehouseName = item.F_WarehouseName;
                        outRec.F_GoodsName = item.F_GoodsName;
                        outRec.F_GoodsId = item.F_GoodsId;
                        outRec.F_CargoPositionId = item.F_CargoPositionId;
                        outRec.F_CargoPositionName = item.F_CargoPositionName;
                        outRec.F_SpecifModel = item.F_SpecifModel;
                        outRec.F_SellingPrice = item.F_SellingPrice.ToString();
                        outRec.F_PurchasePrice = item.F_PurchasePrice.ToString();
                        outRec.F_Unit = item.F_Unit;
                        outRec.F_OutStockNum = item.F_OutStockNum;
                        outRec.F_ReturnNum = item.F_ReturnNum;
                        outRec.F_CreatorTime = time;
                        list.Add(outRec);


                        //产品库存变更信息
                        Sys_StockHistoryInfo HistoryInfo = new Sys_StockHistoryInfo();
                        HistoryInfo.F_CargoPositionId = item.F_CargoPositionId;
                        HistoryInfo.F_CargoPositionName = item.F_CargoPositionName;
                        HistoryInfo.F_GoodsName = item.F_GoodsName;
                        HistoryInfo.F_Batch = item.F_Batch;
                        HistoryInfo.F_WarehouseId = item.F_WarehouseId;
                        HistoryInfo.F_WarehouseName = item.F_WarehouseName;
                        HistoryInfo.F_BllCategory = "出库退回";
                        HistoryInfo.F_OperationNum = item.F_ReturnNum;
                        HistoryInfo.F_VendorName = HeadInfo.F_CustomerName;
                        HistoryInfo.F_Contacts = HeadInfo.F_Contacts;
                        HistoryInfo.F_TelePhone = HeadInfo.F_TelePhone;
                        HistoryInfo.F_Address = HeadInfo.F_Address;
                        HistoryInfo.F_Maker = HeadInfo.F_Operator;
                        HistoryInfo.F_Verify = HeadInfo.F_AuditingUser;
                        HistoryInfo.F_VeriDate = time;
                        HistoryInfo.F_Unit = item.F_Unit;
                        HistoryInfo.F_CreatorTime = time;
                        HistoryInfo.F_Description = HeadInfo.F_Description;
                        HistoryInfo.F_EnCode = HeadInfo.F_EnCode;
                        HisList.Add(HistoryInfo);

                    }
                    Sys_OutReturn.Instance.InsertRange(list, dbtran.Transaction);
                    Sys_StockHistory.Instance.InsertRange(HisList, dbtran.Transaction);
                    //更该审核标识
                    Hashtable has = new Hashtable();
                    has.Add("F_AuditingUser", user);
                    has.Add("F_VeriDate", time);
                    has.Add("F_Status", 1);
                    SO_ReturnedStockHead.Instance.Update(Id, has, dbtran.Transaction);
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
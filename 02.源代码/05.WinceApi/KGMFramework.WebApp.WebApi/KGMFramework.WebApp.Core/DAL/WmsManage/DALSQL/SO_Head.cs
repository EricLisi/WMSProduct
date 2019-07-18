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
    /// 货位表
    /// </summary>
    public class SO_Head : BaseDALSQL<SO_HeadInfo>, ISO_Head
    {
        #region 对象实例及构造函数

        public static SO_Head Instance
        {
            get
            {
                return new SO_Head();
            }
        }
        public SO_Head()
            : base("SO_Head", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override SO_HeadInfo DataReaderToEntity(IDataReader dataReader)
        {
            SO_HeadInfo info = new SO_HeadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.F_AuditingUser = reader.GetString("F_AuditingUser");
            info.F_Description = reader.GetString("F_Description");
            info.F_VeriDate = reader.GetDateTime("F_VeriDate");
            info.F_CustomerId = reader.GetString("F_CustomerId");
            info.F_Address = reader.GetString("F_Address");
            info.F_Operator = reader.GetString("F_Operator");
            info.F_Status = reader.GetString("F_Status");
            info.F_Date = reader.GetDateTime("F_Date");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
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
        protected override Hashtable GetHashByEntity(SO_HeadInfo obj)
        {

            SO_HeadInfo info = obj as SO_HeadInfo;
            Hashtable hash = new Hashtable();
            hash.Add("F_AuditingUser", info.F_AuditingUser);
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
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
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






        ///// <summary>
        /////审核单据 
        ///// </summary>

        ///// <param name="Id">审核单据</param>
        ///// <param name="user">审核人</param>
        //public string Audit(string Id, string user)
        //{

        //    using (DbTransactionScope<SO_HeadInfo> dbtran = base.CreateTransactionScope())
        //    {
        //        DateTime time = DateTime.Now;
        //        try
        //        {
        //            SO_HeadInfo info = BLLFactory<SO_Head>.Instance.FindByID(Id);
        //            if (info.F_Status == "True") return "单据已审核出库";
        //            //根据单据找到需要出库的产品
        //            SearchCondition search = new SearchCondition();
        //            search.AddCondition("F_Hid", Id, SqlOperator.Equal);
        //            List<SO_BodyInfo> BodyInfo = BLLFactory<SO_Body>.Instance.Find(search.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty).Replace("Where (1=1)", " ( 1 = 1 ) "));
        //           //获取单据
        //            SO_HeadInfo HeadInfo = BLLFactory<SO_Head>.Instance.FindByID(Id);
        //            //循环出库，添加记录
        //            List<Sys_StockInfo> list = BLLFactory<Sys_Stock>.Instance.GetAll();
        //            List<Sys_OutRecordsInfo> OutList = new List<Sys_OutRecordsInfo>();
        //            List<Sys_StockHistoryInfo> StockHisList = new List<Sys_StockHistoryInfo>();
        //            //客户Id
        //            string CustomerId = BLLFactory<SO_Head>.Instance.FindByID(Id).F_CustomerId;
        //            foreach (var item in BodyInfo)
        //            {
        //                Sys_StockInfo stockInfo = list.Find(u => u.F_CargoPositionId == item.F_CargoPositionId && u.F_WarehouseId == item.F_WarehouseId && u.F_GoodsId == item.F_GoodsId);

        //                if (stockInfo.F_Number - item.F_OutStockNum < 0)
        //                {
        //                    return "产品数量发生了变化，请重新选择审核出库";
        //                }

        //                Hashtable has = new Hashtable();
        //                has.Add("F_Number", stockInfo.F_Number - item.F_OutStockNum);
        //                Sys_Stock.Instance.Update(stockInfo.F_Id, has, dbtran.Transaction);
        //                //产品出库记录
        //                Sys_OutRecordsInfo outInfo = new Sys_OutRecordsInfo();
        //                outInfo.F_Batch = info.F_EnCode;                       
        //                outInfo.F_GoodsId = item.F_GoodsId;
        //                outInfo.F_GoodsName = item.F_GoodsName;
        //                outInfo.F_EnCode = item.F_EnCode;
        //                outInfo.F_OutStockNum =item.F_OutStockNum;
        //                outInfo.F_CargoPositionId = item.F_CargoPositionId;
        //                outInfo.F_CargoPositionName = item.F_CargoPositionName;
        //                outInfo.F_WarehouseId = item.F_WarehouseId;
        //                outIn[';'' arehouseName = item.F_WarehouseName;
        //                outInfo.F_CreatorTime = DateTime.Now;
        //                outInfo.F_CreatorUserId = item.F_CreatorUserId;
        //                outInfo.F_Description = item.F_Description;
        //                outInfo.F_CustomerId = CustomerId;
        //                outInfo.F_Unit = item.F_Unit;
        //                outInfo.F_Address = info.F_Address;
        //                outInfo.F_Contacts = info.F_Contacts;
       
        //                outInfo.F_Operator = info.F_Operator;
        //                outInfo.F_CustomerName = info.F_CustomerName;
        //                outInfo.F_TelePhone = info.F_TelePhone;
                        

        //                OutList.Add(outInfo);
        //                //添加库存信息
        //                Sys_StockHistoryInfo7 HistoryInfo = new Sys_StockHistoryInfo();
        //                HistoryInfo.F_CargoPositionId = item.F_CargoPositionId;
        //                HistoryInfo.F_CargoPositionName = item.F_CargoPositionName;
        //                HistoryInfo.F_WarehouseId = item.F_WarehouseId;
        //                HistoryInfo.F_WarehouseName = item.F_WarehouseName;
        //                HistoryInfo.F_EnCode= info.F_EnCode;
        //                HistoryInfo.F_Batch =item.F_Batch;
        //                HistoryInfo.F_BllCategory = "出库";
        //                HistoryInfo.F_OperationNum = 0 - item.F_OutStockNum;
        //                HistoryInfo.F_SpecifModel = item.F_SpecifModel;
        //                HistoryInfo.F_Vendor = user;
        //                HistoryInfo.F_GoodsId = item.F_GoodsId;
        //                HistoryInfo.F_GoodsName = item.F_GoodsName;
        //                HistoryInfo.F_Unit = item.F_Unit;
        //                HistoryInfo.F_VendorName = info.F_CustomerName;
        //                HistoryInfo.F_Contacts = info.F_Contacts;
        //                HistoryInfo.F_TelePhone = info.F_TelePhone;
        //                HistoryInfo.F_Maker = info.F_CreatorUserId;
        //                HistoryInfo.F_Verify = user;
        //                HistoryInfo.F_VeriDate = time;
                        
        //                StockHisList.Add(HistoryInfo);
        //            }
        //            //添加出库记录
        //            Sys_OutRecords.Instance.InsertRange(OutList, dbtran.Transaction);
        //            //添加库存记录
        //            Sys_StockHistory.Instance.InsertRange(StockHisList, dbtran.Transaction);
        //            //审核单据
        //            Hashtable hash = new Hashtable();
        //            hash.Add("F_Status", 1);
        //            hash.Add("F_AuditingUser", user);
        //            hash.Add("F_VeriDate", time);
        //            SO_Head.Instance.Update(Id, hash, dbtran.Transaction);

        //            dbtran.Commit();
        //            return "审核出库成功";
        //        }
        //        catch (Exception)
        //        {

        //            dbtran.RollBack();
        //            throw;
        //        }
        //    }
        //}


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public KgmApiResultEntity  Save(DataSet ds)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@PARM_SAVELIST_DP_HEAD",ds.Tables[0]);
            ht.Add("@PARM_SAVELIST_DP_BODY", ds.Tables[1]);
            ds = base.ExecuteDataSetByProc("SAVELIST_SO", ht);
            KgmApiResultEntity result = new KgmApiResultEntity
            {
                result = ds.Tables[0].Rows[0][0].ToString() == "0" ? true : false,
                message = ds.Tables[0].Rows[0][1].ToString()
            };
            return result;
          
            //using (DbTransactionScope<SO_HeadInfo> dbtran = base.CreateTransactionScope())
            //{
            //    try
            //    {
            //        if (string.IsNullOrEmpty(info.F_EnCode))
            //        {
            //            string orderNo = "OT" + DateTime.Now.ToString("yyyyMMdd");
            //            Hashtable hash = new Hashtable();
            //            hash.Add("Prefix", orderNo);
            //            DataTable dt = base.StorePorcToDataTable("SYS_CREATESN", hash, null, dbtran.Transaction);
            //            string SN = dt.Rows[0][0].ToString().PadLeft(6, '0');
            //            info.F_EnCode = orderNo + SN;
            //        }
            //        else
            //        {
            //            //判断当前单据是否已经审核
            //            var head = this.FindByID(info.F_Id, dbtran.Transaction);
            //            if (head != null && head.F_Status == "True")
            //            {
            //                throw new ApplicationException("单据已经审核!");
            //            }
            //        }
            //        //添加主表
            //        info.F_Date = info.F_Date;
            //        SO_Head.Instance.InsertUpdate(info, info.F_Id, dbtran.Transaction);
            //        //删除子表
            //        SearchCondition condition = new SearchCondition();
            //        condition.AddCondition("F_HId", info.F_Id, SqlOperator.Equal);
            //        SO_Body.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
            //        //循环添加子表
            //        foreach (SO_BodyInfo item in dInfo)
            //        {
            //            item.F_CreatorTime = DateTime.Now;
            //            item.F_CreatorUserId = info.F_CreatorUserId;
            //            item.F_Id = Guid.NewGuid().ToString();
            //            item.F_HId = info.F_Id;
            //            item.F_GoodsName = BLLFactory<Mst_Goods>.Instance.FindByID(item.F_GoodsId).F_FullName;
            //        }

            //        SO_Body.Instance.InsertRange(dInfo, dbtran.Transaction);
            //        dbtran.Commit();

            //        return info;
            //    }
            //    catch (Exception ex)
            //    {
            //        dbtran.RollBack();
            //        throw ex;
            //    }
            }
         
 

        ///// 获取审核状态
        ///// </summary>
        ///// <param name="KeyValue"></param>
        ///// <returns></returns>
        //public string StatusSate(string KeyValue)
        //{
        //    SO_HeadInfo soHeadInfo = BLLFactory<SO_Head>.Instance.FindByID(KeyValue);
        //    if (soHeadInfo.F_Status == "True")
        //    {
        //        return "该产品还没审核";
        //    }
        //    else
        //    {
        //        return "产品已审核";
        //    }

        //}
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public KgmApiResultEntity DeleteById(string Id)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@Id", Id);
            DataSet ds = base.ExecuteDataSetByProc("DELETE_SO", ht);
            KgmApiResultEntity result = new KgmApiResultEntity
            {
                result = ds.Tables[0].Rows[0][0].ToString() == "0" ? true : false,
                message = ds.Tables[0].Rows[0][1].ToString()
            };
            return result;
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="user"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public KgmApiResultEntity Verify(string Id, string user, int orderType)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@Id", Id);
            ht.Add("@@USERNAME", user);
            ht.Add("@ORDERTYPE", orderType);
            DataSet ds = base.ExecuteDataSetByProc("[VERIFYLIST_SO]", ht);
            KgmApiResultEntity result = new KgmApiResultEntity
            {
                result = ds.Tables[0].Rows[0][0].ToString() == "0" ? true : false,
                message = ds.Tables[0].Rows[0][1].ToString()
            };
            return result;
        }
    }
}
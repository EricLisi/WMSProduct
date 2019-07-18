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
    public class SO_StockMakeHead : BaseDALSQL<SO_StockMakeHeadInfo>, ISO_StockMakeHead
    {
        #region 对象实例及构造函数

        public static SO_StockMakeHead Instance
        {
            get
            {
                return new SO_StockMakeHead();
            }
        }
        public SO_StockMakeHead()
            : base("SO_StockMakeHead", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override SO_StockMakeHeadInfo DataReaderToEntity(IDataReader dataReader)
        {
            SO_StockMakeHeadInfo info = new SO_StockMakeHeadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");

            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
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
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_date = reader.GetString("F_date");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_Operator = reader.GetString("F_Operator");
            info.F_CargoPositionId = reader.GetString("F_CargoPositionId");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_Status = reader.GetInt32("F_Status");
            info.F_Description = reader.GetString("F_Description");
            info.F_State = reader.GetString("F_State");
            info.F_Verify = reader.GetString("F_Verify");
            info.F_VeriDate = reader.GetString("F_VeriDate");


            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(SO_StockMakeHeadInfo obj)
        {

            SO_StockMakeHeadInfo info = obj as SO_StockMakeHeadInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Operator", info.F_Operator);
            hash.Add("F_Verify", info.F_Verify);
            hash.Add("F_VeriDate", info.F_VeriDate);
            hash.Add("F_date", info.F_date);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_WarehouseId", info.F_WarehouseId);
            hash.Add("F_CargoPositionId", info.F_CargoPositionId);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
            hash.Add("F_Status", info.F_Status);
            hash.Add("F_State", info.F_State);
            hash.Add("F_Description", info.F_Description);
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
        /// 审核盘点
        /// </summary>
        /// <param name="F_Id"></param>
        /// <param name="userName"></param>
        /// <param name="info"></param>
        public void Status(string F_Id, string userName, List<SO_StockMakeBodyInfo> info)
        {
            using (DbTransactionScope<SO_StockMakeHeadInfo> dbtran = base.CreateTransactionScope())
            {
                DateTime time = DateTime.Now;
                try
                {

                    SO_StockMakeHeadInfo head = SO_StockMakeHead.Instance.FindByID(F_Id, dbtran.Transaction);
                    head.F_Status = 1;
                    head.F_Verify = userName;
                    head.F_VeriDate = DateTime.Now.ToShortDateString();
                    SO_StockMakeHead.Instance.Update(head, F_Id, dbtran.Transaction);

                    dbtran.Commit();

                    #region 审核后直接修改库存
                    ////更新登记单主表审核状态，审核人，审核时间
                    //SO_StockMakeHeadInfo head = SO_StockMakeHead.Instance.FindByID(F_Id, dbtran.Transaction);
                    //head.F_Status = 1;
                    //head.F_Verify = userName;
                    //head.F_VeriDate = DateTime.Now.ToShortDateString();
                    //SO_StockMakeHead.Instance.Update(head, F_Id, dbtran.Transaction);
                    ////查询所有库存
                    //List<Sys_StockInfo> StockList = BLLFactory<Sys_Stock>.Instance.GetAll();
                    ////库存更新履历
                    //List<Sys_StockHistoryInfo> StockHisList = new List<Sys_StockHistoryInfo>();
                    ////添加盘点履历
                    //List<Sys_StockMaskHistoryInfo> list = new List<Sys_StockMaskHistoryInfo>();

                    ////更新产品库存
                    //foreach (SO_StockMakeBodyInfo item in info)
                    //{
                    //    Sys_StockInfo Info = StockList.Find(u => u.F_WarehouseId == item.F_WarehouseId && u.F_CargoPositionId == item.F_CargoPositionId && u.F_GoodsId == item.F_GoodsId);
                    //    Hashtable hash = new Hashtable();
                    //    hash.Add("F_Number", item.F_RealNumber);
                    //    Sys_Stock.Instance.Update(Info.F_Id, hash, dbtran.Transaction);


                    //    //添加盘点履历
                    //    Sys_StockMaskHistoryInfo maskInfo = new Sys_StockMaskHistoryInfo();
                    //    maskInfo.F_GoodsId = item.F_GoodsId;
                    //    maskInfo.F_GoodsName = item.F_GoodsName;
                    //    maskInfo.F_WarehouseId = item.F_WarehouseId;
                    //    maskInfo.F_WarehouseName = item.F_WarehouseName;
                    //    maskInfo.F_CargoPositionId = item.F_CargoPositionId;
                    //    maskInfo.F_CargoPositionName = item.F_CargoPositionName;
                    //    maskInfo.F_Unit = item.F_Unit;
                    //    maskInfo.F_Batch = item.F_Batch;
                    //    maskInfo.F_Date = time;
                    //    maskInfo.F_Description = item.F_Description;
                    //    maskInfo.F_EnCode = head.F_EnCode;
                    //    maskInfo.F_Number = item.F_Number;
                    //    maskInfo.F_RealNumber = int.Parse(item.F_RealNumber);
                    //    maskInfo.F_Unit = item.F_Unit;
                    //    maskInfo.F_DiffNumber = Math.Abs(int.Parse(item.F_RealNumber) - item.F_Number);
                    //    list.Add(maskInfo);

                    //    //添加库存信息
                    //    Sys_StockHistoryInfo HistoryInfo = new Sys_StockHistoryInfo();
                    //    HistoryInfo.F_CargoPositionId = item.F_CargoPositionId;
                    //    HistoryInfo.F_CargoPositionName = item.F_CargoPositionName;
                    //    HistoryInfo.F_WarehouseId = item.F_WarehouseId;
                    //    HistoryInfo.F_WarehouseName = item.F_WarehouseName;
                    //    HistoryInfo.F_EnCode = head.F_EnCode;
                    //    HistoryInfo.F_Batch = item.F_Batch;
                    //    HistoryInfo.F_BllCategory = "盘点";
                    //    HistoryInfo.F_OperationNum = int.Parse(item.F_RealNumber)-item.F_Number;
                    //    HistoryInfo.F_SpecifModel = item.F_SpecifModel;
                    //    HistoryInfo.F_Vendor = userName;
                    //    HistoryInfo.F_GoodsId = item.F_GoodsId;
                    //    HistoryInfo.F_GoodsName = item.F_GoodsName;
                    //    HistoryInfo.F_Unit = item.F_Unit;
                    //    //HistoryInfo.F_VendorName = head.;
                    //    //HistoryInfo.F_Contacts = head.F_Contacts;
                    //    //HistoryInfo.F_TelePhone = head.F_TelePhone;
                    //    HistoryInfo.F_Maker = head.F_Operator;
                    //    HistoryInfo.F_Verify = head.F_Verify;


                    //    StockHisList.Add(HistoryInfo);
                    //}
                    //Sys_StockHistory.Instance.InsertRange(StockHisList, dbtran.Transaction);
                    ////添盘点记录
                    //Sys_StockMaskHistory.Instance.InsertRange(list, dbtran.Transaction);
                    //dbtran.Commit();
                    #endregion
                   
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }
        }



        public SO_StockMakeHeadInfo Save(SO_StockMakeHeadInfo info, List<SO_StockMakeBodyInfo> dInfo)
        {
            using (DbTransactionScope<SO_StockMakeHeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    DateTime time = DateTime.Now;
                    if (string.IsNullOrEmpty(info.F_EnCode))
                    {
                        string orderNo = "PD" + DateTime.Now.ToString("yyyyMMdd");
                        Hashtable hash = new Hashtable();
                        hash.Add("Prefix", orderNo);
                        DataTable dt = base.StorePorcToDataTable("SYS_CREATESN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString().PadLeft(6, '0');
                        info.F_EnCode = orderNo + SN;
                        info.F_CreatorTime = time;
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

                    SO_StockMakeHead.Instance.InsertUpdate(info, info.F_Id, dbtran.Transaction);
                    //删除子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", info.F_Id, SqlOperator.Equal);

                    SO_StockMakeBody.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //循环添加子表
                
                    foreach (SO_StockMakeBodyInfo item in dInfo)
                    {
        
                        item.F_WarehouseId = info.F_WarehouseId;
                        item.F_CreatorTime = time;
                        item.F_CreatorUserId = info.F_CreatorUserId;
                        item.F_Id = Guid.NewGuid().ToString();
                        item.F_HId = info.F_Id;
                        item.F_EnabledMark = false;
                       
                    }
         
                    //添加子表
                    SO_StockMakeBody.Instance.InsertRange(dInfo, dbtran.Transaction);
                    dbtran.Commit();

                    return info;
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    return null;
                }
            }
        }

        /// <summary>
        /// 弃审
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string NoAudit(string date, string user, string Id)
        {
            string sql = "select F_Status from SO_StockMakeHead where F_Id='" + Id + "'";
            if (this.GetDataTableBySql(sql).Rows[0][0].ToString() == "1")
            {
                string updatesql = string.Format("update SO_StockMakeHead set F_Status=0,F_VeriDate='{0}',F_Verify='{1}' where F_Id='{2}'", date, user, Id);
                Hashtable hash = new Hashtable();
                base.ExecuteNonQuery(updatesql, hash);
                return "弃审成功";
            }
            else
            {
                return "该单据未被审核";
            }
        }


        public void DeleteAll(string keyValue, bool bLogicDelete = false)
        {
            using (DbTransactionScope<SO_StockMakeHeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    SO_StockMakeHead.Instance.Delete(keyValue, dbtran.Transaction);
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HId", keyValue, SqlOperator.Equal);
                    SO_StockMakeBody.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    dbtran.Commit();
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 获取子表信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetFormInfo(string ID)
        {
            string sql = @"SELECT M.F_Id,M.F_HId,M.F_WarehouseId,W.F_FullName AS F_WarehouseName,M.F_CargoPositionId,C.F_FullName 
                            AS F_CargoPositionName,M.F_GoodsId,G.F_FullName AS F_GoodsName,
                            M.F_Batch,G.F_EnCode AS F_GoodsCode,G.F_SellingPrice,G.F_Unit,M.F_Number,M.F_RealNumber
                            FROM 
                            SO_STOCKMAKEBODY AS M
                            LEFT JOIN Mst_Warehouse AS W ON W.F_Id = M.F_WarehouseId
                            LEFT JOIN MST_CARGOPOSITION AS C ON C.F_ID=M.F_CargoPositionId
                            LEFT JOIN Mst_Goods AS G ON G.F_Id = M.F_GoodsId
                            WHERE F_HID= @FHID";
            Hashtable parms = new Hashtable();
            parms.Add("FHID", ID);
            return base.ExecuteTable(sql, parms);
        }

    }
}
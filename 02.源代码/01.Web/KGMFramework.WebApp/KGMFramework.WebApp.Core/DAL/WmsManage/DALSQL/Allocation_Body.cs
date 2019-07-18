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
    /// 调拨子表
    /// </summary>
    public class Allocation_Body : BaseDALSQL<Allocation_BodyInfo>, IAllocation_Body
    {
        #region 对象实例及构造函数

        public static Allocation_Body Instance
        {
            get
            {
                return new Allocation_Body();
            }
        }
        public Allocation_Body()
            : base("Allocation_Body", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Allocation_BodyInfo DataReaderToEntity(IDataReader dataReader)
        {
            Allocation_BodyInfo info = new Allocation_BodyInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_HId = reader.GetString("F_HId");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_OrderNo = reader.GetString("F_OrderNo");
            info.F_AlreadyOperatedNum = reader.GetInt32("F_AlreadyOperatedNum");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_Num = reader.GetInt32("F_Num");
            info.F_DbNum = reader.GetInt32("F_DbNum");
            info.F_PurchasePrice = reader.GetString("F_PurchasePrice");
            info.F_AllAmount = reader.GetDecimal("F_AllAmount");
            info.F_SerialNum = reader.GetString("F_SerialNum");
            info.F_SpecifModel = reader.GetString("F_SpecifModel");
            info.F_OutWareId = reader.GetString("F_OutWareId");
            info.F_OutWareName = reader.GetString("F_OutWareName");
            info.F_OutCargoPositionId = reader.GetString("F_OutCargoPositionId");
            info.F_OutCargoPositionName = reader.GetString("F_OutCargoPositionName");
            info.F_InWareId = reader.GetString("F_InWareId");
            info.F_InWareName = reader.GetString("F_InWareName");
            info.F_InCargoPositionId = reader.GetString("F_InCargoPositionId");
            info.F_InCargoPositionName = reader.GetString("F_InCargoPositionName");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");
            info.F_Description = reader.GetString("F_Description");
            info.F_FreeTerm1 = reader.GetString("F_FreeTerm1");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Allocation_BodyInfo obj)
        {
            Allocation_BodyInfo info = obj as Allocation_BodyInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_HId", info.F_HId);
            hash.Add("F_OrderNo", info.F_OrderNo);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_AlreadyOperatedNum", info.F_AlreadyOperatedNum);
            hash.Add("F_GoodsId", info.F_GoodsId);
            hash.Add("F_GoodsName", info.F_GoodsName);
            hash.Add("F_SpecifModel", info.F_SpecifModel);
            hash.Add("F_Num", info.F_Num);
            hash.Add("F_DbNum", info.F_DbNum);
            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_PurchasePrice", info.F_PurchasePrice);
            hash.Add("F_AllAmount", info.F_AllAmount);
            hash.Add("F_SerialNum", info.F_SerialNum);
            hash.Add("F_OutWareId", info.F_OutWareId);
            hash.Add("F_OutWareName", info.F_OutWareName);
            hash.Add("F_OutCargoPositionId", info.F_OutCargoPositionId);
            hash.Add("F_OutCargoPositionName", info.F_OutCargoPositionName);
            hash.Add("F_InWareId", info.F_InWareId);
            hash.Add("F_InWareName", info.F_InWareName);
            hash.Add("F_InCargoPositionId", info.F_InCargoPositionId);
            hash.Add("F_InCargoPositionName", info.F_InCargoPositionName);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
            hash.Add("F_DeleteTime", info.F_DeleteTime);
            hash.Add("F_DeleteUserId", info.F_DeleteUserId);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_FreeTerm1", info.F_FreeTerm1);

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
            dict.Add("F_OrderNo", "调拨单据号");
            dict.Add("F_AlreadyOperatedNum", "是否已操作");
            dict.Add("F_State", "是否完成操作");
            dict.Add("F_EnCode", "调拨编码");
            dict.Add("F_GoodsId", "产品Id");
            dict.Add("F_GoodsName", "产品名称");
            dict.Add("F_SpecifModel", "规格型号");
            dict.Add("F_DbNum", "调拨数量");
            dict.Add("F_Unit", "单位");
            dict.Add("F_OutWareId", "调出仓库ID");
            dict.Add("F_OutWareName", "调出仓库");
            dict.Add("F_InWareId", "调入仓库ID");
            dict.Add("F_InWareName", "调入仓库");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_CreatorTime", "创建日期");
            dict.Add("F_CreatorUserId", "创建用户主键");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            dict.Add("F_FreeTerm1", "是否完成出库");

            #endregion

            return dict;
        }

        public string OutStock(string Batch, string id)
        {
            using (DbTransactionScope<Allocation_BodyInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //查询子表信息
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_Id", id, SqlOperator.Equal);
                    Allocation_BodyInfo bodyinfo = BLLFactory<Allocation_Body>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty))[0];

                    //查询主表判断是否审核
                    condition = new SearchCondition();
                    condition.AddCondition("F_Id", bodyinfo.F_HId, SqlOperator.Equal);
                    Allocation_HeadInfo headinfo = BLLFactory<Allocation_Head>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty))[0];
                    if (headinfo.F_Status == 0)
                    {
                        return "该调拨单未审核，不能进行出库操作";
                    }

                    //判断是否出库 
                    if (bodyinfo.F_FreeTerm1 == "") //F_FreeTerm1--0未出库  1已出库
                    {
                        bodyinfo.F_FreeTerm1 = "0";
                    }
                    if (int.Parse(bodyinfo.F_FreeTerm1) > 0)
                    {
                        return "该单据已出库，不能重复执行出库操作";
                    }

                    //查询库存表是否存在该仓库中的产品
                    condition = new SearchCondition();
                    condition.AddCondition("F_GoodsId", bodyinfo.F_GoodsId, SqlOperator.Equal);
                    condition.AddCondition("F_WarehouseId", bodyinfo.F_OutWareId, SqlOperator.Equal);
                    List<Sys_StockInfo> stock = BLLFactory<Sys_Stock>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
                    if (stock.Count == 0)
                    {
                        return "该仓库无此产品";
                    }
                    
                    //判断库存数量是否足够
                    if (stock[0].F_Number > bodyinfo.F_DbNum)
                    {
                        //扣减库存
                        Hashtable hash = new Hashtable();
                        hash.Add("F_Number", stock[0].F_Number - bodyinfo.F_DbNum);
                        Sys_Stock.Instance.Update(stock[0].F_Id, hash, dbtran.Transaction);

                        //更新出库状态
                        hash = new Hashtable();
                        hash.Add("F_FreeTerm1", 1);
                        Allocation_Body.Instance.Update(bodyinfo.F_Id, hash, dbtran.Transaction);
                    }
                    else
                    {
                        return bodyinfo.F_OutWareName + "仓库库存不足，当前产品" + bodyinfo.F_GoodsName + "库存为" + stock[0].F_Number;
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
         
        }





        /// <summary>
        /// 产品入库操作
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="stockinfo"></param>
        /// <returns></returns>
        public string InStock(string Batch, string id)
        {
            using (DbTransactionScope<Allocation_BodyInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //查询子表信息
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_Id", id, SqlOperator.Equal);
                    Allocation_BodyInfo bodyinfo = BLLFactory<Allocation_Body>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty))[0];

                    //查询主表判断是否审核
                    condition = new SearchCondition();
                    condition.AddCondition("F_Id", bodyinfo.F_HId, SqlOperator.Equal);
                    Allocation_HeadInfo headinfo = BLLFactory<Allocation_Head>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty))[0];
                    if (headinfo.F_Status == 0)
                    {
                        return "该调拨单未审核，不能进行出库操作";
                    }

                    //判断是否已入库 
                    if (bodyinfo.F_AlreadyOperatedNum == null)//F_AlreadyOperatedNum--0未入库  1已入库
                    {
                        bodyinfo.F_AlreadyOperatedNum = 0;
                    }
                    if (bodyinfo.F_AlreadyOperatedNum>0)
                    {
                         return "该单据已入库，不能重复执行入库操作";
                    }

                    //判断该调拨单是否出库
                    if (bodyinfo.F_FreeTerm1 == null)//F_FreeTerm1--0未出库  1已出库
                    {
                        bodyinfo.F_FreeTerm1 = "0";
                        return "调拨单中产品未出库，不能进行入库操作";
                    }

                    if (int.Parse(bodyinfo.F_FreeTerm1)>0)
                    {
                        //查询库存表是否存在该仓库中的产品
                        condition = new SearchCondition();
                        condition.AddCondition("F_GoodsId", bodyinfo.F_GoodsId, SqlOperator.Equal);
                        condition.AddCondition("F_WarehouseId", bodyinfo.F_InWareId, SqlOperator.Equal);
                        List<Sys_StockInfo> stock = BLLFactory<Sys_Stock>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
                        //如果不存在
                        if (stock.Count==0)
                        {
                            //新添加一条数据
                            Sys_StockInfo entity = new Sys_StockInfo();
                            entity.F_Id = Guid.NewGuid().ToString();
                            entity.F_GoodsId = bodyinfo.F_GoodsId;
                            entity.F_GoodsName = bodyinfo.F_GoodsName;
                            entity.F_WarehouseId = bodyinfo.F_InWareId;
                            entity.F_WarehouseName = bodyinfo.F_InWareName;
                            entity.F_Number = bodyinfo.F_DbNum;
                            Sys_Stock.Instance.Insert(entity, dbtran.Transaction);

                            //添加履历
                            Sys_AllocationHistoryInfo Dbinfo = new Sys_AllocationHistoryInfo();
                            Dbinfo.F_Id = Guid.NewGuid().ToString();
                            Dbinfo.F_GoodsId = bodyinfo.F_GoodsId;
                            Dbinfo.F_InWareName = bodyinfo.F_InWareName;
                            Dbinfo.F_GoodsName = bodyinfo.F_GoodsName;
                            Dbinfo.F_OutWareId = bodyinfo.F_OutWareId;
                            Dbinfo.F_InWareId = bodyinfo.F_InWareId;
                            Dbinfo.F_OutWareName = bodyinfo.F_OutWareName;
                            Dbinfo.F_Unit = bodyinfo.F_Unit;
                            Dbinfo.F_DBNum = bodyinfo.F_DbNum;
                            Dbinfo.F_SpecifModel = bodyinfo.F_SpecifModel;
                            Dbinfo.F_CreatorTime = DateTime.Now;

                            Sys_AllocationHistory.Instance.Insert(Dbinfo, dbtran.Transaction);

                            //更新入库状态
                            Hashtable hash = new Hashtable();
                            hash.Add("F_AlreadyOperatedNum", 1);
                            Allocation_Body.Instance.Update(bodyinfo.F_Id, hash, dbtran.Transaction);
                        }
                            //如果存在
                        else
                        {
                            //增加库存
                            Hashtable hash = new Hashtable();
                            hash.Add("F_Number", stock[0].F_Number + bodyinfo.F_DbNum);
                            Sys_Stock.Instance.Update(stock[0].F_Id, hash, dbtran.Transaction);

                            //更新入库状态
                            hash = new Hashtable();
                            hash.Add("F_AlreadyOperatedNum", 1);
                            Allocation_Body.Instance.Update(bodyinfo.F_Id, hash, dbtran.Transaction);

                            //添加履历
                            Sys_AllocationHistoryInfo Dbinfo = new Sys_AllocationHistoryInfo();
                            Dbinfo.F_Id = Guid.NewGuid().ToString();
                            Dbinfo.F_GoodsId = bodyinfo.F_GoodsId;
                            Dbinfo.F_InWareName = bodyinfo.F_InWareName;
                            Dbinfo.F_GoodsName = bodyinfo.F_GoodsName;
                            Dbinfo.F_OutWareId = bodyinfo.F_OutWareId;
                            Dbinfo.F_InWareId = bodyinfo.F_InWareId;
                            Dbinfo.F_OutWareName = bodyinfo.F_OutWareName;
                            Dbinfo.F_Unit = bodyinfo.F_Unit;
                            Dbinfo.F_DBNum = bodyinfo.F_DbNum;
                            Dbinfo.F_SpecifModel = bodyinfo.F_SpecifModel;
                            Dbinfo.F_CreatorTime = DateTime.Now;

                            Sys_AllocationHistory.Instance.Insert(Dbinfo, dbtran.Transaction);
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



           
        }

    }
}
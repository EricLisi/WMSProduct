using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGM.Pager.Entity;
using KGMFramework.WebApp.Areas.WmsManage.Model;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Controllers;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Models;
using Stimulsoft.Base.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    /// <summary>
    /// 检货单控制器
    /// </summary>
    public class PackListController : BusinessController<PackList_Head, PackList_HeadInfo>
    {
        /// <summary>
        /// 初始化列表
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="pagination">分页信息</param>
        /// <param name="sortFiled">排序字段</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListGridJsonPagination(string filterStr, Pagination pagination, string sidx = " F_EnCode ", string sord = "desc")
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " F_EnCode ";
            }
            List<PackList_HeadInfo> lista;
            PagerInfo pager = GetPageInfo(pagination);
            List<AdvSearchEntity> advSearchList = new List<AdvSearchEntity>();
            if (string.IsNullOrEmpty(filterStr))
            {
                lista = baseBLL.FindWithPager(GetKeywordCondition("", filterStr), pager, sidx, sord.ToLower() == "desc");


            }
            else
            {

                PackListFilter filter = JsonAppHelper.ToObject<PackListFilter>(filterStr);

                if (!string.IsNullOrEmpty(filter.F_EnCode))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_EnCode,
                        F_searchFiled = "F_EnCode",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_EnabledMark))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_EnabledMark,
                        F_searchFiled = "F_EnabledMark",
                        F_type = "0"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_CustomerId))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_CustomerId,
                        F_searchFiled = "F_CustomerId",
                        F_type = "0"
                    });
                }

                if (!string.IsNullOrEmpty(filter.F_Maker))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Maker,
                        F_searchFiled = "F_Maker",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_SDate))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = Convert.ToDateTime(filter.F_SDate).ToString("yyyy-MM-dd"),
                        F_searchFiled = "F_Date",
                        F_type = "5"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_EDate))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = Convert.ToDateTime(filter.F_EDate).AddDays(1).ToString("yyyy-MM-dd"),
                        F_searchFiled = "F_Date",
                        F_type = "6"
                    });
                }
                lista = BLLFactory<PackList_Head>.Instance.FindWithPager(GetAdvCondition(advSearchList), pager, sidx, sord.ToLower().Equals("desc"));

            }
            var cuList = BLLFactory<Mst_Customer>.Instance.GetAll();
            foreach (var item in lista)
            {
                item.F_CustomerId = cuList.Find(u => u.F_Id == item.F_CustomerId) != null ? cuList.Find(u => u.F_Id == item.F_CustomerId).F_FullName : "";
            }
            return GetPagerContent<PackList_HeadInfo>(lista, pager);
        }

        /// <summary>
        /// 根据出库单据Id查询单据表体信息
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <returns></returns>
        public ActionResult GetOutGoods(string KeyValue) {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_HeadId", KeyValue, SqlOperator.Equal);
            List<V_PACKLISTSELInfo> list = BLLFactory<V_PACKLISTSEL>.Instance.Find(GetConditionStr(search));
            return Content(JsonAppHelper.ToJson(list));
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="headInfo"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public ActionResult Submit(PackList_HeadInfo headInfo,List<PackList_BodyInfo> dInfo) {
            ResultModel result = new ResultModel();
            List<Sm_CurrentStockInfo> stockList = BLLFactory<Sm_CurrentStock>.Instance.GetAll();
            //判断库存是否足够
            for (int i = 0; i < dInfo.Count; i++)
            {
                Sm_CurrentStockInfo stock = stockList.Find(
                    u => u.F_WarehouseId == dInfo[i].F_WarehouseId &&
                    u.F_PositionId == dInfo[i].F_PositionId &&//068f1440-4df9-4b4d-9859-4d4879caf098
                    u.F_ProductId == dInfo[i].F_ProductId &&//4c950519-c8e1-422d-bc9e-e3a6a9963349
                    u.F_Batch == dInfo[i].F_Batch// &&
                    //u.F_Qty>dInfo[i].F_Quantity
                    );
                var F_WarehouseName = BLLFactory<Mst_Warehouse>.Instance.FindByID(dInfo[i].F_WarehouseId).F_FullName;
                var F_PositionName = BLLFactory<Mst_Position>.Instance.FindByID(dInfo[i].F_PositionId).F_FullName;
                var F_ProductName = BLLFactory<Mst_Product>.Instance.FindByID(dInfo[i].F_ProductId).F_FullName;
                if (stock == null)//判断货位上是否有此商品
                {
                   
                    result.bSuccess = false;
                    result.message = string.Format("在{0}的{1}上不存在{2}，请重新选择仓库货位",F_WarehouseName,F_PositionName, F_ProductName);
                    return Content(JsonAppHelper.ToJson(result));
                }
                else
                {
                    if (stock.F_Qty<dInfo[i].F_Quantity)//判断数量是否足够
                    {
                        result.bSuccess = false;
                        result.message = string.Format("{0}在{1}的{2}的数量不足，请重新选择仓库货位", F_ProductName, F_WarehouseName, F_PositionName);
                        return Content(JsonAppHelper.ToJson(result));

                    }
                }
              
            }


            DateTime time = DateTime.Now;
            headInfo.F_Maker = CurrentUser.F_Account;
            if (string.IsNullOrEmpty(headInfo.F_EnCode))//判断是新增还是修改
            {
                headInfo.F_CreatorTime = time;
                headInfo.F_CreatorUserId = CurrentUser.F_Account;
                headInfo.F_EnCode = "JH" + DateTime.Now.ToString("yyyymmddhhmmss")+new Random().Next(10,100).ToString();

                for (int i = 0; i < dInfo.Count; i++)
                {
               
                    
                    dInfo[i].F_CreatorTime = time;
                    dInfo[i].F_CreatorUserId = CurrentUser.F_Account;
                    dInfo[i].F_HeadId = headInfo.F_Id;
                }
            }
            else
            {
                headInfo.F_LastModifyTime = time;
                headInfo.F_LastModifyUserId = CurrentUser.F_Account;
                for (int i = 0; i < dInfo.Count; i++)
                {
                    dInfo[i].F_LastModifyTime = time;
                    dInfo[i].F_LastModifyUserId = CurrentUser.F_Account;
                    dInfo[i].F_HeadId = headInfo.F_Id;

                }
            }
         
            result.bSuccess = BLLFactory<PackList_Head>.Instance.Save(headInfo, dInfo);
            result.message = result.bSuccess ? headInfo.F_EnCode : "操作失败";

            return Content(JsonAppHelper.ToJson(result));
        }
        /// <summary>
        /// 出库通知单界面
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectItem() {
            return View();
        }

        /// <summary>
        /// 查询子表
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetListGridJson(string keyValue) {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_HeadId", keyValue, SqlOperator.Equal);
            List<V_PACKLISTBODYSELInfo> packs = BLLFactory<V_PACKLISTBODYSEL>.Instance.Find(GetConditionStr(search));
            return Content(JsonAppHelper.ToJson(packs));


        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult VerifyList(string keyValue) {
            ResultModel result = new ResultModel();
            PackList_HeadInfo pack = BLLFactory<PackList_Head>.Instance.FindByID(keyValue);
            result.bSuccess = pack.F_EnabledMark==true ? false:true;
            result.message= result.bSuccess ? "审核成功" : "单据已被审核";
            if (!result.bSuccess)
            {
                return Content(JsonAppHelper.ToJson(result));
            }
            pack.F_Verifier = CurrentUser.F_Account;
            pack.F_EnabledMark = true;
            pack.F_Veridate = DateTime.Now;
            result.bSuccess = BLLFactory<PackList_Head>.Instance.Update(pack, keyValue);
            result.message = result.bSuccess ? "审核成功" : "操作失败";
            return Content(JsonAppHelper.ToJson(result));
        }

        /// <summary>
        /// 弃审
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult OnVerifyList(string keyValue)
        {
            ResultModel result = new ResultModel();
            PackList_HeadInfo pack = BLLFactory<PackList_Head>.Instance.FindByID(keyValue);
            result.bSuccess = pack.F_EnabledMark == true ? true : false;
            result.message = result.bSuccess ? "弃核成功" : "单据未被审核";
            if (!result.bSuccess)
            {
                return Content(JsonAppHelper.ToJson(result));
            }
            pack.F_Verifier = CurrentUser.F_Account;
            pack.F_EnabledMark = false;
            pack.F_Veridate = DateTime.Now;
            result.bSuccess = BLLFactory<PackList_Head>.Instance.Update(pack, keyValue);
            result.message = result.bSuccess ? "弃核成功" : "操作失败";
            return Content(JsonAppHelper.ToJson(result));
        }

        /// <summary>
        /// 判断是否是超级管理员
        /// </summary>
        /// <returns></returns>
        public ActionResult IsAdmin() {
            var result = CurrentUser.F_IsAdministrator.ToString().ToLower();
            return Content(result);
        }

       /// <summary>
       /// 获取启用的仓库
       /// </summary>
       /// <returns></returns>
        public ActionResult GetWarSelectJson() {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_EnabledMark", true, SqlOperator.Equal);
            List<Mst_WarehouseInfo> wList = BLLFactory<Mst_Warehouse>.Instance.Find(GetConditionStr(search));
            foreach (var item in wList)
            {
                item.F_FullName = "[" + item.F_EnCode + "]" + item.F_FullName;

            }
            return Content(JsonAppHelper.ToJson(wList));
        }
        /// <summary>
        /// 获取可用货位
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPositonSelectJson()
        {
            List<Mst_PositionInfo> wList = new List<Mst_PositionInfo>();
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_EnabledMark", true, SqlOperator.Equal);
            wList = BLLFactory<Mst_Position>.Instance.Find(GetConditionStr(search));
            foreach (var item in wList)
            {
                item.F_FullName = "[" + item.F_EnCode + "]" + item.F_FullName;
                
            }
           return Content(JsonAppHelper.ToJson(wList));
        }

        /// <summary>
        /// 出库通知单查询
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="pagination">分页信息</param>
        /// <param name="sortFiled">排序字段</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListGridJsonPaginationBySel(string filterStr, Pagination pagination, string sidx = " F_EnCode ", string sord = "desc")
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " F_EnCode ";
            }
            PagerInfo pager = GetPageInfo(pagination);
            List<AdvSearchEntity> advSearchList = new List<AdvSearchEntity>();
            if (string.IsNullOrEmpty(filterStr))
            {

                advSearchList.Add(new AdvSearchEntity
                {
                    F_condition = "And",
                    F_fvalue = "true",
                    F_searchFiled = "F_EnabledMark",
                    F_type = "0"
                });
            }
            else
            {

                OutStockFilter filter = JsonAppHelper.ToObject<OutStockFilter>(filterStr);

                if (!string.IsNullOrEmpty(filter.F_EnCode))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = "true",
                        F_searchFiled = "F_EnabledMark",
                        F_type = "0"
                    });

                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_EnCode,
                        F_searchFiled = "F_EnCode",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_Customer))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Customer,
                        F_searchFiled = "F_CustomerId",
                        F_type = "0"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_Status))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = "",
                        F_searchFiled = "F_Status",
                        F_type = "0"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_SDate))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = Convert.ToDateTime(filter.F_SDate).ToString("yyyy-MM-dd"),
                        F_searchFiled = "F_Date",
                        F_type = "5"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_EDate))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = Convert.ToDateTime(filter.F_EDate).AddDays(1).ToString("yyyy-MM-dd"),
                        F_searchFiled = "F_Date",
                        F_type = "6"
                    });
                }
            }

            List<V_OutStockNoticeHeadInfo> list = BLLFactory<V_OutStockNoticeHead>.Instance.FindWithPager(GetAdvCondition(advSearchList), pager, sidx, sord.ToLower().Equals("desc"));
            return GetPagerContent<V_OutStockNoticeHeadInfo>(list, pager);
        }


    }
}
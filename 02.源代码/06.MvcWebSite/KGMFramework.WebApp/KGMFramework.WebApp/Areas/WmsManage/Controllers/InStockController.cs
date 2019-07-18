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
using System.Collections.Generic;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    /// <summary>
    /// 入库单控制器
    /// </summary>
    public class InStockController : BusinessController<InStock_Head, InStock_HeadInfo>
    {
        /// <summary>
        /// 入库单查询
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
            PagerInfo pager = GetPageInfo(pagination);
            List<AdvSearchEntity> advSearchList = new List<AdvSearchEntity>();
            if (string.IsNullOrEmpty(filterStr))
            {

                advSearchList.Add(new AdvSearchEntity
                {
                    F_condition = "And",
                    F_fvalue = DateTime.Now.ToString("yyyy-MM") + "-01",
                    F_searchFiled = "F_Date",
                    F_type = "5"
                });

                advSearchList.Add(new AdvSearchEntity
                {
                    F_condition = "And",
                    F_fvalue = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                    F_searchFiled = "F_Date",
                    F_type = "6"
                });

            }
            else
            {

                InStockFilter filter = JsonAppHelper.ToObject<InStockFilter>(filterStr);

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
                if (!string.IsNullOrEmpty(filter.F_Supplier))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Supplier,
                        F_searchFiled = "F_SupplierId",
                        F_type = "0"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_Warehouse))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Warehouse,
                        F_searchFiled = "F_WarehouseId",
                        F_type = "0"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_Status))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Status,
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

            List<V_InStockHeadInfo> list = BLLFactory<V_InStockHead>.Instance.FindWithPager(GetAdvCondition(advSearchList), pager, sidx, sord.ToLower().Equals("desc"));
            return GetPagerContent<V_InStockHeadInfo>(list, pager);
        }



        /// <summary>
        /// 获取入库单表体行信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListGridJson(string keyValue, string sidx = " F_EnCode ", string sord = "desc")
        {
            //此处需要新建一张表体视图,暂时使用表代替
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_HeadId", keyValue, SqlOperator.Equal);
            return Content(JsonAppHelper.ToJson(BLLFactory<InStock_Body>.Instance.Find(GetConditionStr(condition))));
        }
    }
}
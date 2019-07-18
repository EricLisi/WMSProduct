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
    /// 供应商控制器
    /// </summary>
    public class SupplierController : BusinessController<Mst_Supplier, Mst_SupplierInfo>
    {
        // GET: WmsManage/Supplier
        /// <summary>
        /// 供应商查询
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
            List<Mst_SupplierInfo> lista;
            if (string.IsNullOrEmpty(filterStr))
            {
                lista = baseBLL.FindWithPager(GetKeywordCondition("", filterStr), pager, sidx, sord.ToLower() == "desc");
            }
            else
            {

                SupplierFilter filter = JsonAppHelper.ToObject<SupplierFilter>(filterStr);

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
                if (!string.IsNullOrEmpty(filter.F_FullName))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_FullName,
                        F_searchFiled = "F_FullName",
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
                lista = BLLFactory<Mst_Supplier>.Instance.FindWithPager(GetAdvCondition(advSearchList), pager, sidx, sord.ToLower().Equals("desc"));

            }

            return GetPagerContent<Mst_SupplierInfo>(lista, pager);
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
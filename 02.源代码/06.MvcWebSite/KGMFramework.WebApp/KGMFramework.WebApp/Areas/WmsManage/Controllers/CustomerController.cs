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
    /// 仓库管理单控制器
    /// </summary>
    public class CustomerController : BusinessController<Mst_Customer, Mst_CustomerInfo>
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
            List<Mst_CustomerInfo> lista;
            if (string.IsNullOrEmpty(filterStr))
            {
              lista = baseBLL.FindWithPager(GetKeywordCondition("", filterStr), pager, sidx, sord.ToLower() == "desc");

                //advSearchList.Add(new AdvSearchEntity
                //{
                //    F_condition = "And",
                //    F_fvalue = DateTime.Now.ToString("yyyy-MM") + "-01",
                //    F_searchFiled = "F_Id",
                //    F_type = "2"
                //});

                //advSearchList.Add(new AdvSearchEntity
                //{
                //    F_condition = "And",
                //    F_fvalue = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                //    F_searchFiled = "F_Id",
                //    F_type = "2"
                //});

            }
            else
            {

                CustomerFilter filter = JsonAppHelper.ToObject<CustomerFilter>(filterStr);

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
                lista = BLLFactory<Mst_Customer>.Instance.FindWithPager(GetAdvCondition(advSearchList), pager, sidx, sord.ToLower().Equals("desc"));

            }

            return GetPagerContent<Mst_CustomerInfo>(lista, pager);
        }

  }
}
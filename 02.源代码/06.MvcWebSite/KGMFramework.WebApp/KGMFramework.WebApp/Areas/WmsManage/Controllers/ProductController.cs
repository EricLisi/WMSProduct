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
    /// 产品控制器
    /// </summary>
    public class ProductController : BusinessController<Mst_Product, Mst_ProductInfo>
    {
        /// <summary>
        /// 选择产品画面
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectItem()
        {
            return View();
        }

        /// <summary>
        /// 产品查询
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
            List<Mst_ProductInfo> lista;
            if (string.IsNullOrEmpty(filterStr))
            {
                lista = baseBLL.FindWithPager(GetKeywordCondition("", filterStr), pager, sidx, sord.ToLower() == "desc");
                //advSearchList.Add(new AdvSearchEntity
                //{
                //    F_condition = "And",
                //    F_fvalue = DateTime.Now.ToString("yyyy-MM") + "-01",
                //    F_searchFiled = "F_CreatorTime",
                //    F_type = "5"
                //});

                //advSearchList.Add(new AdvSearchEntity
                //{
                //    F_condition = "And",
                //    F_fvalue = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                //    F_searchFiled = "F_CreatorTime",
                //    F_type = "6"
                //});

            }
            else
            {

                ProductFilter filter = JsonAppHelper.ToObject<ProductFilter>(filterStr);

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
               
                if (!string.IsNullOrEmpty(filter.F_ShortCode))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_ShortCode,
                        F_searchFiled = "F_ShortCode",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_ShortName))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_ShortName,
                        F_searchFiled = "F_ShortName",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_Brand))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Brand,
                        F_searchFiled = "F_Brand",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_Standard))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Standard,
                        F_searchFiled = "F_Standard",
                        F_type = "2"
                    });
                }
            }

            lista = baseBLL.FindWithPager(GetKeywordCondition("", filterStr), pager, sidx, sord.ToLower() == "desc");
            return GetPagerContent<Mst_ProductInfo>(lista, pager);
        }

    }
}
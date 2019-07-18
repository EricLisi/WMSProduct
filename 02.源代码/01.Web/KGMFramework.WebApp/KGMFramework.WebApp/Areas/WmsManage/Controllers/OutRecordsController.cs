using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGM.Framework.Commons;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Models;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using KGMFramework.WebApp.Controllers;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    public class OutRecordsController : BusinessController<Sys_OutRecords, Sys_OutRecordsInfo>
    {
        /// <summary>
        /// 获取grid显示信息 分页
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="pagination">分页默认是null</param>
        /// <param name="sortFiled">排序字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public  override   ActionResult GetGridJsonPagination(string keyword, string searchFiled, string list, Pagination pagination, string sortFiled = " F_SortCode ")
        {
            List<Sys_OutRecordsInfo> lista;
            PagerInfo pager = GetPageInfo(pagination);
            if (string.IsNullOrEmpty(list))
            {
                lista = baseBLL.FindWithPager(GetKeywordCondition(keyword, searchFiled), pager, sortFiled);
            }
            else
            {
                List<AdvSearchEntity> a = JsonConvert.DeserializeObject<List<AdvSearchEntity>>(list);
                lista = baseBLL.FindWithPager(GetAdvCondition(a), pager, sortFiled);
            }
            List<Mst_CustomerInfo> custList = BLLFactory<Mst_Customer>.Instance.GetAll();
            foreach (Sys_OutRecordsInfo item in lista)
            {
                var Cust = custList.Find(t => t.F_Id == item.F_CustomerId);
                item.F_CustomerId = Cust == null ? "" : Cust.F_FullName;
            }
            return GetPagerContent(lista, pager);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KGM.Pager.Entity;
using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Controllers;
using KGMFramework.WebApp.Library;
using System.Data;
using KGMFramework.WebApp.Models;
using Newtonsoft.Json;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    public class InStockController : BusinessController<V_InStock, V_InStockInfo>
    {
        public ActionResult a(string keyword = "", string searchFiled = "")
        {
            List<V_InStockInfo> info = new List<V_InStockInfo>();
            if (searchFiled == "" && keyword == "")
            {
                info = BLLFactory<V_InStock>.Instance.GetAll();

            }
            else
            {
                string[] a = searchFiled.Split('/');
                SearchCondition search = new SearchCondition();
                for (int i = 0; i < a.Length; i++)
                {
                    search.AddCondition(a[i], keyword, SqlOperator.Equal);
                }
                info = BLLFactory<V_InStock>.Instance.Find(GetConditionStr(search));
            }
            return Content(JsonAppHelper.ToJson(info));

        }


        public ActionResult GetEnCodeList() {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_Status", 1, SqlOperator.Equal);
            List<PI_HeadInfo> list = BLLFactory<PI_Head>.Instance.Find(GetConditionStr(search));
            return Content(JsonAppHelper.ToJson(list));
        
        }
    }
}
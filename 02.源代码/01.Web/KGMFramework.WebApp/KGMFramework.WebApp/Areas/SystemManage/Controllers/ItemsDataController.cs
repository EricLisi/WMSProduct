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

namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{
    public class ItemsDataController : BusinessController<Sys_ItemsDetail, Sys_ItemsDetailInfo>
    {
        [HttpGet]
        public virtual ActionResult GetSelectJsonByType(string type, string orderBy = " Order By F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_EnCode", type, SqlOperator.Equal);
            Sys_ItemsInfo typeInfo = BLLFactory<Sys_Items>.Instance.FindSingle(GetConditionStr(condition));
            List<object> list = new List<object>();
            if (type == null)
            {
                return Content(JsonAppHelper.ToJson(list));
            }

            condition = new SearchCondition();
            condition.AddCondition("F_ItemId", typeInfo.F_Id, SqlOperator.Equal);
            var data = baseBLL.Find(GetConditionStr(condition), orderBy);
            foreach (Sys_ItemsDetailInfo item in data)
            {
                list.Add(new { id = item.F_ItemCode, text = item.F_ItemName });
            }
            return Content(JsonAppHelper.ToJson(list));
        }
    }
}
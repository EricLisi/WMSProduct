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
    public class SperCategoryController : BusinessController<Mst_SperCategory,Mst_SperCategoryInfo>
    {
        //[HttpGet]
        //public virtual ActionResult GetSelectJsonByType(string type, string orderBy = " Order By F_SortCode ")
        //{
        //    SearchCondition condition = new SearchCondition();
        //    condition.AddCondition("F_EnCode", type, SqlOperator.Equal);
        //    Mst_GoodsInfo typeInfo = BLLFactory<Mst_Goods>.Instance.FindSingle(GetConditionStr(condition));
        //    List<object> list = new List<object>();
        //    if (type == null)
        //    {
        //        return Content(JsonAppHelper.ToJson(list));
        //    }

        //    condition = new SearchCondition();
        //    condition.AddCondition("F_CategoryID", typeInfo.F_Id, SqlOperator.Equal);
        //    var data = baseBLL.Find(GetConditionStr(condition), orderBy);
        //    foreach (Mst_CategoryInfo item in data)
        //    {
        //        list.Add(new { id = item.F_Id, text = item.F_FullName });
        //    }
        //    return Content(JsonAppHelper.ToJson(list));
        //}
    }
}
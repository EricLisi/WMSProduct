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
using KGMFramework.WebApp.Models;
using System.IO;

namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{
    public class TerminalGridColumnController : BusinessController<Sys_TerminalGridColumnSetting, Sys_TerminalGridColumnSettingInfo>
    {
        public override ActionResult GetTreeSelectJson(string orderBy = " ORDER BY F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", "0", SqlOperator.Equal);
            var list = BLLFactory<Sys_TerminalGridColumnSetting>.Instance.Find(GetConditionStr(condition));
            return Content(GetTreeSelectJsonStr(list));
        }

        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", keyValue, SqlOperator.Equal);
            BLLFactory<Sys_TerminalGridColumnSetting>.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            BLLFactory<Sys_TerminalGridColumnSetting>.Instance.Delete(keyValue);
            return Success("删除成功");
        }
    }
}
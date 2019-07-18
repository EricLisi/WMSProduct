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

namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{
    public class TerminalListSettingController : BusinessController<Sys_TerminalListSetting, Sys_TerminalListSettingInfo>
    {
        public override ActionResult GetTreeSelectJson(string orderBy = " ORDER BY F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", "0", SqlOperator.NotEqual);
            var list = BLLFactory<Sys_TerminalGridColumnSetting>.Instance.Find(GetConditionStr(condition));
            return Content(GetTreeSelectJsonStr(list));
        }

        public string GetTreeSelectJsonStr(List<Sys_TerminalGridColumnSettingInfo> data)
        {
            var treeList = new List<TreeSelectModel>();
            foreach (Sys_TerminalGridColumnSettingInfo item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = "0";
                treeList.Add(treeModel);
            }
            return treeList.TreeSelectJson();
        }

        protected override ResultModel OnBeforeSubmitForm(Sys_TerminalListSettingInfo info)
        {
            ResultModel result = new ResultModel();
            result.bSuccess = true;
            result.message = string.Empty;
            if (!BLLFactory<Sys_TerminalListSetting>.Instance.IsExistKey("F_Id", info.F_ParentId))
            {
                Sys_TerminalGridColumnSettingInfo GridColumn = BLLFactory<Sys_TerminalGridColumnSetting>.Instance.FindByID(info.F_ParentId);
                Sys_TerminalListSettingInfo t = new Sys_TerminalListSettingInfo();
                t.F_CreatorTime = DateTime.Now;
                t.F_CreatorUserId = CurrentUser.F_Account;
                t.F_Id = info.F_ParentId;
                t.F_EnCode = GridColumn.F_EnCode;
                t.F_FullName = GridColumn.F_FullName;
                t.F_ParentId = "0";
                BLLFactory<Sys_TerminalListSetting>.Instance.Insert(t);
            }
            return result;
        }

        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", keyValue, SqlOperator.Equal);
            BLLFactory<Sys_TerminalListSetting>.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            BLLFactory<Sys_TerminalListSetting>.Instance.Delete(keyValue);
            return Success("删除成功");
        }

    }
}
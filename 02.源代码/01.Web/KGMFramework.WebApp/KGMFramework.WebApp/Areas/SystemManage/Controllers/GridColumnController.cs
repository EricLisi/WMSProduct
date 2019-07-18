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
using System.Data;

namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{
    public class GridColumnController : BusinessController<Sys_GridColumnSetting, Sys_GridColumnSettingInfo>
    {
        public ActionResult Copy()
        {
            return View();
        }

        public override ActionResult GetTreeSelectJson(string orderBy = " ORDER BY F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", "0", SqlOperator.Equal);
            var list = BLLFactory<Sys_GridColumnSetting>.Instance.Find(GetConditionStr(condition));
            return Content(GetTreeSelectJsonStr(list));
        }

        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", keyValue, SqlOperator.Equal);
            BLLFactory<Sys_GridColumnSetting>.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            BLLFactory<Sys_GridColumnSetting>.Instance.Delete(keyValue);
            return Success("删除成功");
        }

        public ActionResult Copys(string F_Id, string F_FullName, string F_EnCode, string F_Page, string F_GridId)
        {
            //组织主表数据
            Sys_GridColumnSettingInfo info = new Sys_GridColumnSettingInfo();
            info.F_CreatorTime = DateTime.Now;
            info.F_CreatorUserId = CurrentUser.F_Account;
            info.F_Id = Guid.NewGuid().ToString();
            info.F_FullName = F_FullName;
            info.F_EnCode = F_EnCode;
            info.F_Page = F_Page;
            info.F_GridId = F_GridId;
            info.F_ParentId = "0";
            //组织详细表信息
            List<Sys_GridColumnSettingInfo> list = new List<Sys_GridColumnSettingInfo>();
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", F_Id, SqlOperator.Equal);
            var data = BLLFactory<Sys_GridColumnSetting>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            foreach (Sys_GridColumnSettingInfo model in data)
            {
                model.F_Id = Guid.NewGuid().ToString();
                model.F_CreatorTime = DateTime.Now;
                model.F_CreatorUserId = info.F_CreatorUserId;
                model.F_ParentId = info.F_Id;
                model.F_Page = info.F_Page;
                model.F_GridId = info.F_GridId;
                list.Add(model);
            }
            BLLFactory<Sys_GridColumnSetting>.Instance.Copys(info, list);
            return Content(JsonAppHelper.ToJson(true));
        }



        //protected override ResultModel OnBeforeSubmitForm(Sys_GridColumnSettingInfo info)
        //{
        //    ResultModel result = new ResultModel();
        //    result.bSuccess = true;
        //    info.F_DataUrl = "/Areas/SystemManage/Content/js/Module/Index_gridList.js";
        //    return result;
        //}

        //protected override ResultModel OnAfterSubmitForm(Sys_GridColumnSettingInfo info)
        //{
        //    ResultModel result = new ResultModel();
        //    result.bSuccess = true;
        //    if (info.F_ParentId.Equals("0"))
        //    {
        //        //如果是第一层节点，则不生成文件
        //        return result;
        //    }
        //    //根据info的父节点,取数据库获取所有父节点对应的子节点
        //    SearchCondition condition = new SearchCondition();
        //    condition.AddCondition("F_ParentId", info.F_ParentId, SqlOperator.Equal);
        //    List<Sys_GridColumnSettingInfo> columnLists = baseBLL.Find(GetConditionStr(condition), " Order By F_SortCode ");

        //    List<GridColumnEntity> list = new List<GridColumnEntity>();
        //    //循环组织节点
        //    foreach (Sys_GridColumnSettingInfo columnInfo in columnLists)
        //    {
        //        //构建列对象
        //        GridColumnEntity column = new GridColumnEntity();
        //        column.label = columnInfo.F_Label;
        //        column.name = columnInfo.F_Name;
        //        column.formatoptions = columnInfo.F_Formatoptions;
        //        column.formatter = columnInfo.F_Formatter;
        //        if (columnInfo.F_Hidden)
        //        {
        //            column.hidden = columnInfo.F_Hidden;
        //        }
        //        if (columnInfo.F_Key)
        //        {
        //            column.key = columnInfo.F_Key;
        //        }
        //        column.width = columnInfo.F_Width;
        //        column.align = columnInfo.F_Align;
        //        list.Add(column);
        //    }
        //    string path = Server.MapPath(info.F_DataUrl);
        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
        //    {
        //        sw.Write(JsonAppHelper.ToJson(list));
        //    }
        //    return result;
        //}
    }
}
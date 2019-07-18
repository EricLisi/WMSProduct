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
using System.Data;

namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{

    public class RuleDeatilController : BusinessController<SYS_BarcodeSettingDetail, SYS_BarcodeSettingDetailInfo>
    {


        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        /// <returns></returns>
        public ActionResult DeleteForm2(string keyValue)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", keyValue, SqlOperator.Equal);
            BLLFactory<SYS_BarcodeSettingDetail>.Instance.deleteDeatail(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 根据主键ID查询子表关联数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetFormJson1(string keyValue)
        {

            // 通过主表ID 获取下方所有子表ID
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", keyValue, SqlOperator.Equal, true, "g");
            var detailList = BLLFactory<SYS_BarcodeSettingDetail>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            return Content(JsonAppHelper.ToJson(detailList));

        }


        /// <summary>
        /// 删除子表信息
        /// </summary>
        /// <param name="keyValue"></param>
        public ActionResult DeleteFrom1(string keyValue)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_Id", keyValue, SqlOperator.Equal);
            BLLFactory<SYS_BarcodeSettingDetail>.Instance.deleteId(keyValue);
            return Success("删除成功");
        }



    }
}
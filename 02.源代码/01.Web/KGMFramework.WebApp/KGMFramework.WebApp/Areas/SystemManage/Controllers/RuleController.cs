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
    public class RuleController : BusinessController<SYS_BarcodeSettingMain, SYS_BarcodeSettingMainInfo>
    {


        /// <summary>
        /// 删除主子表数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        /// <returns></returns>
        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            BLLFactory<SYS_BarcodeSettingMain>.Instance.Delete(keyValue, bLogicDelete);
            return Success("删除成功");
        }


        /// <summary>
        /// 批量增加主子表
        /// </summary>
        /// <param name="info"></param>
        /// <param name="body"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult submitFormMuti(SYS_BarcodeSettingMainInfo info, string dInfo, string keyValue)
        {

            List<SYS_BarcodeSettingDetailInfo> list = JsonAppHelper.ToObject<List<SYS_BarcodeSettingDetailInfo>>(dInfo);
            if (!string.IsNullOrEmpty(keyValue))
            {
                info.F_Id = keyValue;
                info.F_LastModifyTime = DateTime.Now;
                info.F_LastModifyUserId = CurrentUser.F_Account;
            }
            else
            {
                info.F_CreatorTime = DateTime.Now;
                info.F_CreatorUserId = CurrentUser.F_Account;
                info.F_Id = Guid.NewGuid().ToString();
            }


            BLLFactory<SYS_BarcodeSettingMain>.Instance.Save(info, list);
            return Success("操作成功");
        }




    }
}
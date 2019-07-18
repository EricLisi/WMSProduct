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

namespace KGMFramework.WebApp.Areas.SystemSecurity.Controllers
{
    public class DbBackupController : BusinessController<Sys_DbBackup, Sys_DbBackupInfo>
    {
        public override ActionResult Form()
        {
            ViewBag.DBName = "KGM_CollaborativePlatform";
            return base.Form();
        }

        public override ActionResult SubmitForm(Sys_DbBackupInfo info, string keyValue)
        {
            info.F_FilePath = Server.MapPath("~/Resource/DbBackup/" + info.F_FileName + ".bak");
            info.F_FileName = info.F_FileName + ".bak";
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
            }
            BLLFactory<Sys_DbBackup>.Instance.BackUpDB(info);
            return Success("操作成功");
        }

        /// <summary>
        /// 下载备份
        /// </summary>
        /// <param name="keyValue"></param>
        [HttpGet]
        public void DownloadBackup(string keyValue)
        {
            var data = baseBLL.FindByID(keyValue);
            string filename = Server.UrlDecode(data.F_FileName);
            string filepath = Server.MapPath(data.F_FilePath);
            if (FileDownHelper.FileExists(filepath))
            {
                FileDownHelper.DownLoadold(filepath, filename);
            }
        }
    }
}
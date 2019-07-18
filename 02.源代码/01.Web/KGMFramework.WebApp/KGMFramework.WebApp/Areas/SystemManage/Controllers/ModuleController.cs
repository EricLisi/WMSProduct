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
    public class ModuleController : BusinessController<Sys_Module, Sys_ModuleInfo>
    {
        public ActionResult Icon()
        {
            return View();
        }
    }
}
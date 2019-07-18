using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KGMFramework.WebApp.Controllers;

namespace KGMFramework.WebApp.Areas.SystemSecurity.Controllers
{
    public class ServerMonitoringController : BaseController
    {
        /// <summary>
        /// 默认的视图控制方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}

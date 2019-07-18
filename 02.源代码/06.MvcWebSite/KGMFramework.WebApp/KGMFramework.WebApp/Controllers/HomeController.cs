using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            if (this.CurrentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.UserName = this.CurrentUser.F_RealName;
            ViewBag.UserId = this.CurrentUser.F_Id;
            ViewBag.Title = "进销存管理系统";

            return View();

        }

        public ActionResult Default()
        {
            return View();
        }
    }
}
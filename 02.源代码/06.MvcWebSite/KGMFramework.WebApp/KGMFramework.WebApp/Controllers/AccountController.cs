using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Library;
using System.Data;

namespace KGMFramework.WebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult LoginSystem()
        {
            string username = Request["username"];
            string password = Request["password"];
            CommonResult result = CheckUserInfo(username, password);

            return Json(result);

        }

        /// <summary>
        /// 对用户登录的操作进行验证
        /// </summary>
        /// <param name="username">用户账号</param>
        /// <param name="password">用户密码</param> 
        /// <returns></returns>
        private CommonResult CheckUserInfo(string username, string password)
        {
            CommonResult result = new CommonResult();

            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    result.Success = false;
                    result.ErrorMessage = "用户名不能为空";
                }
                else
                {
                    LoginModel model = new LoginModel();
                    model.Account = username;
                    model.Password = DESEncrypt.Encrypt(password);
                    model.LoginSystem = "";
                    model.IPAddress = Net.Ip;
                    model.IPAddressName = Net.GetLocation(model.IPAddress);
                    DataSet ds = BLLFactory<Sys_User>.Instance.LoginSystem(model);

                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["bSuccess"]))
                    {
                        result.Success = true;
                        result.Message = JsonHelper.ToJson(ds);
                        Session["UserInfo"] = JsonAppHelper.ToList<Sys_UserInfo>(JsonAppHelper.ToJson(ds.Tables[0]))[0];
                    }
                    else
                    {
                        result.Success = false;
                        result.ErrorMessage = ds.Tables[0].Rows[0]["errorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }

        public ActionResult Login()
        {
            if (Session["UserInfo"] == null)
            {
                ViewBag.Title = "进销存管理系统-登录";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
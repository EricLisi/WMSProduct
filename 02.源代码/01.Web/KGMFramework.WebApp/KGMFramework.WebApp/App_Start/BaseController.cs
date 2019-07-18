using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Net.Mime;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Runtime.Caching;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGM.Framework.Commons;

namespace KGMFramework.WebApp.Controllers
{
    public class BaseController : Controller
    {
        #region 属性变量

        /// <summary>
        /// 当前登录的用户属性
        /// </summary>
        public Sys_UserInfo CurrentUser = null;
        public DataSet LoginInfo = null; 
        #endregion 

        #region 异常处理及记录
        /// <summary>
        /// 重新基类在Action执行之前的事情
        /// </summary>
        /// <param name="filterContext">重写方法的参数</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext); 

            var user = Session["UserInfo"] as Sys_UserInfo;
            if (user == null)
            {
                Response.Redirect("/Account/Login");//如果用户为空跳转到登录界面
            }
            else
            {
                CurrentUser = user;
            } 
        }

        /// <summary>
        /// 覆盖基类控制器的异常处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is MyDenyAccessException)
            {
                base.OnException(filterContext);

                //自定义非授权的异常处理，可记录用户操作

                // 当自定义显示错误 mode = On，显示友好错误页面
                if (filterContext.HttpContext.IsCustomErrorEnabled)
                {
                    filterContext.ExceptionHandled = true;
                    this.View("Error").ExecuteResult(this.ControllerContext);
                    Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }
            else
            {
                base.OnException(filterContext);
                LogTextHelper.Error(filterContext.Exception);//错误记录

                // 当自定义显示错误 mode = On，显示友好错误页面
                if (filterContext.HttpContext.IsCustomErrorEnabled)
                {
                    filterContext.ExceptionHandled = true;
                    this.View("Error").ExecuteResult(this.ControllerContext); 
                }
            }
        }
        #endregion


        /// <summary>
        /// 将searchcondition对象转换为字符串
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        protected virtual string GetConditionStr(SearchCondition condition)
        {
            return condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty).Replace("Where (1=1)", " ( 1 = 1 ) ");
        }


    }
}
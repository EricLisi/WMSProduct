using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using KGMFramework.WebApp.Library;
using KGM.Framework.Commons;

namespace KGMFramework.WebApp.WebApi
{
    /// <summary>
    /// 程序错误处理句柄
    /// </summary>
    public class WebApiExceptionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 异常过滤处理
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {
                return;
            }
            base.OnActionExecuted(actionExecutedContext);
            //写日志
            LogTextHelper.Error(actionExecutedContext.Exception);
            // 重新封装回传格式
            AjaxResult result = new AjaxResult { state = ResultType.error.ToString(), message = actionExecutedContext.Exception.ToString() };
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, result);
        }

        /// <summary>
        /// 获取Request参数
        /// </summary>
        /// <param name="s"></param>
        private string GetRequestParms(Stream s)
        {
            if (s == null || s.Length == 0)
            {
                return string.Empty;
            }
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            return Encoding.UTF8.GetString(b);
        }
    }
}
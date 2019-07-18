using KGMFramework.WebApp.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace KGMFramework.WebApp.WebApi
{
    /// <summary>
    /// JWT认证
    /// </summary>
    public class WebApiAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 认证方式
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {

                //前端请求api时会将token存放在名为"auth"的请求头中
                var authHeader = from h in actionContext.Request.Headers where h.Key == ConstValue.TOKEN_HEADER select h.Value.FirstOrDefault();

                //没有头部标识
                if (authHeader == null)
                {
                    throw new ApplicationException("没有报文头信息");
                }
                //获取传输过来的token
                string token = authHeader.FirstOrDefault().Substring(6).Trim();
                //token为空 返回false
                if (string.IsNullOrEmpty(token))
                {
                    throw new ApplicationException("没有token信息");
                }

                Dictionary<string, object> dict = JWTTokenHelper.AnalyzeToken(token); 


                //判断当前token与数据库内的是否一致,如果不一致，也报错
                //var userToken = BLLFactory<SysUsertoken>.Instance.FindByID(dict[AppConst.JWT_SUB_KEY]);
                //if (userToken == null || !userToken.Token.Equals(token))
                //{
                //    throw new ApplicationException("token已经失效");
                //}

                //将用户信息存放起来，供后续调用
                actionContext.RequestContext.RouteData.Values.Add(ConstValue.TOKEN_HEADER, dict);

                return true;
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                return false;
            }
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

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message"></param>
        private void WriteLog(string message)
        {
            //LogModel logger = new LogModel();
            //logger.logContent = message;//信息
            //logger.method = HttpContext.Current.Request.HttpMethod;//方法
            //logger.parms = GetRequestParms(HttpContext.Current.Request.InputStream);//传入参数  
            //logger.url = HttpContext.Current.Request.Path;//调用方法

            ////写日志
            //AppUtil.WriteLog(logger);
        }
    }
}
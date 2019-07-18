using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KGMFramework.WebApp.Controllers
{
    public class APIController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        private string GetConditionStr(SearchCondition condition)
        {
            return condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty).Replace("Where (1=1)", " ( 1 = 1 ) ");
        }
        /// <summary>
        /// 登录获取ToKen
        /// </summary>
        /// <param name="logion"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetAuthToken(LogionModel logion)
        {

            SearchCondition search = new SearchCondition();
            search.AddCondition("F_Account", logion.Account, SqlOperator.Equal);
            search.AddCondition("F_PassWord", logion.PassWord, SqlOperator.Equal);
            Sys_UserInfo user = BLLFactory<Sys_User>.Instance.FindSingle(GetConditionStr(search));
            if (user != null)
            {
                return JWTTokenHelper.GetToken(user.F_Account, user.F_IsAdministrator ?? false);
            }
            return "账号或者密码不正确";
        }
 


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
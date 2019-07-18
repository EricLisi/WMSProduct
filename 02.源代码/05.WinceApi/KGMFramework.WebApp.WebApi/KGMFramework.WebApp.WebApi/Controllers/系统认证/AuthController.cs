using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.WebApi.Models;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using KGM.Framework.Commons;

namespace KGMFramework.WebApp.WebApi.Controllers
{
    /// <summary>
    /// 系统认证模块
    /// </summary> 
    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// 获取注册序号
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetRegInfo")]
        public string GetRegInfo()
        {
            return HardwareHelper.GetMacAddress();
        }

        /// <summary>
        /// 获取用户Token 系统登录
        /// </summary>
        /// <param name="loginModel">登录用户</param>
        /// <returns>成功返回token值 失败返回错误信息</returns>
        [HttpPost, Route("LoginSystem")]
        public async Task<KgmApiResultEntity> LoginSystem([FromBody]LoginSystemModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Password))
            {
                loginModel.Password = string.Empty;
            }
            KgmApiResultEntity result = await loginSystemAsync(loginModel);
            return result;
        }


        #region 系统注册相关方法
        /// <summary>
        /// 判断是否注册
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private bool bRegister(out string info)
        {
            info = string.Empty;
            //读取MAC地址
            string macAddress = HardwareHelper.GetMacAddress();
            //配置文件中的MAC地址
            string appAddress = null;

            if (string.IsNullOrEmpty(macAddress))
            {
                info = "系统信息获取失败!";
                return false;
            }

            //读取配置文件中的MAC地址
            appAddress = System.Configuration.ConfigurationManager.AppSettings["regCode"];
            if (string.IsNullOrEmpty(appAddress))
            {
                info = "获取注册信息失败,请先注册!";
                return false;
            }

            //比对信息是否一致
            string[] myAddress = null;
            //反序列化
            try
            {
                myAddress = DESEncrypt.Decrypt(appAddress).Split('|'); //EncodeHelper.DecryptString(appAddress, true).Split('|');
            }
            catch
            {
                info = "系统注册错误，注册码不正确!";
                return false;
            }
            if (!myAddress[0].Equals(macAddress))
            {
                info = "系统注册错误，注册码不正确!";
                return false;
            }

            if (myAddress.Length > 1 && !myAddress[1].Trim().Equals(string.Empty))
            {
                if (DateTime.Now.CompareTo(Convert.ToDateTime(myAddress[1])) > 0)
                {
                    //判断是否过期
                    info = "当前注册已到期,请联系供应商!";
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 获取令牌的方法
        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="loginModel">登录对象</param>
        /// <returns></returns>
        private async Task<KgmApiResultEntity> loginSystemAsync(LoginSystemModel loginModel)
        {
            KgmApiResultEntity result = new KgmApiResultEntity();//返回对象 
            result.result = false;
            result.message = "";

            string errorInfo = string.Empty;
            if (!bRegister(out errorInfo))
            {
                result.result = false;
                result.message = errorInfo;
                return result;
            }

            Sys_UserInfo loginResult;//登录对象
            bool bAdmin = false;
            if (loginModel.Account.Equals(ConstValue.KGMADMIN_USERNAME) && loginModel.Password.Equals(ConstValue.KGMADMIN_PASSWORD))
            {
                //超级管理员
                loginResult = new Sys_UserInfo();
                loginResult.F_Id = ConstValue.KGMADMIN_USERID;
                loginResult.F_UserPassword = ConstValue.KGMADMIN_PASSWORD;
                loginResult.F_RealName = ConstValue.KGMADMIN_USERNAME;
                bAdmin = true;
            }
            else
            {
                SearchCondition condition = new SearchCondition();
                condition.AddCondition("F_Account", loginModel.Account, SqlOperator.Equal);
                loginResult = BLLFactory<Sys_User>.Instance.FindSingle(condition.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty));
            }


            if (loginResult == null)
            {
                SaveLoginLog(loginModel.Account, string.Empty, loginModel.LoginSystem.ToString(), false, "用户名不存在!");
                result.result = false;
                result.message = "用户名不存在!";
            }
            else if (!loginResult.F_UserPassword.Equals(DESEncrypt.Encrypt(loginModel.Password)))
            {
                SaveLoginLog(loginModel.Account, string.Empty, loginModel.LoginSystem.ToString(), false, "用户名与密码不匹配!");
                result.result = false;
                result.message = "用户名与密码不匹配!";
            }
            else
            {
              
                    string token = "";//token 
                    //生成token
                    token = await JWTTokenHelper.GetTokenAsync(loginResult.F_Id, loginModel.LoginSystem, bAdmin);
                    SaveLoginLog(loginResult.F_Account, loginResult.F_NickName, loginModel.LoginSystem.ToString(), true, "登录成功");
                    result.result = true;
                    result.message = token;
                
            }

            return result;
        }

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="nickname">昵称</param>
        /// <param name="loginSys">登录系统</param>
        /// <param name="result">结果</param>
        /// <param name="desc">结果描述</param>
        private void SaveLoginLog(string account, string nickname, string loginSys, bool result, string desc)
        {
            //记录登录日志
            Sys_LogInfo log = new Sys_LogInfo();
            log.F_Date = DateTime.Now;
            log.F_Account = account;
            log.F_NickName = nickname;
            log.F_Type = "API登录";
            log.F_IPAddress = Net.Ip;
            log.F_IPAddressName = Net.GetLocation(log.F_IPAddress);
            log.F_ModuleId = string.Empty;
            log.F_ModuleName = loginSys.Equals("1") ? "App登录" : "系统登录";
            log.F_Result = result;
            log.F_Description = desc;
            log.F_CreatorTime = DateTime.Now;
            log.F_CreatorUserId = loginSys;

            BLLFactory<Sys_Log>.Instance.Insert(log);

        }
        #endregion
    }
}

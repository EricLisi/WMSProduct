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
using System.Security.Cryptography;
using System.Text;

namespace KGMFramework.WebApp.WebApi.Controllers
{
    /// <summary>
    /// 系统登录模块
    /// </summary> 
    [RoutePrefix("api/User")]
    public class UserController : BaseController<Sys_User, Sys_UserInfo>
    {
        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("GetCurrentUser")]
        public async Task<string> GetCurrentUser(LoginModel model)
        {
            KgmApiResultEntity result = new KgmApiResultEntity();//返回对象
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_Account", model.Account, SqlOperator.Equal);
            Sys_UserInfo loginResult = BLLFactory<Sys_User>.Instance.FindSingle(condition.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty));

            if (loginResult == null)
            {
                result.result = false;
                result.message = "用户名不存在!";
            }
            else if (!loginResult.F_UserPassword.Equals(DESEncrypt.Encrypt(model.Password)))
            {
                result.result = false;
                result.message = "用户名与密码不匹配!";
            }
            else
            {
                bool isadmin = false;
                if (loginResult.F_EnabledMark==false)
                {
                    result.result = false;
                    result.message = "该用户已被禁用，请联系管理员启用后再进行登录!";
                }
                else
                {
                    if (loginResult.F_IsAdministrator == true)
                    {
                        isadmin = true;
                    }
                    //生成token
                    var token = await JWTTokenHelper.GetTokenAsync(loginResult.F_Id, "0", isadmin);
                    var id = currentUserId;
                    result.result = true;
                    result.message = token;
                }
               
            }

  
            return JsonAppHelper.ToJson(new { status = result.result, token = result.message, User = loginResult });
        }
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Text")]
        public async Task<string> Text()
        {
            return await Task.Run(() =>
            {
                return "ok";
            });

        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetUserById/{Id}")]
        public async Task<Sys_UserInfo> GetUser(string Id)
        {
            return await Task.Run(() =>
            {
                var user = BLLFactory<Sys_User>.Instance.FindByID(Id);
                if (user != null)
                {
                    Sys_OrganizeInfo organizeInfo = BLLFactory<Sys_Organize>.Instance.FindByID(user.F_OrganizeId);
                    Sys_OrganizeInfo DepInfo = BLLFactory<Sys_Organize>.Instance.FindByID(user.F_DepartmentId);
                    Sys_RoleInfo roleInfo = BLLFactory<Sys_Role>.Instance.FindByID(user.F_RoleId);
                    Sys_DutyInfo dutyInfo = BLLFactory<Sys_Duty>.Instance.FindByID(user.F_DutyId);
                    Mst_WarehouseInfo warehouseInfo = BLLFactory<Mst_Warehouse>.Instance.FindByID(user.F_WarehouseId);

                    user.F_OrganizeName = organizeInfo == null ? "" : organizeInfo.F_FullName;
                    user.F_DepartmentName = DepInfo == null ? "" : DepInfo.F_FullName;
                    user.F_RoleName = roleInfo == null ? "" : roleInfo.F_FullName;
                    user.F_DutyName = dutyInfo == null ? "" : dutyInfo.F_FullName;
                    user.F_WarehouseName = warehouseInfo == null ? "" : warehouseInfo.F_FullName;

                }



                return user;
            });
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("UpdatePassWord")]
        public async Task<string> UpdatePassWord([FromBody]UserFiledEntity model) {
            return await Task.Run(() => {
                var user = BLLFactory<Sys_User>.Instance.FindByID(model.keyValue);
                if (user==null)
                {
                    return "找不到当前用户";
                }
                user.F_UserPassword= Encrypt(model.userPassword);
                if (BLLFactory<Sys_User>.Instance.Update(user, user.F_Id))
                {
                    return "修改成功";
                }
                return "修改失败";

            });
        }



        #region ========加密========
        private static string DESKey = "myprojectdesencrypt_2016";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
               
            return Encrypt(Text, DESKey);
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion
    }
}

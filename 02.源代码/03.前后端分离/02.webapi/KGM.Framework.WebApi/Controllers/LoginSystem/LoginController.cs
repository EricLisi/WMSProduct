using KGM.Framework.Application.Dtos;
using KGM.Framework.Application.Services;
using KGM.Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGM.Framework.WebApi.Controllers
{
    /// <summary>
    /// 用户登录接口
    /// </summary> 
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region 依赖注入
        IUserService _service;//用户 
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">用户服务</param> 
        public LoginController(IUserService service)
        {
            this._service = service;
        }
        #endregion



        /// <summary>
        /// 获取认证token
        /// </summary>
        /// <param name="LoginDto">登录对象</param>
        /// <returns></returns>
        [HttpPost, Route("LoginSystem")]
        public async Task<IActionResult> GetAuthToken(UserLoginDto LoginDto)
        {
            List<SearchCondition> condition = new List<SearchCondition>();
            condition.Add(new SearchCondition
            {
                Filed = "Account",
                Value = LoginDto.Account,
                Operation = CommonEnum.ConditionOperation.Equal
            });
            condition.Add(new SearchCondition
            {
                Filed = "Password",
                Value = SecurityHelper.MD5Encrypt32(LoginDto.Password),
                Operation = CommonEnum.ConditionOperation.Equal
            });
            condition.Add(new SearchCondition
            {
                Filed = "EnabledMark",
                Value = "1",
                Operation = CommonEnum.ConditionOperation.Equal
            });


            var userlist = await _service.QueryAsync<UserSingleDto>(condition);
            if (userlist == null || userlist.Count == 0)
            {
                return Ok(new { Status = false, Message = "用户名或密码不正确" });
            }
            return Ok(new
            {
                status = true,
                message = await AuthorizeConfig.Instance().GenerateTokenAsync(userlist[0].Id, LoginDto.Account),
                user = userlist[0]
            });
        }




        /// <summary>
        /// 获取认证token
        /// </summary>
        /// <param name="user">登录对象</param>
        /// <returns></returns>
        [HttpPost, Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(UserGetAuthToken user)
        {
            return Ok(new
            {
                status = true,
                message = await AuthorizeConfig.Instance().GenerateTokenAsync(user.Id, user.Account)
            });
        }


        ///// <summary>
        ///// 获取用户可登陆平台
        ///// </summary>
        ///// <param name="username"></param>
        ///// <returns></returns>
        //[HttpGet("GetPlat")]
        //public async Task<IActionResult> GetPlat(string username)
        //{
        //    var role = await _service.QuerySingleAsync(u => u.Account.Equals(username));
        //    List<PlatModel> platModels = new List<PlatModel>();
        //    if (role != null)
        //    {
        //        var roleplatform = await _rpservice.QueryAsync(u => u.RoleId.Equals(role.RoleId));
        //        for (int i = 0; i < roleplatform.Count; i++)
        //        {
        //            var platform = await _pservice.QuerySingleAsync(u => u.Id.Equals(roleplatform[i].PlatId));
        //            PlatModel platModel = new PlatModel();
        //            platModel.F_Id = platform.Id;
        //            platModel.F_EnCode = platform.EnCode;
        //            platModel.F_FullName = platform.FullName;
        //            platModel.F_HomePageUrl = platform.HomePageUrl;
        //            platModels.Add(platModel);
        //        }
        //    }
        //    return Ok(platModels);
        //}
    }
}
using System;
using System.Collections.Generic; 
using System.Text;

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// 返回对象
    /// </summary>
 
    public class LoginSystemModel
    {
        /// <summary>
        /// 登录系统
        /// </summary>
        public enum LoginSystemEnum
        {
            后台管理系统 = 0,
            移动端系统 = 1
        }

        /// <summary>
        /// 登录用户
        /// </summary> 
        public string Account { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary> 
        public string Password { get; set; }
        /// <summary>
        /// 登录系统
        /// </summary> 
        public LoginSystemEnum LoginSystem { get; set; }
    }
}

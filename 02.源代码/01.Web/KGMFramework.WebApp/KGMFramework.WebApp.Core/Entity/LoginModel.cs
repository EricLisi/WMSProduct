using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Entity
{
    public class LoginModel
    {
        public string Account;//登录用户
        public string Password;//登录密码
        public string LoginSystem;//登录系统(暂时不用)
        public string IPAddress;//IP地址
        public string IPAddressName;//IP地址名
    }
}

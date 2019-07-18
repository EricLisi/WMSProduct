using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    public class UserFiledEntity
    {
        /// <summary>
        /// 用户密码
        /// </summary>
        public string userPassword { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public string keyValue { get; set; }
    }
}
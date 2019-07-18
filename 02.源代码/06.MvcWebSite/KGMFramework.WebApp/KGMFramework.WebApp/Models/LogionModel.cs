using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.Models
{
    /// <summary>
    /// 打印对象
    /// </summary>
    public class LogionModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string PassWord { get; set; }

  
    }
}
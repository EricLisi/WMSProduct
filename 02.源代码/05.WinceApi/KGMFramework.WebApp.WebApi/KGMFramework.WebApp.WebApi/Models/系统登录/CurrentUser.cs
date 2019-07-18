using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 当前登录用户
    /// </summary>
    [DataContract]
    public class CurrentUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string userName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string realName { get; set; }
    }
}
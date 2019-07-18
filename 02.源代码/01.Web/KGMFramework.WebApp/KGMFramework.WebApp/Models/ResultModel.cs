using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.Models
{
    public class ResultModel
    {
        /// <summary>
        /// 成功标识
        /// </summary>
        [DataMember]
        public bool bSuccess { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [DataMember]
        public string message { get; set; }
    }
}
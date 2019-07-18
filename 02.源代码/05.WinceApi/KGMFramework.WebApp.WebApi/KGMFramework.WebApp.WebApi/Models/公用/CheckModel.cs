using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    public class CheckModel
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [DataMember]
        public string F_Id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public int state { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [DataMember]
        public string msg { get; set; }
    }
}
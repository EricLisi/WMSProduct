using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 转移主子表审核单据对象
    /// </summary>
    [DataContract]
    public class VerifyOrderModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public string F_Id { get; set; }

        /// <summary>
        /// 登录人
        /// </summary>
        [DataMember]
        public string userName { get; set; }

       /// <summary>
        /// 单据类型
        /// </summary>
        [DataMember]
        public string orderType { get; set; }


        /// <summary>
        /// 存放地点
        /// </summary>
        [DataMember]
        public string Owner { get; set; }
    }
}
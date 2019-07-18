using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 获取NC销售出库单条件对象
    /// </summary>
    public class GetNCOrderModel
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [DataMember]
        public string orderNo { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [DataMember]
        public string dSDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [DataMember]
        public string dEDate { get; set; }
    }
}
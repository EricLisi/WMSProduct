using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.Areas.WmsManage.Model
{
    /// <summary>
    /// 入库单过滤对象
    /// </summary>
    public class InStockFilter
    {
        /// <summary>
        /// 单据号
        /// </summary>
        public string F_EnCode { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string F_Supplier { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string F_Warehouse { get; set; }

        /// <summary>
        /// 单据状态
        /// </summary>
        public string F_Status { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public string F_SDate { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        public string F_EDate { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.Areas.WmsManage.Model
{
    /// <summary>
    /// 入库单过滤对象
    /// </summary>
    public class PositionFilter
    {
        /// <summary>
        ///编码
        /// </summary>
        public string F_EnCode { get; set; }

        /// <summary>
        /// 名称        
        /// </summary>
        public string F_FullName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string F_EnabledMark { get; set; }
    }
}
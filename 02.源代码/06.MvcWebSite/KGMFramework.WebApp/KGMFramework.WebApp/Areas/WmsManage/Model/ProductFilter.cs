using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.Areas.WmsManage.Model
{
    /// <summary>
    /// 入库单过滤对象
    /// </summary>
    public class ProductFilter
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
        /// 代码        
        /// </summary>
        public string F_ShortCode { get; set; }
        /// <summary>
        /// 别名        
        /// </summary>
        public string F_ShortName { get; set; }
        /// <summary>
        /// 品牌        
        /// </summary>
        public string F_Brand { get; set; }
        /// <summary>
        /// 规格        
        /// </summary>
        public string F_Standard { get; set; }
    }
}
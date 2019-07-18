using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 打印对象
    /// </summary>
    public class PrintLabelModel
    {

        /// <summary>
        /// 客户编码
        /// </summary>
        public virtual string CCCusCode { get; set; }

        /// <summary>
        /// 物料型号
        /// </summary>
        public virtual string MaterialType { get; set; }
    }
}
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
    public class PrintModel
    {
        /// <summary>
        /// 文件模板名
        /// </summary>
        public virtual string fileName { get; set; }

        /// <summary>
        /// 数据源名
        /// </summary>
        public virtual string sourceName { get; set; }

        /// <summary>
        /// 数据库数据源
        /// </summary>
        public virtual DataTable sourceData { get; set; }
    }
}
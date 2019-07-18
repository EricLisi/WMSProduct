using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.Models
{

    public class AdvSearchEntity
    {

        /// <summary>
        /// And Or
        /// </summary>
        public string F_condition { get; set; }

        /// <summary>
        /// 查询字段
        /// </summary>
        public string F_searchFiled { get; set; }

        /// <summary>
        /// 查询的值
        /// </summary>
        public string F_fvalue { get; set; }

        /// <summary>
        /// = <> ..
        /// </summary>
        public string F_type { get; set; } 

    }
}
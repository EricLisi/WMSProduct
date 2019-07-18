using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 根据值过滤数据的对象
    /// </summary>
    public class KeyFiledEntity
    {
        /// <summary>
        /// 值 多个值and的关系 使用|分隔
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 字段名 or的关系使用/分隔 多个值and的关系 使用|分隔
        /// </summary>
        public string searchFiled { get; set; }
    }
}
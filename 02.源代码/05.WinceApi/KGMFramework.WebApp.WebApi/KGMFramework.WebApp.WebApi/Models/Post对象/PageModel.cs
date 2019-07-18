using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 分页对象
    /// </summary>
    [DataContract]
    public class PageModel
    { 
        /// <summary>
        /// 当前显示第几页
        /// </summary>
        [DataMember]
        public int pageIndex { get; set; }

        /// <summary>
        /// 一页显示多少行
        /// </summary>
        [DataMember]
        public int pageSize { get; set; } 
    }
}
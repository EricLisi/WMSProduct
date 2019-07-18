using KGM.Framework.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 查询对象
    /// </summary>
    [DataContract]
    public class SearchEntity
    {  
        /// <summary>
        /// 字段
        /// </summary>
        [DataMember]
        public string filed { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [DataMember]
        public string value { get; set; }
        /// <summary>
        /// 操作符
        /// </summary>
        [DataMember]
        public SqlOperator oper { get; set; }
    }
}
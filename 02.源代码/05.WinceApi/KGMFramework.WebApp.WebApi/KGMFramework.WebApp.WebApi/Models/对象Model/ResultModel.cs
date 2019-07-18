using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 树形结构图
    /// </summary>
    [DataContract]
    public class ResultModel
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [DataMember]
        public string r { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        [DataMember]
        public string msg { get; set; }
 
    }
}
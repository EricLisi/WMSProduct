using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 查询字段
    /// </summary>
    [DataContract]
    public class SearchModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [DataMember]
        public string UserId { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        [DataMember]
        public string orderNo { get; set; }
        /// <summary>
        /// 单据类型(PI 入库,SO 出库,CW 盘点)
        /// </summary>
        [DataMember]
        public string orderType { get; set; }
        /// <summary>
        /// 查询集合
        /// </summary>
        [DataMember]
        public string list { get; set; }
       
    }
}
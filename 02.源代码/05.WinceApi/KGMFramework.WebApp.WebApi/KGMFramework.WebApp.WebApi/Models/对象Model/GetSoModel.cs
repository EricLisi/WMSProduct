using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 出库单主子表
    /// </summary>
    [DataContract]
    public class GetSoModel
    {
        /// <summary>
        /// 表头
        /// </summary>
        [DataMember]
        public SO_HeadInfo info { get; set; }
        /// <summary>
        /// 表体
        /// </summary>
        [DataMember]
        public List<SO_BodyInfo>  dInfo{ get; set; }
        

    }
}
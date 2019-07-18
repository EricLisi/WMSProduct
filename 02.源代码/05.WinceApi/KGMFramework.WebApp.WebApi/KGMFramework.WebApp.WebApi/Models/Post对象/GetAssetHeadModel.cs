using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 获取单据表头的对象
    /// </summary>
    [DataContract]
    public class GetAssetHeadModel
    { 
        /// <summary>
        /// 过滤条件
        /// </summary>
        [DataMember]
        public List<SearchEntity> SearchCondition { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        [DataMember]
        public MyEnum.orderType Type { get; set; }

        /// <summary>
        /// 分页对象
        /// </summary>
        [DataMember]
        public KGM.Pager.Entity.PagerInfo pager { get; set; }

    }
}
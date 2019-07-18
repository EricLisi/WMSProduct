using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 单据审核参数对象
    /// </summary>
    [DataContract]
    public class VerifyListEntity
    {
        /// <summary>
        /// 单据id
        /// </summary>
        [DataMember]
        public string orderId;
        /// <summary>
        /// 单据号
        /// </summary>
        [DataMember]
        public string orderNo;
        /// <summary>
        /// 单据类型
        /// </summary>
        [DataMember]
        public string orderType;
        /// <summary>
        /// 用户id
        /// </summary>
        [DataMember]
        public string userId;
        /// <summary>
        /// 公司id
        /// </summary>
        [DataMember]
        public string corpId;
    }
}

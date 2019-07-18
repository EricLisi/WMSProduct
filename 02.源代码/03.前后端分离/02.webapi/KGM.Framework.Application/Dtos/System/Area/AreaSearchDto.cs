using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 地区查询Dto
    /// </summary>
    [DataContract]
    public class AreaSearchDto
    {
        /// <summary>
        /// 账户
        /// </summary>
        [DataMember]
        public string EnCode { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary> 
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary> 
        [DataMember]
        public string NickName { get; set; }
    }
}

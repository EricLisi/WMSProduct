using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KGMFramework.WebApp.Library
{
    /// <summary>
    /// 分页数据对象
    /// </summary>
    [DataContract]
    public class PagerDataEntity<T>
    {
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public int total { get; set; }

        /// <summary>
        /// 当前页数据
        /// </summary>
        [DataMember]
        public List<T> rows { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        [DataMember]
        public int page { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public int records { get; set; }
    }
}

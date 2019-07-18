using System.Runtime.Serialization;

namespace KGMFramework.WebApp.Library
{
    /// <summary>
    /// 分页对象
    /// </summary>
    [DataContract]
    public class PagerEntity
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int currentPageIndex { get; set; }

        /// <summary>
        /// 每页行数
        /// </summary>
        public int pageSize { get; set; }
    }
}

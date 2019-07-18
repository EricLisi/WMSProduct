
namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// 查询对象
    /// </summary> 
    public class SearchEntity
    {
        /// <summary>
        /// 字段
        /// </summary> 
        public string filed { get; set; }
        /// <summary>
        /// 值
        /// </summary> 
        public string value { get; set; }
        /// <summary>
        /// 操作符
        /// </summary> 
        public int oper { get; set; }

        public SearchEntity(string filed,string value,int oper)
        {
            this.filed = filed;
            this.value = value;
            this.oper = oper;
        }
    }
}
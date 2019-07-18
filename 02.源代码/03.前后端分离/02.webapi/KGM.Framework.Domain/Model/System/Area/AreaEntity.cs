using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.ComponentModel;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 地区类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_Area")]
    public class AreaEntity : AggregateRoot
    {
        /// <summary>
        /// 节点
        /// </summary> 
        public string ParentId { get; set; }


        /// <summary>
        /// 编号
        /// </summary> 
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary> 
        public string FullName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string SimpleSpelling { get; set; }

        /// <summary>
        /// 层
        /// </summary>
        public int? Layer { get; set; }
    }
}

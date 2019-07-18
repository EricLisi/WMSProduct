using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 模块类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_ItemsDetail")]
    public class DictionaryDetailEntity : AggregateRoot
    {
        /// <summary>
        /// 节点
        /// </summary> 
        public virtual string ParentId { get; set; }


        /// <summary>
        /// 主表主键
        /// </summary>
        public virtual string ItemId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string ItemCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string ItemName { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        public virtual string SimpleSpelling { get; set; }

        /// <summary>
        /// 默认
        /// </summary>
        public virtual bool? IsDefault { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        public virtual int? Layers { get; set; }
    }

}

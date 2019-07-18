using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 模块类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_Items")]
    public class DictionaryEntity : AggregateRoot
    {
        /// <summary>
        /// 树型
        /// </summary>
        public virtual bool? IsTree { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        public virtual int? Layers { get; set; }
        
        /// <summary>
        /// 父级
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// 数据 详情
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public virtual List<DetailEntity> DetailEntities { get; set; }
        
        #region 用于同一领域内的所有类 均集成Entity
        /// <summary>
        /// 模块按钮 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "Sys_ItemsDetail")]
        public class DetailEntity : Entity
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

            /// <summary>
            /// 模块对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public DictionaryEntity Dictionary { get; set; }
        }
        #endregion
    }

}

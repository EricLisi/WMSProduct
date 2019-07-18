using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;


namespace KGM.Framework.Domain
{
    /// <summary>
    /// 模块按钮 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "MST_OWNER")]
    public class OwnerEntity : AggregateRoot
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        public string Define1 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        public string Define2 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        public string Define3 { get; set; }

        /// <summary>
        /// 客户id
        /// </summary>
        public string CusId { get; set; }
    }
}


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
    [MappingTable(TableName = "MST_POSITION")]
    public class PositionEntity : AggregateRoot
    {

        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 仓库id
        /// </summary>
        public string WhCode { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }


        /// <summary>
        /// 货位类型
        /// </summary>
        public string PosType { get; set; }

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
    }
}

using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "MST_SAVEWAY")]
    public class SaveWayEntity : AggregateRoot
    {

        /// <summary>
        /// 
        /// </summary>
		
        public string EnCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define3 { get; set; }

    }
}

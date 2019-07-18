using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "MST_SETUP")]
    public class SetUpEntity : AggregateRoot
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
		
        public string PreFix { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public int NumberLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public bool IsBatch { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string HavePL { get; set; }

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

using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "InStock_Body")]
    public class InStockBodyEntity : AggregateRoot
    { 
       
        /// <summary>
        /// 
        /// </summary>
		
        public int? RowNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string HeadId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string OrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string WarehouseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string PositionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Batch { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public DateTime? MadeDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string BoxNo { get; set; }

        public decimal? Quantity { get; set; }
        public decimal? InQty { get; set; }
        public decimal? Price { get; set; }
        public string Define1 { get; set; }

        public string Define2 { get; set; }
        public string Define3 { get; set; }
        public string Define4 { get; set; }
        public string Define5 { get; set; }

        public string Define6 { get; set; }
        public string Define7 { get; set; }
        public string Define8 { get; set; }
        public string Define9 { get; set; }
        public string Define10 { get; set; }
    }
}
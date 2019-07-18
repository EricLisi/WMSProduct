using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "InStock_Head")]
    public class InStockHeadEntity : AggregateRoot
    {

        /// <summary>
        /// 
        /// </summary>
        public  string OrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  string ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  string ParentOrderNo { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public  string CustomId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		 
        public  string WarehouseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		 
        public  string SrTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		 
        public  string OwnerId { get; set; }

        public string Maker { get; set; }

        public DateTime? Date { get; set; }

        public string Verifier { get; set; }
        public DateTime? Veridate { get; set; }
        public int? Status { get; set; }
        public decimal? AllPrice { get; set; }
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

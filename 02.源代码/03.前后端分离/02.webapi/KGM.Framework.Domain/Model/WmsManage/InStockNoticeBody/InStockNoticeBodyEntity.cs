using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 仓库类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "InStockNotice_Body")]
    public class InStockNoticeBodyEntity : AggregateRoot
    {


        /// <summary>
        /// 行号
        /// </summary>
		
        public int RowNo { get; set; }

        /// <summary>
        /// 主表Id
        /// </summary>
		
        public string HeadId { get; set; }

        /// <summary>
        /// 单据号
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
        /// 商品Id
        /// </summary>
		
        public string ProductId { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
		
        public string Batch { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
		
        public DateTime MadeDate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
		
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
		
        public decimal Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public decimal Price { get; set; }

        /// <summary>
        /// 自定义项1
        /// </summary>
		
        public string Define1 { get; set; }

        /// <summary>
        /// 自定义项2
        /// </summary>
		
        public string Define2 { get; set; }

        /// <summary>
        /// 自定义项3
        /// </summary>
		
        public string Define3 { get; set; }

        /// <summary>
        /// 自定义项4
        /// </summary>
		
        public string Define4 { get; set; }

        /// <summary>
        /// 自定义项5
        /// </summary>
		
        public string Define5 { get; set; }

        /// <summary>
        /// 自定义项6
        /// </summary>
		
        public string Define6 { get; set; }

        /// <summary>
        /// 自定义项7
        /// </summary>
		
        public string Define7 { get; set; }

        /// <summary>
        /// 自定义项8
        /// </summary>
		
        public string Define8 { get; set; }

        /// <summary>
        /// 自定义项9
        /// </summary>
		
        public string Define9 { get; set; }

        /// <summary>
        /// 自定义项10
        /// </summary>
		
        public string Define10 { get; set; }

        /// <summary>
        /// 箱号
        /// </summary>

        public string BoxNo { get; set; }

    }
}

using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 库存类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "SM_STOCK")]
    public class StockEntity : AggregateRoot
    {
        
        
        public  string  RowId { get; set; }

        
        public  string  WareHouseId { get; set; }

        
        public  string  PositonId { get; set; }

        
        public  string  Barcode { get; set; }

        
        public  string  BoxNo { get; set; }

        
        public  string  ProductSKU { get; set; }

        
        public  string  ProductId { get; set; }

        
        public  string  ProductName { get; set; }

        
        public  string  CustomerId { get; set; }

        
        public  int?  bType { get; set; }

        
        public  string  Cbatch { get; set; }

        
        public  DateTime?  dMDate { get; set; }

        
        public  int?  Qty { get; set; }

        
        public  bool?  bStopFlag { get; set; }

        
        public  double?  Inqty { get; set; }

        
        public  double?  Outqty { get; set; }

        
        public  DateTime?  InDate { get; set; }

        
        public  string  Property { get; set; }

  

    }
}

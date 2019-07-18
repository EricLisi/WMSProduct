using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 仓库类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "DP_DETAIL")]
    public class DPDetailEntity : AggregateRoot
    {

        /// <summary>
        ///  
        /// </summary> 
         public string Province { get; set; }
        /// <summary>
        /// 箱
        /// </summary> 
        public string BoxNo { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary> 
        public string BarCode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary> 
        public string rowID { get; set; }

        /// <summary>
        /// 表头ID
        /// </summary> 
        public string orderNo { get; set; }

        /// <summary>
        /// 单据号類型
        /// </summary> 
        public int? DPType { get; set; }

        /// <summary>
        /// 商品SKU
        /// </summary> 
        public string ProductId { get; set; }
        /// <summary>
        /// 商品SKU
        /// </summary> 
        public string ProductName { get; set; }

        /// <summary>
        /// 數量
        /// </summary> 
        public double qty { get; set; }

        ///<summary>
        /// 裝箱數量
        /// </summary> 
        public double? packqty { get; set; }

        /// <summary>
        /// 已操作数量
        /// </summary> 
        public double? doneqty { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public double? outqty { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public double? backqty { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        public string cbatch { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public DateTime? dMDate { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public DateTime? dVDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BCODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double CODPRICE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double DISCOUNT { get; set; }


        ///<summary>
        /// 自定义项1
        /// </summary>  
        public string Define1 { get; set; }

        ///<summary>
        /// 自定义项2
        /// </summary>  
        public string Define2 { get; set; }

        ///<summary>
        /// 自定义项3
        /// </summary>  
        public string Define3 { get; set; }


        ///<summary>
        /// 自定义项4
        /// </summary>  
        public string Define4 { get; set; }


        ///<summary>
        /// 自定义项5
        /// </summary>  
        public string Define5 { get; set; }

        ///<summary>
        /// 自定义项6
        /// </summary>  
        public string Define6 { get; set; }

        ///<summary>
        /// 自定义项7
        /// </summary>  
        public string Define7 { get; set; }


        ///<summary>
        /// 自定义项8
        /// </summary>  
        public string Define8 { get; set; }

        ///<summary>
        /// 自定义项9
        /// </summary>  
        public string Define9 { get; set; }

        ///<summary>
        /// 自定义项10
        /// </summary>  
        public string Define10 { get; set; }

        ///<summary>
        /// 自定义项11
        /// </summary>  
        public string Define11 { get; set; }


        ///<summary>
        /// 自定义项12
        /// </summary>  
        public string Define12 { get; set; }


        ///<summary>
        /// 自定义项13
        /// </summary>  
        public string Define13 { get; set; }


        ///<summary>
        /// 自定义项14
        /// </summary>  
        public string Define14 { get; set; }


        ///<summary>
        /// 自定义项15
        /// </summary>  
        public string Define15 { get; set; }


        ///<summary>
        /// 自定义项16
        /// </summary>  
        public string Define16 { get; set; }


        ///<summary>
        /// 自定义项17
        /// </summary>  
        public string Define17 { get; set; }


        ///<summary>
        /// 自定义项18
        /// </summary>  
        public string Define18 { get; set; }

        ///<summary>
        /// 自定义项19
        /// </summary>  
        public string Define19 { get; set; }

        ///<summary>
        /// 自定义项20
        /// </summary>  
        public string Define20 { get; set; }
    }
}

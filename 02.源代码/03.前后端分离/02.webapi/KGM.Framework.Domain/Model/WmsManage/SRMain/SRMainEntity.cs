using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 拣货主类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "SR_MAIN")]
    public class SRMainEntity : AggregateRoot
    {

        public string orderNo { get; set; }


        public int orderType { get; set; }


        public int srType { get; set; }


        public string CustomerId { get; set; }


        public string WarehouseId { get; set; }


        public DateTime sendDate { get; set; }


        public string dpNo { get; set; }


        public string backExpComp { get; set; }


        public string backExpNo { get; set; }


        public string cMaker { get; set; }


        public DateTime dDate { get; set; }


        public string cVerify { get; set; }


        public DateTime dVeriDate { get; set; }


        public int status { get; set; }


        public bool isPrint { get; set; }


        public bool isUpLoad { get; set; }


        public string Property { get; set; }

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


        public string Define11 { get; set; }


        public string Define12 { get; set; }


        public string Define13 { get; set; }


        public string Define14 { get; set; }


        public string Define15 { get; set; }


        public string Define16 { get; set; }


        public string Define17 { get; set; }


        public string Define18 { get; set; }


        public string Define19 { get; set; }


        public string Define20 { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
 
        public virtual string WarehouseName { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
 
        public virtual string CustomerName { get; set; }
    }
}

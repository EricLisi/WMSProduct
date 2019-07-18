using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 拣货子类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "SR_Detail")]
    public class SRDetailEntity : AggregateRoot
    {

        public string RowID { get; set; }


        public string autoID { get; set; }


        public string orderNo { get; set; }


        public int DPType { get; set; }


        public string ProductId { get; set; }


        public string cbatch { get; set; }


        public DateTime dMDate { get; set; }


        public DateTime dVDate { get; set; }


        public double qty { get; set; }


        public double doneqty { get; set; }


        public double outqty { get; set; }
    }
}

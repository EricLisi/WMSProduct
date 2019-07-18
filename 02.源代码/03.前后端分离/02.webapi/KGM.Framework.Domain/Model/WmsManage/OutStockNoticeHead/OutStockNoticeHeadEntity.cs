using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 仓库类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "OutStockNotice_Head")]
    public class OutStockNoticeHeadEntity : AggregateRoot
    {
        

        /// <summary>
        /// 单据号
        /// </summary>
		
        public string OrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string CustomerId { get; set; }

        /// <summary>
        /// 
        /// 
        /// </summary>
		
        public string WarehouseId { get; set; }

        /// <summary>
        /// 收发类别Id
        /// </summary>
		
        public string SrTypeId { get; set; }

        /// <summary>
        /// 商品权属Id
        /// </summary>
		
        public string OwnerId { get; set; }

        /// <summary>
        /// 整箱还是散货
        /// </summary>
		
        public string Type { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
		
        public string Maker { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
		
        public DateTime? Date { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
		
        public string Verifier { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
		
        public DateTime? Veridate { get; set; }

        /// <summary>
        /// 单据状态(0 待审核 1 已审核)
        /// </summary>
		
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public decimal AllPrice { get; set; }

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
        /// 发运方式
        /// </summary>
        public string SendType { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public string ExpCompanyId { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string ExpNo { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string ReceivePerson { get; set; }
        /// <summary>
        /// 收件人联系方式
        /// </summary>
        public string ReceivePersonTel { get; set; }
        /// <summary>
        /// 收件人地址
        /// </summary>
        public string ReceiveAddress { get; set; }
        /// <summary>
        /// 是否拣货
        /// </summary>
        public bool? IsPick { get; set; }


    }
}

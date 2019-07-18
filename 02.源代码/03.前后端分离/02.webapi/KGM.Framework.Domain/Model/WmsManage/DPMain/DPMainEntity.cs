using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 仓库类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "DP_MAIN")]
    public class DPMainEntity : AggregateRoot
    {        /// <summary>
             ///  
             /// </summary> 
        public string City { get; set; }
        /// <summary>
        ///  
        /// </summary> 
        public string Province { get; set; }
        /// <summary>
        /// 编码
        /// </summary> 
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary> 
        public string FullName { get; set; }

        /// <summary>
        /// 单据号
        /// </summary> 
        public string OrderNo { get; set; }


        /// <summary>
        /// 单据类型
        /// </summary> 
        public int? OrderType { get; set; }

        ///<summary>
        /// 类型
        /// </summary> 
        public int? Type { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary> 
        public string CustomerId { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary> 
        public string CustomerName { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? sendDate { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int sendType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string sendPerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string sendAddress { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string expCompany { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string postcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string contory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expNo { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Maker { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string Verify { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? VeriDate { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? isLock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? isPack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? isPrint { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool? isUpLoad { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public bool? isWeight { get; set; }

        /// <summary>
        /// 权属
        /// </summary>
        public string Property { get; set; }

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


        ///<summary>
        /// 自定义项20
        /// </summary>  
        public string OFFSHELFFINISHER { get; set; }


        ///<summary>
        /// 自定义项20
        /// </summary>  
        public DateTime? OFFSHELFFINISHTIME { get; set; }

        ///<summary>
        /// 自定义项20
        /// </summary>  
        public string OUTFINISHER { get; set; }

        ///<summary>
        /// 自定义项20
        /// </summary>  
        public DateTime? OUTFINISHTIME { get; set; }


        ///<summary>
        /// 自定义项20
        /// </summary>  
        public string PROVINCE { get; set; }


        ///<summary>
        /// 自定义项20
        /// </summary>  
        public string CITY { get; set; }
    }
}

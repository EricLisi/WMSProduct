using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{ 
    public class OutEntity : AggregateRoot
    {

        /// <summary>
        /// 编码
        /// </summary> 
        public string F_EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary> 
        public string F_FullName { get; set; }

        /// <summary>
        /// 单据号
        /// </summary> 
        public string F_OrderNo { get; set; }


        /// <summary>
        /// 单据类型
        /// </summary> 
        public int? F_OrderType { get; set; }

        ///<summary>
        /// 类型
        /// </summary> 
        public int? F_Type { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary> 
        public string F_CustomerId { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary> 
        public string F_CustomerName { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public string F_WarehouseId { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public string F_WarehouseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? F_arrveDate { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime? F_Date { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string F_Maker { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string F_Verify { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? F_VeriDate { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public int F_Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? F_isLock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? F_isPack { get; set; }


        /// <summary>
        /// 权属
        /// </summary>
        public string F_Property { get; set; }

        ///<summary>
        /// 自定义项1
        /// </summary>  
        public string F_Define1 { get; set; }

        ///<summary>
        /// 自定义项2
        /// </summary>  
        public string F_Define2 { get; set; }

        ///<summary>
        /// 自定义项3
        /// </summary>  
        public string F_Define3 { get; set; }


        ///<summary>
        /// 自定义项4
        /// </summary>  
        public string F_Define4 { get; set; }


        ///<summary>
        /// 自定义项5
        /// </summary>  
        public string F_Define5 { get; set; }

        ///<summary>
        /// 自定义项6
        /// </summary>  
        public string F_Define6 { get; set; }

        ///<summary>
        /// 自定义项7
        /// </summary>  
        public string F_Define7 { get; set; }


        ///<summary>
        /// 自定义项8
        /// </summary>  
        public string F_Define8 { get; set; }

        ///<summary>
        /// 自定义项9
        /// </summary>  
        public string F_Define9 { get; set; }

        ///<summary>
        /// 自定义项10
        /// </summary>  
        public string F_Define10 { get; set; }


        ///<summary>
        /// 自定义项11
        /// </summary>  
        public string F_Define11 { get; set; }


        ///<summary>
        /// 自定义项12
        /// </summary>  
        public string F_Define12 { get; set; }


        ///<summary>
        /// 自定义项13
        /// </summary>  
        public string F_Define13 { get; set; }


        ///<summary>
        /// 自定义项14
        /// </summary>  
        public string F_Define14 { get; set; }


        ///<summary>
        /// 自定义项15
        /// </summary>  
        public string F_Define15 { get; set; }


        ///<summary>
        /// 自定义项16
        /// </summary>  
        public string F_Define16 { get; set; }


        ///<summary>
        /// 自定义项17
        /// </summary>  
        public string F_Define17 { get; set; }


        ///<summary>
        /// 自定义项18
        /// </summary>  
        public string F_Define18 { get; set; }

        ///<summary>
        /// 自定义项19
        /// </summary>  
        public string F_Define19 { get; set; }

        ///<summary>
        /// 自定义项20
        /// </summary>  
        public string F_Define20 { get; set; }



    }
}

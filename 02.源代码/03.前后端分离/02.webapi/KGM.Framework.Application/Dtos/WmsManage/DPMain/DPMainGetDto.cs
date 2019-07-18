using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 入库通知单表头Dto
    /// </summary>
    [DataContract]
    public class DPMainGetDto
    {
        /// <summary>
        /// 初始化本身
        /// </summary>
        public DPMainGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.OrderType = 1;
            this.CreatorTime = DateTime.Now;
            this.EnabledMark = false;
            this.DeleteMark = false;
            this.SortCode = 0;
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        ///  
        /// </summary> 
        [DataMember] public string City { get; set; }

        /// <summary>
        ///  
        /// </summary> 
        [DataMember] public string Province { get; set; }
        /// <summary>
        /// 编码
        /// </summary> 
        [DataMember] public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary> 
        [DataMember] public string FullName { get; set; }

        /// <summary>
        /// 单据号
        /// </summary> 
        [DataMember] public string OrderNo { get; set; }


        /// <summary>
        /// 单据类型
        /// </summary> 
        [DataMember] public int? OrderType { get; set; }

        ///<summary>
        /// 类型
        /// </summary> 
        [DataMember] public int? Type { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary> 
        [DataMember] public string CustomerId { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary> 
        [DataMember] public string CustomerName { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember] public string WarehouseId { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember] public string WarehouseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember] public DateTime? sendDate { get; set; }

        ///<summary>
        /// 自定义项20
        /// </summary>  
        [DataMember] public DateTime? OUTFINISHTIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember] public int sendType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember] public string sendPerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember] public string sendAddress { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember] public string expCompany { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember] public string phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember] public string postcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember] public string contory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember] public string expNo { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        [DataMember] public DateTime? Date { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember] public string Maker { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember] public string Verify { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        [DataMember] public DateTime? VeriDate { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        [DataMember] public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember] public int? isLock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember] public int? isPack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember] public bool? isPrint { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember] public bool? isUpLoad { get; set; }



        /// <summary>
        /// 
        /// </summary>
        [DataMember] public bool? isWeight { get; set; }

        /// <summary>
        /// 权属
        /// </summary>
        [DataMember] public string Property { get; set; }
        ///<summary>
        /// 自定义项2
        /// </summary>  
        [DataMember] public string Define1 { get; set; }

        ///<summary>
        /// 自定义项2
        /// </summary>  
        [DataMember] public string Define2 { get; set; }

        ///<summary>
        /// 自定义项3
        /// </summary>  
        [DataMember] public string Define3 { get; set; }


        ///<summary>
        /// 自定义项4
        /// </summary>  
        [DataMember] public string Define4 { get; set; }


        ///<summary>
        /// 自定义项5
        /// </summary>  
        [DataMember] public string Define5 { get; set; }

        ///<summary>
        /// 自定义项6
        /// </summary>  
        [DataMember] public string Define6 { get; set; }

        ///<summary>
        /// 自定义项7
        /// </summary>  
        [DataMember] public string Define7 { get; set; }


        ///<summary>
        /// 自定义项8
        /// </summary>  
        [DataMember] public string Define8 { get; set; }

        ///<summary>
        /// 自定义项9
        /// </summary>  
        [DataMember] public string Define9 { get; set; }

        ///<summary>
        /// 自定义项10
        /// </summary>  
        [DataMember] public string Define10 { get; set; }


        ///<summary>
        /// 自定义项11
        /// </summary>  
        [DataMember] public string Define11 { get; set; }


        ///<summary>
        /// 自定义项12
        /// </summary>  
        [DataMember] public string Define12 { get; set; }


        ///<summary>
        /// 自定义项13
        /// </summary>  
        [DataMember] public string Define13 { get; set; }


        ///<summary>
        /// 自定义项14
        /// </summary>  
        [DataMember] public string Define14 { get; set; }


        ///<summary>
        /// 自定义项15
        /// </summary>  
        [DataMember] public string Define15 { get; set; }


        ///<summary>
        /// 自定义项16
        /// </summary>  
        [DataMember] public string Define16 { get; set; }


        ///<summary>
        /// 自定义项17
        /// </summary>  
        [DataMember] public string Define17 { get; set; }


        ///<summary>
        /// 自定义项18
        /// </summary>  
        [DataMember] public string Define18 { get; set; }

        ///<summary>
        /// 自定义项19
        /// </summary>  
        [DataMember] public string Define19 { get; set; }

        ///<summary>
        /// 自定义项20
        /// </summary>  
        [DataMember] public string Define20 { get; set; }



        /// <summary>
        /// 描述
        /// </summary> 
        [DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 排序码
        /// </summary> 
        [DataMember]
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary> 
        [DataMember]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary> 
        [DataMember]
        public virtual bool? EnabledMark { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [DataMember]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [DataMember]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [DataMember]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary> 
        [DataMember]
        public virtual string DeleteUserId { get; set; }



    }
}

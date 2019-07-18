using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// MST_BARCODERULEMAINInfo
    /// </summary>
    [DataContract]
    public class InStockHeadGetDto
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public InStockHeadGetDto()
		{
            this.Id= System.Guid.NewGuid().ToString();
             this.SortCode= 0;
             this.DeleteMark= false;
             this.EnabledMark= false;
         
		}

        #region Property Members
        
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string OrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string ParentOrderNo { get; set; }


        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string CustomId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string WarehouseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string SrTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string OwnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Maker { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public DateTime? Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Verifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public DateTime? Veridate { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public int? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public decimal? AllPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define10 { get; set; }

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
        /// 描述
        /// </summary>
		[DataMember]
        public virtual string Description { get; set; }

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


        #endregion
        
        ///// <summary>
        ///// 仓库名
        ///// </summary>
        //public string WarehouseName;


        ///// <summary>
        ///// 客户名
        ///// </summary>
        //public string CustomerName;

        ///// <summary>
        ///// 仓库编码
        ///// </summary>
        //public string WarehouseCode;


        ///// <summary>
        ///// 客户编码
        ///// </summary>
        //public string CustomerCode;

        ///// <summary>
        ///// 权属编码
        ///// </summary>
        //public string OwnnerCode;
        ///// <summary>
        ///// 权属名称
        ///// </summary>
        //public string OwnnerName;

        ///// <summary>
        ///// 收发类别名
        ///// </summary>
        //public string StrTypeName;
        ///// <summary>
        ///// 收发类别编码
        ///// </summary>
        //public string StrTypeCode;
    }
}
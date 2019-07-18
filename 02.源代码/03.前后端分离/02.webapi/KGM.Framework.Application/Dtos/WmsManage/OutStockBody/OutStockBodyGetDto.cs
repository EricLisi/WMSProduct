using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 入库单通知单子表
    /// </summary>
    [DataContract]
    public class OutStockBodyGetDto
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public OutStockBodyGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.RowNo = 0;
            this.Quantity = 0;
            this.Price = 0;
            this.SortCode = 0;
            this.DeleteMark = false;
            this.EnabledMark = false;

        }

        #region Property Members
        
        /// <summary>
        /// 主键
        /// </summary>
		[DataMember]
        public  string Id { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
		[DataMember]
        public  int? RowNo { get; set; }

        /// <summary>
        /// 主表Id
        /// </summary>
		[DataMember]
        public  string HeadId { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
		[DataMember]
        public  string OrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public  string WarehouseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public  string PositionId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
		[DataMember]
        public  string ProductId { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
		[DataMember]
        public  string Batch { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
		[DataMember]
        public  DateTime? MadeDate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
		[DataMember]
        public  DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
		[DataMember]
        public  decimal? Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public  decimal? Price { get; set; }

        /// <summary>
        /// 自定义项1
        /// </summary>
		[DataMember]
        public  string Define1 { get; set; }

        /// <summary>
        /// 自定义项2
        /// </summary>
		[DataMember]
        public  string Define2 { get; set; }

        /// <summary>
        /// 自定义项3
        /// </summary>
		[DataMember]
        public  string Define3 { get; set; }

        /// <summary>
        /// 自定义项4
        /// </summary>
		[DataMember]
        public  string Define4 { get; set; }

        /// <summary>
        /// 自定义项5
        /// </summary>
		[DataMember]
        public  string Define5 { get; set; }

        /// <summary>
        /// 自定义项6
        /// </summary>
		[DataMember]
        public  string Define6 { get; set; }

        /// <summary>
        /// 自定义项7
        /// </summary>
		[DataMember]
        public  string Define7 { get; set; }

        /// <summary>
        /// 自定义项8
        /// </summary>
		[DataMember]
        public  string Define8 { get; set; }

        /// <summary>
        /// 自定义项9
        /// </summary>
		[DataMember]
        public  string Define9 { get; set; }

        /// <summary>
        /// 自定义项10
        /// </summary>
		[DataMember]
        public  string Define10 { get; set; }


        /// <summary>
        /// 箱号
        /// </summary>
        [DataMember]
        public string BoxNo { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
		[DataMember]
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
		[DataMember]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标记
        /// </summary>
		[DataMember]
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
		[DataMember]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
		[DataMember]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
		[DataMember]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除操作人
        /// </summary>
		[DataMember]
        public virtual string DeleteUserId { get; set; }


        #endregion


        ///// <summary>
        ///// 产品名
        ///// </summary>
        //[DataMember]
        //public string ProductName { get; set; }

        ///// <summary>
        ///// sku
        ///// </summary>

        //public string InvSKU { get; set; }

        ///// <summary>
        ///// 客户编号
        ///// </summary>

        //public string CustomerCode { get; set; }
        
        ///// <summary>
        ///// 产品编号
        ///// </summary>

        //public string ProductCode { get; set; }
    }
}
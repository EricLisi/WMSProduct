using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 入库通知单主表
    /// </summary>
    [DataContract]
    public class OutStockHeadGetDto
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public OutStockHeadGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Status = 0;
            this.AllPrice = 0;
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
        /// ParentId
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }

        /// <summary>
        /// ParentOrderNo
        /// </summary>
        [DataMember]
        public string ParentOrderNo { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
		[DataMember]
        public  string OrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public  string CustomerId { get; set; }

        /// <summary>
        /// 
        /// 
        /// </summary>
		[DataMember]
        public  string WarehouseId { get; set; }

        /// <summary>
        /// 收发类别Id
        /// </summary>
		[DataMember]
        public  string SrTypeId { get; set; }

        /// <summary>
        /// 商品权属Id
        /// </summary>
		[DataMember]
        public  string OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public  string Type { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
		[DataMember]
        public  string Maker { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
		[DataMember]
        public  DateTime? Date { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
		[DataMember]
        public  string Verifier { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
		[DataMember]
        public  DateTime? Veridate { get; set; }

        /// <summary>
        /// 单据状态(0 待审核 1 已审核)
        /// </summary>
		[DataMember]
        public  int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public  decimal AllPrice { get; set; }

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

        /// <summary>
        /// 发运方式
        /// </summary>
		[DataMember]
        public virtual string SendType { get; set; }

        /// <summary>
        /// 快递公司
        /// </summary>
		[DataMember]
        public virtual string ExpCompanyId { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
		[DataMember]
        public virtual string ExpNo { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
		[DataMember]
        public virtual string ReceivePerson { get; set; }
        /// <summary>
        /// 收件人联系方式
        /// </summary>
		[DataMember]
        public virtual string ReceivePersonTel { get; set; }
        /// <summary>
        /// 收件人地址
        /// </summary>
		[DataMember]
        public virtual string ReceiveAddress { get; set; }
        /// <summary>
        /// 是否拣货
        /// </summary>
		[DataMember]
        public virtual bool? IsPick { get; set; }


        #endregion


        ///// <summary>
        ///// 仓库名
        ///// </summary>
        //[DataMember]
        //public string WarehouseName { get; set; }


        ///// <summary>
        ///// 客户名
        ///// </summary>
        //[DataMember]
        //public string CustomerName { get; set; }

        ///// <summary>
        ///// 仓库编码
        ///// </summary>
        //[DataMember]
        //public string WarehouseCode { get; set; }


        ///// <summary>
        ///// 客户编码
        ///// </summary>
        //[DataMember]
        //public string CustomerCode { get; set; }

        ///// <summary>
        ///// 权属编码
        ///// </summary>
        //[DataMember]
        //public string OwnnerCode { get; set; }
        ///// <summary>
        ///// 权属名称
        ///// </summary>
        //[DataMember]
        //public string OwnnerName { get; set; }

        ///// <summary>
        ///// 收发类别名
        ///// </summary>
        //[DataMember]
        //public string StrTypeName { get; set; }
        ///// <summary>
        ///// 收发类别编码
        ///// </summary>
        //[DataMember]
        //public string StrTypeCode { get; set; }

    }
}
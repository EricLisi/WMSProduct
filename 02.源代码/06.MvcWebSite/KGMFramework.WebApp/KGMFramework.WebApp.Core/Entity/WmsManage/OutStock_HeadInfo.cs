using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 出库单主表
    /// </summary>
    [DataContract]
    public class OutStock_HeadInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public OutStock_HeadInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Status = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

      

        /// <summary>
        /// 仓库Id
        /// </summary>
		[DataMember]
        public virtual string F_WarehouseId { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
		[DataMember]
        public virtual string F_CustomerId { get; set; }

        /// <summary>
        /// 收发类别Id
        /// </summary>
		[DataMember]
        public virtual string F_SrTypeId { get; set; }

        /// <summary>
        /// 商品权属Id
        /// </summary>
		[DataMember]
        public virtual string F_OwnershipId { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
		[DataMember]
        public virtual string F_Maker { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
		[DataMember]
        public virtual DateTime F_Date { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
		[DataMember]
        public virtual string F_Verifier { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
		[DataMember]
        public virtual DateTime F_Veridate { get; set; }

        /// <summary>
        /// 单据状态(0 待审核 1 已审核)
        /// </summary>
		[DataMember]
        public virtual int F_Status { get; set; }

        /// <summary>
        /// 来源单据主表Id
        /// </summary>
		[DataMember]
        public virtual string F_SourceId { get; set; }

        /// <summary>
        /// 来源单据类型(目前仅收货通知)
        /// </summary>
		[DataMember]
        public virtual string F_SourceType { get; set; }

        /// <summary>
        /// 来源单据号
        /// </summary>
		[DataMember]
        public virtual string F_SourceNo { get; set; }

        /// <summary>
        /// 自定义项1
        /// </summary>
		[DataMember]
        public virtual string F_Define1 { get; set; }

        /// <summary>
        /// 自定义项2
        /// </summary>
		[DataMember]
        public virtual string F_Define2 { get; set; }

        /// <summary>
        /// 自定义项3
        /// </summary>
		[DataMember]
        public virtual string F_Define3 { get; set; }

        /// <summary>
        /// 自定义项4
        /// </summary>
		[DataMember]
        public virtual string F_Define4 { get; set; }

        /// <summary>
        /// 自定义项5
        /// </summary>
		[DataMember]
        public virtual string F_Define5 { get; set; }

        /// <summary>
        /// 自定义项6
        /// </summary>
		[DataMember]
        public virtual string F_Define6 { get; set; }

        /// <summary>
        /// 自定义项7
        /// </summary>
		[DataMember]
        public virtual string F_Define7 { get; set; }

        /// <summary>
        /// 自定义项8
        /// </summary>
		[DataMember]
        public virtual string F_Define8 { get; set; }

        /// <summary>
        /// 自定义项9
        /// </summary>
		[DataMember]
        public virtual string F_Define9 { get; set; }

        /// <summary>
        /// 自定义项10
        /// </summary>
		[DataMember]
        public virtual string F_Define10 { get; set; }

     
        #endregion

    }
}
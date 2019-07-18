﻿using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 入库单通知单子表
    /// </summary>
    [DataContract]
    public class InStockNotice_BodyInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public InStockNotice_BodyInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_RowNo = 0;
            this.F_Quantity = 0;
            this.F_DoneQty = 0;
            this.F_SourceRowNo = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members
        
        /// <summary>
        /// 主键
        /// </summary>
		[DataMember]
        public virtual string F_Id { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
		[DataMember]
        public virtual int F_RowNo { get; set; }

        /// <summary>
        /// 主表Id
        /// </summary>
		[DataMember]
        public virtual string F_HeadId { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
		[DataMember]
        public virtual string F_EnCode { get; set; }

        /// <summary>
        /// 所属机构Id
        /// </summary>
		[DataMember]
        public virtual string F_OrganizationId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
		[DataMember]
        public virtual string F_ProductId { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
		[DataMember]
        public virtual string F_WarehouseId { get; set; }

        /// <summary>
        /// 货位Id
        /// </summary>
		[DataMember]
        public virtual string F_PositionId { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
		[DataMember]
        public virtual string F_Batch { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
		[DataMember]
        public virtual DateTime F_MadeDate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
		[DataMember]
        public virtual DateTime F_ExpiryDate { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
		[DataMember]
        public virtual decimal F_Quantity { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
		[DataMember]
        public virtual decimal F_DoneQty { get; set; }

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
        /// 来源单据行号
        /// </summary>
		[DataMember]
        public virtual int F_SourceRowNo { get; set; }

        /// <summary>
        /// 来源单据子表Id
        /// </summary>
		[DataMember]
        public virtual string F_SourceBodyId { get; set; }

        /// <summary>
        /// 商品权属Id
        /// </summary>
		[DataMember]
        public virtual string F_OwnershipId { get; set; }

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

        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string F_Description { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
		[DataMember]
        public virtual int F_SortCode { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
		[DataMember]
        public virtual bool F_DeleteMark { get; set; }

        /// <summary>
        /// 有效标记
        /// </summary>
		[DataMember]
        public virtual bool F_EnabledMark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime F_CreatorTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
		[DataMember]
        public virtual string F_CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime F_LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
		[DataMember]
        public virtual string F_LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
		[DataMember]
        public virtual DateTime F_DeleteTime { get; set; }

        /// <summary>
        /// 删除操作人
        /// </summary>
		[DataMember]
        public virtual string F_DeleteUserId { get; set; }


        /// <summary>
        /// 产品编码
        /// </summary>
        [DataMember]
        public string F_ProductCode { get; set; }


        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public string F_ProductName { get; set; }


        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public string F_ProductStandard { get; set; }


        #endregion

    }
}
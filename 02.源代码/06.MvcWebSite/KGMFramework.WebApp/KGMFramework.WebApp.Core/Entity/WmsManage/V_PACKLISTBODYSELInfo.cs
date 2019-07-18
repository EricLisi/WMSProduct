using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    [DataContract]
    public class V_PACKLISTBODYSELInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public V_PACKLISTBODYSELInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
        }

        #region Property Members
        

        /// <summary>
        /// 商品Id
        /// </summary>
        [DataMember]
        public virtual string F_ProductId { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        [DataMember]
        public virtual string F_ProductCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public virtual string F_ProductName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [DataMember]
        public virtual string F_ProductStandard { get; set; }

        /// <summary>
        /// 批次管理
        /// </summary>
        [DataMember]
        public virtual string F_ProdcuntBatchManagement { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public virtual string F_Unit { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [DataMember]
        public virtual string F_Batch { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public virtual decimal F_Quantity { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseCode { get; set; }


        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }

        /// <summary>
        /// 货位Id
        /// </summary>
        [DataMember]
        public virtual string F_PositionId { get; set; }

        /// <summary>
        /// 货位编码
        /// </summary>
        [DataMember]
        public virtual string F_PositionCode { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_PositionName { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        [DataMember]
        public virtual DateTime F_ExpiryDate { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        public virtual DateTime F_MadeDate { get; set; }

        /// <summary>
        /// 表头
        /// </summary>
        [DataMember]
        public virtual string F_HeadId { get; set; }

    
        #endregion

    }
}
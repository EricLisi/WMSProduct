using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 仓库信息表
    /// </summary>
    [DataContract]
    public class Sys_StockInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_StockInfo()
		{
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
		}

        #region Property Members

        /// <summary>
        /// 批次
        /// </summary>
        [DataMember]
        public virtual string F_Batch { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string F_GoodsId { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }
        /// <summary>
        /// 产品名
        /// </summary>
        [DataMember]
        public virtual string F_GoodsName { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        [DataMember]
        public virtual int F_Number { get; set; }
        /// <summary>
        /// 货位编号
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionId { get; set; }
        /// <summary>
        /// 货物名称
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionName { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        public virtual string F_ProDate { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        [DataMember]
        public virtual string  F_ExpiratDate { get; set; }
        /// <summary>
        /// 产品类型编号
        /// </summary>
        [DataMember]
        public virtual string F_CategoryID { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public virtual string F_SpecifModel { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public virtual string F_Unit { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [DataMember]
        public virtual string F_Pic { get; set; }
        /// <summary>
        /// 批发价
        /// </summary>
        [DataMember]
        public virtual string F_TradePrice { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [DataMember]
        public virtual string F_RetailPrice { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        [DataMember]
        public virtual string F_ShelfLife { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        [DataMember]
        public virtual string F_SellingPrice { get; set; }
        /// <summary>
        /// 采购价格
        /// </summary>
        public virtual  string F_PurchasePrice { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        [DataMember]
        public virtual string F_SerialNum { get; set; }

        #endregion






    }
}
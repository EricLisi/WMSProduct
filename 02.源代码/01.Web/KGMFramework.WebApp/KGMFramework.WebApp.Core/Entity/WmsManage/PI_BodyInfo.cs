using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 入库子表
    /// </summary>
    [DataContract]
    public class PI_BodyInfo : AppBaseEntity
    {
       
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public PI_BodyInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members
         
        /// <summary>
        /// 主表Id
        /// </summary>
        [DataMember]
        public virtual string F_HId { get; set; }

        
        /// <summary>
        /// 入库数量
        /// </summary>
        [DataMember]
        public virtual int F_InStockNum { get; set; }

        /// <summary>
        /// 已操作数量
        /// </summary>
        [DataMember]
        public virtual string F_AlreadyOperatedNum { get; set; }

        /// <summary>
        /// 货位号
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionId { get; set; }

        /// <summary>
        /// 货位号
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionName { get; set; }

        /// <summary>
        /// 指定日期
        /// </summary>
        [DataMember]
        public virtual DateTime F_SpecifiedDate { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public virtual string F_GoodsName { get; set; }

        /// <summary>
        /// 产品id
        /// </summary>
        [DataMember]
        public virtual string F_GoodsId { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public virtual string F_Unit { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [DataMember]
        public virtual decimal F_TradePrice { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        [DataMember]
        public virtual decimal F_AllAmount { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [DataMember]
        public virtual string F_SerialNum { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        [DataMember]
        public virtual string F_OrderNo { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        [DataMember]
        public virtual string F_CategoryID { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public virtual string F_SpecifModel { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        [DataMember]
        public virtual string F_ShelfLife { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [DataMember]
        public virtual string F_Pic { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        [DataMember]
        public virtual string F_SellingPrice { get; set; }
        /// <summary>
        /// 基本税率
        /// </summary>
        [DataMember]
        public virtual string F_BasicRate { get; set; }
        /// <summary>
        /// 采购价格
        /// </summary>
        [DataMember]
        public virtual string F_PurchasePrice { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [DataMember]
        public virtual string F_Supplier { get; set; }

        [DataMember]
        public virtual bool IsHave { get; set; }

        [DataMember]
        public virtual string StockID { get; set; }

        [DataMember]
        public virtual int StockNumber { get; set; }
        

        #endregion



        public System.Collections.Generic.List<PI_BodyInfo> Find(string p)
        {
            throw new NotImplementedException();
        }



    }
}
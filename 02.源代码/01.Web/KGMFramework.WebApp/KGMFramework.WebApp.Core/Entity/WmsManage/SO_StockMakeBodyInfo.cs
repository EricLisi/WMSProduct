using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 用户信息照片表
    /// </summary>
    [DataContract]
    public class SO_StockMakeBodyInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        /// 

        public SO_StockMakeBodyInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region 产品信息

        /// <summary>
        /// 售价
        /// </summary>
        [DataMember]
        public virtual decimal F_SellingPrice { get; set; }

        /// <summary>
        /// 进价
        /// </summary>
        [DataMember]
        public virtual decimal F_PurchasePrice { get; set; }

        /// <summary>
        /// 主表Id
        /// </summary>
        [DataMember]
        public virtual string F_HId { get; set; }
        /// <summary>
        /// 物品编号
        /// </summary>
        [DataMember]
        public virtual string F_GoodsId { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [DataMember]
        public virtual string F_SpecifiedDate { get; set; }

        /// <summary>
        /// 产品批次
        /// </summary>
        [DataMember]
        public virtual string F_Batch { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }


        /// <summary>
        /// 货位编号
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionId { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public string F_WarehouseName { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public string F_CargoPositionName { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        public virtual string F_ProDate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        [DataMember]
        public virtual string F_ExpiratDate { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public virtual string F_SpecifModel { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public virtual int F_Number { get; set; }

        /// <summary>
        /// 实盘数量
        /// </summary>
        [DataMember]
        public virtual string F_RealNumber { get; set; }

        /// <summary>
        /// 指定日期
        /// </summary>
        [DataMember]
        public virtual string SpecifiedDate { get; set; }
        /// <summary>
        ///产品名称
        /// </summary>
        [DataMember]
        public virtual string F_GoodsName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public virtual string F_Unit { get; set; }

        /// <summary>

        /// <summary>
        /// 自由项1
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm1 { get; set; }

        /// <summary>
        /// 自由项2
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm2 { get; set; }

        /// <summary>
        /// 自由项3
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm3 { get; set; }

        /// <summary>
        /// 自由项4
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm4 { get; set; }

        /// <summary>
        /// 自由项5
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm5 { get; set; }

        /// <summary>
        /// 自由项6
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm6 { get; set; }

        /// <summary>
        /// 自由项7
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm7 { get; set; }

        /// <summary>
        /// 自由项8
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm8 { get; set; }

        /// <summary>
        /// 自由项9
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm9 { get; set; }

        /// <summary>
        /// 自由项10
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm10 { get; set; }

        #endregion

    }
}
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 资产信息照片表
    /// </summary>
    [DataContract]
    public class SO_ReturnedStockBodyInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public SO_ReturnedStockBodyInfo()
		{
             this.F_Id= System.Guid.NewGuid().ToString();
             this.F_SortCode= 0;
             this.F_DeleteMark= false;
             this.F_EnabledMark= false;
		}

        #region Property Members

        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public virtual string F_SpecifModel { get; set; }
        /// <summary>
        /// 货位数量
        /// </summary>
        [DataMember]
        public virtual string F_Num { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        [DataMember]
        public virtual string F_CustomerId { get; set; }

        /// 客户名称
        /// </summary>
        [DataMember]
        public virtual string F_CustomerName { get; set; }

        /// <summary>
        /// 主表批次
        /// </summary>
        [DataMember]
        public virtual string F_HeadBatch { get; set; }

        /// <summary>
        /// 单据
        /// </summary>
        [DataMember]
        public virtual string F_Batch { get; set; }

  


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
        /// 主表ID
        /// </summary>
		[DataMember]
        public virtual string F_HId { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public virtual string F_Unit { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
		[DataMember]
        public virtual string F_GoodsId { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        [DataMember]
        public virtual int F_OutStockNum { get; set; }

        /// <summary>
        /// 退回数量
        /// </summary>
        [DataMember]
        public virtual int F_ReturnNum { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
		[DataMember]
        public virtual string F_GoodsName { get; set; }

        /// <summary>
        ///仓库ID
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }

        /// <summary>
        ///仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }

        /// <summary>
        ///货位Id
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionId { get; set; }

        /// <summary>
        ///货位名称
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionName { get; set; }


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
        public virtual string F_FreeTerm4{ get; set; }

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
        public virtual string F_FreeTerm8{ get; set; }

        /// <summary>
        /// 自由项9
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm9{ get; set; }

        /// <summary>
        /// 自由项10
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm10 { get; set; }  

        #endregion

    }
}
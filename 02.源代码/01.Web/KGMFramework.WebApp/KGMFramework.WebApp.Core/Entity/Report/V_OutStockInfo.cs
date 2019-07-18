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
    public class V_OutStockInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public V_OutStockInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();

        }

        #region Property Members



        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public virtual string F_Contacts { get; set; }
        /// </summary>
        /// 电话
        /// </summary>
        [DataMember]
        public virtual string F_TelePhone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public virtual string F_Address { get; set; }


        /// <summary>
        /// 客户Id
        /// </summary>
        [DataMember]
        public virtual string F_CustomerId { get; set; }
        /// </summary>
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
        /// 产品批次
        /// </summary>
        [DataMember]
        public virtual string F_Batch { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public virtual string F_SpecifModel { get; set; }


        /// <summary>
        /// 售价
        /// </summary>
        [DataMember]
        public virtual decimal F_SellingPrice { get; set; }




        /// <summary>
        /// 主表ID
        /// </summary>
        [DataMember]
        public virtual string F_HId { get; set; }

        /// <summary>
        /// 主表ID
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
        ///库存数量
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionName { get; set; }

        /// <summary>
        ///保质期
        /// </summary>
        [DataMember]
        public virtual string F_ShelfLife { get; set; }
        /// <summary>
        ///库存数量
        /// </summary>
        [DataMember]
        public virtual string F_Num { get; set; }


        #endregion

    }
}
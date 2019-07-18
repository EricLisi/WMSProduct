using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    [DataContract]
    public class V_STOCKMASKHISTORYINFO : AppBaseEntity
    {
        #region Property Members

        /// <summary>
        /// 差异数
        /// </summary>
        [DataMember]
        public virtual int F_DiffNumber { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
		[DataMember]
        public virtual string F_WarehouseName { get; set; }

        /// <summary>
        /// 货位编号
        /// </summary>
		[DataMember]
        public virtual string F_CargoPositionId { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionName { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
		[DataMember]
        public virtual string F_Operator { get; set; }

        /// <summary>
        ///时间
        /// </summary>
        [DataMember]
        public virtual DateTime F_Date { get; set; }

        /// <summary>
        /// 产品Id
        /// </summary>
		[DataMember]
        public virtual string F_GoodsId { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
		[DataMember]
        public virtual string F_GoodsCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
		[DataMember]
        public virtual string F_GoodsName { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        [DataMember]
        public virtual int F_Number { get; set; }

        /// <summary>
        /// 实盘数量
        /// </summary>
        [DataMember]
        public virtual int F_RealNumber { get; set; }

        /// <summary>
        /// 采购价格
        /// </summary>
        [DataMember]
        public virtual decimal F_SellingPrice { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [DataMember]
        public virtual string F_Batch { get; set; }

        /// <summary>
        ///单位
        /// </summary>
        [DataMember]
        public virtual string F_Unit { get; set; }
        /// <summary>
        ///单位
        /// </summary>
        [DataMember]
        public virtual string GOODSCODE { get; set; }
        /// <summary>
        ///单位
        /// </summary>
        [DataMember]
        public virtual string CPOCODE { get; set; }
        /// <summary>
        ///单位
        /// </summary>
        [DataMember]
        public virtual string WHCODE { get; set; }




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

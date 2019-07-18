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
    public class Sys_InReturnHistoryInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        /// 

        public Sys_InReturnHistoryInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region 入库履历
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string F_GoodsId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public virtual string F_GoodsName { get; set; }
        /// <summary>
        /// 产品状态
        /// </summary>
        [DataMember]
        public virtual string F_BllCategory { get; set; }
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
        /// 单价
        /// </summary>
        [DataMember]
        public virtual string F_TradePrice { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_Vendor { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [DataMember]
        public virtual string F_VendorName { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        [DataMember]
        public virtual string F_Date { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public virtual string F_Contacts { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public virtual string F_TelePhone { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember]
        public virtual string F_Verify { get; set; }
        /// <summary>
        ///制单人
        /// </summary>
        [DataMember]
        public virtual string F_Maker { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        [DataMember]
        public virtual DateTime? F_VeriDate { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        [DataMember]
        public virtual int F_InStockNum { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        [DataMember]
        public virtual int F_ReturnNum { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [DataMember]
        public virtual string F_Batch { get; set; }
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
        /// 总金额
        /// </summary>
        [DataMember]
        public virtual string F_TotalAmount { get; set; }
        
        /// <summary>
        /// 仓库编号
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }

        /// <summary>
        /// 货位ID
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionId { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionName { get; set; }
        /// <summary>
        /// 采购价格
        /// </summary>
        [DataMember]
        public virtual string F_PurchasePrice { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        [DataMember]
        public virtual string F_SellingPrice { get; set; }

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

        /// <summary>
        /// 退货地址
        /// </summary>
        [DataMember]
        public virtual string F_Address { get; set; }

        #endregion










    }
}
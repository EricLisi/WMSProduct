using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 入库主表
    /// </summary>
    [DataContract]
    public class PI_HeadInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public PI_HeadInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Status = 0;
            this.F_SortCode = 0;
            this.F_DocumentNum = "0";
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members


     
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
        /// 供应商
        /// </summary>
        [DataMember]
        public virtual string F_SupplierId { get; set; }

      
        /// <summary>
        /// 单据状态
        /// </summary>
        [DataMember]
        public virtual int F_Status { get; set; }

        /// <summary>
        /// 完成操作状态
        /// </summary>
        [DataMember]
        public virtual int F_State { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember]
        public virtual string F_Verify { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [DataMember]
        public virtual DateTime? F_VeriDate { get; set; }
        

        [DataMember]
        /// <summary>
        /// 编号
        /// </summary>
        public virtual string F_DocumentNum { get; set; }

        [DataMember]
        /// <summary>
        /// 操作人
        /// </summary>
        public virtual string F_Operator { get; set; }

        [DataMember]
        /// <summary>
        /// 审核
        /// </summary>
        public virtual string F_Auditing { get; set; }

        [DataMember]
        /// <summary>
        /// 总量
        /// </summary>
        public virtual decimal F_TotalAmount { get; set; }

        [DataMember]
        /// <summary>
        /// 发票号
        /// </summary>
        public virtual string F_Invoice { get; set; }

        [DataMember]

        /// <summary>
        /// 供应商
        /// </summary>
        public virtual string F_Vendor { get; set; }

        [DataMember]
        /// <summary>
        /// 供应商名字
        /// </summary>
        public virtual string F_VendorName { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionId { get; set; }

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
        /// 货位号
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionName { get; set; }

        #endregion








        
    }
}
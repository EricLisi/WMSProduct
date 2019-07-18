using System;
using System.Xml.Serialization;
using System.Runtime.Serialization; 

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// 销售出库单表头
    /// </summary>
   
    public class SO_HeadInfo 
    { 
           /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public SO_HeadInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_IsPrint = false;
            this.F_Status = 0;
            this.F_TotalMoney = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
        }

        #region Property Members



        public virtual string F_Id { get; set; }
        public virtual string F_DocumentNum { get; set; }


        public virtual string F_CustomerId { get; set; }

        public virtual string F_CustomerName { get; set; }

        public virtual string F_Contacts { get; set; }

        public virtual string F_TelePhone { get; set; }

        public virtual string F_MobilePhone { get; set; }

        public virtual string F_Address { get; set; }

        public virtual string F_Warehouse { get; set; }

        public virtual string F_Description { get; set; }

        public virtual string F_ManuOrderMan { get; set; }

        public virtual DateTime F_ManuOrderTime { get; set; }

        public virtual int F_Status { get; set; }

        public virtual bool F_IsPrint { get; set; }

        public virtual string F_AuditMan { get; set; }

        public virtual DateTime F_AuditTima { get; set; }

        public virtual decimal F_TotalMoney { get; set; }

        public virtual DateTime F_CreatorTime { get; set; }

        public virtual string F_CreatorUserId { get; set; }

        public virtual DateTime F_LastModifyTime { get; set; }

        public virtual string F_LastModifyUserId { get; set; }

        public virtual DateTime F_DeleteTime { get; set; }

        public virtual string F_DeleteUserId { get; set; }

        public virtual int F_SortCode { get; set; }

        public virtual bool F_DeleteMark { get; set; }

        public virtual bool F_EnabledMark { get; set; }

        public virtual string F_Define1 { get; set; }

        public virtual string F_Define2 { get; set; }

        public virtual string F_Define3 { get; set; }

        public virtual string F_Define4 { get; set; }

        public virtual string F_Define5 { get; set; }

        public virtual string F_Define6 { get; set; }

        public virtual string F_Define7 { get; set; }

        public virtual string F_Define8 { get; set; }

        public virtual string F_Define9 { get; set; }

        public virtual string F_Define10 { get; set; }


        #endregion

    }
}
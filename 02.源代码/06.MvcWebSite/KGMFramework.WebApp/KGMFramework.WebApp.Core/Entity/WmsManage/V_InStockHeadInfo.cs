using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 入库单视图
    /// </summary>
    [DataContract]
    public class V_InStockHeadInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public V_InStockHeadInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Status = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members 

        [DataMember]
        public virtual string F_OrganizationId { get; set; }

        [DataMember]
        public virtual string F_WarehouseId { get; set; }

        [DataMember]
        public virtual string F_SupplierId { get; set; }

        [DataMember]
        public virtual string F_SrTypeId { get; set; }

        [DataMember]
        public virtual string F_OwnershipId { get; set; }

        [DataMember]
        public virtual string F_Maker { get; set; }

        [DataMember]
        public virtual DateTime F_Date { get; set; }

        [DataMember]
        public virtual string F_Verifier { get; set; }

        [DataMember]
        public virtual DateTime F_Veridate { get; set; }

        [DataMember]
        public virtual int F_Status { get; set; }

        [DataMember]
        public virtual string F_SourceId { get; set; }

        [DataMember]
        public virtual string F_SourceType { get; set; }

        [DataMember]
        public virtual string F_SourceNo { get; set; }

        [DataMember]
        public virtual string F_Define1 { get; set; }

        [DataMember]
        public virtual string F_Define2 { get; set; }

        [DataMember]
        public virtual string F_Define3 { get; set; }

        [DataMember]
        public virtual string F_Define4 { get; set; }

        [DataMember]
        public virtual string F_Define5 { get; set; }

        [DataMember]
        public virtual string F_Define6 { get; set; }

        [DataMember]
        public virtual string F_Define7 { get; set; }

        [DataMember]
        public virtual string F_Define8 { get; set; }

        [DataMember]
        public virtual string F_Define9 { get; set; }

        [DataMember]
        public virtual string F_Define10 { get; set; } 
        [DataMember]
        public virtual string F_SupplierCode { get; set; }

        [DataMember]
        public virtual string F_SupplierName { get; set; }

        [DataMember]
        public virtual string F_SupplierClassId { get; set; }

        [DataMember]
        public virtual string F_SupplierContacts { get; set; }

        [DataMember]
        public virtual string F_SupplierTelePhone { get; set; }

        [DataMember]
        public virtual string F_SupplierMobilePhone { get; set; }

        [DataMember]
        public virtual string F_SupplierEmail { get; set; }

        [DataMember]
        public virtual string F_SupplierWeChat { get; set; }

        [DataMember]
        public virtual string F_SupplierFax { get; set; }

        [DataMember]
        public virtual string F_SupplierAddress { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine1 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine2 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine3 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine4 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine5 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine6 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine7 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine8 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine9 { get; set; }

        [DataMember]
        public virtual string F_SupplierDefine10 { get; set; }

        [DataMember]
        public virtual string F_SupplierDescription { get; set; }

        [DataMember]
        public virtual string F_WarehouseCode { get; set; }

        [DataMember]
        public virtual string F_WarehouseName { get; set; }

        [DataMember]
        public virtual string F_WarehouseContacts { get; set; }

        [DataMember]
        public virtual string F_WarehouseTelePhone { get; set; }

        [DataMember]
        public virtual string F_WarehouseMobilePhone { get; set; }

        [DataMember]
        public virtual string F_WarehouseEmail { get; set; }

        [DataMember]
        public virtual string F_WarehouseWeChat { get; set; }

        [DataMember]
        public virtual string F_WarehouseFax { get; set; }

        [DataMember]
        public virtual string F_WarehouseAddress { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine1 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine2 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine3 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine4 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine5 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine6 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine7 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine8 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine9 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDefine10 { get; set; }

        [DataMember]
        public virtual string F_WarehouseDescription { get; set; }

        [DataMember]
        public virtual string F_SrTypeCode { get; set; }

        [DataMember]
        public virtual string F_SrTypeName { get; set; }


        #endregion

    }
}
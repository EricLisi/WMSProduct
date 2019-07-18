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
    public class SO_HeadInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public SO_HeadInfo()
		{
             this.F_Id= System.Guid.NewGuid().ToString();
             this.F_SortCode= 0;
             this.F_DeleteMark= false;
             this.F_EnabledMark= false;
             this.F_OutSMark = "0";
         
		}

        #region Property Members




        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public virtual string F_Contacts { get; set; }

        /// <summary>
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
        /// 操作人
        /// </summary>
		[DataMember]
        public virtual string F_Operator { get; set; }


        /// <summary>
        /// 客户编号
        /// </summary>
        [DataMember]
        public virtual string F_CustomerId { get; set; }


        /// <summary>
        /// 客户名称
        /// </summary>
        [DataMember]
        public virtual string F_CustomerName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
		[DataMember]
        public virtual string F_Status { get; set; }
         /// <summary>
        /// 出库时间
        /// </summary>
		[DataMember]
        public virtual DateTime  F_Date { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember]
        public virtual string F_AuditingUser { get; set; }
                
         /// <summary>
        /// 审核时间
        /// </summary>
		[DataMember]
        public virtual DateTime? F_VeriDate { get; set; }

        
           /// <summary>
        /// 单据出库状态
        /// </summary>
		[DataMember]
        public virtual string F_OutSMark { get; set; }
        
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
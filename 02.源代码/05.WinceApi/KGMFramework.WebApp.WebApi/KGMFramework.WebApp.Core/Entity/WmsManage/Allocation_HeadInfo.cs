using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 调拨子表
    /// </summary>
    [DataContract]
    public class Allocation_HeadInfo : AppBaseEntity
    {
       
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Allocation_HeadInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

        /// <summary>
        /// 单据日期
        /// </summary>
        [DataMember]
        public virtual DateTime F_Date { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember]       
        public virtual string F_Operator { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        [DataMember]      
        public virtual string F_Maker { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        [DataMember]      
        public virtual string F_Invoice { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        [DataMember]      
        public virtual DateTime F_AccountDate { get; set; }
        /// <summary>
        /// 是否完成操作状态
        /// </summary>
        [DataMember]
        public virtual int F_State { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember]       
        public virtual string F_Verify { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember]       
        public virtual int F_Status { get; set; }

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



        public System.Collections.Generic.List<PI_BodyInfo> Find(string p)
        {
            throw new NotImplementedException();
        }


       
    }
}
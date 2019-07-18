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
    public class Allocation_BodyInfo : AppBaseEntity
    {
       
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Allocation_BodyInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
        }

        #region Property Members
         
        /// <summary>
        /// 主表Id
        /// </summary>
        [DataMember]
        public virtual string F_HId { get; set; }

        /// <summary>
        /// 是否已操作
        /// </summary>
        [DataMember]
        public virtual int F_AlreadyOperatedNum { get; set; }// 0未操作 1已操作
        /// <summary>
        /// 单据号
        /// </summary>
        [DataMember]
        public virtual string F_OrderNo { get; set; }
        /// <summary>
        /// 调出仓库ID
        /// </summary>
        [DataMember]
        public virtual string F_OutWareId { get; set; }
        /// <summary>
        /// 调出仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_OutWareName { get; set; }
        /// <summary>
        /// 调入仓库ID
        /// </summary>
        [DataMember]
        public virtual string F_InWareId { get; set; }
        /// <summary>
        /// 调入仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_InWareName { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public virtual string F_GoodsName { get; set; }

        /// <summary>
        /// 产品id
        /// </summary>
        [DataMember]
        public virtual string F_GoodsId { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public virtual string F_Unit { get; set; }

        /// <summary>
        /// 调拨数量
        /// </summary>
        [DataMember]
        public virtual int F_DbNum { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public virtual string F_SpecifModel { get; set; }

        /// <summary>
        /// 是否完成出库
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm1 { get; set; }
        /// <summary>
        /// 调出仓位ID
        /// </summary>
        [DataMember]
        public virtual string F_OutCargoPositionId { get; set; }
        /// <summary>
        /// 调出仓位
        /// </summary>
        [DataMember]
        public virtual string F_OutCargoPositionName { get; set; }
        /// <summary>
        /// 调入仓位ID
        /// </summary>
        [DataMember]
        public virtual string F_InCargoPositionId { get; set; }
        /// <summary>
        /// 调入仓位
        /// </summary>
        [DataMember]
        public virtual string F_InCargoPositionName { get; set; }

        /// <summary>
        /// 采购价格
        /// </summary>
        [DataMember]
        public virtual string F_PurchasePrice { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        [DataMember]
        public virtual decimal F_AllAmount { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        [DataMember]
        public virtual string F_SerialNum { get; set; }
        [DataMember]
        public virtual int F_Num { get; set; }
        #endregion



        public System.Collections.Generic.List<Allocation_BodyInfo> Find(string p)
        {
            throw new NotImplementedException();
        }

    }
}
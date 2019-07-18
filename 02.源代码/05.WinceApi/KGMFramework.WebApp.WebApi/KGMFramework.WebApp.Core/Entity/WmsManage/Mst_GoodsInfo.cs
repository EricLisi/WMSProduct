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
    public class Mst_GoodsInfo : AppBaseEntity
    {
        public string F_Pic; 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_GoodsInfo()
		{
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_CreatorTime = DateTime.Now;
            this.F_DeleteMark = false;
		}

        #region Property Members
        /// <summary>
        ///生产日期
        /// </summary>
        [DataMember]
        public virtual DateTime F_ProDate { get; set; }
        /// <summary>
        /// 有效日期
        /// </summary>
        [DataMember]
        public virtual DateTime F_ExpiratDate { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        [DataMember]
        public virtual string F_CategoryID { get; set; }
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
        /// 保质期
        /// </summary>
        [DataMember]
        public virtual string F_ShelfLife { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        [DataMember]
        public virtual string F_SellingPrice { get; set; }
        /// <summary>
        /// 采购价格
        /// </summary>
        [DataMember]
        public virtual string F_PurchasePrice { get; set; }
        /// <summary>
        /// 基本税率
        /// </summary>
        [DataMember]
        public virtual string F_BasicRate { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        [DataMember]
        public string F_SerialNum { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public virtual string F_Batch { get; set; }

        /// <summary>
        /// 长
        /// </summary>
        [DataMember]
        public virtual string F_Long { get; set; }
        /// <summary>
        /// 宽
        /// </summary>
        [DataMember]
        public virtual string F_Wide { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        [DataMember]
        public virtual string F_Height { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        [DataMember]
        public virtual string F_NetWeight { get; set; }
        /// <summary>
        /// 体积
        /// </summary>
        [DataMember]
        public virtual string F_Volume { get; set; }
        /// <summary>
        /// 是否开启配置
        /// </summary>
        [DataMember]
        public virtual bool F_OpenConfigure { get; set; }

        
        [DataMember]
        public virtual string F_FreeTerm2 { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        [DataMember]
        public virtual string F_GrossWeight { get; set; }
        /// <summary>
        /// 是否批次
        /// </summary>
        [DataMember]
        public virtual bool F_OpenBatch { get; set; }
        #endregion








        public string F_GoodsId { get; set; }

        public string F_FreeTerm1 { get; set; }




    }
}
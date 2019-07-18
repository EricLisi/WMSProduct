using System;
using System.Xml.Serialization;
using System.Runtime.Serialization; 

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// 扫描记录表
    /// </summary> 
    public class BuScanInfo
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public BuScanInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
                              this.Qty= 0;
             this.CStatus= 0;
  
		}

        #region Property Members
        
        /// <summary>
        /// id
        /// </summary>
		
        public virtual string Id { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
		
        public virtual string CMaker { get; set; }

        /// <summary>
        /// 操作日期
        /// </summary>
		
        public virtual DateTime DDate { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
		
        public virtual string OrderNo { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
		
        public virtual string OrderType { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
		
        public virtual string CCusName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
		
        public virtual string CAddress { get; set; }

        /// <summary>
        /// 来源单据号
        /// </summary>
		
        public virtual string CSourceCode { get; set; }

        /// <summary>
        /// 货品id
        /// </summary>
		
        public virtual string CInvId { get; set; }

        /// <summary>
        /// 货品编码
        /// </summary>
		
        public virtual string CInvCode { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
		
        public virtual string Cbatch { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
		
        public virtual DateTime DMDate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
		
        public virtual DateTime DVDate { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
		
        public virtual string CInvStd { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
		
        public virtual string Sn { get; set; }

        /// <summary>
        /// 针长
        /// </summary>
		
        public virtual string CInvLength { get; set; }

        /// <summary>
        /// USP
        /// </summary>
		
        public virtual string Usp { get; set; }

        /// <summary>
        /// 图示+弧
        /// </summary>
		
        public virtual string Radi { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
		
        public virtual int Qty { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
		
        public virtual int CStatus { get; set; }


        #endregion

    }
}
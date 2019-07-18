using System;
using System.Xml.Serialization;
using System.Runtime.Serialization; 

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// 条码扫描记录表
    /// </summary> 
    public class Mst_TempScanInfo
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_TempScanInfo()
		{
             
		}

        #region Property Members

        /// <summary>
        /// id
        /// </summary>

        public virtual string F_Id { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>

        public virtual string F_OperOrder { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>

        public virtual string F_CustomerName { get; set; }


        /// <summary>
        /// 客户地址
        /// </summary>

        public virtual string F_Address { get; set; }

        /// <summary>
        /// 条码
        /// </summary>

        public virtual string F_BarCode { get; set; }


        /// <summary>
        /// 业务类型
        /// </summary>

        public virtual string F_OrderType { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>

        public virtual string F_SpecifModel { get; set; }

        /// <summary>
        /// 货品id
        /// </summary>

        public virtual string CInvId { get; set; }


        
        /// <summary>
        /// 货品编码
        /// </summary>

        public virtual string F_ProductNo { get; set; }


        /// <summary>
        /// 货品名称
        /// </summary>

        public virtual string F_ProductName { get; set; }

        
        /// <summary>
        /// 仓库
        /// </summary>

        public virtual string F_Warehouse { get; set; }


        /// <summary>
        /// 货位
        /// </summary>

        public virtual string F_Position { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>

        public virtual string F_CategoryID { get; set; }

        /// <summary>
        /// 类别名
        /// </summary>

        public virtual string F_ClassName { get; set; }

        /// <summary>
        /// 批次
        /// </summary>

        public virtual string F_Batch { get; set; }

        /// <summary>
        /// 单位
        /// </summary>

        public virtual string F_Unit { get; set; }


        /// <summary>
        /// 操作人
        /// </summary>

        public virtual string F_OperUser { get; set; }


        /// <summary>
        /// 操作时间
        /// </summary>

        public virtual DateTime? F_OperTime { get; set; }


        /// <summary>
        /// 描述
        /// </summary>

        public virtual string F_Description { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
		
        public virtual DateTime? DMDate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
		
        public virtual DateTime? DVDate { get; set; }

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
        
        public virtual int? F_Qty { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        
        public virtual bool? F_Status { get; set; }


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
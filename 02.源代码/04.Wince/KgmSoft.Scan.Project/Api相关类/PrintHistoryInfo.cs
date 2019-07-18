using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace KgmSoft.Scan.Project
{
    public class PrintHistoryInfo
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public PrintHistoryInfo()
		{
             
		}

        #region Property Members
        public virtual string F_Id { get; set; }
        public virtual string F_BarCode { get; set; }

        public virtual string F_ProductNo { get; set; }
        public virtual string F_ProductId { get; set; }

        public virtual string F_SpecifModel { get; set; }

        public virtual string F_ProductName { get; set; }

        public virtual string F_CategoryID { get; set; }

        public virtual string F_ClassName { get; set; }

        public virtual string F_Unit { get; set; }

        public virtual decimal? F_PurchasePrice { get; set; }

        public virtual decimal? F_SellingPrice { get; set; }

        public virtual string F_Batch { get; set; }

        public virtual DateTime? F_ProductDate { get; set; }

        public virtual DateTime? F_LoseDate { get; set; }

        public virtual string F_SerialNo { get; set; }

        public virtual int? F_Qty { get; set; }

        public virtual string F_Description { get; set; }

        public virtual string F_SortCode { get; set; }

        public virtual DateTime F_CreatorTime { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public virtual bool F_DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool F_EnabledMark { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public virtual string F_CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public virtual string F_LastModifyUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime F_LastModifyTime { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime F_DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>

        public virtual string F_DeleteUserId { get; set; }


        public virtual string F_FreeTerm1 { get; set; }

        public virtual string F_FreeTerm2 { get; set; }


        public virtual string F_FreeTerm3 { get; set; }


        public virtual string F_FreeTerm4 { get; set; }


        public virtual string F_FreeTerm5 { get; set; }


        public virtual string F_FreeTerm6 { get; set; }


        public virtual string F_FreeTerm7 { get; set; }


        public virtual string F_FreeTerm8 { get; set; }


        public virtual string F_FreeTerm9 { get; set; }


        public virtual string F_FreeTerm10 { get; set; }


        #endregion
    }
}

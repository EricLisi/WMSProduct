using System;
using System.Collections.Generic;  
using System.Web;

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// 历史记录对象
    /// </summary> 
    public class Mst_HistoryInfo
    {

        public virtual string F_BarCode { get; set; }

        public virtual string F_Id { get; set; }

        public virtual string F_OrderNo { get; set; }

        public virtual string F_OrderType { get; set; }

        public virtual string F_ProductNo { get; set; }

        public virtual string F_Warehouse { get; set; }

        public virtual string F_Batch { get; set; }

        public virtual string F_ProductName { get; set; }

        public virtual string F_CategoryID { get; set; }

        public virtual string F_ClassName { get; set; }

        public virtual string F_Unit { get; set; }

        public virtual string F_Position { get; set; }

        public virtual decimal F_Qty { get; set; }

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
    }
}
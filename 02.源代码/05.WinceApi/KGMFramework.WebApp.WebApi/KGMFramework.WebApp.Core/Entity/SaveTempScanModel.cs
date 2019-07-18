using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 保存临时扫描记录Dto对象
    /// </summary>
 
    public class SaveTempScanModel
    {


 
        /// <summary>
        /// 单据号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 单据类型PI 入库，S0 出库，CW盘点
        /// </summary>
        public string OrderType { get; set; }

        ///// <summary>
        ///// 权属
        ///// </summary>

        //public string Property { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string Warehouse { get; set; }
        /// <summary>
        /// 货位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 目标货位
        /// </summary>
        public string DesPosition { get; set; }

        /// <summary>
        /// 目标货位
        /// </summary>
        public string DesWarehouse { get; set; }

        /// <summary>
        /// 条码
        /// </summary>

        public string Barcode { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string OperUser { get; set; }
        /// <summary>
        /// 数量
        /// </summary>

        public int Qty { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public bool DeleteMark { get; set; }
    }
}

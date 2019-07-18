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
    [DataContract]
    public class FinishTempScanDto
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [DataMember]
        public string OrderNo { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        [DataMember]
        public string OrderType { get; set; }

        /// <summary>
        /// 调入库位
        /// </summary>
        [DataMember]
        public string CMPosCode { get; set; }

        /// <summary>
        /// 调入仓库
        /// </summary>
        [DataMember]
        public string CMCWHCode { get; set; }

    }
}

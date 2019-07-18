using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 单据审核参数对象
    /// </summary>
    [DataContract]
    public class CarGoEntity
    {
        /// <summary>
        /// 编号前缀
        /// </summary>
        [DataMember]
        public string F_Prefix;
        /// <summary>
        /// 开始数字
        /// </summary>
        [DataMember]
        public int F_BenginNum;
        /// <summary>
        /// 结束字数
        /// </summary>
        [DataMember]
        public int F_EndNum;
        /// 基本信息
        /// </summary>
        [DataMember]
        public Mst_CargoPositionInfo Info;
    }
}

using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 用户信息照片表
    /// </summary>
    [DataContract]
    public class V_STOCKHISTORYINFO : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        /// 

        public V_STOCKHISTORYINFO()
        {
        }

        #region 入库履历
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string F_ID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string F_ENCODE { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string WHID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string F_BLLCATEGORY { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string WHCODE { get; set; }
        

        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string WHNAME { get; set; }

        /// <summary>
        /// 货位ID
        /// </summary>
        [DataMember]
        public virtual string POSID { get; set; }
        /// <summary>
        /// 货位ID
        /// </summary>
        [DataMember]
        public virtual string POSCODE { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string POSNAME { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string GOODSID { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string GOODSCODE { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_BATCH { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string GOODSNAME { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_Vendor { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_VENDORNAME { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_Contacts { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_TELEPHONE { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_ADDRESS { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_OperationNum { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_UNIT { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_SPECIFMODEL { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_Maker { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_VERIFY { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_VERIDATE { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_CREATORTIME { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [DataMember]
        public virtual string F_DESCRIPTION { get; set; }

        #endregion
    }
}

using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    [DataContract]
    public class V_STOCK_SHOWINFO : AppBaseEntity
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string F_ID { get; set; }
        
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public virtual string WHID { get; set; }
        
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
        public virtual string F_NUMBER { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_UNIT { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_SPECIFMODEL { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_SellingPrice { get; set; }

    }
}

using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 产品信息表
    /// </summary>
    [DataContract]
    public class Mst_ProductInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_ProductInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members


        /// <summary>
        /// 项目号
        /// </summary>
        [DataMember]
        public virtual string F_PROTOCOL_ID { get; set; }

        /// <summary>
        /// 标签号
        /// </summary>
        [DataMember]
        public virtual string F_LABEL_ID { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [DataMember]
        public virtual string F_VERSION { get; set; }

        /// <summary>
        /// 语言版本
        /// </summary>
        [DataMember]
        public virtual string F_COUNTRY { get; set; }

        [DataMember]
        public virtual string F_CONTENT1 { get; set; }

        [DataMember]
        public virtual string F_CONTENT2 { get; set; }

        [DataMember]
        public virtual string F_CONTENT3 { get; set; }

        [DataMember]
        public virtual string F_CONTENT4 { get; set; }

        [DataMember]
        public virtual string F_CONTENT5 { get; set; }

        [DataMember]
        public virtual string F_CONTENT6 { get; set; }

        [DataMember]
        public virtual string F_CONTENT7 { get; set; }

        [DataMember]
        public virtual string F_CONTENT8 { get; set; }

        [DataMember]
        public virtual string F_CONTENT9 { get; set; }

        [DataMember]
        public virtual string F_CONTENT10 { get; set; }

        [DataMember]
        public virtual string F_CONTENT11 { get; set; }

        [DataMember]
        public virtual string F_CONTENT12 { get; set; }

        [DataMember]
        public virtual string F_CONTENT13 { get; set; }

        [DataMember]
        public virtual string F_CONTENT14 { get; set; }

        [DataMember]
        public virtual string F_CONTENT15 { get; set; }

        [DataMember]
        public virtual string F_CONTENT16 { get; set; }

        [DataMember]
        public virtual string F_CONTENT17 { get; set; }

        [DataMember]
        public virtual string F_CONTENT18 { get; set; }

        [DataMember]
        public virtual string F_CONTENT19 { get; set; }

        [DataMember]
        public virtual string F_CONTENT20 { get; set; }

        [DataMember]
        public virtual string F_CONTENT21 { get; set; }

        [DataMember]
        public virtual string F_CONTENT22 { get; set; }

        [DataMember]
        public virtual string F_CONTENT23 { get; set; }

        [DataMember]
        public virtual string F_CONTENT24 { get; set; }

        [DataMember]
        public virtual string F_CONTENT25 { get; set; }
        #endregion

    }
}
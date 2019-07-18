using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 供应商信息表
    /// </summary>
    [DataContract]
    public class Mst_SupplierInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_SupplierInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

        /// <summary>
        /// 所属机构Id
        /// </summary>
        [DataMember]
        public virtual string F_OrganizationId { get; set; }

        /// <summary>
        /// 供应商分类Id
        /// </summary>
        [DataMember]
        public virtual string F_ClassId { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public virtual string F_Contacts { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [DataMember]
        public virtual string F_TelePhone { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DataMember]
        public virtual string F_MobilePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public virtual string F_Email { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [DataMember]
        public virtual string F_WeChat { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [DataMember]
        public virtual string F_Fax { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public virtual string F_Address { get; set; }

        /// <summary>
        /// 自定义项1
        /// </summary>
        [DataMember]
        public virtual string F_Define1 { get; set; }

        /// <summary>
        /// 自定义项2
        /// </summary>
        [DataMember]
        public virtual string F_Define2 { get; set; }

        /// <summary>
        /// 自定义项3
        /// </summary>
        [DataMember]
        public virtual string F_Define3 { get; set; }

        /// <summary>
        /// 自定义项4
        /// </summary>
        [DataMember]
        public virtual string F_Define4 { get; set; }

        /// <summary>
        /// 自定义项5
        /// </summary>
        [DataMember]
        public virtual string F_Define5 { get; set; }

        /// <summary>
        /// 自定义项6
        /// </summary>
        [DataMember]
        public virtual string F_Define6 { get; set; }

        /// <summary>
        /// 自定义项7
        /// </summary>
        [DataMember]
        public virtual string F_Define7 { get; set; }

        /// <summary>
        /// 自定义项8
        /// </summary>
        [DataMember]
        public virtual string F_Define8 { get; set; }

        /// <summary>
        /// 自定义项9
        /// </summary>
        [DataMember]
        public virtual string F_Define9 { get; set; }

        /// <summary>
        /// 自定义项10
        /// </summary>
        [DataMember]
        public virtual string F_Define10 { get; set; }

        #endregion

    }
}
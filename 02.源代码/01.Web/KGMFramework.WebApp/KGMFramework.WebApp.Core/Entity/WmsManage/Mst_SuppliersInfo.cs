using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 资产信息照片表
    /// </summary>
    [DataContract]
    public class Mst_SuppliersInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_SuppliersInfo()
		{
            this.F_Id = System.Guid.NewGuid().ToString();
       
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
		}

        #region Property Members

        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public virtual string F_Contacts { get; set; }

        /// <summary>
        /// 供应商类型
        /// </summary>
        [DataMember]
        public virtual string F_SperCategoryId { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public virtual string F_TelePhone { get; set; }

        /// <summary>
        /// 客户地址
        /// </summary>
        [DataMember]
        public virtual string F_Address { get; set; }

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
        /// 手机号
        /// </summary>
        [DataMember]
        public virtual string F_MobilePhone { get; set; }

        #endregion



    }
}
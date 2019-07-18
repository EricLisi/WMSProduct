using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 组织表
    /// </summary>
    [DataContract]
    public class Sys_OrganizeInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_OrganizeInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Layers = 0;
            this.F_AllowEdit = false;
            this.F_AllowDelete = false;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
            this.F_CreatorTime = System.DateTime.Now;

        }

        #region Property Members  
        /// <summary>
        /// 层次
        /// </summary>
        [DataMember]
        public virtual int? F_Layers { get; set; } 
        /// <summary>
        /// 简称
        /// </summary>
        [DataMember]
        public virtual string F_ShortName { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [DataMember]
        public virtual string F_CategoryId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [DataMember]
        public virtual string F_ManagerId { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [DataMember]
        public virtual string F_TelePhone { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [DataMember]
        public virtual string F_MobilePhone { get; set; }

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
        /// 邮箱
        /// </summary>
        [DataMember]
        public virtual string F_Email { get; set; }

        /// <summary>
        /// 归属区域
        /// </summary>
        [DataMember]
        public virtual string F_AreaId { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        [DataMember]
        public virtual string F_Address { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        [DataMember]
        public virtual bool? F_AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        [DataMember]
        public virtual bool? F_AllowDelete { get; set; }
        #endregion

    }
}
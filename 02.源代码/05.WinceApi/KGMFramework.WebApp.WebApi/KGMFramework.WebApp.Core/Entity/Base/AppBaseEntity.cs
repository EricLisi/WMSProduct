using KGM.Framework.ControlUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.Entity
{
    public class AppBaseEntity : BaseEntity
    {
        /// <summary>
        /// 模块主键
        /// </summary>
        [DataMember]
        public virtual string F_Id { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [DataMember]
        public virtual string F_ParentId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember]
        public virtual string F_EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string F_FullName { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [DataMember]
        public virtual int? F_SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        [DataMember]
        public virtual bool? F_DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [DataMember]
        public virtual bool? F_EnabledMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public virtual string F_Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime? F_CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [DataMember]
        public virtual string F_CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        public virtual DateTime? F_LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [DataMember]
        public virtual string F_LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [DataMember]
        public virtual DateTime? F_DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [DataMember]
        public virtual string F_DeleteUserId { get; set; }

    }
}
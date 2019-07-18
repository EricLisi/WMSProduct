using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 收发类别表
    /// </summary>
    [DataContract]
    public class Mst_SrTypeInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_SrTypeInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SrFlag = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

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
        /// 所属机构Id
        /// </summary>
        [DataMember]
        public virtual string F_OrganizationId { get; set; }

        /// <summary>
        /// 收发标识
        /// </summary>
        [DataMember]
        public virtual int F_SrFlag { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string F_Description { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [DataMember]
        public virtual int F_SortCode { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [DataMember]
        public virtual bool F_DeleteMark { get; set; }

        /// <summary>
        /// 有效标记
        /// </summary>
        [DataMember]
        public virtual bool F_EnabledMark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime F_CreatorTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public virtual string F_CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        public virtual DateTime F_LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        [DataMember]
        public virtual string F_LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [DataMember]
        public virtual DateTime F_DeleteTime { get; set; }

        /// <summary>
        /// 删除操作人
        /// </summary>
        [DataMember]
        public virtual string F_DeleteUserId { get; set; }


        #endregion

    }
}
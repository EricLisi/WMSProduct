using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 选项明细表
    /// </summary>
    [DataContract]
    public class Sys_ItemsDetailInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_ItemsDetailInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_IsDefault = false;
            this.F_Layers = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

        /// <summary>
        /// 主表主键
        /// </summary>
        [DataMember]
        public virtual string F_ItemId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        [DataMember]
        public virtual string F_ItemCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string F_ItemName { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        [DataMember]
        public virtual string F_SimpleSpelling { get; set; }

        /// <summary>
        /// 默认
        /// </summary>
        [DataMember]
        public virtual bool? F_IsDefault { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        [DataMember]
        public virtual int? F_Layers { get; set; }
        #endregion

    }
}
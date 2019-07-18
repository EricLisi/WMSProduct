using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 过滤IP
    /// </summary>
    [DataContract]
    public class Sys_FilterIPInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_FilterIPInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Type = false;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members
        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public virtual bool? F_Type { get; set; }

        /// <summary>
        /// 开始IP
        /// </summary>
        [DataMember]
        public virtual string F_StartIP { get; set; }

        /// <summary>
        /// 结束IP
        /// </summary>
        [DataMember]
        public virtual string F_EndIP { get; set; } 
        #endregion

    }
}
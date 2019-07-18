using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 选项主表
    /// </summary>
    [DataContract]
    public class Sys_ItemsInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_ItemsInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_IsTree = false;
            this.F_Layers = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members
        /// <summary>
        /// 树型
        /// </summary>
        [DataMember]
        public virtual bool? F_IsTree { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        [DataMember]
        public virtual int? F_Layers { get; set; }
        #endregion

    }
}
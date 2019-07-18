using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 岗位表
    /// </summary>
    [Serializable]
    public class Sys_DutyInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_DutyInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
        }

        #region Property Members

        /// <summary>
        /// 组织主键
        /// </summary>
        [DataMember]
        public virtual string F_OrganizeId { get; set; }


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
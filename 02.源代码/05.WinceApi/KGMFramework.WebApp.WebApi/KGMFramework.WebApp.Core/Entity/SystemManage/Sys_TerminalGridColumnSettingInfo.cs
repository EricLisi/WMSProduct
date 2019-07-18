using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 终端列表显示设置
    /// </summary>
    [DataContract]
    public class Sys_TerminalGridColumnSettingInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_TerminalGridColumnSettingInfo()
        {
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

        /// <summary>
        /// 模块ID
        /// </summary>
        [DataMember]
        public virtual string F_ModuleId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        [DataMember]
        public virtual string F_ModuleName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [DataMember]
        public virtual string F_ModuleIcon { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public virtual string F_Url { get; set; }


        #endregion

    }
}
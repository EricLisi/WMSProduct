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
    public class Sys_TerminalListSettingInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_TerminalListSettingInfo()
        {
            this.F_Required = false;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

        /// <summary>
        /// 显示值
        /// </summary>
        [DataMember]
        public virtual string F_Display { get; set; }

        /// <summary>
        /// 文本框类型
        /// </summary>
        [DataMember]
        public virtual string F_Type { get; set; }

        /// <summary>
        /// API方法地址
        /// </summary>
        [DataMember]
        public virtual string F_Address { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        [DataMember]
        public virtual bool F_Required { get; set; }


        #endregion

    }
}
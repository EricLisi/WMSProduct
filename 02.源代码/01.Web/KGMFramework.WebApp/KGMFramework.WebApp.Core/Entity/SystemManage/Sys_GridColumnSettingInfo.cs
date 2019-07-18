using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 列表显示设置
    /// </summary>
    [DataContract]
    public class Sys_GridColumnSettingInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_GridColumnSettingInfo()
        {
            this.F_Hidden = false;
            this.F_Key = false;
            this.F_Width = 0;
            this.F_Editable = false;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

        /// <summary>
        /// 所属页面
        /// </summary>
        [DataMember]
        public virtual string F_Page { get; set; }

        /// <summary>
        /// 列表ID
        /// </summary>
        [DataMember]
        public virtual string F_GridId { get; set; }

        /// <summary>
        /// 列显示
        /// </summary>
        [DataMember]
        public virtual string F_Label { get; set; }

        /// <summary>
        /// 列映射后台字段
        /// </summary>
        [DataMember]
        public virtual string F_Name { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        [DataMember]
        public virtual bool F_Hidden { get; set; }

        /// <summary>
        /// 主键标识
        /// </summary>
        [DataMember]
        public virtual bool F_Key { get; set; }

        /// <summary>
        /// 列宽
        /// </summary>
        [DataMember]
        public virtual int F_Width { get; set; }

        /// <summary>
        /// 对齐方式
        /// </summary>
        [DataMember]
        public virtual string F_Align { get; set; }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        [DataMember]
        public virtual bool F_Editable { get; set; }

        /// <summary>
        /// 显示格式
        /// </summary>
        [DataMember]
        public virtual string F_Formatter { get; set; }

        /// <summary>
        /// 显示格式选项
        /// </summary>
        [DataMember]
        public virtual string F_Formatoptions { get; set; }


        ///// <summary>
        ///// 对应的文件路径
        ///// </summary>
        //[DataMember]
        //public virtual string F_DataUrl { get; set; }
        #endregion

    }
}
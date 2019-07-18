using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 模块按钮
    /// </summary>
    [DataContract]
    public class Sys_ModuleButtonInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_ModuleButtonInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Layers = 0;
            this.F_Location = 0;
            this.F_Split = false;
            this.F_IsPublic = false;
            this.F_AllowEdit = false;
            this.F_AllowDelete = false;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region Property Members

        /// <summary>
        /// 模块主键
        /// </summary>
        [DataMember]
        public virtual string F_ModuleId { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        [DataMember]
        public virtual int? F_Layers { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [DataMember]
        public virtual string F_Icon { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [DataMember]
        public virtual int? F_Location { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        [DataMember]
        public virtual string F_JsEvent { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        [DataMember]
        public virtual string F_UrlAddress { get; set; }

        /// <summary>
        /// 分开线
        /// </summary>
        [DataMember]
        public virtual bool? F_Split { get; set; }

        /// <summary>
        /// 公共
        /// </summary>
        [DataMember]
        public virtual bool? F_IsPublic { get; set; }

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
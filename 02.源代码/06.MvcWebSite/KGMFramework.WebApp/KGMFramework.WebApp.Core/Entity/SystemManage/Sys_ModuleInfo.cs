using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 系统模块
    /// </summary>
    [DataContract]
    public class Sys_ModuleInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_ModuleInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Layers = 0;
            this.F_IsMenu = false;
            this.F_IsExpand = false;
            this.F_IsPublic = false;
            this.F_AllowEdit = false;
            this.F_AllowDelete = false;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
        }

        #region Property Members 

        /// <summary>
        /// 父级
        /// </summary>
        [DataMember]
        public override string F_ParentId { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        [DataMember]
        public virtual int? F_Layers { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember]
        public virtual string F_EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public override string F_FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [DataMember]
        public virtual string F_Icon { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        [DataMember]
        public virtual string F_UrlAddress { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        [DataMember]
        public virtual string F_Target { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [DataMember]
        public virtual bool? F_IsMenu { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        [DataMember]
        public virtual bool? F_IsExpand { get; set; }

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
        /// <summary>
        /// 是否App
        /// </summary>
        [DataMember]
        public virtual bool? F_IsApp { get; set; } 
        #endregion

    }
}
using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 模块类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_Module")]
    public class ModuleEntity : AggregateRoot
    {
        /// <summary>
        /// 平台Id
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// 平台对象
        /// </summary>
        [MappingFiled(Ignore = true)]
        public PlatFormEntity PlatForm { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        public string UrlAddress { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public bool? IsMenu { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        public bool? IsExpand { get; set; }

        /// <summary>
        /// 公共
        /// </summary>
        public virtual bool? IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public virtual bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public virtual bool? AllowDelete { get; set; }
        /// <summary>
        /// 是否App
        /// </summary>
        public virtual bool? IsApp { get; set; }

        /// <summary>
        /// 模块按钮
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public virtual List<ButtonEntity> ButtonEntities { get; set; }

        /// <summary>
        /// 模块页面表单
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public virtual List<FormEntity> FormEntities { get; set; }

        /// <summary>
        /// 模块列
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public virtual List<ColumnEntity> ColumnEntities { get; set; }


        #region 用于同一领域内的所有类 均集成Entity
        /// <summary>
        /// 模块按钮 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "Sys_ModuleButton")]
        public class ButtonEntity : Entity
        {
            #region x
            /// <summary>
            /// 编号
            /// </summary> 
            public virtual string EnCode { get; set; }

            /// <summary>
            /// 节点
            /// </summary> 
            public virtual string ParentId { get; set; }

            /// <summary>
            /// 名称
            /// </summary> 
            public virtual string FullName { get; set; }

            /// <summary>
            /// 模块主键
            /// </summary>
            public virtual string ModuleId { get; set; }

            /// <summary>
            /// 图标
            /// </summary> 
            public virtual string Icon { get; set; }

            /// <summary>
            /// 链接地址
            /// </summary> 
            public virtual string ActionAddress { get; set; }

            /// <summary>
            /// 模块对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public ModuleEntity Module { get; set; }
            #endregion

        }


        /// <summary>
        /// 模块页面表单 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "Sys_ModuleForm")]
        public class FormEntity : Entity
        {
            /// <summary>
            /// 模块主键
            /// </summary> 
            public virtual string ModuleId { get; set; }

            /// <summary>
            /// 编码
            /// </summary> 
            public virtual string EnCode { get; set; }

            /// <summary>
            /// 名称
            /// </summary> 
            public virtual string FullName { get; set; }

            /// <summary>
            /// 模块对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public ModuleEntity Module { get; set; }
        }


        /// <summary>
        /// 模块列 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "Sys_ModuleColumn")]
        public class ColumnEntity : Entity
        {
            /// <summary>
            /// 编码
            /// </summary> 
            public virtual string EnCode { get; set; }

            /// <summary>
            /// 名称
            /// </summary> 
            public virtual string FullName { get; set; }

            /// <summary>
            /// 父节点
            /// </summary> 
            public virtual string ParentId { get; set; }

            /// <summary>
            /// 模块主键
            /// </summary> 
            public virtual string ModuleId { get; set; }

            /// <summary>
            /// 图标
            /// </summary> 
            public virtual string Icon { get; set; }

            /// <summary>
            /// 位置
            /// </summary> 
            public virtual string ActionAddress { get; set; }

            /// <summary>
            /// 模块对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public ModuleEntity Module { get; set; }
        }
        #endregion
    }

}

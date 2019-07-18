using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_Role")]
    public class RoleEntity : AggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary> 
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary> 
        public string FullName { get; set; }

        /// <summary>
        ///是否是超级管理员
        /// </summary>
        [MappingFiled(Required = true)]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 角色拥有的模块
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public List<RoleModuleEntity> Modules { get; set; }

        /// <summary>
        /// 角色拥有的模块按钮
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public List<RoleButtonEntity> Buttons { get; set; }


        ///// <summary>
        ///// 角色拥有的模块页面
        ///// </summary>
        //[MappingFiledAttribute(Ignore = true)]
        //public List<RoleFormEntity> Forms { get; set; }

        /// <summary>
        /// 角色拥有的模块列
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public List<RoleColumnEntity> Columns { get; set; }

        /// <summary>
        /// 权限配置 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "Sys_Role_Module")]
        public class RoleModuleEntity : Entity
        {
            /// <summary>
            /// 角色Id
            /// </summary> 
            public string RoleId { get; set; }

            /// <summary>
            /// 角色对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public RoleEntity Role { get; set; }

            /// <summary>
            /// 权限Id
            /// </summary> 
            public string ModuleId { get; set; }

            /// <summary>
            /// 模块对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public ModuleEntity Module { get; set; }
        }


        /// <summary>
        /// 权限配置 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "Sys_Role_ModuleButton")]
        public class RoleButtonEntity : Entity
        {
            /// <summary>
            /// 角色Id
            /// </summary> 
            public string RoleId { get; set; }

            /// <summary>
            /// 角色对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public RoleEntity Role { get; set; }

            /// <summary>
            /// 按钮Id
            /// </summary> 
            public string ModuleButtonId { get; set; }

            /// <summary>
            /// 模块按钮对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public ModuleEntity.ButtonEntity Button { get; set; }
        }


        ///// <summary>
        ///// 权限配置 与数据库结构一致
        ///// </summary> 
        //[MappingTable(TableName = "Sys_Role_ModuleForm")]
        //public class RoleFormEntity : Entity
        //{
        //    /// <summary>
        //    /// 角色Id
        //    /// </summary> 
        //    public string RoleId { get; set; }

        //    /// <summary>
        //    /// 角色对象
        //    /// </summary>
        //    [MappingFiledAttribute(Ignore = true)]
        //    public RoleEntity Role { get; set; }

        //    /// <summary>
        //    /// 页面Id
        //    /// </summary> 
        //    public string ModuleFormId { get; set; }

        //    /// <summary>
        //    /// 模块页面对象
        //    /// </summary>
        //    [MappingFiledAttribute(Ignore = true)]
        //    public ModuleEntity.FormEntity Form { get; set; }
        //}


        /// <summary>
        /// 权限配置 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "Sys_Role_ModuleColumn")]
        public class RoleColumnEntity : Entity
        {
            /// <summary>
            /// 角色Id
            /// </summary> 
            public string RoleId { get; set; }

            /// <summary>
            /// 角色对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public RoleEntity Role { get; set; }

            /// <summary>
            /// 列Id
            /// </summary> 
            public string ModuleColumnId { get; set; }

            /// <summary>
            /// 模块列对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public ModuleEntity.ColumnEntity Column { get; set; }
        }
    }

}

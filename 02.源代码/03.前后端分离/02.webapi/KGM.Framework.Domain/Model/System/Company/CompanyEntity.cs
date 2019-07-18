using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 公司类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_Company")]
    public class CompanyEntity : AggregateRoot
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
        /// 父节点
        /// </summary> 
        public string ParentId { get; set; }

        /// <summary>
        /// 图标
        /// </summary> 
        public string Icon { get; set; }

        /// <summary>
        /// 简称
        /// </summary> 
        public string ShortName { get; set; }

        /// <summary>
        /// 类型
        /// </summary> 
        public int? Nature { get; set; }

        /// <summary>
        /// 电话
        /// </summary> 
        public string Phone { get; set; }

        /// <summary>
        /// 传真
        /// </summary> 
        public string Fax { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary> 
        public string Email { get; set; }

        /// <summary>
        /// 联系人
        /// </summary> 
        public string Manager { get; set; }

        /// <summary>
        /// 所在地址
        /// </summary> 
        public string Address { get; set; }

        /// <summary>
        /// 公司网址
        /// </summary> 
        public string WebAddress { get; set; }

        /// <summary>
        /// 省区
        /// </summary> 
        public string ProvinceId { get; set; }

        /// <summary>
        /// 市区
        /// </summary> 
        public string CityId { get; set; }

        /// <summary>
        /// 县区
        /// </summary> 
        public string CountyId { get; set; }

        /// <summary>
        /// 邮编
        /// </summary> 
        public string Postalcode { get; set; }

        /// <summary>
        /// 部门集合
        /// </summary>
        [MappingFiled(Ignore = true)]
        public virtual List<DepartmentEntity> Departments { get; set; }

        /// <summary>
        /// 部门类 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "Sys_Department")]

        public class DepartmentEntity : Entity
        {
            /// <summary>
            /// 编号
            /// </summary> 
            public virtual string EnCode { get; set; }

            /// <summary>
            /// 名称
            /// </summary> 
            public virtual string FullName { get; set; }

            /// <summary>
            /// 简称
            /// </summary> 
            public virtual string ShortName { get; set; }

            /// <summary>
            /// 父节点
            /// </summary> 
            public virtual string ParentId { get; set; }

            /// <summary>
            /// 所属公司
            /// </summary> 
            public virtual string CompanyId { get; set; }

            /// <summary>
            /// 公司
            /// </summary>
            [MappingFiled(Ignore = true)]
            public CompanyEntity Company { get; set; }

            /// <summary>
            /// 图标
            /// </summary> 
            public virtual string Icon { get; set; }

            /// <summary>
            /// 类型
            /// </summary>
            public virtual int? Nature { get; set; }

            /// <summary>
            /// 联系人
            /// </summary>
            public virtual string Manager { get; set; }

            /// <summary>
            /// 电话
            /// </summary>
            public virtual string Phone { get; set; }

            /// <summary>
            /// 邮箱
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// 传真
            /// </summary>
            public virtual string Fax { get; set; }

        }
    }
}

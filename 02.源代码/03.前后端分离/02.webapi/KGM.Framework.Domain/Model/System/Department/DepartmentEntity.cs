using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 部门类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_Department")]

    public class DepartmentEntity : AggregateRoot
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
        /// 简称
        /// </summary> 
        public string ShortName { get; set; }

        /// <summary>
        /// 父节点
        /// </summary> 
        public string ParentId { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary> 
        public string CompanyId { get; set; }

        /// <summary>
        /// 图标
        /// </summary> 
        public string Icon { get; set; } 
          
        /// <summary>
        /// 类型
        /// </summary>
        public int? Nature { get; set; }
         
        /// <summary>
        /// 联系人
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

    }
}

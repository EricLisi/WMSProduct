using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 权限配置 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_PlatForm")]
    public class PlatFormEntity : AggregateRoot
    {
        /// <summary>
        /// 编码
        /// </summary> 
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary> 
        public string FullName { get; set; }

        /// <summary>
        /// 网址
        /// </summary> 
        public string HomePageUrl { get; set; }

        /// <summary>
        /// 平台下属模块
        /// </summary>
        [MappingFiled(Ignore = true)]
        public List<ModuleEntity> Modules { get; set; }

    }
}

using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    public interface IModuleRepository : IRepository<ModuleEntity>
    {
        /// <summary>
        /// 获取模型按钮树形
        /// </summary>
        /// <returns></returns>
        List<ModuleEntity> QueryAllModule();

        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<ModuleEntity> QueryModuleByPagers(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

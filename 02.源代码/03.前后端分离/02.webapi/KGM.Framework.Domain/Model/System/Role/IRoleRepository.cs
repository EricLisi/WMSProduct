using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    public interface IRoleRepository : IRepository<RoleEntity>
    {
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <returns></returns>
        int Update(RoleEntity Entity);

        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<RoleEntity> QueryRoleByPagers(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

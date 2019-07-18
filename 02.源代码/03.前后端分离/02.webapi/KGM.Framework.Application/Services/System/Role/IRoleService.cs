using KGM.Framework.Application.Core;
using KGM.Framework.Domain;
using System.Threading.Tasks;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 角色服务接口
    /// </summary>
    public interface IRoleService : IService<RoleEntity>
    {
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Update(RoleEntity entity);
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<RoleSingleDto>> QueryRoleByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

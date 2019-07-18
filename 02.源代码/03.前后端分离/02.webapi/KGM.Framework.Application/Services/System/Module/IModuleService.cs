using KGM.Framework.Application.Core;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 菜单服务接口
    /// </summary>
    public interface IModuleService:IService<ModuleEntity>
    {
        /// <summary>
        /// 获取模块按钮树形
        /// </summary>
        /// <returns></returns>
        Task<List<ModuleSingleDto>> QueryAllModule();
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Update(ModuleEntity entity);
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<ModuleGridDto>> QueryModuleByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null);

        
        
    }
}

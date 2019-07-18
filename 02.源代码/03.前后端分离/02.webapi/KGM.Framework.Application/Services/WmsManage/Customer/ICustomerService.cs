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
    public interface ICustomerService : IService<CustomerEntity>
    {
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<CustomerSingleDto>> QueryCustomerByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null);


        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<CustomerOwnerSingleDto>> QueryCustomerOwnerByPagers(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

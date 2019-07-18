using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<CustomerEntity> QueryCustomerByPagers(PagerInfo pager, List<SearchCondition> condition = null);


        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<CustomerEntity.OwnerEntity> QueryCustomerOwnerByPagers(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

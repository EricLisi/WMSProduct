using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    public interface IAreaRepository : IRepository<AreaEntity>
    {
        List<AreaEntity> QueryAll();
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<AreaEntity> QueryAreaByPagers(PagerInfo pager, List<SearchCondition> condition = null);
        /// <summary>
        /// 根据省份获取城市
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PagerEntity<AreaEntity> QueryCityByProvinceAsync(string Id);
    }
}

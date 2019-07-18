using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    public interface IBarCodeRuleMainRepository : IRepository<BarCodeRuleMainEntity>
    {
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<BarCodeRuleMainEntity> QueryBarCodeRuleByPagers(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

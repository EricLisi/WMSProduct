using KGM.Framework.Application.Core;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 客户服务接口
    /// </summary>
    public interface IBarCodeRuleMainService : IService<BarCodeRuleMainEntity>
    {
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<BarCodeRuleGridDto>> QueryBarCodeRuleByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

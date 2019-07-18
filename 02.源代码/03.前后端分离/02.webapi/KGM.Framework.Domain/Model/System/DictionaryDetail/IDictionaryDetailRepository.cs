using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    public interface IDictionaryDetailRepository : IRepository<DictionaryDetailEntity>
    {
        //int UpdateItem(DictionaryEntity.DetailEntity detailEntity);

        /// <summary>
        /// 分页查询 + 条件查询 + 排序 
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<DictionaryDetailEntity> QueryDictionaryDetailByPagers(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    public interface IDictionaryRepository : IRepository<DictionaryEntity>
    {
        //int UpdateItem(DictionaryEntity.DetailEntity detailEntity);

        /// <summary>
        /// 分页查询 + 条件查询 + 排序 
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<DictionaryEntity.DetailEntity> QueryItemByPagers(PagerInfo pager, List<SearchCondition> condition = null);

        /// <summary>
        /// 分页查询 + 条件查询 + 排序 主表
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<DictionaryEntity> QueryDictionaryByPagers(PagerInfo pager, List<SearchCondition> condition = null);

        ///// <summary>
        ///// 更新子表
        ///// </summary>
        ///// <param name="detailEntity"></param>
        ///// <returns></returns>
        //int UpdateDetail(DictionaryEntity.DetailEntity detailEntity);


        /// <summary>
        /// 删除子表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int DeleteDetail(object key);
    }
}

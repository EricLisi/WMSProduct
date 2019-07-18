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
    public interface IDictionaryService : IService<DictionaryEntity>
    {
        //int UpdateItem(DictionaryEntity.DetailEntity detailEntity);

        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<DictionaryDetailSingleDto>> QueryItemByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null);


        /// <summary>
        /// 分页查询 + 条件查询 + 排序 主表
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<DictionarySingleDto>> QueryDictionaryByPagers(PagerInfo pager, List<SearchCondition> condition = null);

        ///// <summary>
        ///// 更新子表
        ///// </summary>
        ///// <param name="detailEntity"></param>
        ///// <returns></returns>
        //Task<int> UpdateDetail(DictionaryDetailSingleDto detailEntity);

        /// <summary>
        /// 删除子表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<int> DeleteDetail(object key);
    }
}

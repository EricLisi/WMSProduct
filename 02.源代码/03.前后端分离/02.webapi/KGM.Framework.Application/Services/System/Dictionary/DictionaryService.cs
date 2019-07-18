using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KGM.Framework.Application.Core;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 用户服务实现
    /// </summary>

    public class DictionaryService : BaseService<DictionaryEntity>, IDictionaryService
    {
        #region 私有成员
        private readonly IDictionaryRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public DictionaryService(IDictionaryRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        #endregion

        #region 接口实现 
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public async Task<PagerEntity<DictionaryDetailSingleDto>> QueryItemByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null)
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryItemByPagers(pager, condition);
                return _mapper.Map<PagerEntity<DictionaryDetailSingleDto>>(list);
            });
        }

        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public async Task<PagerEntity<DictionarySingleDto>> QueryDictionaryByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryDictionaryByPagers(pager, condition);
                return _mapper.Map<PagerEntity<DictionarySingleDto>>(list);
            });
        }

        ///// <summary>
        ///// 更新子表
        ///// </summary>
        ///// <param name="detailEntity"></param>
        ///// <returns></returns>
        //public async Task<int> UpdateDetail(DictionaryDetailSingleDto detailEntity)
        //{
        //    return await Task.Run(() =>
        //    {
        //        DictionaryEntity.DetailEntity detail = null;

        //        var list = _repository.UpdateDetail(detail);
        //        return _mapper.Map<int>(list);
        //    });
        //}

        /// <summary>
        /// 删除子表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<int> DeleteDetail(object key)
        {
            return await Task.Run(() =>
            {
                var list = _repository.DeleteDetail(key);
                return _mapper.Map<int>(list);
            });
        }
        #endregion
    }
}

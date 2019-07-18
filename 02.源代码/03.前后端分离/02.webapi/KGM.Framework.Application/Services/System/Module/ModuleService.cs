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

    public class ModuleService : BaseService<ModuleEntity>, IModuleService
    {
        #region 私有成员
        private readonly IModuleRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public ModuleService(IModuleRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        #endregion

        #region 接口实现 
        /// <summary>
        /// 获取模块按钮树形
        /// </summary>
        /// <returns></returns>
        public  async Task<List<ModuleSingleDto>> QueryAllModule()
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryAllModule();
                return _mapper.Map<List<ModuleSingleDto>>(list);
            });
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Update(ModuleEntity entity) {
            return await Task.Run(()=>
            {
                return _repository.Update(entity);
            }
            );
        }
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public async Task<PagerEntity<ModuleGridDto>> QueryModuleByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null)
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryModuleByPagers(pager, condition);
                return _mapper.Map<PagerEntity<ModuleGridDto>>(list);
            });
        }

        #endregion
    }
}

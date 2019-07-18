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
    /// 角色服务实现
    /// </summary>
    public class RoleService : BaseService<RoleEntity>, IRoleService
    {
        #region 私有成员
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public RoleService(IRoleRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        #endregion
        #region 接口实现
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Update(RoleEntity entity)
        {
            return await Task.Run(() =>
            {
                return _repository.Update(entity);
            }
            );
        }
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="condition"></param>
        /// <returns></returns>

        public async Task<PagerEntity<RoleSingleDto>> QueryRoleByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null)
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryRoleByPagers(pager, condition);
                return _mapper.Map<PagerEntity<RoleSingleDto>>(list);
            });
        }
        #endregion

    }
}

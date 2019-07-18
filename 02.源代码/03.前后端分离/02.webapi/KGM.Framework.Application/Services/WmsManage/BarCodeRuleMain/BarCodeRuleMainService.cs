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
    /// 部门服务实现
    /// </summary>
    public class BarCodeRuleMainService : BaseService<BarCodeRuleMainEntity>, IBarCodeRuleMainService
    {
        #region 私有成员
        private readonly IBarCodeRuleMainRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public BarCodeRuleMainService(IBarCodeRuleMainRepository repository, IMapper mapper) : base(repository, mapper)
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
        public async Task<PagerEntity<BarCodeRuleGridDto>> QueryBarCodeRuleByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null)
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryBarCodeRuleByPagers(pager, condition);
                return _mapper.Map<PagerEntity<BarCodeRuleGridDto>>(list);
            });
        }
        #endregion
    }
}

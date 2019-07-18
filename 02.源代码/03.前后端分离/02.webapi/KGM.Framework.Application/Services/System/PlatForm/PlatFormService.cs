using AutoMapper;
using KGM.Framework.Application.Core;
using KGM.Framework.Domain;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 平台服务实现
    /// </summary>
    public class PlatFormService : BaseService<PlatFormEntity>, IPlatFormService
    {
        #region 私有成员
        private readonly IPlatFormRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public PlatFormService(IPlatFormRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        #endregion
    }
}

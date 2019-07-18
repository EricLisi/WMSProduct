using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 收货人服务实现
    /// </summary>
    public class OutStockNoticeBodyService : BaseService<OutStockNoticeBodyEntity, OutStockNoticeBodyGetDto>, IOutStockNoticeBodyService
    {
        #region 私有成员
        private readonly IOutStockNoticeBodyRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public OutStockNoticeBodyService(IOutStockNoticeBodyRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


     
        #endregion
    }
}

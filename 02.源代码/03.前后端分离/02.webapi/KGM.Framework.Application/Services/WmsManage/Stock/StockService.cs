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
    /// 库存服务实现
    /// </summary>
    public class StockService : BaseService<StockEntity, StockGetDto>, IStockService
    {
        #region 私有成员
        private readonly IStockRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public StockService(IStockRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<StockEntity, string> Expression(string keyValue)
        {

            Func<StockEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "barcode":
                    exp = u => u.Barcode;
                    break;
                case "boxno":
                    exp = u => u.BoxNo;
                    break;
                case "productname":
                    exp = u => u.ProductName;
                    break;
                case "qty":
                    exp = u => u.Qty.ToString();
                    break;
                case "creatortime":
                    exp = u => u.CreatorTime.ToString();
                    break;
                default:
                    exp = u => u.SortCode.ToString();
                    break;

            }

            return exp;
        }
        #endregion
    }
}

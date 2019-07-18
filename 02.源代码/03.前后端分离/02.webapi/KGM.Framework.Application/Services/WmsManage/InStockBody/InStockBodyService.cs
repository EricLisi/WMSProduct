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
    /// 部门服务实现
    /// </summary>
    public class InStockBodyService : BaseService<InStockBodyEntity, InStockBodyGetDto>, IInStockBodyService
    {
        #region 私有成员
        private readonly IInStockBodyRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public InStockBodyService(IInStockBodyRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        ///// <summary>
        ///// 排序
        ///// </summary>
        ///// <param name="keyValue"></param>
        ///// <returns></returns>
        //public Func<BarCodeRuleDetailEntity, string> Expression(string keyValue)
        //{

        //    Func<BarCodeRuleDetailEntity, string> exp = null;

        //    switch (keyValue.ToLower())
        //    {
        //        case "encode":
        //            exp = u => u.EnCode;
        //            break;
        //        case "fullname":
        //            exp = u => u.FullName;
        //            break;
        //        case "phone":
        //            exp = u => u.Phone;
        //            break;
        //        case "person":
        //            exp = u => u.Person;
        //            break;

        //        case "mobile":
        //            exp = u => u.Mobile;
        //            break;

        //        case "email":
        //            exp = u => u.Email;
        //            break;

        //        case "address":
        //            exp = u => u.Address;
        //            break;

        //        case "city":
        //            exp = u => u.City;
        //            break;

        //        case "unitprice":
        //            exp = u => u.UnitPrice.ToString();
        //            break;

        //        case "norenttime":
        //            exp = u => u.NoRentTime.ToString();
        //            break;

        //        case "ownership":
        //            exp = u => u.Ownership;
        //            break;

        //        case "creatortime":
        //            exp = u => u.CreatorTime.ToString();
        //            break;
        //        default:
        //            exp = u => u.SortCode.ToString();
        //            break;

        //    }

        //    return exp;
        //}
        #endregion
    }
}

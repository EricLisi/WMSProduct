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
    public class InStockHeadService : BaseService<InStockHeadEntity, InStockHeadGetDto>, IInStockHeadService
    {
        #region 私有成员
        private readonly IInStockHeadRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public InStockHeadService(IInStockHeadRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        /// <summary>
        /// 审核弃审
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public ReturnModel VerifyList(string ID, string User, int orderType)
        {
            return _mapper.Map<ReturnModel>(_repository.VerifyList(ID, User, orderType));
        }
        ///// <summary>
        ///// 添加或修改入库通知单
        ///// </summary>
        ///// <param name="ds"></param>
        ///// <returns></returns>
        //public ReturnModel InsUpdateBarCodeRule(DataSet ds)

        //{
        //    return _mapper.Map<ReturnModel>(_repository.InsUpdateBarCodeRule(ds));

        //}

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //public ReturnModel DeleteBarCodeRule(string Id)
        //{
        //    GetResultModel model = _repository.DeleteBarCodeRule(Id);
        //    ReturnModel @return = _mapper.Map<ReturnModel>(model);
        //    return @return;

        //}

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<InStockHeadEntity, string> Expression(string keyValue)
        {

            Func<InStockHeadEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "orderNo":
                    exp = u => u.OrderNo;
                    break;
                case "parentOrderNo":
                    exp = u => u.ParentOrderNo;
                    break;
                case "maker":
                    exp = u => u.Maker;
                    break;
                case "date":
                    exp = u => u.Date.ToString();
                    break;
                case "verifier":
                    exp = u => u.Verifier;
                    break;
                case "veridate":
                    exp = u => u.Veridate.ToString();
                    break;
                case "status":
                    exp = u => u.Status.ToString();
                    break;
                case "creatorTime":
                    exp = u => u.CreatorTime.ToString();
                    break;
                default:
                    exp = u => u.Id;
                    break;

            }

            return exp;
        }
        #endregion
    }
}

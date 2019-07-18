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
    /// 拣货单服务实现
    /// </summary>
    public class SRMainService : BaseService<SRMainEntity, SRMainGetDto>, ISRMainService
    {
        #region 私有成员
        private readonly ISRMainRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public SRMainService(ISRMainRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        /// <summary>
        /// 回写快递单号
        /// </summary>
        /// <param name="dt"></param>
        public void ReWriteLogicCode(DataTable dt) {
            _repository.ReWriteLogicCode(dt);
        }

       
        /// <summary>
        /// 生成拣货单
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public List<PackListModelDto> GeneratePackList(DataTable dt, string User, int orderType) {
            return _mapper.Map<List<PackListModelDto>>(_repository.GeneratePackList(dt, User, orderType));
        }


        /// <summary>
        /// 创建快递单订单号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public DataTable GetExpOrder(string orderNo) {
            return _repository.GetExpOrder(orderNo);
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<SRMainEntity, string> Expression(string keyValue)
        {

            Func<SRMainEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "orderno":
                    exp = u => u.orderNo;
                    break;
                case "senddate":
                    exp = u => u.sendDate.ToString();
                    break;
                //case "arrvedate":
                //    exp = u => u.arrveDate.ToString();
                //    break;
                //case "maker":
                //    exp = u => u.Maker;
                //    break;
                //case "date":
                //    exp = u => u.Date.ToString();
                //    break;
                //case "verify":
                //    exp = u => u.Verify;
                //    break;
                //case "veriDate":
                //    exp = u => u.VeriDate.ToString();
                //    break;

                //case "Status":
                //    exp = u => u.Status.ToString();
                //    break;

                //case "islock":
                //    exp = u => u.isLock.ToString();
                //    break;

                //case "ispack":
                //    exp = u => u.isPack.ToString();
                //    break;
                case "property":
                    exp = u => u.Property.ToString();
                    break;
                case "description":
                    exp = u => u.Description;
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

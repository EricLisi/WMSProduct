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
    /// 入库通知单服务实现
    /// </summary>
    public class OutStockHeadService : BaseService<OutStockHeadEntity, OutStockHeadGetDto>, IOutStockHeadService
    {
        #region 私有成员
        private readonly IOutStockHeadRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public OutStockHeadService(IOutStockHeadRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }



        /// <summary>
        /// 添加或修改入库通知单
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public  ReturnModel InsUpdateOutStock(DataSet ds)

        { 
            return  _mapper.Map<ReturnModel>(_repository.InsUpdateOutStock(ds));

        }
      
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ReturnModel DeleteOutStock(string Id) {
            GetResultModel model = _repository.DeleteOutStock(Id);
            ReturnModel @return = _mapper.Map<ReturnModel>(model);
            return @return;

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
            return _mapper.Map<ReturnModel>(_repository.VerifyList(ID,User,orderType));
        }
        
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<OutStockHeadEntity, string> Expression(string keyValue)
        {

            Func<OutStockHeadEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "orderNo":
                    exp = u => u.OrderNo;    
                    break;
                case "customerId":  
                    exp = u => u.CustomerId;
                    break;
                case "warehouseId":
                    exp = u => u.WarehouseId;
                    break;
                case "srTypeId":
                    exp = u => u.SrTypeId;
                    break;
                case "ownerId":
                    exp = u => u.OwnerId;
                    break;
                case "type":
                    exp = u => u.Type;
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
                case "allPrice":
                    exp = u => u.AllPrice.ToString();
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

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
    public class InStockNoticeHeadService : BaseService<InStockNoticeHeadEntity, InStockNoticeHeadGetDto>, IInStockNoticeHeadService
    {
        #region 私有成员
        private readonly IInStockNoticeHeadRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public InStockNoticeHeadService(IInStockNoticeHeadRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }



        /// <summary>
        /// 添加或修改入库通知单
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public  ReturnModel InsUpdateInStockNotice(DataSet ds)

        { 
            return  _mapper.Map<ReturnModel>(_repository.InsUpdateInStockNotice(ds));

        }
      
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ReturnModel DeleteInStockNotice(string Id) {
            GetResultModel model = _repository.DeleteInStockNotice(Id);
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
        /// 快速上架
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="PositionCode"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public ReturnModel QuickShelf(string orderNo, string PositionCode, string User)
        {
            return _mapper.Map<ReturnModel>(_repository.QuickShelf(orderNo, PositionCode, User));
        }

        /// <summary>
        /// 到货完成
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public ReturnModel QuickPU(DataTable dt, string User) {
            return _mapper.Map<ReturnModel>(_repository.QuickPU(dt, User));
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<InStockNoticeHeadEntity, string> Expression(string keyValue)
        {

            Func<InStockNoticeHeadEntity, string> exp = null;

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

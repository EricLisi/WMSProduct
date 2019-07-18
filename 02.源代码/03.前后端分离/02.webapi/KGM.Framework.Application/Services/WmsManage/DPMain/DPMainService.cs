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
    public class DPMainService : BaseService<DPMainEntity, DPMainGetDto>, IDPMainService
    {
        #region 私有成员
        private readonly IDPMainRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public DPMainService(IDPMainRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

       

        /// <summary>
        /// 添加或修改入库通知单
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public  ReturnModel InsUpdateDP(DataSet ds)

        { 
            return  _mapper.Map<ReturnModel>(_repository.InsUpdateDP(ds));

        }
      
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ReturnModel DeleteDP(string Id) {
            GetResultModel model = _repository.DeleteDP(Id);
            ReturnModel @return = _mapper.Map<ReturnModel>(model);
            return @return;

        }
       /// <summary>
       /// 审核，弃审
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
        public Func<DPMainEntity, string> Expression(string keyValue)
        {

            Func<DPMainEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "encode":
                    exp = u => u.EnCode;
                    break;
                case "fullname":
                    exp = u => u.FullName;
                    break;
                //case "arrvedate":
                //    exp = u => u.arrveDate.ToString();
                //    break;
                case "maker":
                    exp = u => u.Maker;
                    break;
                case "date":
                    exp = u => u.Date.ToString();
                    break;
                case "verify":
                    exp = u => u.Verify;
                    break;
                case "veriDate":
                    exp = u => u.VeriDate.ToString();
                    break;

                case "Status":
                    exp = u => u.Status.ToString();
                    break;

                case "islock":
                    exp = u => u.isLock.ToString();
                    break;

                case "ispack":
                    exp = u => u.isPack.ToString();
                    break;
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

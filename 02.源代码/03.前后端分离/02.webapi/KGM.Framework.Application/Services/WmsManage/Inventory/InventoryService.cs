using System;
using AutoMapper;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using System.Data.SqlClient;
namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 收货人服务实现
    /// </summary>
    public class InventoryService : BaseService<InventoryEntity, InventoryGetDto>, IInventoryService
    {
        #region 私有成员
        private readonly IInventoryRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public InventoryService(IInventoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        /// <summary>
        /// 获取SKU
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public String GetSkU(int len)
        {

            var SKU = this._repository.GetSku(len);
            return SKU.ToString();
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<InventoryEntity, string> Expression(string keyValue)
        {

            Func<InventoryEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "encode":
                    exp = u => u.EnCode;
                    break;
                case "fullname":
                    exp = u => u.FullName;
                    break;
                case "sku":
                    exp = u => u.InvSKU;
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

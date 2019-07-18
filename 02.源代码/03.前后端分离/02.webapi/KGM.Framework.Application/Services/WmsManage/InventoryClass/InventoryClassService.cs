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
    public class InventoryClassService : BaseService<InventoryClassEntity, InventoryClassGetDto>, IInventoryClassService
    {
        #region 私有成员
        private readonly IInventoryClassRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public InventoryClassService(IInventoryClassRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        ///// <returns></returns>
        public Func<InventoryClassEntity, string> Expression(string keyValue)
        {

            Func<InventoryClassEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "encode":
                    exp = u => u.EnCode;
                    break;
                case "fullname":
                    exp = u => u.FullName;
                    break;

                case "description":
                    exp = u => u.Description;
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

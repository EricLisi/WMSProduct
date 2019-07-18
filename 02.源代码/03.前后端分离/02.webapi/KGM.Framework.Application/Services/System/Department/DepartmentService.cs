
using AutoMapper;
using KGM.Framework.Application.Core;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 部门服务实现
    /// </summary>
  public  class DepartmentService: BaseService<DepartmentEntity>, IDepartmentService
    {
        #region 私有成员
        private readonly IDepRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public DepartmentService(IDepRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<DepartmentEntity, string> Expression(string keyValue)
        {

            Func<DepartmentEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "encode":
                    exp = u => u.EnCode;
                    break;
                case "fullname":
                    exp = u => u.FullName;
                    break;
                case "shortname":
                    exp = u => u.ShortName;
                    break;
                case "nature":
                    exp = u => u.Nature.ToString();
                    break;

                case "manager":
                    exp = u => u.Manager;
                    break;
                case "phone":
                    exp = u => u.Phone;
                    break;
                case "creatortime":
                    exp = u => u.CreatorTime.ToString();
                    break;
                case "fax":
                    exp = u => u.Fax;
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
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>

        public async Task<PagerEntity<DepartmentSingleDto>> QueryDepartmentByPagesAsync(PagerInfo pager, List<SearchCondition> condition)
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryDepartmentByPagers(pager, condition);
                return _mapper.Map<PagerEntity<DepartmentSingleDto>>(list);
            });
        }
        #endregion
    }
}

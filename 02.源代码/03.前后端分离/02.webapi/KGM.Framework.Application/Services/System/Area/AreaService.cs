
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
    /// 角色服务实现
    /// </summary>
    ///     public class CompanyService : BaseService<CompanyEntity>, ICompanyService
    public class AreaService : BaseService<AreaEntity>, IAreaService
    {
        #region 私有成员
        private readonly IAreaRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public AreaService(IAreaRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<AreaEntity, string> Expression(string keyValue)
        {


            Func<AreaEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "encode":
                    exp = u => u.EnCode;
                    break;
                case "fullname":
                    exp = u => u.FullName;
                    break;
                case "simplespelling":
                    exp = u => u.SimpleSpelling;
                    break;
                case "creatortime":
                    exp = u => u.CreatorTime.ToString();
                    break;
                case "description":
                    exp = u => u.Description;
                    break;
                case "sortcode":
                    exp = u => u.SortCode.ToString();
                    break;
                default:
                    exp = u => u.Id;
                    break;
            }

            return exp;

        }

        #endregion

        #region 接口实现
        /// <summary>
        /// 获取所有地区
        /// </summary>
        /// <returns></returns>
        public async Task<List<AreaSingleDto>> QueryAll()
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryAll();
                return _mapper.Map<List<AreaSingleDto>>(list);
            }
          );
        }
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>

        public async Task<PagerEntity<AreaSingleDto>> QueryAreaByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null)
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryAreaByPagers(pager, condition);
                return _mapper.Map<PagerEntity<AreaSingleDto>>(list);
            });
        }
        /// <summary>
        /// 根据省份查询城市
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<PagerEntity<AreaSingleDto>> QueryCityByProvinceAsync(string Id)
        {
            return await Task.Run(() =>
            {
                var list = _repository.QueryCityByProvinceAsync(Id);
                return _mapper.Map<PagerEntity<AreaSingleDto>>(list);
            });
        }


        #endregion
    }
}

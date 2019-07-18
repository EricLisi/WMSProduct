using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KGM.Framework.Application.Core;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 地区服务接口
    /// </summary>
    public interface IAreaService : IService<AreaEntity>
    {
        /// <summary>
        /// 获取所有地区不分页
        /// </summary>
        /// <returns></returns>
        Task<List<AreaSingleDto>> QueryAll();
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Func<AreaEntity, string> Expression(string keyValue);
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<AreaSingleDto>> QueryAreaByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null);
        /// <summary>
        /// 根据省份查询城市
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<PagerEntity<AreaSingleDto>> QueryCityByProvinceAsync(string Id);
    }
}

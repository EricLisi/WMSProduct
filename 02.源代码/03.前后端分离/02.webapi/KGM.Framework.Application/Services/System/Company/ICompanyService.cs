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
    /// 公司服务接口
    /// </summary>
    public interface ICompanyService : IService<CompanyEntity>
    {

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Update(CompanyEntity entity);
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Func<CompanyEntity, string> Expression(string keyValue);
        /// <summary>
        /// 分页查询 + 条件查询 + 排序(公司)
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        Task<PagerEntity<CompanySingleDto>> QueryCompanyByPagesAsync(PagerInfo pager, List<SearchCondition> condition = null);
        /// <summary>
        /// 分页查询 + 条件查询 + 排序(部门 )
        /// </summary> 
        /// <param name="pager">分页对象</param>
        /// <param name="codition">过滤条件</param>
        Task<PagerEntity<DepartmentSingleDto>> QueryDepartmentByPagesAsync(PagerInfo pager, List<SearchCondition> codition = null);

    }
}

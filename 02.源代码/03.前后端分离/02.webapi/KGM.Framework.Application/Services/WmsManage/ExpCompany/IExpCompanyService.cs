using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 客户服务接口
    /// </summary>
    public interface IExpCompanyService : IService<ExpCompanyEntity, ExpCompanyGetDto>
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Func<ExpCompanyEntity, string> Expression(string keyValue);
        ///// <summary>
        ///// 获取分页信息
        ///// </summary>
        ///// <param name="returnEntity">分页entity</param>
        ///// <param name="searchDto">查询Dto</param>
        ///// <param name="sidx">排序字段</param>
        ///// <param name="IsAsc">升序降序</param>
        ///// <returns></returns>
        //Task<PagerEntity<ExpCompanyGetDto>>  GetPagerEntity(ReturnEntity returnEntity, ExpCompanySearchDto searchDto, string sidx, bool IsAsc);
    }
}

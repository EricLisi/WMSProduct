using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    public interface ICompanyRepository : IRepository<CompanyEntity>
    {
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <returns></returns>
        int Update(CompanyEntity moduleEntity);
        /// <summary>
        /// 分页查询 + 条件查询 + 排序(公司)
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<CompanyEntity> QueryCompanyByPagers(PagerInfo pager, List<SearchCondition> condition = null);
        /// <summary>
        /// 分页查询 + 条件查询 + 排序(部门)
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        PagerEntity<CompanyEntity.DepartmentEntity> QueryDepartmentByPagers(PagerInfo pager, List<SearchCondition> condition = null);
    }
}

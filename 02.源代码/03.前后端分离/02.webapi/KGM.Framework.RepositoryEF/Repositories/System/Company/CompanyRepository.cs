using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    public class CompanyRepository : BaseRepository<CompanyEntity, CompanyContext>, ICompanyRepository
    {
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CompanyRepository() : base()
        {
        }
        #endregion

        #region 私有方法
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="context"> dbcontext </param>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        private CompanyEntity GetByKey(CompanyContext context, object key)
        {
            return context.CurrentDbSet
                .Where(it => it.Id.Equals(key))
                .Include(it => it.Departments)
                .FirstOrDefault();
        }
        #endregion

        #region 重写基类的接口
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override int Update(CompanyEntity entity)
        {

            using (var uow = new EFUnitOfWork<CompanyContext>(CurrentDbContext))
            {
                //更新主表
                uow.RegisterModified(entity, true);
                //得到现在所有的department
                var departments = uow.DbContext.Department
                    .Where(it => it.CompanyId.Equals(entity.Id));
                //读取出不在当前departments集合内的department,这部分作为删除对象
                var departmentDeleted = departments
                    .Where(it => !entity.Departments.Any(t => t.Id.Equals(it.Id)));
                //循环
                foreach (var department in departmentDeleted)
                {
                    //将这部分department作为删除  

                    uow.RegisterDeleted(department);
                }
                //找出当前不在数据库内的departments,作为新增对象
                var dptAdd = entity.Departments
                    .Where(it => !departments.Any(t => t.Id.Equals(it.Id)));
                //循环
                foreach (var button in dptAdd)
                {
                    //将这部分department作为新增
                    uow.RegisterNew(button);
                }
                //得到更新部分
                var departmentModify = entity.Departments
                    .Where(it => departments.Any(t => t.Id.Equals(it.Id)));
                //循环
                foreach (var department in departmentModify)
                {
                    //将这部分department作为新增
                    uow.RegisterModified(department);
                }
                return uow.Commit();
            }
        }
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public override CompanyEntity GetByKey(object key)
        {
            return GetByKey(CurrentDbContext, key);
        }

        /// <summary>
        ///删除指定编号的记录
        /// </summary>
        /// <param name="key"> 实体记录编号 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int DeleteByKey(object key)
        {
            using (var uow = new EFUnitOfWork<CompanyContext>(CurrentDbContext))
            { 
                //设置级联删除以后,取对象必须先InClude
                var entity = GetByKey(uow.DbContext, key); 
                uow.RegisterDeleted(entity);

                return uow.Commit();
            }
        }
        #endregion

        #region 自身接口实现
        // <summary>
        /// 分页查询 + 条件查询 + 排序(部门)
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        public PagerEntity<CompanyEntity.DepartmentEntity> QueryDepartmentByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbContext.Department.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<CompanyEntity.DepartmentEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<CompanyEntity.DepartmentEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }

        /// <summary>
        /// 分页查询 + 条件查询 + 排序(公司)
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 

        public PagerEntity<CompanyEntity> QueryCompanyByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {

            var entity = CurrentDbSet.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<CompanyEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<CompanyEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }
        #endregion
    }
}

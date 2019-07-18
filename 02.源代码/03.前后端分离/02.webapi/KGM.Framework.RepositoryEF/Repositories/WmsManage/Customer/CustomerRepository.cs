using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using KGM.Framework.RepositoryEF.Core;
using KGM.Framework.RepositoryEF.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    /// <summary>
    /// 模块的仓储方法
    /// </summary>
    public class CustomerRepository : BaseRepository<CustomerEntity, CustomerContext>, ICustomerRepository
    {
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CustomerRepository() : base()
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
        private CustomerEntity GetByKey(CustomerContext context, object key)
        {
            return context.CurrentDbSet
                .Where(it => it.Id.Equals(key))
                .Include(it => it.OwnerEntities)
                .FirstOrDefault();
        }
        #endregion

        #region 重写基类的接口
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public override CustomerEntity GetByKey(object key)
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
            using (var uow = new EFUnitOfWork<CustomerContext>(CurrentDbContext))
            {
                //设置级联删除以后,取对象必须先InClude
                var entity = GetByKey(uow.DbContext, key);

                uow.RegisterDeleted(entity);

                return uow.Commit();
            }
        }


        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override int Update(CustomerEntity entity)
        {
            using (var uow = new EFUnitOfWork<CustomerContext>(CurrentDbContext))
            {
                //更新主表
                uow.RegisterModified(entity, true);
                //得到现在所有的button,column,form
                var Owner = uow.DbContext.Owner
                    .Where(it => it.CusId.Equals(entity.Id));

                var OwnerDeleted = Owner
                    .Where(it => !entity.OwnerEntities.Any(t => t.Id.Equals(it.Id)));

                foreach (var item in OwnerDeleted)
                {
                    uow.RegisterDeleted(item);
                }

                var OwnerAdd = entity.OwnerEntities
                    .Where(it => !Owner.Any(t => t.Id.Equals(it.Id)));


                foreach (var item in OwnerAdd)
                {
                    uow.RegisterNew(item);
                }

                var OwnerModify = entity.OwnerEntities
                    .Where(it => Owner.Any(t => t.Id.Equals(it.Id)));

                foreach (var item in OwnerModify)
                {
                    uow.RegisterModified(item);
                }
                return uow.Commit();
            }
        }


        #endregion

        #region 自身接口实现
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        public PagerEntity<CustomerEntity> QueryCustomerByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbSet.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<CustomerEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<CustomerEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }



        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        public PagerEntity<CustomerEntity.OwnerEntity> QueryCustomerOwnerByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbContext.Owner.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<CustomerEntity.OwnerEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<CustomerEntity.OwnerEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }
        #endregion

    }
}

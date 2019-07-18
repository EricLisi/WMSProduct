using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    /// <summary>
    /// 模块的仓储方法
    /// </summary>
    public class DictionaryRepository : BaseRepository<DictionaryEntity, DictionaryContext>, IDictionaryRepository
    {
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DictionaryRepository() : base()
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
        private DictionaryEntity GetByKey(DictionaryContext context, object key)
        {
            return context.CurrentDbSet
                .Where(it => it.Id.Equals(key))
                .Include(it => it.DetailEntities)
                .FirstOrDefault();
        }

        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="context"> dbcontext </param>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        private DictionaryEntity.DetailEntity GetByKeyItem(DictionaryContext context, object key)
        {
            return context.Detail
                .Where(it => it.Id.Equals(key))
                .FirstOrDefault();
        }
        #endregion

        #region 重写基类的接口
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public override DictionaryEntity GetByKey(object key)
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
            using (var uow = new EFUnitOfWork<DictionaryContext>(CurrentDbContext))
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
        public override int Update(DictionaryEntity entity)
        {
            using (var uow = new EFUnitOfWork<DictionaryContext>(CurrentDbContext))
            {
                //更新主表
                uow.RegisterModified(entity, true);
                //得到现在所有的button,column,form
                var Items = uow.DbContext.Detail
                    .Where(it => it.ItemId.Equals(entity.Id));

                var ItemsDeleted = Items
                    .Where(it => !entity.DetailEntities.Any(t => t.Id.Equals(it.Id)));

                foreach (var item in ItemsDeleted)
                {
                    uow.RegisterDeleted(item);
                }

                var ItemsAdd = entity.DetailEntities
                    .Where(it => !Items.Any(t => t.Id.Equals(it.Id)));

                
                foreach (var item in ItemsAdd)
                {
                    uow.RegisterNew(item);
                }

                var ItemsModify = entity.DetailEntities
                    .Where(it => Items.Any(t => t.Id.Equals(it.Id)));

                foreach (var item in ItemsModify)
                {
                    uow.RegisterModified(item);
                }
                return uow.Commit();
            }
        }


        /// <summary>
        ///删除指定编号的记录
        /// </summary>
        /// <param name="key"> 实体记录编号 </param>
        /// <returns> 操作影响的行数 </returns>
        //public int DeleteItemByKey(object key)
        //{
        //    using (var uow = new EFUnitOfWork<DictionaryContext>(CurrentDbContext))
        //    {
        //        var entity = GetByKeyItem(uow.DbContext, key);

        //        //var items = uow.DbContext.Detail
        //        //    .Where(it => it.ItemId.Equals(entity.Id));

        //        uow.RegisterDeleted<DictionaryEntity.DetailEntity>(entity);

        //        return uow.Commit();
        //    }

        //}
        #endregion

        #region 自身接口实现
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        public PagerEntity<DictionaryEntity.DetailEntity> QueryItemByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbContext.Detail.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<DictionaryEntity.DetailEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<DictionaryEntity.DetailEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }

        /// <summary>
        /// 分页查询 + 条件查询 + 排序 主表
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        public PagerEntity<DictionaryEntity> QueryDictionaryByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbSet.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<DictionaryEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<DictionaryEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }

        ///// <summary>
        ///// 更新子表
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public int UpdateDetail(DictionaryEntity.DetailEntity entity)
        //{
        //    using (var uow = new EFUnitOfWork<DictionaryContext>(CurrentDbContext))
        //    {
        //        //更新主表
        //        uow.RegisterModified(entity);

        //        return uow.Commit();
        //    }
        //}

        /// <summary>
        /// 删除子表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int DeleteDetail(object key)
        {
            using (var uow = new EFUnitOfWork<DictionaryContext>(CurrentDbContext))
            {
                //设置级联删除以后,取对象必须先InClude
                var entity = GetByKeyItem(uow.DbContext, key);

                uow.RegisterDeleted<DictionaryEntity.DetailEntity>(entity);

                return uow.Commit();
            }
        }

        #endregion

    }
}


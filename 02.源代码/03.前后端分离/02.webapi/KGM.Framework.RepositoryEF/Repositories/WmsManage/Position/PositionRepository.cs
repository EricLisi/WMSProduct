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
    public class PositionRepository : BaseRepository<PositionEntity, PositionContext>, IPositionRepository
    {
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public PositionRepository() : base()
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
        private PositionEntity GetByKey(PositionContext context, object key)
        {
            return context.CurrentDbSet
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
        public override PositionEntity GetByKey(object key)
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
            using (var uow = new EFUnitOfWork<PositionContext>(CurrentDbContext))
            {
                //设置级联删除以后,取对象必须先InClude
                var entity = GetByKey(uow.DbContext, key);

                uow.RegisterDeleted(entity);

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
        public PagerEntity<PositionEntity> QueryPositionByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbSet.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<PositionEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<PositionEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }
        #endregion

    }
}

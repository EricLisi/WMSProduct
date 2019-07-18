using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using KGM.Framework.RepositoryEF.Core;
using KGM.Framework.RepositoryEF.DbContext;
using System.Collections.Generic;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    public class AreaRepository : BaseRepository<AreaEntity, AreaContext>, IAreaRepository
    {
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public AreaRepository() : base()
        {
        }


        #endregion
        #region 自身接口实现
        /// <summary>
        /// 根据省份获取城市
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PagerEntity<AreaEntity> QueryCityByProvinceAsync(string Id)
        {
            var entity = CurrentDbSet.Where(it=>it.ParentId==Id);
            return new PagerEntity<AreaEntity>
            {
                Entity = entity.ToList()
            };

        }
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 

        public PagerEntity<AreaEntity> QueryAreaByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbSet.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<AreaEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<AreaEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }
        /// <summary>
        /// 获取所有地区不分页
        /// </summary>
        /// <returns></returns>
        public List<AreaEntity> QueryAll()
        {
            var entity = CurrentDbSet.Where(it => true);
            return entity.ToList();
        }
        #endregion
    }
}

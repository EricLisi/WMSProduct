using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    public class UserRepository : BaseRepository<UserEntity,UserContext>, IUserRepository
    {
         
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public UserRepository() : base()
        {
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 查找指定主键的实体记录
        /// </summary>
        /// <param name="dbContext">DbContext</param>
        /// <param name="key">指定主键</param>
        /// <returns></returns>
        private UserEntity GetByKey(UserContext dbContext, object key)
        {
            return dbContext.CurrentDbSet
               .Where(it => it.Id.Equals(key))
               .Include(it => it.Company)
               .Include(it => it.Department)
               .Include(it => it.Role)
               .FirstOrDefault();
        }
        #endregion

        #region 重写基类的接口
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public override UserEntity GetByKey(object key)
        { 
            return GetByKey(CurrentDbContext, key);
        }
        //public UserEntity QueryByIdAsync(string Id)
        //{

        //}
        #endregion


        #region 自身接口实现
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        public PagerEntity<UserEntity> QueryUserByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
           
            var entity = CurrentDbSet.Where(it => true);
            
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<UserEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<UserEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }

        public int UpdatePwd(string Id,string Pwd)
        {
            using (var uow = new EFUnitOfWork<UserContext>(CurrentDbContext))
            {
                //设置级联删除以后,取对象必须先InClude
                var entity = GetByKey(uow.DbContext, Id);
                entity.Password = Pwd;
                uow.RegisterModified(entity, true);

                return uow.Commit();
            }
        }
        #endregion
    }
}

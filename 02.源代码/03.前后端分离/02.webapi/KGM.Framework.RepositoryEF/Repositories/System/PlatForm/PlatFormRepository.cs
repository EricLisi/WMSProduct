using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    public class PlatFormRepository : BaseRepository<PlatFormEntity, PlatFormContext>, IPlatFormRepository
    {
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public PlatFormRepository() : base()
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
        private PlatFormEntity GetByKey(PlatFormContext dbContext, object key)
        {
            return dbContext.CurrentDbSet
               .Where(it => it.Id.Equals(key))
               .Include(it => it.Modules)
               .FirstOrDefault();
        }

        #endregion

        #region 重写基类的接口
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public override PlatFormEntity GetByKey(object key)
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
            using (var uow = new EFUnitOfWork<PlatFormContext>(CurrentDbContext))
            { 
                //设置级联删除以后,取对象必须先InClude
                var entity = GetByKey(uow.DbContext, key);

                uow.RegisterDeleted(entity);

                return uow.Commit();
            }
        }
        #endregion
    }
}

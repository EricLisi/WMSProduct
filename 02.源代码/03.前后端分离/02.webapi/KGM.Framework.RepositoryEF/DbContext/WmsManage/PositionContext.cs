using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using KGM.Framework.RepositoryEF.DbContext.Mapping.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF.DbContext
{
  public  class PositionContext : EFDbContext<PositionEntity, PositionContext>
    {
        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PositionMapping.MappingToTable(modelBuilder);
        }
    }
}

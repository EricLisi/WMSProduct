using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    public class PlatFormContext : EFDbContext<PlatFormEntity, PlatFormContext>
    {
        public DbSet<ModuleEntity> Module { get; set; }

        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PlatFormMapping.MappingToTable(modelBuilder);
        }
    }
}


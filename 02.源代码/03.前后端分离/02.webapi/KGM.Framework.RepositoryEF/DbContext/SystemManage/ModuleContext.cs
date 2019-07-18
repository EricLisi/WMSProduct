using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    public class ModuleContext : EFDbContext<ModuleEntity, ModuleContext>
    {

        public DbSet<ModuleEntity.ButtonEntity> Button { get; set; }
        public DbSet<ModuleEntity.ColumnEntity> Column { get; set; }
        public DbSet<ModuleEntity.FormEntity> Form { get; set; }
        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
         
            ModuleMapping.MappingToTable(modelBuilder);
           
        }
    }
}


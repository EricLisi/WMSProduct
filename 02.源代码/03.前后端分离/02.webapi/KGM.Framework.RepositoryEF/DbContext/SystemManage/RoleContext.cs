using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    public class RoleContext : EFDbContext<RoleEntity, RoleContext>
    {
        public DbSet<RoleEntity.RoleButtonEntity> RoleButton { get; set; }
        public DbSet<RoleEntity.RoleColumnEntity> RoleColumn { get; set; }
        //public DbSet<RoleEntity.RoleFormEntity> RoleForm { get; set; }
        public DbSet<RoleEntity.RoleModuleEntity> RoleModule { get; set; } 
        public DbSet<ModuleEntity> Module { get; set; }
        public DbSet<ModuleEntity.ButtonEntity> Button { get; set; }
        public DbSet<ModuleEntity.ColumnEntity> Column { get; set; }
        //public DbSet<ModuleEntity.FormEntity> Form { get; set; }

        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoleMapping.MappingToTable(modelBuilder);

        }
    }
}


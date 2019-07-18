using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    public class UserContext :EFDbContext<UserEntity,UserContext>
    {
        public DbSet<CompanyEntity> Company { get; set; }
        public DbSet<CompanyEntity.DepartmentEntity> Department { get; set; }
        public DbSet<RoleEntity> Role { get; set; }

        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //对 StudentMap 进行配置
            UserMapping.MappingToTable(modelBuilder);
        } 
    }
}


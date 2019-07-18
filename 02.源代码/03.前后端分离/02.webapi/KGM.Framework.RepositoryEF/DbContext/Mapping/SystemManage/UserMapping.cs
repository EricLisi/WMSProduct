using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 用户映射
    /// </summary>
    public class UserMapping : EntityMapping<UserEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public new static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射用户表
            var user = EntityMapping<UserEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射公司表
            EntityMapping<CompanyEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射部门表
            EntityMapping<CompanyEntity.DepartmentEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射角色表
            EntityMapping<RoleEntity>.MappingToTable(modelBuilder, bAutoMapping);

            //设置关系  
            user.HasOne(m => m.Company).WithOne().HasForeignKey<UserEntity>(it => it.CompanyId);
            user.HasOne(m => m.Department).WithOne().HasForeignKey<UserEntity>(it => it.DepartmentId);
            user.HasOne(m => m.Role).WithOne().HasForeignKey<UserEntity>(it => it.RoleId);
        }
        #endregion
    }
}

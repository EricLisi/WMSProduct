using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 角色映射
    /// </summary>
    public class RoleMapping :EntityMapping<RoleEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public new static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            var role = EntityMapping<RoleEntity>.MappingToTable(modelBuilder, bAutoMapping);
            ////映射 模块
            //EntityMapping<RoleEntity.RoleModuleEntity>.MappingToTable(modelBuilder, bAutoMapping);
            ////映射列
            //EntityMapping<RoleEntity.RoleColumnEntity>.MappingToTable(modelBuilder, bAutoMapping);
            ////映射按钮
            //EntityMapping<RoleEntity.RoleButtonEntity>.MappingToTable(modelBuilder, bAutoMapping);
            var roleModule = EntityMapping<RoleEntity.RoleModuleEntity>.MappingToTable(modelBuilder, bAutoMapping);
            var roleButton = EntityMapping<RoleEntity.RoleButtonEntity>.MappingToTable(modelBuilder, bAutoMapping);
            var roleColumn = EntityMapping<RoleEntity.RoleColumnEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //var roleForm = EntityMapping<RoleEntity.RoleFormEntity>.MappingToTable(modelBuilder, bAutoMapping);

            //映射模块表
            EntityMapping<ModuleEntity>.MappingToTable(modelBuilder, bAutoMapping);
            EntityMapping<ModuleEntity.ButtonEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //EntityMapping<ModuleEntity.FormEntity>.MappingToTable(modelBuilder, bAutoMapping);
            EntityMapping<ModuleEntity.ColumnEntity>.MappingToTable(modelBuilder, bAutoMapping);

            //设置关系  
            role.HasMany(m => m.Modules).WithOne(b => b.Role).HasForeignKey(it => it.RoleId).OnDelete(DeleteBehavior.Cascade);
            role.HasMany(m => m.Buttons).WithOne(b => b.Role).HasForeignKey(it => it.RoleId).OnDelete(DeleteBehavior.Cascade);
            role.HasMany(m => m.Columns).WithOne(b => b.Role).HasForeignKey(it => it.RoleId).OnDelete(DeleteBehavior.Cascade);
            //role.HasMany(m => m.Forms).WithOne(b => b.Role).HasForeignKey(it => it.RoleId).OnDelete(DeleteBehavior.Cascade);

            roleModule.HasOne(m => m.Module).WithOne().HasForeignKey<RoleEntity.RoleModuleEntity>(it => it.ModuleId);
            roleButton.HasOne(m => m.Button).WithOne().HasForeignKey<RoleEntity.RoleButtonEntity>(it => it.ModuleButtonId);
            roleColumn.HasOne(m => m.Column).WithOne().HasForeignKey<RoleEntity.RoleColumnEntity>(it => it.ModuleColumnId);
            //roleForm.HasOne(m => m.Form).WithOne().HasForeignKey<RoleEntity.RoleFormEntity>(it => it.ModuleFormId);
        }
        #endregion
    }
}

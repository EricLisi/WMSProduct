using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 模块映射
    /// </summary>
    public class ModuleMapping : EntityMapping<ModuleEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public new static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射模块表
            var module = EntityMapping<ModuleEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射模块按钮表
            EntityMapping<ModuleEntity.ButtonEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射模块表单表
            EntityMapping<ModuleEntity.FormEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射模块列表
            EntityMapping<ModuleEntity.ColumnEntity>.MappingToTable(modelBuilder, bAutoMapping);
                     
            //设置关系  
            module.HasMany(m => m.ButtonEntities).WithOne(b => b.Module).HasForeignKey(it => it.ModuleId).OnDelete(DeleteBehavior.Cascade);
            module.HasMany(m => m.FormEntities).WithOne(b => b.Module).HasForeignKey(it => it.ModuleId).OnDelete(DeleteBehavior.Cascade);
            module.HasMany(m => m.ColumnEntities).WithOne(b => b.Module).HasForeignKey(it => it.ModuleId).OnDelete(DeleteBehavior.Cascade);
        }
        #endregion
    }
}

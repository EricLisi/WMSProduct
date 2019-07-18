using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 平台映射
    /// </summary>
    public class PlatFormMapping : EntityMapping<PlatFormEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public new static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射平台表
            var platForm = EntityMapping<PlatFormEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射模块表
            EntityMapping<ModuleEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //设置关系  
            platForm.HasMany(m => m.Modules).WithOne(b => b.PlatForm).HasForeignKey(it => it.PlatformId).OnDelete(DeleteBehavior.Cascade);
        }
        #endregion
    }
}

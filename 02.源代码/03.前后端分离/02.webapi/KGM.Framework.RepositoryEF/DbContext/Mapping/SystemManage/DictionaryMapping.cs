using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 模块映射
    /// </summary>
    public class DictionaryMapping : EntityMapping<PlatFormEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射模块表
            var dict = EntityMapping<DictionaryEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射模块详情子表
            EntityMapping<DictionaryEntity.DetailEntity>.MappingToTable(modelBuilder, bAutoMapping);

            //设置关系  
            dict.HasMany(m => m.DetailEntities).WithOne(b => b.Dictionary).HasForeignKey(it => it.ItemId).OnDelete(DeleteBehavior.Cascade);
        }
        #endregion
    }
}

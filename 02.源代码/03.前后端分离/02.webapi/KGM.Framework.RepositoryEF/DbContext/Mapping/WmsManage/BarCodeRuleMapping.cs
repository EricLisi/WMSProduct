using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 模块映射
    /// </summary>
    public class BarCodeRuleMapping
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射条码规则表
            var BarCodeRule = EntityMapping<BarCodeRuleMainEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射模块按钮表
            EntityMapping<BarCodeRuleMainEntity.BarCodeRuleDetailEntity>.MappingToTable(modelBuilder, bAutoMapping);

            //设置关系  
            BarCodeRule.HasMany(m => m.BarCodeRuleDetailEntities).WithOne(b => b.BarCodeRuleMain).HasForeignKey(it => it.MainId).OnDelete(DeleteBehavior.Cascade);
        }
        #endregion
    }
}

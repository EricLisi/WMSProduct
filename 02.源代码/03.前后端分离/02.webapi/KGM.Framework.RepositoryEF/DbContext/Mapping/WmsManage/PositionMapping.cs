using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 货位
    /// </summary>
    public class PositionMapping : EntityMapping<PositionEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public new static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射货位表
            var cus = EntityMapping<PositionEntity>.MappingToTable(modelBuilder, bAutoMapping);

        }
        #endregion
    }
}

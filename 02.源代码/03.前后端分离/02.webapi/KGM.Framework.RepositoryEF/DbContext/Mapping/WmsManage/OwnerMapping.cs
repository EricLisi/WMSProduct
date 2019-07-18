using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 地区映射
    /// </summary>
    public class OwnerMapping : EntityMapping<OwnerEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public new static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射权属表
            var cus = EntityMapping<OwnerEntity>.MappingToTable(modelBuilder, bAutoMapping);

        }
        #endregion
    }
}

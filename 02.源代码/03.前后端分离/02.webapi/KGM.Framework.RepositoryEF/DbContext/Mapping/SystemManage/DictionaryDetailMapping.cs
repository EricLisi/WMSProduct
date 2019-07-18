using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 数据字典映射
    /// </summary>
    public class DictionaryDetailMapping : EntityMapping<DictionaryDetailEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射数据字典子表
            var dict = EntityMapping<DictionaryDetailEntity>.MappingToTable(modelBuilder, bAutoMapping);
        }
        #endregion
    }
}

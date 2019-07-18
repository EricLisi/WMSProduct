using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF.DbContext.Mapping.SystemManage
{
    /// <summary>
    /// 地区映射
    /// </summary>
    public class AreaMapping
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射公司表
            var area = EntityMapping<AreaEntity>.MappingToTable(modelBuilder, bAutoMapping);
        }
        #endregion
    }
}

using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF.DbContext
{
    /// <summary>
    /// 部门映射
    /// </summary>
    public class DepartmentMapping : EntityMapping<DepartmentEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public new static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射部门表
            var department = EntityMapping<DepartmentEntity>.MappingToTable(modelBuilder, bAutoMapping);
         
        }
        #endregion
    }
}

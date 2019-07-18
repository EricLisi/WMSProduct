using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 公司映射
    /// </summary>
    public class CompnayMapping:EntityMapping<CompanyEntity>
    {
        #region 接口实现

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="bAutoMapping"></param>
        public new static void MappingToTable(ModelBuilder modelBuilder, bool bAutoMapping = true)
        {
            //映射公司表
            var company = EntityMapping<CompanyEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射部门表
            EntityMapping<CompanyEntity.DepartmentEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //设置关系  
            company.HasMany(m => m.Departments).WithOne(b => b.Company).HasForeignKey(it => it.CompanyId).OnDelete(DeleteBehavior.Cascade);
        }
        #endregion
    }
}

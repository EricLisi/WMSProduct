using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF
{
    /// <summary>
    /// 地区映射
    /// </summary>
    public class CustomerMapping : EntityMapping<CustomerEntity>
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
            var cus = EntityMapping<CustomerEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射模块详情子表
            EntityMapping<CustomerEntity.OwnerEntity>.MappingToTable(modelBuilder, bAutoMapping);

            //映射地区表
            //EntityMapping<AreaEntity>.MappingToTable(modelBuilder, bAutoMapping);

            //设置关系  
            cus.HasMany(m => m.OwnerEntities).WithOne(b => b.Customer).HasForeignKey(it => it.CusId).OnDelete(DeleteBehavior.Cascade);
            //cus.HasOne(m => m.Provincelist).WithOne().HasForeignKey<AreaEntity>(it => it.Id);
        }
        #endregion
    }
}

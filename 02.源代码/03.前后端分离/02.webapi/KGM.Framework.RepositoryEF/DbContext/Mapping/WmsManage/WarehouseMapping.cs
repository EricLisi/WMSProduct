using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;

namespace KGM.Framework.RepositoryEF.DbContext.Mapping.SystemManage
{
    /// <summary>
    /// 地区映射
    /// </summary>
    public class WarehouseMapping : EntityMapping<PlatFormEntity>
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
            var cus = EntityMapping<WarehouseEntity>.MappingToTable(modelBuilder, bAutoMapping);
            //映射模块详情子表
            EntityMapping<WarehouseEntity.PositionEntity>.MappingToTable(modelBuilder, bAutoMapping);

            //设置关系  
            cus.HasMany(m => m.PositionEntities).WithOne(b => b.Warehouse).HasForeignKey(it => it.WhCode).OnDelete(DeleteBehavior.Cascade);
            //cus.HasOne(m => m.Provincelist).WithOne().HasForeignKey<AreaEntity>(it => it.Id);
        }
        #endregion
    }
}

using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using KGM.Framework.RepositoryEF.Core;
using KGM.Framework.RepositoryEF.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.IO;

namespace KGM.Framework.RepositoryEF
{
    public class DepartmentContext : EFDbContext<DepartmentEntity, DepartmentContext>
    {

        public DbSet<DepartmentEntity> departments { get; set; }

        public DbSet<CompanyEntity.DepartmentEntity> Department { get; set; }

        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            DepartmentMapping.MappingToTable(modelBuilder);
        }
    }
}


using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.IO;

namespace KGM.Framework.RepositoryEF
{
    public class OutStockContext : DbContext
    {
        public DbSet<OutStockHeadEntity>  info { get; set; }
        public DbSet<OutStockBodyEntity> dInfo { get; set; }
        public DbSet<GetResultModel> GetResultModel { get; set; }

        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //对 StudentMap 进行配置
            EntityMapping<OutStockHeadEntity>.MappingToTable(modelBuilder);
            EntityMapping<OutStockBodyEntity>.MappingToTable(modelBuilder);
           
        }

        /// <summary>
        /// 重写连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            EFConnection.InitConnetion(optionsBuilder);
            base.OnConfiguring(optionsBuilder); 
        }
    }
}


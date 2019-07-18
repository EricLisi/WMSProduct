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
    public class GetResultModelContext : DbContext
    {
        public DbSet<GetResultModel> GetResultModel { get; set; }


        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //对 StudentMap 进行配置
            EntityMapping<GetResultModel>.MappingToTable(modelBuilder);
       
           
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


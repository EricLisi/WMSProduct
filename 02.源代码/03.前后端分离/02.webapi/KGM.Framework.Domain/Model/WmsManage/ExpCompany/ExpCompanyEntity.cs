using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "MST_EXPCOMPANY")]
    public class ExpCompanyEntity : AggregateRoot
    {

        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string KDAccout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string KDPwd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string KDMonthAccout { get; set; }

        /// <summary>
        /// 快递鸟key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// 快递鸟id
        /// </summary>
        public string KDNId { get; set; }

        /// <summary>
        /// 仓库id
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Contacts { get; set; }
        

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        public string Define1 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        public string Define2 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        public string Define3 { get; set; }
        
    }
}

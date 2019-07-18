
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
    [MappingTable(TableName = "MST_CUSTOMER")]
    public class CustomerEntity : AggregateRoot
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
        /// 负责人
        /// </summary>
        public string Person { get; set; }

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
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 省编码
        /// </summary>
        public string ProvinceCode { get; set; }

        ///// <summary>
        ///// 省
        ///// </summary>
        //[MappingFiled(Ignore = true)]
        //public AreaEntity Provincelist { get; set; }

        ///// <summary>
        ///// 市
        ///// </summary>
        //[MappingFiled(Ignore = true)]
        //public AreaEntity Citylist { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 市编码
        /// </summary>
        public string CityCode { get; set; }

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

        /// <summary>
        /// 数据 详情
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public virtual List<OwnerEntity> OwnerEntities { get; set; }

        #region 用于同一领域内的所有类 均集成Entity
        /// <summary>
        /// 模块按钮 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "MST_OWNER")]
        public class OwnerEntity : Entity
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

            /// <summary>
            /// 客户id
            /// </summary>
            public string CusId { get; set; }

            /// <summary>
            /// 模块对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public CustomerEntity Customer { get; set; }
        }
        #endregion
    }
}

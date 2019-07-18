
using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;


namespace KGM.Framework.Domain
{
    /// <summary>
    /// 仓库类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "MST_WAREHOUSE")]
    public class WarehouseEntity : AggregateRoot
    {

        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string WhPerson { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string WhPhone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string WhEmail { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string WhAddress { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string WhType { get; set; }

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
        public virtual List<PositionEntity> PositionEntities { get; set; }

        #region 用于同一领域内的所有类 均集成Entity
        /// <summary>
        /// 模块按钮 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "MST_POSITION")]
        public class PositionEntity : Entity
        {

            /// <summary>
            /// 编码
            /// </summary>
            public string EnCode { get; set; }

            /// <summary>
            /// 仓库id
            /// </summary>
            public string WhCode { get; set; }


            /// <summary>
            /// 名称
            /// </summary>
            public string FullName { get; set; }


            /// <summary>
            /// 货位类型
            /// </summary>
            public string PosType { get; set; }

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
            /// 模块对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public WarehouseEntity Warehouse { get; set; }
        }
        #endregion
    }
}

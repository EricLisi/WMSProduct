using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System.Collections.Generic;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "MST_BARCODERULEMAIN")]
    public class BarCodeRuleMainEntity : AggregateRoot
    {

        /// <summary>
        /// 
        /// </summary>
        public  string EnCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  string Type { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public  string Separator { get; set; }

        /// <summary>
        /// 
        /// </summary>
		 
        public  string Define1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		 
        public  string Define2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		 
        public  string Define3 { get; set; }

        /// <summary>
        /// 条码规则子表
        /// </summary>
        [MappingFiledAttribute(Ignore = true)]
        public virtual List<BarCodeRuleDetailEntity> BarCodeRuleDetailEntities { get; set; }


        #region 用于同一领域内的所有类 均集成Entity
        /// <summary>
        /// 条码规则子表 与数据库结构一致
        /// </summary> 
        [MappingTable(TableName = "MST_BARCODERULEDETAIL")]
        public class BarCodeRuleDetailEntity : Entity
        {
            /// <summary>
            /// 
            /// </summary>

            public virtual string MainId { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public virtual string EnCode { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public virtual string FullName { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public virtual string Type { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public virtual string Length { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public virtual string Number { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public virtual string Define1 { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public virtual string Define2 { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public virtual string Define3 { get; set; }

            /// <summary>
            /// 条码规则主表对象
            /// </summary>
            [MappingFiledAttribute(Ignore = true)]
            public BarCodeRuleMainEntity BarCodeRuleMain { get; set; }
        }
        #endregion
    }
}

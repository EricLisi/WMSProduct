using KGM.Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "MST_INVENTORY")]
    public class InventoryEntity : AggregateRoot
    {
        

        /// <summary>
        /// 
        /// </summary>
		
        public string InvSKU { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string EnCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string BarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string CusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Length { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public double Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public double Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public double Volumn { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public double fWeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public double gWeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public double Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public decimal Price2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define5 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define6 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define7 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define8 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define9 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define10 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define12 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define13 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define14 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define15 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define16 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define17 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define18 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define19 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		
        public string Define20 { get; set; }
    }
}

using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// MST_INVENTORYInfo
    /// </summary>
    [DataContract]
    public class InventoryGetDto
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public InventoryGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Width = 0;
            this.Height = 0;
            this.Volumn = 0;
            this.fWeight = 0;
            this.gWeight = 0;
            this.Price = 0;
            this.Price2 = 0;
            this.SortCode = 0;
            this.DeleteMark = false;
            this.EnabledMark = false;

        }

        #region Property Members
        
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string InvSKU { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string EnCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string BarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string CusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Length { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public double Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public double Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public double Volumn { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public double fWeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public double gWeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public double Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public decimal Price2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define5 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define6 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define7 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define8 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define9 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define10 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define12 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define13 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define14 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define15 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define16 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define17 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define18 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define19 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define20 { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
		[DataMember]
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
		[DataMember]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
		[DataMember]
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
		[DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
		[DataMember]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
		[DataMember]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
		[DataMember]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
		[DataMember]
        public virtual string DeleteUserId { get; set; }


        #endregion



        /// <summary>
        /// 客户编码
        /// </summary>
        [DataMember]
        public string CustomerCode { get; set; }

        /// <summary>
        /// 客户名
        /// </summary>
		[DataMember]
        public string CustomerName { get; set; }


        /// <summary>
        /// 分类名
        /// </summary>
		[DataMember]
        public string TypeName { get; set; }

    }
}
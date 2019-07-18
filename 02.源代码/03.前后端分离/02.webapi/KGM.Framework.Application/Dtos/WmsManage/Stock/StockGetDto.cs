using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 查询库存Dto
    /// </summary>
    [DataContract]
    public class StockGetDto
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StockGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.SortCode = 0;
            this.CreatorTime = DateTime.Now;
            this.EnabledMark = false;
            this.DeleteMark = false;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string RowId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string WareHouseId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string PositonId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string Barcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string BoxNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string ProductSKU { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string ProductId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  int? bType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string Cbatch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  DateTime? dMDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  int? Qty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  bool? bStopFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  double? Inqty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  double? Outqty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  DateTime? InDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string Property { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  int? SortCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  bool? DeleteMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  bool? EnabledMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  DateTime? CreatorTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string CreatorUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string LastModifyUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public  string DeleteUserId { get; set; }


    }
}

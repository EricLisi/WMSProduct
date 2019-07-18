using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 入库通知单表头Dto
    /// </summary>
    [DataContract]
    public class SRDetailGetDto
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public SRDetailGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.DPType = 0;
            this.qty = 0;
            this.doneqty = 0;
            this.outqty = 0;
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
        public string RowID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string autoID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string orderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int DPType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ProductId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string cbatch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime dMDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime dVDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public double qty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public double doneqty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public double outqty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int SortCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool DeleteMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool EnabledMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime CreatorTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime LastModifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LastModifyUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime DeleteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DeleteUserId { get; set; }


        #endregion


    }
}

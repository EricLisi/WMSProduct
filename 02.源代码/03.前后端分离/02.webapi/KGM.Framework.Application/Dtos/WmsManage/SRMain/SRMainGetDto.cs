using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 拣货单表头Dto
    /// </summary>
    [DataContract]
    public class SRMainGetDto
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public SRMainGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.orderType = 0;
            this.srType = 0;
            this.status = 0;
            this.isPrint = false;
            this.isUpLoad = false;
            this.SortCode = 0;
            this.DeleteMark = false;
            this.EnabledMark = false;

        }

        #region Property Members

        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string WarehouseName { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [DataMember]
        public virtual string CustomerName { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public virtual string Id { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        [DataMember]
        public virtual string orderNo { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        [DataMember]
        public virtual int orderType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual int srType { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        [DataMember]
        public virtual string CustomerId { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        [DataMember]
        public virtual string WarehouseId { get; set; }
        /// <summary>
        /// 送货日期
        /// </summary>
        [DataMember]
        public virtual DateTime sendDate { get; set; }
        /// <summary>
        /// 出库单
        /// </summary>
        [DataMember]
        public virtual string dpNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string backExpComp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string backExpNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string cMaker { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual DateTime dDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string cVerify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual DateTime dVeriDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual bool isPrint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual bool isUpLoad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Property { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual int SortCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual bool DeleteMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual bool EnabledMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual DateTime CreatorTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string CreatorUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual DateTime LastModifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string LastModifyUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual DateTime DeleteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string DeleteUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define13 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define14 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define15 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define16 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define17 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define18 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define19 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string Define20 { get; set; }


        #endregion
    }
}

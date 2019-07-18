using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 出库通知单子表Dto
    /// </summary>
    [DataContract]
    public class DPDetailGetDto
    {
        /// <summary>
        /// 初始化本身
        /// </summary>
        public DPDetailGetDto()
        {
            this.Id =Guid.NewGuid().ToString();
            this.CreatorTime = DateTime.Now;
            this.EnabledMark = false;
            this.DeleteMark = false;
            this.SortCode = 0;
        }


        /// <summary>
        /// 商品SKU
        /// </summary> 
        [DataMember]
        public string ProductName { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary> 
        [DataMember]public string Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary> 
        [DataMember]public string rowID { get; set; }

        /// <summary>
        /// 表头ID
        /// </summary> 
        [DataMember]public string orderNo { get; set; }

        /// <summary>
        /// 单据号類型
        /// </summary> 
        [DataMember]public int? DPType { get; set; }

        /// <summary>
        /// 商品SKU
        /// </summary> 
        [DataMember]public string ProductId { get; set; }
   
        /// <summary>
        /// 箱
        /// </summary> 
        [DataMember] public string BoxNo { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary> 
        [DataMember] public string BarCode { get; set; }
        /// <summary>
        /// 數量
        /// </summary> 
        [DataMember]public decimal qty { get; set; }

        ///<summary>
        /// 裝箱數量
        /// </summary> 
        [DataMember]public double? packqty { get; set; }

        /// <summary>
        /// 已操作数量
        /// </summary> 
        [DataMember]public double? doneqty { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        [DataMember]public double? outqty { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [DataMember]public double? backqty { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        [DataMember]public string cbatch { get; set; }

        /// <summary>
        ///  
        /// </summary>
        [DataMember]public DateTime? dMDate { get; set; }

        /// <summary>
        ///  
        /// </summary>
        [DataMember]public DateTime? dVDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]public string BCODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]public double CODPRICE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember] public double? price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]public double DISCOUNT { get; set; }






        ///<summary>
        /// 自定义项1
        /// </summary>  
        [DataMember]
        public string Define1 { get; set; }

        ///<summary>
        /// 自定义项2
        /// </summary>  
        [DataMember]
        public string Define2 { get; set; }

        ///<summary>
        /// 自定义项3
        /// </summary>  
        [DataMember]
        public string Define3 { get; set; }


        ///<summary>
        /// 自定义项4
        /// </summary>  
        [DataMember]
        public string Define4 { get; set; }


        ///<summary>
        /// 自定义项5
        /// </summary>  
        [DataMember]
        public string Define5 { get; set; }

        ///<summary>
        /// 自定义项6
        /// </summary>  
        [DataMember]
        public string Define6 { get; set; }

        ///<summary>
        /// 自定义项7
        /// </summary>  
        [DataMember]
        public string Define7 { get; set; }


        ///<summary>
        /// 自定义项8
        /// </summary>  
        [DataMember]
        public string Define8 { get; set; }

        ///<summary>
        /// 自定义项9
        /// </summary>  
        [DataMember]
        public string Define9 { get; set; }

        ///<summary>
        /// 自定义项10
        /// </summary>  
        [DataMember]
        public string Define10 { get; set; }




        ///<summary>
        /// 自定义项11
        /// </summary>  
        [DataMember] public string Define11 { get; set; }


        ///<summary>
        /// 自定义项12
        /// </summary>  
        [DataMember] public string Define12 { get; set; }


        ///<summary>
        /// 自定义项13
        /// </summary>  
        [DataMember] public string Define13 { get; set; }


        ///<summary>
        /// 自定义项14
        /// </summary>  
        [DataMember] public string Define14 { get; set; }


        ///<summary>
        /// 自定义项15
        /// </summary>  
        [DataMember] public string Define15 { get; set; }


        ///<summary>
        /// 自定义项16
        /// </summary>  
        [DataMember] public string Define16 { get; set; }


        ///<summary>
        /// 自定义项17
        /// </summary>  
        [DataMember] public string Define17 { get; set; }


        ///<summary>
        /// 自定义项18
        /// </summary>  
        [DataMember] public string Define18 { get; set; }

        ///<summary>
        /// 自定义项19
        /// </summary>  
        [DataMember] public string Define19 { get; set; }

        ///<summary>
        /// 自定义项20
        /// </summary>  
        [DataMember] public string Define20 { get; set; }
        /// <summary>
        /// 描述
        /// </summary> 
        [DataMember]
        public virtual string Description { get; set; }

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



        ///// <summary>
        ///// 省区
        ///// </summary> 
        //[DataMember]
        //public string ProvinceId { get; set; }

        ///// <summary>
        ///// 市区
        ///// </summary> 
        //[DataMember]
        //public string CityId { get; set; }

        ///// <summary>
        ///// 县区
        ///// </summary> 
        //[DataMember]
        //public string CountyId { get; set; }

        ///// <summary>
        ///// 邮编
        ///// </summary> 
        //[DataMember]
        //public string Postalcode { get; set; }
    }
}

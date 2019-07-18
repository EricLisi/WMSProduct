using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 用户信息照片表
    /// </summary>
    [DataContract]
    public class Sys_TransferInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        /// 

        public Sys_TransferInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
             this.F_SortCode= 0;
             this.F_DeleteMark= false;
             this.F_EnabledMark= false;
         
		}

        #region 转移产品信息
        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public virtual string F_GoodsName { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        public virtual string F_CargoPositionName { get; set; }
        /// <summary>
        ///产品数量
        /// </summary>
        [DataMember]
        public virtual string F_Number { get; set; }
        /// <summary>
        /// 转移数量    
        /// </summary>
        [DataMember]
        public virtual string F_TransferNum { get; set; }
        
        /// <summary>
        /// 转移货位
        /// </summary>
        [DataMember]
        public virtual string F_TransferCargo { get; set; }


        /// <summary>
        /// 转移仓库
        /// </summary>
        [DataMember]
        public virtual string F_TransferWarHouse { get; set; }
             /// <summary>
        /// 转移仓库ID
        /// </summary>
        [DataMember]
        public virtual string F_TransferWarHouseId { get; set; }
             /// <summary>
        /// 转移货位ID
        /// </summary>
        [DataMember]
        public virtual string F_TransferCargoId { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        [DataMember]
        public virtual string F_GoodsId { get; set; }
        
         /// <summary>
        /// 当前库存编号ID
        /// </summary>
        [DataMember]
        public virtual string F_StockId { get; set; }
        /// <summary>
        /// 自由项1
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm1 { get; set; }

        /// <summary>
        /// 自由项2
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm2 { get; set; }

        /// <summary>
        /// 自由项3
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm3 { get; set; }

        /// <summary>
        /// 自由项4
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm4{ get; set; }

        /// <summary>
        /// 自由项5
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm5 { get; set; }

        /// <summary>
        /// 自由项6
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm6 { get; set; }

        /// <summary>
        /// 自由项7
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm7 { get; set; }

        /// <summary>
        /// 自由项8
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm8{ get; set; }

        /// <summary>
        /// 自由项9
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm9{ get; set; }

        /// <summary>
        /// 自由项10
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm10 { get; set; }  

        #endregion

    }
}
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 资产信息照片表
    /// </summary>
    [DataContract]
    public class  Mst_CargoPositionInfo: AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_CargoPositionInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
               this.F_SortCode= 0;
             this.F_DeleteMark= false;
             this.F_EnabledMark= true;
         
		}

        #region Property Members



        ///// <summary>
        ///// 排序码
        ///// </summary>
        //[DataMember]
        //public virtual int F_SortCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
		[DataMember]
        public virtual string F_WarehouseName { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
		[DataMember]
        public virtual string F_SpecificatModel { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
		[DataMember]
        public virtual string F_Unit { get; set; }

        ///// <summary>
        ///// 区域性
        ///// </summary>
        //[DataMember]
        //public virtual string F_Regionally { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
		[DataMember]
        public virtual string F_Acreage { get; set; }

        /// <summary>
        /// 容量
        /// </summary>
		[DataMember]
        public virtual string F_Capacity { get; set; }

        /// <summary>
        /// 存放物料描述
        /// </summary>
		[DataMember]
        public virtual string F_WhatIs { get; set; }
        
        //  /// <summary>
        ///// 层
        ///// </summary>
        //[DataMember]
        //public virtual string F_Layers { get; set; }
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
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 货位信息表
    /// </summary>
    [DataContract]
    public class Mst_PositionInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_PositionInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Property = 0;
            this.F_Type = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = true;

        }

        #region Property Members

    

        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }

        /// <summary>
        /// 仓库名
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }
        /// <summary>
        /// 货位属性(0 正常品 1 待定品 2 坏品)
        /// </summary>
        [DataMember]
        public virtual int F_Property { get; set; }

        /// <summary>
        /// 货位类型(0 整箱区 1 散货区)
        /// </summary>
        [DataMember]
        public virtual int F_Type { get; set; }

        /// <summary>
        /// 自定义项1
        /// </summary>
        [DataMember]
        public virtual string F_Define1 { get; set; }

        /// <summary>
        /// 自定义项2
        /// </summary>
        [DataMember]
        public virtual string F_Define2 { get; set; }

        /// <summary>
        /// 自定义项3
        /// </summary>
        [DataMember]
        public virtual string F_Define3 { get; set; }

        /// <summary>
        /// 自定义项4
        /// </summary>
        [DataMember]
        public virtual string F_Define4 { get; set; }

        /// <summary>
        /// 自定义项5
        /// </summary>
        [DataMember]
        public virtual string F_Define5 { get; set; }

        /// <summary>
        /// 自定义项6
        /// </summary>
        [DataMember]
        public virtual string F_Define6 { get; set; }

        /// <summary>
        /// 自定义项7
        /// </summary>
        [DataMember]
        public virtual string F_Define7 { get; set; }

        /// <summary>
        /// 自定义项8
        /// </summary>
        [DataMember]
        public virtual string F_Define8 { get; set; }

        /// <summary>
        /// 自定义项9
        /// </summary>
        [DataMember]
        public virtual string F_Define9 { get; set; }

        /// <summary>
        /// 自定义项10
        /// </summary>
        [DataMember]
        public virtual string F_Define10 { get; set; }

  

        #endregion

    }
}
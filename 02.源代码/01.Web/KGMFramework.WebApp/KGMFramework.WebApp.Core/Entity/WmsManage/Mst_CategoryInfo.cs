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
    public class Mst_CategoryInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_CategoryInfo()
		{
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Layers = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
		}

        #region Property Members

        [DataMember]
        public virtual int? F_Layers { get; set; }
        ///// <summary>
        ///// 主键
        ///// </summary>
        //[DataMember]
        //public virtual string F_Id { get; set; }

        /////// <summary>
        /////// 父节点
        /////// </summary>
        ////[DataMember]
        ////public virtual string F_ParentId { get; set; }

        ///// <summary>
        ///// 货位编码
        ///// </summary>
        //[DataMember]
        //public virtual string F_EnCode { get; set; }

        ///// <summary>
        ///// 货位名称
        ///// </summary>
        //[DataMember]
        //public virtual string F_FullName { get; set; }

        ///// <summary>
        ///// 排序码
        ///// </summary>
        //[DataMember]
        //public virtual int F_SortCode { get; set; }

        //[DataMember]
        //public object F_Layers { get; set; }

        #endregion

       
    }
}
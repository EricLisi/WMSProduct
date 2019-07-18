using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 客户类别表
    /// </summary>
    [DataContract]
    public class Mst_SperCategoryInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        /// 

        public Mst_SperCategoryInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
               this.F_SortCode= 0;
             this.F_DeleteMark= false;
             this.F_EnabledMark= false;
         
		}

        #region 用户信息
 

        /// <summary>
        /// 层
        /// </summary>
        [DataMember]
        public string F_Layers { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string F_Description { get; set; }

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
    
        #endregion

    }
}
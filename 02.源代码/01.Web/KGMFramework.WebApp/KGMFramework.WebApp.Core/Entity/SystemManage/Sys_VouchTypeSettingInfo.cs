using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 业务类型选项表
    /// </summary>
    [DataContract]
    public class Sys_VouchTypeSettingInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Sys_VouchTypeSettingInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
                 this.F_ItemValue= false;
             this.F_DeleteMark= false;
             this.F_SortCode= 0;
             this.F_EnabledMark= false;
        
		}

        #region Property Members
        

        /// <summary>
        /// 业务类型Id
        /// </summary>
		[DataMember]
        public virtual string F_VouchId { get; set; }

        /// <summary>
        /// 选项Id
        /// </summary>
		[DataMember]
        public virtual string F_VouchSettingItemId { get; set; }

        /// <summary>
        /// 选项值
        /// </summary>
		[DataMember]
        public virtual bool F_ItemValue { get; set; }



        #endregion

    }
}
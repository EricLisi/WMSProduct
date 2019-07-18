using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 业务类型
    /// </summary>
    [DataContract]
    public class SYS_BarcodeSettingMainInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public SYS_BarcodeSettingMainInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
               this.F_Type= 0;
              this.F_SortCode= 0;
             this.F_DeleteMark= false;
             this.F_EnabledMark= false;
         
		}

        #region Property Members
        

        /// <summary>
        /// 类型
        /// </summary>
		[DataMember]
        public virtual int F_Type { get; set; }

        /// <summary>
        /// 分隔符
        /// </summary>
		[DataMember]
        public virtual string F_Split { get; set; }

      

        ///// <summary>
        ///// 删除用户
        ///// </summary>
        //[DataMember]
        //public virtual string F_DeleteUserID { get; set; }


        #endregion

    }
}
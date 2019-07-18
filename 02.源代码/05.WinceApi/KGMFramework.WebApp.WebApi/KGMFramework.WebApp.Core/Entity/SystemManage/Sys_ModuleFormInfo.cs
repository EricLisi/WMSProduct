using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 模块表单
    /// </summary>
    [DataContract]
    public class Sys_ModuleFormInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Sys_ModuleFormInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
                 this.F_SortCode= 0;
             this.F_DeleteMark= false;
             this.F_EnabledMark= false;
         
		}

        #region Property Members
        
 

        /// <summary>
        /// 模块主键
        /// </summary>
		[DataMember]
        public virtual string F_ModuleId { get; set; }

      

        /// <summary>
        /// 表单控件Json
        /// </summary>
		[DataMember]
        public virtual string F_FormJson { get; set; }

     

        #endregion

    }
}
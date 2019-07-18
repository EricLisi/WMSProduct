using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 行政区域表
    /// </summary>
    [DataContract]
    public class Sys_PlatformInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_PlatformInfo()
        { 
            this.F_Id = System.Guid.NewGuid().ToString(); 
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false; 
        } 
    }
}
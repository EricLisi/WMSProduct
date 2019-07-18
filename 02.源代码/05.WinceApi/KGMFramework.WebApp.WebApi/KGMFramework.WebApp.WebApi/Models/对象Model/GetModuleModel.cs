using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 树菜单结构
    /// </summary>
    [DataContract]
    public class GetModuleModel
    {
        /// <summary>
        /// 菜单
        /// </summary>
        [DataMember]
        public Sys_ModuleInfo module { get; set; }
        /// <summary>
        /// 页面
        /// </summary>
        [DataMember]
        public List<Sys_ModuleFormInfo>  FromList{ get; set; }
        /// <summary>
        ///  按钮
        /// </summary>
        [DataMember]
        public List<Sys_ModuleFormInstanceInfo> FromInsList { get; set; }

        /// <summary>
        ///  按钮
        /// </summary>
        [DataMember]
        public List<Sys_ModuleButtonInfo> ButtonList { get; set; }

    }
}
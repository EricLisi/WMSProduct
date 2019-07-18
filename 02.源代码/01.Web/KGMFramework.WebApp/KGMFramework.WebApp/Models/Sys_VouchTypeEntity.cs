using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.Models
{
    public class Sys_VouchTypeEntity: KGMFramework.WebApp.Entity.Sys_VouchTypeInfo
    {
        [DataMember]
        public string F_Type { get; set; }
        public string F_OrganizeId { get; set; }
    }
}
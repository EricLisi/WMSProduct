using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    [DataContract]
    public class SaveSNModel
    {
        [DataMember]
        public string jsonstr { get; set; }
    }
}
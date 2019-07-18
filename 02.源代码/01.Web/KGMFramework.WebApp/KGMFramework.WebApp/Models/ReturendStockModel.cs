using KGM.Framework.Commons;
using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.Models
{
    public class ReturendStockModel
    {
        public  SO_HeadInfo HeadInfo { get; set; }

        public List<SO_BodyInfo> BodyList { get; set; }
    }
}
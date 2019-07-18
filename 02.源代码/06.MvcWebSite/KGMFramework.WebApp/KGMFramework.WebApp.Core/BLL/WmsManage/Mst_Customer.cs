using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.BLL
{
    /// <summary>
    /// 客户信息表
    /// </summary>
	public class Mst_Customer : BaseBLL<Mst_CustomerInfo>
    {
        public Mst_Customer() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}

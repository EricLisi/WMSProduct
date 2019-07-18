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
    ///入库子表
    /// </summary>
    public class SO_ReturnedStockBody : BaseBLL<SO_ReturnedStockBodyInfo>
    {
        public SO_ReturnedStockBody()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }



    }
}

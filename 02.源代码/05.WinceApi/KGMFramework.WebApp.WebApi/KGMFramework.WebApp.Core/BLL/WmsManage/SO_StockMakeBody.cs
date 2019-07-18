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
    ///调拨子表
    /// </summary>
	public class SO_StockMakeBody : BaseBLL<SO_StockMakeBodyInfo>
    {
        public SO_StockMakeBody()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        public string UpMaskNum(DataTable dt, List<SO_StockMakeBodyInfo> list) { 
        ISO_StockMakeBody dal=baseDal as ISO_StockMakeBody;
          return  dal.UpMaskNum(dt,list);

        }
    }
}

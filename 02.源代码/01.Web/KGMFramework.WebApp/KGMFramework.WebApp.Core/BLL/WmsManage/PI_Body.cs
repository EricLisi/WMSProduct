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
	public class PI_Body : BaseBLL<PI_BodyInfo>
    {
        public PI_Body() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public string InStock(string Batch, List<PI_BodyInfo> stockinfo) {
            IPI_Body dal = baseDal as IPI_Body;
            return dal.InStock(Batch,stockinfo);
        }
    }
}

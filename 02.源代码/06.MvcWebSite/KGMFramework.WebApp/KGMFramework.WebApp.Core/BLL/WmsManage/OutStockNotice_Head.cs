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
    /// 出库通知单主表
    /// </summary>
	public class OutStockNotice_Head : BaseBLL<OutStockNotice_HeadInfo>
    {
        public OutStockNotice_Head() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public OutStockNotice_HeadInfo Save(OutStockNotice_HeadInfo info, List<OutStockNotice_BodyInfo> Binfo)
        {
            IOutStockNotice_Head dal = baseDal as IOutStockNotice_Head;
            return dal.Save(info, Binfo);
        }
    }
}

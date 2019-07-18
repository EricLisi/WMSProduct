using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;

namespace KGMFramework.WebApp.IDAL
{
    /// <summary>
    /// 出库通知单主表
    /// </summary>
	public interface IOutStockNotice_Head : IBaseDAL<OutStockNotice_HeadInfo>
	{
        OutStockNotice_HeadInfo Save(OutStockNotice_HeadInfo info, List<OutStockNotice_BodyInfo> BInfo);
    }
}
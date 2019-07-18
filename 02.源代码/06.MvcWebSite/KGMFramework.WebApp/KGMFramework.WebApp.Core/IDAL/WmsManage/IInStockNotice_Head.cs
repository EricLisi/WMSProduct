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
    /// 入库通知单主表
    /// </summary>
	public interface IInStockNotice_Head : IBaseDAL<InStockNotice_HeadInfo>
	{
        InStockNotice_HeadInfo Save(InStockNotice_HeadInfo info, List<InStockNotice_BodyInfo> BInfo);

        string UploadExcel(DataTable dt, string user);
    }
}
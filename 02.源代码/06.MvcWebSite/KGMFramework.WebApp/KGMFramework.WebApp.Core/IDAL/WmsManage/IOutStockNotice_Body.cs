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
    /// 出库通知单子表
    /// </summary>
	public interface IOutStockNotice_Body : IBaseDAL<OutStockNotice_BodyInfo>
	{
    }
}
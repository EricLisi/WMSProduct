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
    /// 库存现存量表
    /// </summary>
	public interface ISm_CurrentStock : IBaseDAL<Sm_CurrentStockInfo>
	{
    }
}
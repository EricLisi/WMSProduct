﻿using System;
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
    ///出库履历
    /// </summary>
    public interface ISys_AllocationHistory : IBaseDAL<Sys_AllocationHistoryInfo>
	{
    }
}
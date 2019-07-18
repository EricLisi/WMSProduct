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
    /// 仓库信息表
    /// </summary>
	public interface IMst_Warehouse : IBaseDAL<Mst_WarehouseInfo>
	{
        /// <summary>
        /// 更改仓库状态
        /// </summary>
        /// <param name="Id">仓库ID</param>
        bool upEnMask(string Id);
    }
}
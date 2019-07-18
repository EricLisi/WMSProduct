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
    /// 资产调拨子表
    /// </summary>
    public interface IMst_Warehouse : IBaseDAL<Mst_WarehouseInfo>
    {
        /// <summary>
        /// 更改标识
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="Name"></param>
        /// <param name="State"></param>
       void UpMark(string keyValue, string Name, bool State);
    }
}
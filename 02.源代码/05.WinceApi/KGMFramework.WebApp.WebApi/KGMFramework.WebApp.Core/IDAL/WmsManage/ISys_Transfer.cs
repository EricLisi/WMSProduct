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
    /// 货位表
    /// </summary>
    public interface ISys_Transfer : IBaseDAL<Sys_TransferInfo>
	{
        /// <summary>
        /// 产品转移
        /// </summary>
        /// <param name="info">转移信息</param>
        /// <param name="Stock_Id">转移产品行Id</param>
        /// <param name="F_GoodsId">产品的Id</param>
        /// <returns></returns>
        string SaveTra(Sys_TransferInfo info);
    }
}
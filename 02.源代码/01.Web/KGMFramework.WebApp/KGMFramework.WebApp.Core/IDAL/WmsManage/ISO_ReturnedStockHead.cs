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
    /// 产品出库表
    /// </summary>
    public interface ISO_ReturnedStockHead : IBaseDAL<SO_ReturnedStockHeadInfo>
	{
        /// <summary>
        /// 退货单据保存
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        SO_ReturnedStockHeadInfo Save(SO_ReturnedStockHeadInfo info, List<SO_ReturnedStockBodyInfo> dInfo);

        /// <summary>
        /// 审核退货
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
         string VerifyReturnGoods(string Id,string user);
    }
}
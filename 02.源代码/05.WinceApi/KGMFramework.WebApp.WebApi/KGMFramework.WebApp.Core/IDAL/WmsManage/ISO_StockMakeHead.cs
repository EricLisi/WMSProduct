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
    /// 盘点主表
    /// </summary>
    public interface ISO_StockMakeHead : IBaseDAL<SO_StockMakeHeadInfo>
    {
        /// <summary>
        /// 保存盘点
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        SO_StockMakeHeadInfo Save(SO_StockMakeHeadInfo info, List<SO_StockMakeBodyInfo> dInfo);
        /// <summary>
        /// 删除盘点单据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        void DeleteAll(string keyValue, bool bLogicDelete);
        /// <summary>
        /// 审核出库
        /// </summary>
        /// <param name="F_Id"></param>
        /// <param name="userName"></param>
        /// <param name="info"></param>
        void Status(string F_Id, string userName, List<SO_StockMakeBodyInfo> info);
    }
}
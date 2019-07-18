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
    public interface ISO_StockMakeBody : IBaseDAL<SO_StockMakeBodyInfo>
    {
        /// <summary>
        /// 更改产品盘点数量
        /// </summary>
        /// <param name="dt">更改的数据源</param>
        /// <param name="list">要修改的数据源</param>
        /// <returns></returns>
        string UpMaskNum(DataTable dt, List<SO_StockMakeBodyInfo> list);

    }
}
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
    /// 入库子表
    /// </summary>
    public interface IPI_ReturnBody : IBaseDAL<PI_ReturnBodyInfo>
    {
        DataTable SelReturnStock();
    }
}
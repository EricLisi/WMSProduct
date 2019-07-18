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
    /// 产品信息表
    /// </summary>
    public interface IMst_Product : IBaseDAL<Mst_ProductInfo>
    {
        DataSet GetTree();
        DataTable GetPrint(string filter);
        bool Audit(string F_Id, int state);
        bool DataRecovery(string F_Id);
    }
}
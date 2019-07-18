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
    /// 共通类
    /// </summary>
    public interface IAppCommon : IBaseDAL<BaseEntity>
    {
        DataSet GetPreVerify(string corpId);
        DataSet Asset_GetStatusReport(string corpId);

        DataSet Asset_GetRecordReport(string corpId);
        DataSet GetBarcodeInfo(VerifyListEntity entity);
        DataSet VerifyList(VerifyListEntity entity);
        DataSet GetTreeInfo(TreeInfoEntity entity);
        DataSet GetAssetInfo(string corpId, string deptId, string status, string condition, int pageindex = -1, int pagesize = 50);
    }
}
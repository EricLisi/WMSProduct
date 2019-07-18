using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;

namespace KGMFramework.WebApp.IDAL
{
    /// <summary>
    /// 入库主表
    /// </summary>
    public interface IPI_Head : IBaseDAL<PI_HeadInfo>
    {
        PI_HeadInfo Save(PI_HeadInfo info, List<PI_BodyInfo> dInfo);

        void DeleteAll(string keyValue, bool bLogicDelete);

        void Status(string F_Id, string userName);

        DataTable GetPrint(string sourceData);

        DataTable GetAssetPicture(string id);

        string createCode(string F_Id);

        bool Check2(string F_Id);

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="Id">审核单据</param>
        /// <param name="user">审核人</param>
        string Audit(string date, string Id, string user, List<PI_BodyInfo> stockinfo);
        
       /// <summary>
       /// 反审核
       /// </summary>
       /// <param name="date"></param>
       /// <param name="Id"></param>
       /// <param name="user"></param>
        string NoAudit(string date, string Id, string user);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        KgmApiResultEntity DeleteOrder(string ID);
    }
}
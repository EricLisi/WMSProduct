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
    /// 调拨主表
    /// </summary>
    public interface IAllocation_Head : IBaseDAL<Allocation_HeadInfo>
    {
        Allocation_HeadInfo Save(Allocation_HeadInfo info, List<Allocation_BodyInfo> dInfo);

        void DeleteAll(string keyValue, bool bLogicDelete);

        void Status(string F_Id, string userName);

        DataTable GetPrint(string sourceData);

        string createCode(string F_Id);

        bool Check2(string F_Id);

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="Id">审核单据</param>
        /// <param name="user">审核人</param>
        string Audit(string date, string Id, string user,List<Allocation_BodyInfo> DbInfo);
        
       /// <summary>
       /// 反审核
       /// </summary>
       /// <param name="date"></param>
       /// <param name="Id"></param>
       /// <param name="user"></param>
        string NoAudit(string date, string Id, string user);
    }
}
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
    public interface ISO_Head : IBaseDAL<SO_HeadInfo>
	{

        SO_HeadInfo Save(SO_HeadInfo info, List<SO_BodyInfo> dInfo);

        void DeleteAll(string keyValue, bool bLogicDelete);
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Id">审核单据</param>
        /// <param name="user">审核人</param>
        string Audit(string Id, string user);

        /// <summary>
        /// 查询审核状态
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        string StatusSate(string keyValue);
        DataTable GetPrint(string sourceData);

       /// <summary>
        /// 弃审
       /// </summary>
       /// <param name="date"></param>
       /// <param name="user"></param>
       /// <param name="Id"></param>
       /// <returns></returns>
        string NoAudit(string date, string user,string Id);

    }
}
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
    /// 产品出库表
    /// </summary>
    public interface ISO_Head : IBaseDAL<SO_HeadInfo>
	{
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        KgmApiResultEntity Save(DataSet ds);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        KgmApiResultEntity DeleteById(string Id);
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Id">审核单据ID</param>
        /// <param name="user">审核人</param>
        /// <param name="orderType">类型0审核 1反审</param>
        /// <returns></returns>
        KgmApiResultEntity Verify(string Id, string user,int orderType);
    }
}
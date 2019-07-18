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
    /// 拣货单主表
    /// </summary>
	public interface IPackList_Head : IBaseDAL<PackList_HeadInfo>
    {
        /// <summary>
        /// 保存拣货单
        /// </summary>
        /// <param name="headInfo"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        bool Save(PackList_HeadInfo headInfo, List<PackList_BodyInfo> dInfo);

        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        DataTable GetPrint(string sourceData);
    }
}
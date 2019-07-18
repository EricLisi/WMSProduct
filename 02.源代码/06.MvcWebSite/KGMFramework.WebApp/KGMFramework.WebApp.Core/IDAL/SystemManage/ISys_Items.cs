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
    /// 选项主表
    /// </summary>
	public interface ISys_Items : IBaseDAL<Sys_ItemsInfo>
	{
        /// <summary>
        ///根据字典明细获取对应的字典类型
        /// </summary>
        /// <param name="itemcode"></param>
        /// <returns></returns>
        string GetNameByCode(string itemcode);

    }
}
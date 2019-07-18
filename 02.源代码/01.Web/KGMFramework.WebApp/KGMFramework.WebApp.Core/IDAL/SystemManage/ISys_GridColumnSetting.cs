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
    /// 列表显示设置
    /// </summary>
    public interface ISys_GridColumnSetting : IBaseDAL<Sys_GridColumnSettingInfo>
    {
        void Copys(Sys_GridColumnSettingInfo Info, List<Sys_GridColumnSettingInfo> list);
    }
}
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
    /// 终端列表显示设置
    /// </summary>
	public interface ISys_TerminalGridColumnSetting : IBaseDAL<Sys_TerminalGridColumnSettingInfo>
	{
    }
}
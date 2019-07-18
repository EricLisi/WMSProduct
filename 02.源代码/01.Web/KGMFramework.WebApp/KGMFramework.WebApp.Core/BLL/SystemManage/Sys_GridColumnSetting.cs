using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.BLL
{
    /// <summary>
    /// 列表显示设置
    /// </summary>
    public class Sys_GridColumnSetting : BaseBLL<Sys_GridColumnSettingInfo>
    {
        public Sys_GridColumnSetting()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public void Copys(Sys_GridColumnSettingInfo Info, List<Sys_GridColumnSettingInfo> list)
        {
            ISys_GridColumnSetting dal = baseDal as ISys_GridColumnSetting;
            dal.Copys(Info, list);
        }
    }
}

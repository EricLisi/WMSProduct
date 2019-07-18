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
    /// 资产调拨子表
    /// </summary>
	public class Mst_Warehouse : BaseBLL<Mst_WarehouseInfo>
    {
        public Mst_Warehouse()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public void UpMark(string keyValue, string Name, bool State) {
            IMst_Warehouse dal = baseDal as IMst_Warehouse;
            dal.UpMark(keyValue, Name, State);
        }
    }
}

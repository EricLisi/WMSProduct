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
    ///入库子表
    /// </summary>
    public class Sys_Transfer : BaseBLL<Sys_TransferInfo>
    {
        public Sys_Transfer()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        public string SaveTra(Sys_TransferInfo info)
        {
            ISys_Transfer dal = baseDal as ISys_Transfer;
            return dal.SaveTra(info);
        }

    }
}

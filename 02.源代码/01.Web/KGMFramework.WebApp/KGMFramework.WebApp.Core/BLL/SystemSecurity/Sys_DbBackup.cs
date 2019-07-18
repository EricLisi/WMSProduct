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
    /// 数据库备份
    /// </summary>
    public class Sys_DbBackup : BaseBLL<Sys_DbBackupInfo>
    {
        public Sys_DbBackup()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// 备份数据
        /// </summary>
        /// <param name="info"></param>
        public void BackUpDB(Sys_DbBackupInfo info)
        {
            ISys_DbBackup dal = baseDal as ISys_DbBackup;
            dal.BackUpDB(info);
        }
    }
}

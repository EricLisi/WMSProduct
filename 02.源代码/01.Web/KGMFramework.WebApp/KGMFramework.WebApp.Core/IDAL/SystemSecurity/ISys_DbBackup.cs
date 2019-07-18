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
    /// 数据库备份
    /// </summary>
    public interface ISys_DbBackup : IBaseDAL<Sys_DbBackupInfo>
    {
        void BackUpDB(Sys_DbBackupInfo info);
    }
}
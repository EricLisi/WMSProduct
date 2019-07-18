using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 数据库备份
    /// </summary>
    [DataContract]
    public class Sys_DbBackupInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_DbBackupInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
            this.F_BackupTime = DateTime.Now;

        }

        #region Property Members
        /// <summary>
        /// 备份类型
        /// </summary>
        [DataMember]
        public virtual string F_BackupType { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        [DataMember]
        public virtual string F_DbName { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [DataMember]
        public virtual string F_FileName { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [DataMember]
        public virtual string F_FileSize { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [DataMember]
        public virtual string F_FilePath { get; set; }

        /// <summary>
        /// 备份时间
        /// </summary>
        [DataMember]
        public virtual DateTime? F_BackupTime { get; set; }
         
        #endregion

    }
}
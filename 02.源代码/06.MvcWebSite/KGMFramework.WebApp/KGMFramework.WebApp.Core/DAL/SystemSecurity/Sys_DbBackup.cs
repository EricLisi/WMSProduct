using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGM.Pager.Entity;
using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;
using KGMFramework.WebApp.Library;

namespace KGMFramework.WebApp.DALSQL
{
    /// <summary>
    /// 数据库备份
    /// </summary>
    public class Sys_DbBackup : BaseDALSQL<Sys_DbBackupInfo>, ISys_DbBackup
    {
        #region 对象实例及构造函数

        public static Sys_DbBackup Instance
        {
            get
            {
                return new Sys_DbBackup();
            }
        }
        public Sys_DbBackup()
            : base("Sys_DbBackup", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_DbBackupInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_DbBackupInfo info = new Sys_DbBackupInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_BackupType = reader.GetString("F_BackupType");
            info.F_DbName = reader.GetString("F_DbName");
            info.F_FileName = reader.GetString("F_FileName");
            info.F_FileSize = reader.GetString("F_FileSize");
            info.F_FilePath = reader.GetString("F_FilePath");
            info.F_BackupTime = reader.GetDateTimeNullable("F_BackupTime");
            info.F_SortCode = reader.GetInt32Nullable("F_SortCode");
            info.F_DeleteMark = reader.GetBooleanNullable("F_DeleteMark");
            info.F_EnabledMark = reader.GetBooleanNullable("F_EnabledMark");
            info.F_Description = reader.GetString("F_Description");
            info.F_CreatorTime = reader.GetDateTimeNullable("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyTime = reader.GetDateTimeNullable("F_LastModifyTime");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_DeleteTime = reader.GetDateTimeNullable("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_DbBackupInfo obj)
        {
            Sys_DbBackupInfo info = obj as Sys_DbBackupInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_BackupType", info.F_BackupType);
            hash.Add("F_DbName", info.F_DbName);
            hash.Add("F_FileName", info.F_FileName);
            hash.Add("F_FileSize", info.F_FileSize);
            hash.Add("F_FilePath", info.F_FilePath);
            hash.Add("F_BackupTime", info.F_BackupTime);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_DeleteTime", info.F_DeleteTime);
            hash.Add("F_DeleteUserId", info.F_DeleteUserId);

            return hash;
        }

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
            dict.Add("F_Id", "备份主键");
            dict.Add("F_BackupType", "备份类型");
            dict.Add("F_DbName", "数据库名称");
            dict.Add("F_FileName", "文件名称");
            dict.Add("F_FileSize", "文件大小");
            dict.Add("F_FilePath", "文件路径");
            dict.Add("F_BackupTime", "备份时间");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_Description", "描述");
            dict.Add("F_CreatorTime", "创建时间");
            dict.Add("F_CreatorUserId", "创建用户");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            #endregion

            return dict;
        }

        /// <summary>
        /// 备份数据
        /// </summary>
        /// <param name="info"></param>
        public void BackUpDB(Sys_DbBackupInfo info)
        {
            //备份数据库
            string sql = string.Empty;
            if (info.F_BackupType == "1")
            {
                sql = string.Format("BACKUP DATABASE {0} TO DISK = '{1}' WITH FORMAT", info.F_DbName, info.F_FilePath);
            }
            else
            {
                sql = string.Format("BACKUP DATABASE {0} TO DISK = '{1}' WITH FORMAT,DIFFERENTIAL", info.F_DbName, info.F_FilePath);
            }

            Hashtable hash = new Hashtable();
            base.ExecuteNonQuery(sql, hash);

            info.F_FilePath = "/Resource/DbBackup/" + info.F_FileName;
            info.F_FileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(info.F_FilePath));

            //写入数据库
            this.Insert(info);


        }
    }
}
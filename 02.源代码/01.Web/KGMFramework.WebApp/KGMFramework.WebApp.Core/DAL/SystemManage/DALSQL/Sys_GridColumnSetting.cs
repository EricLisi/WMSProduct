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

namespace KGMFramework.WebApp.DALSQL
{
    /// <summary>
    /// 列表显示设置
    /// </summary>
    public class Sys_GridColumnSetting : BaseDALSQL<Sys_GridColumnSettingInfo>, ISys_GridColumnSetting
    {
        #region 对象实例及构造函数

        public static Sys_GridColumnSetting Instance
        {
            get
            {
                return new Sys_GridColumnSetting();
            }
        }
        public Sys_GridColumnSetting()
            : base("Sys_GridColumnSetting", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_GridColumnSettingInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_GridColumnSettingInfo info = new Sys_GridColumnSettingInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_Page = reader.GetString("F_Page");
            info.F_GridId = reader.GetString("F_GridId");
            info.F_Label = reader.GetString("F_Label");
            info.F_Name = reader.GetString("F_Name");
            info.F_Hidden = reader.GetBoolean("F_Hidden");
            info.F_Key = reader.GetBoolean("F_Key");
            info.F_Width = reader.GetInt32("F_Width");
            info.F_Align = reader.GetString("F_Align");
            info.F_Editable = reader.GetBoolean("F_Editable");
            info.F_Formatter = reader.GetString("F_Formatter");
            info.F_Formatoptions = reader.GetString("F_Formatoptions");
            info.F_ParentId = reader.GetString("F_ParentId");
            //info.F_DataUrl = reader.GetString("F_DataUrl");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_Description = reader.GetString("F_Description");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_GridColumnSettingInfo obj)
        {
            Sys_GridColumnSettingInfo info = obj as Sys_GridColumnSettingInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_Page", info.F_Page);
            hash.Add("F_GridId", info.F_GridId);
            hash.Add("F_Label", info.F_Label);
            hash.Add("F_Name", info.F_Name);
            hash.Add("F_Hidden", info.F_Hidden);
            hash.Add("F_Key", info.F_Key);
            hash.Add("F_Width", info.F_Width);
            hash.Add("F_Align", info.F_Align);
            hash.Add("F_Editable", info.F_Editable);
            hash.Add("F_Formatter", info.F_Formatter);
            hash.Add("F_Formatoptions", info.F_Formatoptions);
            //hash.Add("F_DataUrl", info.F_DataUrl);
            hash.Add("F_ParentId", info.F_ParentId);
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
            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "编码");
            dict.Add("F_FullName", "名称");
            dict.Add("F_Page", "所属页面");
            dict.Add("F_GridId", "列表ID");
            dict.Add("F_Label", "列显示");
            dict.Add("F_Name", "列映射后台字段");
            dict.Add("F_Hidden", "是否隐藏");
            dict.Add("F_Key", "主键标识");
            dict.Add("F_Width", "列宽");
            dict.Add("F_Align", "对齐方式");
            dict.Add("F_Editable", "是否可编辑");
            dict.Add("F_Formatter", "显示格式");
            dict.Add("F_Formatoptions", "显示格式选项");
            dict.Add("F_ParentId", "父节点ID");
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

        public void Copys(Sys_GridColumnSettingInfo Info, List<Sys_GridColumnSettingInfo> list)
        {
            using (DbTransactionScope<Sys_GridColumnSettingInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //新增主表
                    Sys_GridColumnSetting.Instance.Insert(Info, dbtran.Transaction);
                    //新增详细表
                    foreach (Sys_GridColumnSettingInfo model in list)
                    {
                        Sys_GridColumnSetting.Instance.Insert(model, dbtran.Transaction);
                    }
                    dbtran.Commit();
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }
        }



    }
}
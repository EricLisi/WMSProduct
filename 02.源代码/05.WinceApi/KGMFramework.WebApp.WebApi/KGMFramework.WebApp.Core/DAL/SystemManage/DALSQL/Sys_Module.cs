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
    /// 系统模块
    /// </summary>
	public class Sys_Module : BaseDALSQL<Sys_ModuleInfo>, ISys_Module
    {
        #region 对象实例及构造函数

        public static Sys_Module Instance
        {
            get
            {
                return new Sys_Module();
            }
        }
        public Sys_Module() : base("Sys_Module", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_ModuleInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_ModuleInfo info = new Sys_ModuleInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_ParentId = reader.GetString("F_ParentId");
            info.F_Layers = reader.GetInt32Nullable("F_Layers");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_Icon = reader.GetString("F_Icon");
            info.F_UrlAddress = reader.GetString("F_UrlAddress");
            info.F_Target = reader.GetString("F_Target");
            info.F_IsMenu = reader.GetBooleanNullable("F_IsMenu");
            info.F_IsExpand = reader.GetBooleanNullable("F_IsExpand");
            info.F_IsPublic = reader.GetBooleanNullable("F_IsPublic");
            info.F_AllowEdit = reader.GetBooleanNullable("F_AllowEdit");
            info.F_AllowDelete = reader.GetBooleanNullable("F_AllowDelete");
            info.F_IsApp = reader.GetBooleanNullable("F_IsApp");
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
        protected override Hashtable GetHashByEntity(Sys_ModuleInfo obj)
        {
            Sys_ModuleInfo info = obj as Sys_ModuleInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_ParentId", info.F_ParentId);
            hash.Add("F_Layers", info.F_Layers);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_Icon", info.F_Icon);
            hash.Add("F_UrlAddress", info.F_UrlAddress);
            hash.Add("F_Target", info.F_Target);
            hash.Add("F_IsMenu", info.F_IsMenu);
            hash.Add("F_IsExpand", info.F_IsExpand);
            hash.Add("F_IsPublic", info.F_IsPublic);
            hash.Add("F_AllowEdit", info.F_AllowEdit);
            hash.Add("F_AllowDelete", info.F_AllowDelete);
            hash.Add("F_IsApp", info.F_IsApp);
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
            dict.Add("F_Id", "模块主键");
            dict.Add("F_ParentId", "父级");
            dict.Add("F_Layers", "层次");
            dict.Add("F_EnCode", "编码");
            dict.Add("F_FullName", "名称");
            dict.Add("F_Icon", "图标");
            dict.Add("F_UrlAddress", "连接");
            dict.Add("F_Target", "目标");
            dict.Add("F_IsMenu", "菜单");
            dict.Add("F_IsExpand", "展开");
            dict.Add("F_IsPublic", "公共");
            dict.Add("F_AllowEdit", "允许编辑");
            dict.Add("F_AllowDelete", "允许删除");
            dict.Add("F_IsApp", "是否App");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_Description", "描述");
            dict.Add("F_CreatorTime", "创建日期");
            dict.Add("F_CreatorUserId", "创建用户主键");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            #endregion

            return dict;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fromList"></param>
        /// <param name="fromInsList"></param>
        /// <param name="buttonList"></param>
        /// <returns></returns>
        public string Save(Sys_ModuleInfo model, List<Sys_ModuleFormInfo> fromList, List<Sys_ModuleFormInstanceInfo> fromInsList, List<Sys_ModuleButtonInfo> buttonList)
        {
            using (DbTransactionScope<Sys_ModuleInfo> dbtran = base.CreateTransactionScope())   
            {
                try
                {
                    //添加或修改主表
                    BLLFactory<Sys_Module>.Instance.InsertUpdate(model, model.F_Id,dbtran.Transaction);
                    //先删除子表再添加子表
                    SearchCondition search = new SearchCondition();
                    search.AddCondition("F_ModuleId", model.F_Id, SqlOperator.Equal);
                    BLLFactory<Sys_ModuleButton>.Instance.DeleteByCondition(search.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty), dbtran.Transaction);
                    //找到对应的from界面
                    List<Sys_ModuleFormInfo> GetfromList = BLLFactory<Sys_ModuleForm>.Instance.Find(search.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty), dbtran.Transaction);
                    if (GetfromList!=null)//循环删除FromInstance
                    {
                        foreach (var item in GetfromList)
                        {
                            search = new SearchCondition();
                            search.AddCondition("F_FormId", item.F_Id, SqlOperator.Equal);
                            BLLFactory<Sys_ModuleFormInstance>.Instance.DeleteByCondition(search.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty), dbtran.Transaction);
                        }
                    }
                   ///删除from界面
                    BLLFactory<Sys_ModuleForm>.Instance.DeleteByCondition(search.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty), dbtran.Transaction);
                    dbtran.Commit();
                    //添加子表
                    if (fromList!=null && fromList.Count>0)
                    {
                        BLLFactory<Sys_ModuleForm>.Instance.InsertRange(fromList);
                    }
                    if (fromInsList!=null && fromInsList.Count>0)
                     {
                        BLLFactory<Sys_ModuleFormInstance>.Instance.InsertRange(fromInsList);
                    }
                    if (buttonList!=null &&buttonList.Count>0)
                    {
                        BLLFactory<Sys_ModuleButton>.Instance.InsertRange(buttonList);
                    }
                    dbtran.Commit();
                    return "1";
                }



                catch (Exception)
                {
                    dbtran.RollBack();
                    throw;
                }
            }


        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteFromById(string Id) {

            using (DbTransactionScope<Sys_ModuleInfo> dbtran=base.CreateTransactionScope())
            {
                try
                {
                    SearchCondition search = new SearchCondition();
                    search.AddCondition("F_ModuleId", Id, SqlOperator.Equal);
                    BLLFactory<Sys_ModuleButton>.Instance.DeleteByCondition(search.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty), dbtran.Transaction);
                    //找到对应的from界面
                    List<Sys_ModuleFormInfo> GetfromList = BLLFactory<Sys_ModuleForm>.Instance.Find(search.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty), dbtran.Transaction);
                    if (GetfromList != null)//循环删除FromInstance
                    {
                        foreach (var item in GetfromList)
                        {
                            search = new SearchCondition();
                            search.AddCondition("F_FormId", item.F_Id, SqlOperator.Equal);
                            BLLFactory<Sys_ModuleFormInstance>.Instance.DeleteByCondition(search.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty), dbtran.Transaction);
                        }
                    }
                    ///删除from界面
                    BLLFactory<Sys_ModuleForm>.Instance.DeleteByCondition(search.BuildConditionSql().Replace(" Where (1=1)  AND", string.Empty), dbtran.Transaction);
                    dbtran.Commit();
                    return true;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }
    }
}
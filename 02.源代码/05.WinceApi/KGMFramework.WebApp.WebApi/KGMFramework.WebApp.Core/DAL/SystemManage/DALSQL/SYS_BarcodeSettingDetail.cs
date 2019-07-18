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
    /// SYS_BarcodeSettingDetail
    /// </summary>
    public class SYS_BarcodeSettingDetail : BaseDALSQL<SYS_BarcodeSettingDetailInfo>, ISYS_BarcodeSettingDetail
    {
        #region 对象实例及构造函数

        public static SYS_BarcodeSettingDetail Instance
        {
            get
            {
                return new SYS_BarcodeSettingDetail();
            }
        }
        public SYS_BarcodeSettingDetail()
            : base("SYS_BarcodeSettingDetail", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override SYS_BarcodeSettingDetailInfo DataReaderToEntity(IDataReader dataReader)
        {
            SYS_BarcodeSettingDetailInfo info = new SYS_BarcodeSettingDetailInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_ParentId = reader.GetString("F_ParentId");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_Type = reader.GetInt32("F_Type");
            info.F_Length = reader.GetInt32("F_Length");
            info.F_AnalyzeMark = reader.GetBoolean("F_AnalyzeMark");
            info.F_Table = reader.GetString("F_Table");
            info.F_ValueFiled = reader.GetString("F_ValueFiled");
            info.F_DisplayFiled = reader.GetString("F_DisplayFiled");
            info.F_Condition = reader.GetString("F_Condition");
            info.F_GenerateMark = reader.GetBoolean("F_GenerateMark");
            info.F_GenerateRule = reader.GetInt32("F_GenerateRule");
            info.F_GenerateFormatter = reader.GetString("F_GenerateFormatter");
            info.F_GenerateLength = reader.GetInt32("F_GenerateLength");
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
            info.F_IndexSpilt = reader.GetInt32("F_IndexSpilt");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(SYS_BarcodeSettingDetailInfo obj)
        {
            SYS_BarcodeSettingDetailInfo info = obj as SYS_BarcodeSettingDetailInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_ParentId", info.F_ParentId);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_Type", info.F_Type);
            hash.Add("F_Length", info.F_Length);
            hash.Add("F_AnalyzeMark", info.F_AnalyzeMark);
            hash.Add("F_Table", info.F_Table);
            hash.Add("F_ValueFiled", info.F_ValueFiled);
            hash.Add("F_DisplayFiled", info.F_DisplayFiled);
            hash.Add("F_Condition", info.F_Condition);
            hash.Add("F_GenerateMark", info.F_GenerateMark);
            hash.Add("F_GenerateRule", info.F_GenerateRule);
            hash.Add("F_GenerateFormatter", info.F_GenerateFormatter);
            hash.Add("F_GenerateLength", info.F_GenerateLength);
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
            hash.Add("F_IndexSpilt", info.F_IndexSpilt);

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
            dict.Add("F_ParentId", "主键");
            dict.Add("F_EnCode", "编码");
            dict.Add("F_FullName", "规则名称");
            dict.Add("F_Type", "类型");
            dict.Add("F_Length", "长度");
            dict.Add("F_AnalyzeMark", "解析标识");
            dict.Add("F_Table", "映射表名");
            dict.Add("F_ValueFiled", "映射字段名");
            dict.Add("F_DisplayFiled", "显示字段");
            dict.Add("F_Condition", "过滤条件");
            dict.Add("F_GenerateMark", "自动生成标识");
            dict.Add("F_GenerateRule", "生成规则");
            dict.Add("F_GenerateFormatter", "生成格式");
            dict.Add("F_GenerateLength", "生成长度");
            dict.Add("F_SortCode", "排序字段");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "是否有效标志");
            dict.Add("F_Description", "描述");
            dict.Add("F_CreatorTime", "创建时间");
            dict.Add("F_CreatorUserId", "创建用户");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserID", "删除用户");
            dict.Add("F_IndexSpilt", "位置截取数");
            #endregion

            return dict;
        }


        /// <summary>
        /// 增加子表
        /// </summary>
        /// <param name="info"></param>
        /// <param name="keyValue"></param>
        public void insert(SYS_BarcodeSettingDetailInfo info, string keyValue)
        {
            using (DbTransactionScope<SYS_BarcodeSettingDetailInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    SYS_BarcodeSettingDetail.Instance.InsertUpdate(info, keyValue, dbtran.Transaction);
                    dbtran.Commit();
                }
                catch (Exception)
                {

                    throw;
                }


            }

        }

        /// <summary>
        /// 根据主表的分隔类型删除子表的信息
        /// </summary>
        /// <param name="keyValue"></param>
        public void deleteDeatail(string keyValue)
        {
            using (DbTransactionScope<SYS_BarcodeSettingDetailInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_ParentId", keyValue, SqlOperator.Equal);
                    BLLFactory<SYS_BarcodeSettingDetail>.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    dbtran.Commit();
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }

            }
        }

        /// <summary>
        /// 删除子表信息
        /// </summary>
        /// <param name="keyValue"></param>
        public void deleteId(string keyValue)
        {
            using (DbTransactionScope<SYS_BarcodeSettingDetailInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_Id", keyValue, SqlOperator.Equal);
                    BLLFactory<SYS_BarcodeSettingDetail>.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    dbtran.Commit();
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }





        }


        /// <summary>
        /// 修改子表
        /// </summary>
        /// <param name="info"></param>
        /// <param name="keyword"></param>
        /// <param name="keyValue"></param>
        public void insertDetail(SYS_BarcodeSettingDetailInfo info, string keyword, string keyValue)
        {
            using (DbTransactionScope<SYS_BarcodeSettingDetailInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_Parent", keyword, SqlOperator.Equal);
                    condition.AddCondition("F_Id", keyValue, SqlOperator.Equal);
                    BLLFactory<SYS_BarcodeSettingDetail>.Instance.InsertUpdate(info, condition);
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
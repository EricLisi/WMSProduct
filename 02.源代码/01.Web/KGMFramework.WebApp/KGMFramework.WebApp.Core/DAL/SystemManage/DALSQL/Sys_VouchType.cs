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
    /// 业务类型
    /// </summary>
    public class Sys_VouchType : BaseDALSQL<Sys_VouchTypeInfo>, ISys_VouchType
    {
        #region 对象实例及构造函数

        public static Sys_VouchType Instance
        {
            get
            {
                return new Sys_VouchType();
            }
        }
        public Sys_VouchType()
            : base("Sys_VouchType", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_VouchTypeInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_VouchTypeInfo info = new Sys_VouchTypeInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_ParentId = reader.GetString("F_ParentId");
            info.F_Layers = reader.GetInt32("F_Layers");
            info.F_Prefix = reader.GetString("F_Prefix");
            info.F_ModuleId = reader.GetString("F_ModuleId");
            info.F_InoutType = reader.GetInt32("F_InoutType");
            info.F_Source = reader.GetString("F_Source");
            info.F_SourceDb = reader.GetString("F_SourceDb");
            info.F_SourceTable = reader.GetString("F_SourceTable");
            info.F_SourceBusiness = reader.GetString("F_SourceBusiness");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");
            info.F_BrbFlag = reader.GetBoolean("F_BrbFlag");
            info.F_IsNeedDverfy = reader.GetBoolean("F_IsNeedDverfy");
            info.F_IsAllMatch = reader.GetBoolean("F_IsAllMatch");
            info.F_IsFiFo = reader.GetBoolean("F_IsFiFo");
            info.F_Bprint = reader.GetBoolean("F_Bprint");
            info.F_Bdefalut = reader.GetBoolean("F_Bdefalut");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_VouchTypeInfo obj)
        {
            Sys_VouchTypeInfo info = obj as Sys_VouchTypeInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_ParentId", info.F_ParentId);
            hash.Add("F_Layers", info.F_Layers);
            hash.Add("F_Prefix", info.F_Prefix);
            hash.Add("F_ModuleId", info.F_ModuleId);
            hash.Add("F_InoutType", info.F_InoutType);
            hash.Add("F_Source", info.F_Source);
            hash.Add("F_SourceDb", info.F_SourceDb);
            hash.Add("F_SourceTable", info.F_SourceTable);
            hash.Add("F_SourceBusiness", info.F_SourceBusiness);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_DeleteTime", info.F_DeleteTime);
            hash.Add("F_DeleteUserId", info.F_DeleteUserId);
            hash.Add("F_BrbFlag", info.F_BrbFlag);
            hash.Add("F_IsNeedDverfy", info.F_IsNeedDverfy);
            hash.Add("F_IsAllMatch", info.F_IsAllMatch);
            hash.Add("F_IsFiFo", info.F_IsFiFo);
            hash.Add("F_Bprint", info.F_Bprint);
            hash.Add("F_Bdefalut", info.F_Bdefalut);

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
            dict.Add("F_Id", "主键  ");
            dict.Add("F_EnCode", "业务模块编码  ");
            dict.Add("F_FullName", "业务类型名称");
            dict.Add("F_ParentId", "父级");
            dict.Add("F_Layers", "层次");
            dict.Add("F_Prefix", "业务类型前缀");
            dict.Add("F_ModuleId", "模块ID");
            dict.Add("F_InoutType", "出入库类型");
            dict.Add("F_Source", "来源类型");
            dict.Add("F_SourceDb", "来源库");
            dict.Add("F_SourceTable", "来源表");
            dict.Add("F_SourceBusiness", "来源业务类型");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_CreatorTime", "创建日期");
            dict.Add("F_CreatorUserId", "创建用户主键");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            dict.Add("F_BrbFlag", "是否红字");
            dict.Add("F_IsNeedDverfy", "审核");
            dict.Add("F_IsAllMatch", "完全匹配");
            dict.Add("F_IsFiFo", "先进先出");
            dict.Add("F_Bprint", "是否打印");
            dict.Add("F_Bdefalut", "默认来源");
            #endregion

            return dict;
        }
        /// <summary>
        /// 获取业务类型设置树形结构
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public DataSet GetVouchTree()
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            return base.ExecuteDataSetByProc("SYS_VOUCHTYPETREE", paramList);
        }
        //保存业务类型设置
        public void Save(Sys_VouchTypeInfo info, List<Sys_VouchTypeDefaultInfo> dInfo, string keyValue)
        {
            using (DbTransactionScope<Sys_VouchTypeInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //主子表同时更新

                    //主表更新/新增

                    //子表根据主表id全删除

                    //添加子表


                    //增加子表
                    //如果是修改，先删除后增加
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_VouchId", info.F_Id, SqlOperator.Equal);
                    BLLFactory<Sys_VouchTypeDefault>.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
                    foreach (Sys_VouchTypeDefaultInfo model in dInfo)
                    {
                        //如果不选择默认值，即传入的F_EnCode为null就不插值
                        if (!string.IsNullOrEmpty(model.F_EnCode))
                        {
                            Sys_VouchTypeDefault.Instance.Insert(model, dbtran.Transaction);
                        }

                    }
                    //增加主表
                    this.InsertUpdate(info, keyValue, dbtran.Transaction);

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
        /// 批量删除主子表
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteBatch(string keyValue, bool bLogicDelete)
        {
            using (DbTransactionScope<Sys_VouchTypeInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    if (bLogicDelete)
                    {
                        //逻辑删除v
                        //UPDATE字段
                        Hashtable hash = new Hashtable();
                        hash.Add("字段名", "修改后的值");
                        this.Update(keyValue, hash, dbtran.Transaction);
                        //UPDATE 对象
                        Sys_VouchTypeInfo info = this.FindByID(keyValue, dbtran.Transaction);
                        info.F_DeleteMark = false;
                        info.F_DeleteTime = DateTime.Now;
                        this.Update(info, keyValue, dbtran.Transaction);
                        //获取所有的子表信息
                        SearchCondition c = new SearchCondition();
                        c.AddCondition("F_VouchId", keyValue, SqlOperator.Equal);
                        List<Sys_VouchTypeDefaultInfo> details = Sys_VouchTypeDefault.Instance.Find(c.BuildConditionSql());

                        foreach (Sys_VouchTypeDefaultInfo d in details)
                        {
                            d.F_DeleteMark = false;
                            d.F_DeleteTime = DateTime.Now;
                            Sys_VouchTypeDefault.Instance.Update(d, d.F_Id, dbtran.Transaction);
                        }
                        //sql方式update
                        //更新主表状态删除标志状态
                        string sql = "UPDATE Sys_VouchType   SET DeleteMark =1 WHERE F_Id = @F_Id";
                        Hashtable parms = new Hashtable();
                        parms.Add("F_Id", keyValue);
                        base.ExecuteNonQuery(sql, parms, dbtran.Transaction);
                        //更新子表删除标志状态
                        sql = "UPDATE Sys_VouchTypeDefault SET DeleteMark =1 WHERE F_VouchId = @F_Id";
                        base.ExecuteNonQuery(sql, parms, dbtran.Transaction);

                    }
                    else
                    {
                        //物理删除
                        //删除 sys_VouchType
                        this.Delete(keyValue, dbtran.Transaction);
                        //删除 sys_VouchTypeDefault
                        SearchCondition condition = new SearchCondition();
                        condition.AddCondition("F_VouchId", keyValue, SqlOperator.Equal);
                        Sys_VouchTypeDefault.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);

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

        /// <summary>
        /// 根据选中父节点的值获取对应的出入库类型
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public DataTable GetTypeByParent(string F_FullName)
        {
            Hashtable parms = new Hashtable();
            parms.Add("F_FullName", F_FullName);
           string sql = "SELECT TOP 1 F_InoutType FROM  Sys_VouchType WHERE F_FullName = @F_FullName";
            return base.ExecuteTable(sql, parms);
        }

    }
}
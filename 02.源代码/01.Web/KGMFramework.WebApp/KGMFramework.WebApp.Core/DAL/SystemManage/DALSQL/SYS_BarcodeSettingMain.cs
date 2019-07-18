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
    /// SYS_BarcodeSettingMain
    /// </summary>
    public class SYS_BarcodeSettingMain : BaseDALSQL<SYS_BarcodeSettingMainInfo>, ISYS_BarcodeSettingMain
    {
        #region 对象实例及构造函数

        public static SYS_BarcodeSettingMain Instance
        {
            get
            {
                return new SYS_BarcodeSettingMain();
            }
        }
        public SYS_BarcodeSettingMain()
            : base("SYS_BarcodeSettingMain", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override SYS_BarcodeSettingMainInfo DataReaderToEntity(IDataReader dataReader)
        {
            SYS_BarcodeSettingMainInfo info = new SYS_BarcodeSettingMainInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_Type = reader.GetInt32("F_Type");
            info.F_Split = reader.GetString("F_Split");
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
        protected override Hashtable GetHashByEntity(SYS_BarcodeSettingMainInfo obj)
        {
            SYS_BarcodeSettingMainInfo info = obj as SYS_BarcodeSettingMainInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_Type", info.F_Type);
            hash.Add("F_Split", info.F_Split);
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
            dict.Add("F_FullName", "规则名称");
            dict.Add("F_Type", "类型");
            dict.Add("F_Split", "分隔符");
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
            #endregion

            return dict;
        }
        /// <summary>
        /// 删除主子表
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="bLogicDelete"></param>
        public void Delete(string keyValue, bool bLogicDelete)
        {
            using (DbTransactionScope<SYS_BarcodeSettingMainInfo> dbtran = base.CreateTransactionScope())
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
                        SYS_BarcodeSettingMainInfo info = this.FindByID(keyValue, dbtran.Transaction);
                        info.F_DeleteMark = false;
                        info.F_DeleteTime = DateTime.Now;
                        this.Update(info, keyValue, dbtran.Transaction);


                        //获取所有的子表信息
                        SearchCondition c = new SearchCondition();
                        c.AddCondition("F_ParentId", keyValue, SqlOperator.Equal);
                        List<SYS_BarcodeSettingDetailInfo> details = SYS_BarcodeSettingDetail.Instance.Find(c.BuildConditionSql());

                        foreach (SYS_BarcodeSettingDetailInfo d in details)
                        {
                            d.F_DeleteMark = false;
                            d.F_DeleteTime = DateTime.Now;
                            SYS_BarcodeSettingDetail.Instance.Update(d, d.F_Id, dbtran.Transaction);
                        }


                        //sql方式update
                        string sql = "UPDATE Sys_VouchType WHERE F_Id = @F_ParentId";
                        Hashtable parms = new Hashtable();
                        parms.Add("F_Id(参数名,不需要@)", keyValue);
                        base.ExecuteNonQuery(sql, parms, dbtran.Transaction);


                        sql = "UPDATE SYS_BarcodeSettingDetail WHERE F_VouchId = @F_ParentId";
                        base.ExecuteNonQuery(sql, parms, dbtran.Transaction);

                    }
                    else
                    {
                        //物理删除

                        //删除 SYS_BarcodeSettingDetail
                        SearchCondition condition = new SearchCondition();
                        condition.AddCondition("F_ParentId", keyValue, SqlOperator.Equal);
                        SYS_BarcodeSettingDetail.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                        //删除 SYS_BarcodeSettingMain
                        this.Delete(keyValue, dbtran.Transaction);
                    }
                    dbtran.Commit();
                }
                catch (Exception e)
                {
                    dbtran.RollBack();
                    throw e;
                }



            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        public void Save(SYS_BarcodeSettingMainInfo info, List<SYS_BarcodeSettingDetailInfo> dInfo)
        {
            using (DbTransactionScope<SYS_BarcodeSettingMainInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    //主表添加，修改
                    SYS_BarcodeSettingMain.Instance.InsertUpdate(info, info.F_Id, dbtran.Transaction);
                    //子表根据主表id全删除
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_ParentId", info.F_Id, SqlOperator.Equal);
                    BLLFactory<SYS_BarcodeSettingDetail>.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //添加子表               
                    foreach (SYS_BarcodeSettingDetailInfo model in dInfo)
                    {
                        model.F_CreatorTime = DateTime.Now;
                        model.F_CreatorUserId = info.F_CreatorUserId;
                        model.F_Id = Guid.NewGuid().ToString();
                        model.F_ParentId = info.F_Id;
                        SYS_BarcodeSettingDetail.Instance.Insert(model, dbtran.Transaction);
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
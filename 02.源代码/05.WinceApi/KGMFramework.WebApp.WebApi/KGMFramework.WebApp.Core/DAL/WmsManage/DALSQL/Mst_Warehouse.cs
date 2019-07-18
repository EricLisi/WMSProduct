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
    /// 货位表
    /// </summary>
    public class Mst_Warehouse : BaseDALSQL<Mst_WarehouseInfo>, IMst_Warehouse
    {
        #region 对象实例及构造函数

        public static Mst_Warehouse Instance
        {
            get
            {
                return new Mst_Warehouse();
            }
        }
        public Mst_Warehouse()
            : base("Mst_Warehouse", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Mst_WarehouseInfo DataReaderToEntity(IDataReader dataReader)
        {
            Mst_WarehouseInfo info = new Mst_WarehouseInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.F_Position = reader.GetString("F_Position");
            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_ParentId = reader.GetString("F_ParentId");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");
            info.F_FreeTerm1 = reader.GetString("F_FreeTerm1");
            info.F_FreeTerm2 = reader.GetString("F_FreeTerm2");
            info.F_FreeTerm3 = reader.GetString("F_FreeTerm3");
            info.F_FreeTerm4 = reader.GetString("F_FreeTerm4");
            info.F_FreeTerm5 = reader.GetString("F_FreeTerm5");
            info.F_FreeTerm6 = reader.GetString("F_FreeTerm6");
            info.F_FreeTerm7 = reader.GetString("F_FreeTerm7");
            info.F_FreeTerm8 = reader.GetString("F_FreeTerm8");
            info.F_FreeTerm9 = reader.GetString("F_FreeTerm9");
            info.F_FreeTerm10 = reader.GetString("F_FreeTerm10");
            info.F_MaxStock = reader.GetString("F_MaxStock");
            info.F_CarGoMark = reader.GetBoolean("F_CarGoMark");
            info.F_MinStock = reader.GetString("F_MinStock");
            info.F_Contacts = reader.GetString("F_Contacts");
            info.F_TelePhone = reader.GetString("F_TelePhone");
            info.F_AreaId = reader.GetString("F_AreaId");
            info.F_Address = reader.GetString("F_Address");
            info.F_Description = reader.GetString("F_Description");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Mst_WarehouseInfo obj)
        {
            Mst_WarehouseInfo info = obj as Mst_WarehouseInfo;

            Hashtable hash = new Hashtable();
            hash.Add("F_TelePhone", info.F_TelePhone);
            hash.Add("F_Position", info.F_Position);
            hash.Add("F_MaxStock", info.F_MaxStock);
            hash.Add("F_ParentId", info.F_ParentId);
            hash.Add("F_MinStock", info.F_MinStock);
            hash.Add("F_Contacts", info.F_Contacts);
            hash.Add("F_AreaId", info.F_AreaId);
            hash.Add("F_Address", info.F_Address);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_FreeTerm1", info.F_FreeTerm1);
            hash.Add("F_FreeTerm2", info.F_FreeTerm2);
            hash.Add("F_FreeTerm3", info.F_FreeTerm3);
            hash.Add("F_FreeTerm4", info.F_FreeTerm4);
            hash.Add("F_FreeTerm5", info.F_FreeTerm5);
            hash.Add("F_FreeTerm6", info.F_FreeTerm6);
            hash.Add("F_FreeTerm7", info.F_FreeTerm7);
            hash.Add("F_FreeTerm8", info.F_FreeTerm8);
            hash.Add("F_FreeTerm9", info.F_FreeTerm9);
            hash.Add("F_FreeTerm10", info.F_FreeTerm10);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
            hash.Add("F_DeleteTime", info.F_DeleteTime);
            hash.Add("F_DeleteUserId", info.F_DeleteUserId);
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_CarGoMark", info.F_CarGoMark);
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
            dict.Add("F_WarehouseName", "仓库名称");
            dict.Add("F_Acreage", "面积");
            dict.Add("F_Unit", "计量单位");
            dict.Add("F_Regionally", "区域性");
            dict.Add("F_Capacity", "容量");
            dict.Add("F_Layers", "层");
            dict.Add("F_WhatIs", "存放物料描述");
            dict.Add("F_SpecificatModel", "规格型号");

            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "货位编码");
            dict.Add("F_FullName", "货位名称");

            dict.Add("F_FreeTerm1", "自定义项1");
            dict.Add("F_FreeTerm2", "自定义项1");
            dict.Add("F_FreeTerm3", "自定义项1");
            dict.Add("F_FreeTerm4", "自定义项1");
            dict.Add("F_FreeTerm5", "自定义项1");
            dict.Add("F_FreeTerm6", "自定义项1");
            dict.Add("F_FreeTerm7", "自定义项1");
            dict.Add("F_FreeTerm8", "自定义项1");
            dict.Add("F_FreeTerm9", "自定义项1");
            dict.Add("F_FreeTerm10", "自定义项1");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_CreatorTime", "创建日期");
            dict.Add("F_CreatorUserId", "创建用户主键");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            #endregion

            return dict;
        }



        public void UpMark(string keyValue, string Name, bool State) {
            using (DbTransactionScope<Mst_WarehouseInfo> dbtran=base.CreateTransactionScope())
            {
                 try
            {
                Mst_WarehouseInfo info = BLLFactory<Mst_Warehouse>.Instance.FindByID(keyValue);
                Hashtable hash = new Hashtable();
                //判断是否是仓库仓库做操作
                if (Name == "F_EnabledMark")
                {
                    hash.Add("F_EnabledMark", State);
                    //如果是禁用仓库，便禁用此仓库下的货位
                    if (!State)
                    {
                        hash.Add("F_CarGoMark", State);
                        BLLFactory<Mst_Warehouse>.Instance.Update(info.F_Id, hash,dbtran.Transaction);
                       
                        SearchCondition search = new SearchCondition();
                        search.AddCondition("F_WarehouseId", keyValue, SqlOperator.Equal);
                        List<Mst_CargoPositionInfo> CarInfo = BLLFactory<Mst_CargoPosition>.Instance.Find(search.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty).Replace("Where (1=1)", " ( 1 = 1 ) "));
                        foreach (Mst_CargoPositionInfo item in CarInfo)
                        {
                            hash = new Hashtable();
                            hash.Add("F_EnabledMark", State);
                            Mst_CargoPosition.Instance.Update(item.F_Id, hash, dbtran.Transaction);
                        }
            
                    }
                }
                else
                {
                    hash.Add("F_CarGoMark", State);
                    BLLFactory<Mst_Warehouse>.Instance.Update(info.F_Id, hash);
                }

                dbtran.Commit();
            }
            catch (Exception)
            {
                dbtran.RollBack();
                throw;
            }
            }
        
        }
    }
}
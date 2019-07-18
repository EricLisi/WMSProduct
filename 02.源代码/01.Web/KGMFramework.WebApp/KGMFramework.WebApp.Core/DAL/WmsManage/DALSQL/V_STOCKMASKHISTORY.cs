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
    public class V_STOCKMASKHISTORY : BaseDALSQL<V_STOCKMASKHISTORYINFO>, IV_STOCKMASKHISTORY
    {
        #region 对象实例及构造函数

        public static V_STOCKMASKHISTORY Instance
        {
            get
            {
                return new V_STOCKMASKHISTORY();
            }
        }
        public V_STOCKMASKHISTORY()
            : base("V_STOCKMASKHISTORY", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override V_STOCKMASKHISTORYINFO DataReaderToEntity(IDataReader dataReader)
        {
            V_STOCKMASKHISTORYINFO info = new V_STOCKMASKHISTORYINFO();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_Number = reader.GetInt32("F_Number");
            info.F_RealNumber = reader.GetInt32("F_RealNumber");
            info.F_DiffNumber = reader.GetInt32("F_DiffNumber");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_Batch = reader.GetString("F_Batch");
            info.GOODSCODE = reader.GetString("GOODSCODE");
            info.CPOCODE = reader.GetString("CPOCODE");
            info.WHCODE = reader.GetString("WHCODE");
            info.F_SortCode = reader.GetInt32("F_SortCode");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(V_STOCKMASKHISTORYINFO obj)
        {
            V_STOCKMASKHISTORYINFO info = obj as V_STOCKMASKHISTORYINFO;
            Hashtable hash = new Hashtable();

            hash.Add("F_GoodsName", info.F_GoodsName);
            hash.Add("F_Batch", info.F_Batch);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
            hash.Add("F_Number", info.F_Number);
            hash.Add("F_DiffNumber", info.F_DiffNumber);
            hash.Add("F_RealNumber", info.F_RealNumber);
            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("GOODSCODE", info.GOODSCODE);
            hash.Add("CPOCODE", info.CPOCODE);
            hash.Add("WHCODE", info.WHCODE);
            hash.Add("F_SortCode", info.F_SortCode);

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
            dict.Add("F_ParentId", "父节点");
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
    }
}

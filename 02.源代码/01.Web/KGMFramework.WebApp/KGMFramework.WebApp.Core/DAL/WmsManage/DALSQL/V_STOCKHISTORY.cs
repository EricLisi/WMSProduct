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
    public class V_STOCKHISTORY : BaseDALSQL<V_STOCKHISTORYINFO>, IV_STOCKHISTORY
    {
        #region 对象实例及构造函数

        public static V_STOCKHISTORY Instance
        {
            get
            {
                return new V_STOCKHISTORY();
            }
        }
        public V_STOCKHISTORY()
            : base("V_STOCKHISTORY", "F_ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override V_STOCKHISTORYINFO DataReaderToEntity(IDataReader dataReader)
        {
            V_STOCKHISTORYINFO info = new V_STOCKHISTORYINFO();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.F_ID = reader.GetString("F_ID");
            info.F_ENCODE = reader.GetString("F_ENCODE");
            info.WHID = reader.GetString("WHID");
            info.F_BLLCATEGORY = reader.GetString("F_BLLCATEGORY");
            info.WHCODE = reader.GetString("WHCODE");
            info.WHNAME = reader.GetString("WHNAME");
            info.POSID = reader.GetString("POSID");
            info.POSCODE = reader.GetString("POSCODE");
            info.POSNAME = reader.GetString("POSNAME");
            info.F_Vendor = reader.GetString("F_Vendor");
            info.GOODSID = reader.GetString("GOODSID");
            info.GOODSCODE = reader.GetString("GOODSCODE");
            info.F_BATCH = reader.GetString("F_BATCH");
            info.GOODSNAME = reader.GetString("GOODSNAME");
            info.F_VENDORNAME = reader.GetString("F_VENDORNAME");
            info.F_Contacts = reader.GetString("F_Contacts");
            info.F_TELEPHONE = reader.GetString("F_TELEPHONE");
            info.F_ADDRESS = reader.GetString("F_ADDRESS");
            info.F_OperationNum = reader.GetString("F_OperationNum");
            info.F_UNIT = reader.GetString("F_UNIT");
            info.F_SPECIFMODEL = reader.GetString("F_SPECIFMODEL");
            info.F_Maker = reader.GetString("F_Maker");
            info.F_VERIFY = reader.GetString("F_VERIFY");
            info.F_VERIDATE = reader.GetString("F_VERIDATE");
            info.F_CREATORTIME = reader.GetString("F_CREATORTIME");
            info.F_DESCRIPTION = reader.GetString("F_DESCRIPTION");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(V_STOCKHISTORYINFO obj)
        {
            V_STOCKHISTORYINFO info = obj as V_STOCKHISTORYINFO;
            Hashtable hash = new Hashtable();
            hash.Add("F_ID", info.F_ID);
            hash.Add("F_ENCODE", info.F_ENCODE);
            hash.Add("WHID", info.WHID);
            hash.Add("F_BLLCATEGORY", info.F_BLLCATEGORY);
            hash.Add("WHCODE", info.WHCODE);
            hash.Add("WHNAME", info.WHNAME);
            hash.Add("POSID", info.POSID);
            hash.Add("POSCODE", info.POSCODE);
            hash.Add("POSNAME", info.POSNAME);
            hash.Add("GOODSID", info.GOODSID);
            hash.Add("GOODSCODE", info.GOODSCODE);
            hash.Add("F_BATCH", info.F_BATCH);
            hash.Add("F_OperationNum", info.F_OperationNum);
            hash.Add("GOODSNAME", info.GOODSNAME);
            hash.Add("F_Vendor", info.F_Vendor);
            hash.Add("F_VENDORNAME", info.F_VENDORNAME);
            hash.Add("F_TELEPHONE", info.F_TELEPHONE);
            hash.Add("F_Contacts", info.F_Contacts);
            hash.Add("F_ADDRESS", info.F_ADDRESS);
            hash.Add("F_UNIT", info.F_UNIT);
            hash.Add("F_SPECIFMODEL", info.F_SPECIFMODEL);
            hash.Add("F_Maker", info.F_Maker);
            hash.Add("F_VERIFY", info.F_VERIFY);
            hash.Add("F_VERIDATE", info.F_VERIDATE);
            hash.Add("F_CREATORTIME", info.F_CREATORTIME);
            hash.Add("F_DESCRIPTION", info.F_DESCRIPTION);
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
            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "入库编号");
            dict.Add("F_GoodsId", "产品Id");
            dict.Add("F_GoodsName", "产品名称");
            dict.Add("F_FullName", "产品名称");
            dict.Add("F_CategoryID", "产品类型");
            dict.Add("F_SpecifModel", "规格型号");
            dict.Add("F_WarehouseId", "仓库Id");
            dict.Add("F_WarehouseName", "仓库名称");
            dict.Add("F_Unit", "单位");
            dict.Add("F_InStockNum", "入库数量");
            dict.Add("F_Pic", "图片");
            dict.Add("F_ShelfLife", "保质期");
            dict.Add("F_PurchasePrice", "采购价格");
            dict.Add("F_SellingPrice", "销售价格");
            dict.Add("F_BasicRate", "基本税率");
            dict.Add("F_CargoPositionId", "货位号");
            dict.Add("F_CargoPositionName", "货位名称");
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

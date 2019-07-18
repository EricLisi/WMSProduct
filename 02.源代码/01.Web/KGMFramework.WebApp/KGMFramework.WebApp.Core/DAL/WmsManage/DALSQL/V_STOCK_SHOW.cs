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
    public class V_STOCK_SHOW : BaseDALSQL<V_STOCK_SHOWINFO>, IV_STOCK_SHOW
    {
        #region 对象实例及构造函数

        public static V_STOCK_SHOW Instance
        {
            get
            {
                return new V_STOCK_SHOW();
            }
        }
        public V_STOCK_SHOW()
            : base("V_STOCK_SHOW", "F_ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override V_STOCK_SHOWINFO DataReaderToEntity(IDataReader dataReader)
        {
            V_STOCK_SHOWINFO info = new V_STOCK_SHOWINFO();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.F_ID = reader.GetString("F_ID");
            info.WHID = reader.GetString("WHID");
            info.WHCODE = reader.GetString("WHCODE");
            info.WHNAME = reader.GetString("WHNAME");
            info.POSID = reader.GetString("POSID");
            info.POSCODE = reader.GetString("POSCODE");
            info.POSNAME = reader.GetString("POSNAME");
            info.GOODSID = reader.GetString("GOODSID");
            info.GOODSCODE = reader.GetString("GOODSCODE");
            info.F_BATCH = reader.GetString("F_BATCH");
            info.GOODSNAME = reader.GetString("GOODSNAME");
            info.F_UNIT = reader.GetString("F_UNIT");
            info.F_SPECIFMODEL = reader.GetString("F_SPECIFMODEL");
            info.F_NUMBER = reader.GetString("F_NUMBER");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_SellingPrice = reader.GetString("F_SellingPrice");
            info.F_Description = reader.GetString("F_Description");
            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(V_STOCK_SHOWINFO obj)
        {
            V_STOCK_SHOWINFO info = obj as V_STOCK_SHOWINFO;
            Hashtable hash = new Hashtable();
            hash.Add("F_ID", info.F_ID);
            hash.Add("WHID", info.WHID);
            hash.Add("WHCODE", info.WHCODE);
            hash.Add("WHNAME", info.WHNAME);
            hash.Add("POSID", info.POSID);
            hash.Add("POSCODE", info.POSCODE);
            hash.Add("POSNAME", info.POSNAME);
            hash.Add("GOODSID", info.GOODSID);
            hash.Add("GOODSCODE", info.GOODSCODE);
            hash.Add("F_BATCH", info.F_BATCH);
            hash.Add("GOODSNAME", info.GOODSNAME);
            hash.Add("F_UNIT", info.F_UNIT);
            hash.Add("F_SPECIFMODEL", info.F_SPECIFMODEL);
            hash.Add("F_NUMBER", info.F_NUMBER);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_SellingPrice", info.F_SellingPrice);
            hash.Add("F_Description", info.F_Description);

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

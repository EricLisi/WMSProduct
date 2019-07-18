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
    /// 资产调拨子表
    /// </summary>
    public class Mst_Goods : BaseDALSQL<Mst_GoodsInfo>,IMst_Goods
	{
		#region 对象实例及构造函数

		public static Mst_Goods Instance
		{
			get
			{
				return new Mst_Goods();
			}
		}
        public Mst_Goods()
            : base("Mst_Goods", "F_Id")
		{
		}

		#endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Mst_GoodsInfo DataReaderToEntity(IDataReader dataReader)
        {
            Mst_GoodsInfo info = new Mst_GoodsInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);
            info.F_ProDate = reader.GetDateTime("F_ProDate");
            info.F_ExpiratDate = reader.GetDateTime("F_ExpiratDate");
            info.F_Id = reader.GetString("F_Id");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_Batch = reader.GetString("F_Batch");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_CategoryID = reader.GetString("F_CategoryID");
            info.F_SpecifModel = reader.GetString("F_SpecifModel");
            info.F_Unit = reader.GetString("F_Unit");
            info.F_Pic = reader.GetString("F_Pic");
            info.F_ShelfLife = reader.GetString("F_ShelfLife");
            info.F_SellingPrice = reader.GetString("F_SellingPrice");
            info.F_PurchasePrice = reader.GetString("F_PurchasePrice");
            info.F_BasicRate = reader.GetString("F_BasicRate");
            info.F_SerialNum = reader.GetString("F_SerialNum");
            info.F_FreeTerm2 = reader.GetString("F_FreeTerm2");
            info.F_Long = reader.GetString("F_Long");
            info.F_Wide = reader.GetString("F_Wide");
            info.F_Height = reader.GetString("F_Height");
            info.F_NetWeight = reader.GetString("F_NetWeight");
            info.F_GrossWeight = reader.GetString("F_GrossWeight");
            info.F_Volume = reader.GetString("F_Volume");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_Description = reader.GetString("F_Description");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_OpenConfigure = reader.GetBoolean("F_OpenConfigure");
            info.F_OpenBatch = reader.GetBoolean("F_OpenBatch");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Mst_GoodsInfo obj)
        {
            Mst_GoodsInfo info = obj as Mst_GoodsInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_ProDate", info.F_ProDate);
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_GoodsId", info.F_GoodsId);
            hash.Add("F_Batch", info.F_Batch);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_CategoryID", info.F_CategoryID);
            hash.Add("F_SpecifModel", info.F_SpecifModel);
            hash.Add("F_Unit", info.F_Unit);
            hash.Add("F_Pic", info.F_Pic);
            hash.Add("F_ShelfLife", info.F_ShelfLife);
            hash.Add("F_PurchasePrice", info.F_PurchasePrice);
            hash.Add("F_SellingPrice", info.F_SellingPrice);
            hash.Add("F_BasicRate", info.F_BasicRate);
            hash.Add("F_SerialNum", info.F_SerialNum);
            hash.Add("F_FreeTerm2", info.F_FreeTerm2);
            hash.Add("F_Long", info.F_Long);
            hash.Add("F_Wide", info.F_Wide);
            hash.Add("F_Height", info.F_Height);
            hash.Add("F_NetWeight", info.F_NetWeight);
            hash.Add("F_GrossWeight", info.F_GrossWeight);
            hash.Add("F_Volume", info.F_Volume);
            hash.Add("F_OpenConfigure", info.F_OpenConfigure);
            hash.Add("F_OpenBatch", info.F_OpenBatch);
            hash.Add("F_SortCode", info.F_SortCode);
            hash.Add("F_Description", info.F_Description);
            hash.Add("F_DeleteMark", info.F_DeleteMark);
            hash.Add("F_EnabledMark", info.F_EnabledMark);
            hash.Add("F_CreatorTime", info.F_CreatorTime);
            hash.Add("F_CreatorUserId", info.F_CreatorUserId);
            hash.Add("F_LastModifyUserId", info.F_LastModifyUserId);
            hash.Add("F_LastModifyTime", info.F_LastModifyTime);
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
            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "产品编码");
            dict.Add("F_FullName", "产品名称");
            dict.Add("F_CategoryID", "产品类型");
            dict.Add("F_SpecifModel", "规格型号");
            dict.Add("F_Unit", "单位");
            dict.Add("F_Pic", "图片");
            dict.Add("F_ShelfLife", "保质期");
            dict.Add("F_PurchasePrice", "采购价格");
            dict.Add("F_SellingPrice", "销售价格");
            dict.Add("F_BasicRate", "基本税率");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_Description", "备注");
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

        public DataTable GetGoodsById(string Id)
        {
            string sql = "select * from Mst_Goods where F_Id='" + Id + "'";
            return this.GetDataTableBySql(sql);
        }

        public DataTable selGoodsCategory()
        {
            string sql = "select a.*,F_CategoryName=b.F_FullName from [dbo].[Mst_Goods] a,[dbo].[Mst_Category] b where a.F_CategoryID=b.F_Id ";
            DataTable dt = this.GetDataTableBySql(sql);
            return dt;
        }

        public string GetNameByCode(string itemcode)
        {
            string sql = "SELECT F_FullName FROM Sys_Items AS A INNER JOIN Sys_ItemsDetail AS B ON A.F_Id=B.F_ItemId WHERE B.F_ItemName=@itemcode";
            Hashtable parms = new Hashtable();
            parms.Add("itemcode", itemcode);
            return base.ExecuteTable(sql, parms).Rows[0][0].ToString();
        }

        public DataTable GetPrint(string Id)
        {
            var str = Id.Split('|');
            string sql = string.Format("SELECT * FROM Mst_Goods WHERE F_Id = '{0}'", str[2]);
            DataTable dt = base.ExecuteTable(sql);
            dt.Rows[0]["F_Batch"] = str[1];
            dt.Columns.Add("F_Qty", typeof(string));
            dt.Rows[0]["F_Qty"] = str[0];
            return dt;
        }
    }
}
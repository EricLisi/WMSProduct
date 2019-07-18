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
    /// 拣货单子表
    /// </summary>
	public class PackList_Body : BaseDALSQL<PackList_BodyInfo>, IPackList_Body
	{
		#region 对象实例及构造函数

		public static PackList_Body Instance
		{
			get
			{
				return new PackList_Body();
			}
		}
		public PackList_Body() : base("PackList_Body","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override PackList_BodyInfo DataReaderToEntity(IDataReader dataReader)
		{
			PackList_BodyInfo info = new PackList_BodyInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_RowNo = reader.GetInt32("F_RowNo");
			info.F_HeadId = reader.GetString("F_HeadId");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_OrganizationId = reader.GetString("F_OrganizationId");
			info.F_ProductId = reader.GetString("F_ProductId");
			info.F_WarehouseId = reader.GetString("F_WarehouseId");
			info.F_PositionId = reader.GetString("F_PositionId");
			info.F_Batch = reader.GetString("F_Batch");
			info.F_MadeDate = reader.GetDateTime("F_MadeDate");
			info.F_ExpiryDate = reader.GetDateTime("F_ExpiryDate");
			info.F_Quantity = reader.GetDecimal("F_Quantity");
			info.F_DoneQty = reader.GetDecimal("F_DoneQty");
			info.F_SourceId = reader.GetString("F_SourceId");
			info.F_SourceType = reader.GetString("F_SourceType");
			info.F_SourceNo = reader.GetString("F_SourceNo");
			info.F_SourceRowNo = reader.GetInt32("F_SourceRowNo");
			info.F_SourceBodyId = reader.GetString("F_SourceBodyId");
			info.F_OwnershipId = reader.GetString("F_OwnershipId");
			info.F_Define1 = reader.GetString("F_Define1");
			info.F_Define2 = reader.GetString("F_Define2");
			info.F_Define3 = reader.GetString("F_Define3");
			info.F_Define4 = reader.GetString("F_Define4");
			info.F_Define5 = reader.GetString("F_Define5");
			info.F_Define6 = reader.GetString("F_Define6");
			info.F_Define7 = reader.GetString("F_Define7");
			info.F_Define8 = reader.GetString("F_Define8");
			info.F_Define9 = reader.GetString("F_Define9");
			info.F_Define10 = reader.GetString("F_Define10");
			info.F_Description = reader.GetString("F_Description");
			info.F_SortCode = reader.GetInt32("F_SortCode");
			info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
			info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
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
        protected override Hashtable GetHashByEntity(PackList_BodyInfo obj)
		{
		    PackList_BodyInfo info = obj as PackList_BodyInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_RowNo", info.F_RowNo);
 			hash.Add("F_HeadId", info.F_HeadId);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_OrganizationId", info.F_OrganizationId);
 			hash.Add("F_ProductId", info.F_ProductId);
 			hash.Add("F_WarehouseId", info.F_WarehouseId);
 			hash.Add("F_PositionId", info.F_PositionId);
 			hash.Add("F_Batch", info.F_Batch);
 			hash.Add("F_MadeDate", info.F_MadeDate);
 			hash.Add("F_ExpiryDate", info.F_ExpiryDate);
 			hash.Add("F_Quantity", info.F_Quantity);
 			hash.Add("F_DoneQty", info.F_DoneQty);
 			hash.Add("F_SourceId", info.F_SourceId);
 			hash.Add("F_SourceType", info.F_SourceType);
 			hash.Add("F_SourceNo", info.F_SourceNo);
 			hash.Add("F_SourceRowNo", info.F_SourceRowNo);
 			hash.Add("F_SourceBodyId", info.F_SourceBodyId);
 			hash.Add("F_OwnershipId", info.F_OwnershipId);
 			hash.Add("F_Define1", info.F_Define1);
 			hash.Add("F_Define2", info.F_Define2);
 			hash.Add("F_Define3", info.F_Define3);
 			hash.Add("F_Define4", info.F_Define4);
 			hash.Add("F_Define5", info.F_Define5);
 			hash.Add("F_Define6", info.F_Define6);
 			hash.Add("F_Define7", info.F_Define7);
 			hash.Add("F_Define8", info.F_Define8);
 			hash.Add("F_Define9", info.F_Define9);
 			hash.Add("F_Define10", info.F_Define10);
 			hash.Add("F_Description", info.F_Description);
 			hash.Add("F_SortCode", info.F_SortCode);
 			hash.Add("F_DeleteMark", info.F_DeleteMark);
 			hash.Add("F_EnabledMark", info.F_EnabledMark);
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
             dict.Add("F_RowNo", "行号");
             dict.Add("F_HeadId", "主表Id");
             dict.Add("F_EnCode", "单据号");
             dict.Add("F_OrganizationId", "所属机构Id");
             dict.Add("F_ProductId", "商品Id");
             dict.Add("F_WarehouseId", "仓库Id");
             dict.Add("F_PositionId", "货位Id");
             dict.Add("F_Batch", "批次");
             dict.Add("F_MadeDate", "生产日期");
             dict.Add("F_ExpiryDate", "失效日期");
             dict.Add("F_Quantity", "数量");
             dict.Add("F_DoneQty", "下架数量");
             dict.Add("F_SourceId", "来源单据主表Id");
             dict.Add("F_SourceType", "来源单据类型(目前仅收货通知)");
             dict.Add("F_SourceNo", "来源单据号");
             dict.Add("F_SourceRowNo", "来源单据行号");
             dict.Add("F_SourceBodyId", "来源单据子表Id");
             dict.Add("F_OwnershipId", "商品权属Id");
             dict.Add("F_Define1", "自定义项1");
             dict.Add("F_Define2", "自定义项2");
             dict.Add("F_Define3", "自定义项3");
             dict.Add("F_Define4", "自定义项4");
             dict.Add("F_Define5", "自定义项5");
             dict.Add("F_Define6", "自定义项6");
             dict.Add("F_Define7", "自定义项7");
             dict.Add("F_Define8", "自定义项8");
             dict.Add("F_Define9", "自定义项9");
             dict.Add("F_Define10", "自定义项10");
             dict.Add("F_Description", "备注");
             dict.Add("F_SortCode", "排序号");
             dict.Add("F_DeleteMark", "删除标记");
             dict.Add("F_EnabledMark", "有效标记");
             dict.Add("F_CreatorTime", "创建时间");
             dict.Add("F_CreatorUserId", "创建人");
             dict.Add("F_LastModifyTime", "最后修改时间");
             dict.Add("F_LastModifyUserId", "最后修改人");
             dict.Add("F_DeleteTime", "删除时间");
             dict.Add("F_DeleteUserId", "删除操作人");
             #endregion

            return dict;
        }
		
     
    }
}
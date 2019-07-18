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
    /// 货位信息表
    /// </summary>
	public class Mst_Position : BaseDALSQL<Mst_PositionInfo>, IMst_Position
	{
		#region 对象实例及构造函数

		public static Mst_Position Instance
		{
			get
			{
				return new Mst_Position();
			}
		}
		public Mst_Position() : base("Mst_Position","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Mst_PositionInfo DataReaderToEntity(IDataReader dataReader)
		{
			Mst_PositionInfo info = new Mst_PositionInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_FullName = reader.GetString("F_FullName");
			info.F_WarehouseId = reader.GetString("F_WarehouseId");
			info.F_Property = reader.GetInt32("F_Property");
			info.F_Type = reader.GetInt32("F_Type");
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
            info.F_ParentId = reader.GetString("F_ParentId");
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
        protected override Hashtable GetHashByEntity(Mst_PositionInfo obj)
		{
		    Mst_PositionInfo info = obj as Mst_PositionInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_FullName", info.F_FullName);
 			hash.Add("F_WarehouseId", info.F_WarehouseId);
 			hash.Add("F_Property", info.F_Property);
 			hash.Add("F_Type", info.F_Type);
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
            hash.Add("F_ParentId", info.F_ParentId);
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
             dict.Add("F_EnCode", "货位编号");
             dict.Add("F_FullName", "货位名称");
             dict.Add("F_WarehouseId", "仓库Id");
             dict.Add("F_Parent", "上级货位");
             dict.Add("F_Property", "货位属性(0 正常品 1 待定品 2 坏品)");
             dict.Add("F_Type", "货位类型(0 整箱区 1 散货区)");
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
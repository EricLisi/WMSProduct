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
    /// 拣货单主表
    /// </summary>
	public class PackList_Head : BaseDALSQL<PackList_HeadInfo>, IPackList_Head
	{
		#region 对象实例及构造函数

		public static PackList_Head Instance
		{
			get
			{
				return new PackList_Head();
			}
		}
		public PackList_Head() : base("PackList_Head","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override PackList_HeadInfo DataReaderToEntity(IDataReader dataReader)
		{
			PackList_HeadInfo info = new PackList_HeadInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_OrganizationId = reader.GetString("F_OrganizationId");
			info.F_CustomerId = reader.GetString("F_CustomerId");
			info.F_WarehouseId = reader.GetString("F_WarehouseId");
			info.F_SrTypeId = reader.GetString("F_SrTypeId");
			info.F_OwnershipId = reader.GetString("F_OwnershipId");
			info.F_PackPolicy = reader.GetInt32("F_PackPolicy");
			info.F_Maker = reader.GetString("F_Maker");
			info.F_Date = reader.GetDateTime("F_Date");
			info.F_Verifier = reader.GetString("F_Verifier");
			info.F_Veridate = reader.GetDateTime("F_Veridate");
			info.F_Status = reader.GetInt32("F_Status");
			info.F_SourceId = reader.GetString("F_SourceId");
			info.F_SourceType = reader.GetString("F_SourceType");
			info.F_SourceNo = reader.GetString("F_SourceNo");
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
        protected override Hashtable GetHashByEntity(PackList_HeadInfo obj)
		{
		    PackList_HeadInfo info = obj as PackList_HeadInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_OrganizationId", info.F_OrganizationId);
 			hash.Add("F_CustomerId", info.F_CustomerId);
 			hash.Add("F_WarehouseId", info.F_WarehouseId);
 			hash.Add("F_SrTypeId", info.F_SrTypeId);
 			hash.Add("F_OwnershipId", info.F_OwnershipId);
 			hash.Add("F_PackPolicy", info.F_PackPolicy);
 			hash.Add("F_Maker", info.F_Maker);
 			hash.Add("F_Date", info.F_Date);
 			hash.Add("F_Verifier", info.F_Verifier);
 			hash.Add("F_Veridate", info.F_Veridate);
 			hash.Add("F_Status", info.F_Status);
 			hash.Add("F_SourceId", info.F_SourceId);
 			hash.Add("F_SourceType", info.F_SourceType);
 			hash.Add("F_SourceNo", info.F_SourceNo);
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
             dict.Add("F_EnCode", "单据号");
             dict.Add("F_OrganizationId", "所属机构Id");
             dict.Add("F_CustomerId", "客户Id");
             dict.Add("F_WarehouseId", "仓库Id");
             dict.Add("F_SrTypeId", "收发类别Id");
             dict.Add("F_OwnershipId", "商品权属Id");
             dict.Add("F_PackPolicy", "拣货策略");
             dict.Add("F_Maker", "制单人");
             dict.Add("F_Date", "单据日期");
             dict.Add("F_Verifier", "审核人");
             dict.Add("F_Veridate", "审核日期");
             dict.Add("F_Status", "单据状态(0 待审核 1 已审核)");
             dict.Add("F_SourceId", "来源单据主表Id");
             dict.Add("F_SourceType", "来源单据类型(目前仅收货通知)");
             dict.Add("F_SourceNo", "来源单据号");
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
        /// <summary>
        /// 保存拣货单
        /// </summary>
        /// <param name="headInfo"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public bool Save(PackList_HeadInfo headInfo, List<PackList_BodyInfo> dInfo)
        {
            using (DbTransactionScope<PackList_HeadInfo> dbtran=base.CreateTransactionScope())
            {
                try
                {
                   
              
                        //判断当前单据是否已经审核
                        var head = this.FindByID(headInfo.F_Id, dbtran.Transaction);
                        if (head != null && head.F_Status > 0)
                        {
                            throw new ApplicationException("单据已经审核!");
                        }

                    var ID = headInfo.F_Id;
                        Instance.InsertUpdate(headInfo,headInfo.F_Id, dbtran.Transaction);//添加主表
                        SearchCondition search = new SearchCondition();//查找子表
                        search.AddCondition("F_HeadId", headInfo.F_Id, SqlOperator.Equal);
                        PackList_Body.Instance.DeleteByCondition(search.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);//删除子表
                        PackList_Body.Instance.InsertRange(dInfo, dbtran.Transaction);//添加主表
                    


                    dbtran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    return false;
                    throw;
                }
            }

        }

        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public DataTable GetPrint(string sourceData)
        {

            DataTable dt = null;
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_Id", sourceData, SqlOperator.Equal);
            List<PackList_HeadInfo> hinfo = BLLFactory<PackList_Head>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));

            condition = new SearchCondition();
            condition.AddCondition("F_HeadId", sourceData, SqlOperator.Equal);
            List<PackList_BodyInfo> binfo = PackList_Body.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));

            dt = new DataTable();
            dt.Columns.Add("EnCode");
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("Maker");
            dt.Columns.Add("Date");
            dt.Columns.Add("Verifier");
            dt.Columns.Add("Veridate");
            dt.Columns.Add("Description");

            dt.Columns.Add("ProductCode");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("ProductStandard");
            dt.Columns.Add("Batch");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("WarehouseName");
            dt.Columns.Add("PositionName");
            dt.Columns.Add("MadeDate");
            dt.Columns.Add("ExpiryDate");

            List<Mst_WarehouseInfo> wList = BLLFactory<Mst_Warehouse>.Instance.GetAll();//所有供应商
            List<Mst_PositionInfo> pList = BLLFactory<Mst_Position>.Instance.GetAll();//所有货位
            List<Mst_CustomerInfo> cList = BLLFactory<Mst_Customer>.Instance.GetAll();//所有客户
            List<Mst_ProductInfo> dList = BLLFactory<Mst_Product>.Instance.GetAll();//所有商品

            for (int i = 0; i < binfo.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["EnCode"] = hinfo[0].F_EnCode;
                dr["CustomerName"] = cList.Find(u => u.F_Id == hinfo[0].F_CustomerId)!=null?cList.Find(u => u.F_Id == hinfo[0].F_CustomerId).F_FullName:"";
                dr["Description"] = hinfo[0].F_Description;
                dr["Maker"] = hinfo[0].F_Maker;
                dr["Date"] = hinfo[0].F_Date;
                dr["Verifier"] = hinfo[0].F_Verifier;
                dr["Veridate"] = hinfo[0].F_Veridate;

                var product=dList.Find(u => u.F_Id == binfo[i].F_ProductId);
               var warehouse=wList.Find(u => u.F_Id == binfo[i].F_WarehouseId);
                var Position=pList.Find(u=>u.F_Id==binfo[i].F_PositionId);
                dr["ProductCode"] = product != null ? product .F_EnCode: "";
                dr["ProductName"] = product != null ? product.F_FullName : "";
                dr["ProductStandard"] = product != null ? product.F_Standard : "";
                dr["Batch"] = binfo[i].F_Batch;
                dr["Quantity"] = binfo[i].F_Quantity;
                dr["WarehouseName"] = warehouse != null ? warehouse.F_FullName : "";
                dr["PositionName"] = Position!=null?Position.F_FullName:"";
                dr["MadeDate"] = binfo[i].F_MadeDate;
                dr["ExpiryDate"] = binfo[i].F_ExpiryDate;
        

                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
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
    /// 入库通知单主表
    /// </summary>
	public class InStockNotice_Head : BaseDALSQL<InStockNotice_HeadInfo>, IInStockNotice_Head
	{
		#region 对象实例及构造函数

		public static InStockNotice_Head Instance
		{
			get
			{
				return new InStockNotice_Head();
			}
		}
		public InStockNotice_Head() : base("InStockNotice_Head","F_Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override InStockNotice_HeadInfo DataReaderToEntity(IDataReader dataReader)
		{
			InStockNotice_HeadInfo info = new InStockNotice_HeadInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.F_Id = reader.GetString("F_Id");
			info.F_EnCode = reader.GetString("F_EnCode");
			info.F_OrganizationId = reader.GetString("F_OrganizationId");
			info.F_SupplierId = reader.GetString("F_SupplierId");
			info.F_SrTypeId = reader.GetString("F_SrTypeId");
			info.F_OwnershipId = reader.GetString("F_OwnershipId");
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
        protected override Hashtable GetHashByEntity(InStockNotice_HeadInfo obj)
		{
		    InStockNotice_HeadInfo info = obj as InStockNotice_HeadInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("F_Id", info.F_Id);
 			hash.Add("F_EnCode", info.F_EnCode);
 			hash.Add("F_OrganizationId", info.F_OrganizationId);
 			hash.Add("F_SupplierId", info.F_SupplierId);
 			hash.Add("F_SrTypeId", info.F_SrTypeId);
 			hash.Add("F_OwnershipId", info.F_OwnershipId);
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
             dict.Add("F_SupplierId", "供应商Id");
             dict.Add("F_SrTypeId", "收发类别Id");
             dict.Add("F_OwnershipId", "商品权属Id");
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


        public InStockNotice_HeadInfo Save(InStockNotice_HeadInfo info, List<InStockNotice_BodyInfo> BInfo)
        {
            using (DbTransactionScope<InStockNotice_HeadInfo> dbtran = base.CreateTransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(info.F_EnCode))
                    {
                        string orderNo = "INOT" + DateTime.Now.ToString("yyyyMMdd");
                        Hashtable hash = new Hashtable();
                        hash.Add("Prefix", orderNo);
                        DataTable dt = base.StorePorcToDataTable("SYS_GENERATE_SN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString();
                        info.F_EnCode = SN;
                    }
                    else
                    {
                        //判断当前单据是否已经审核
                        var head = this.FindByID(info.F_Id, dbtran.Transaction);
                        if (head != null && head.F_Status == 1)
                        {
                            throw new ApplicationException("单据已经审核!");
                        }
                    }
                    info.F_Status = 0;
                    info.F_Verifier = "";
                    info.F_Veridate = null;
                    //添加主表
                    InStockNotice_Head.Instance.InsertUpdate(info, info.F_Id, dbtran.Transaction);
                    //删除子表
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_HeadId", info.F_Id, SqlOperator.Equal);
                    InStockNotice_Body.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty), dbtran.Transaction);
                    //循环添加子表
                    foreach (InStockNotice_BodyInfo item in BInfo)
                    {
                        item.F_CreatorTime = DateTime.Now;
                        item.F_CreatorUserId = info.F_CreatorUserId;
                        item.F_Id = Guid.NewGuid().ToString();
                        item.F_HeadId = info.F_Id;


                        string orderNo = "INOTB" + DateTime.Now.ToString("yyyyMMdd");
                        Hashtable hash = new Hashtable();
                        hash.Add("Prefix", orderNo);
                        DataTable dt = base.StorePorcToDataTable("SYS_GENERATE_SN", hash, null, dbtran.Transaction);
                        string SN = dt.Rows[0][0].ToString();
                        item.F_EnCode = SN;
                        //InStockNotice_Body.Instance.Insert(item, dbtran.Transaction);
                    }
                    InStockNotice_Body.Instance.InsertRange(BInfo, dbtran.Transaction);

                    dbtran.Commit();

                    return info;
                }
                catch (Exception ex)
                {
                    dbtran.RollBack();
                    throw ex;
                }
            }
        }


        public string UploadExcel(DataTable dt, string user)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var Supplier = BLLFactory<Mst_Supplier>.Instance.FindSingle(string.Format(" F_EnCode='{0}'", dt.Rows[i]["供应商编码"].ToString()));
                if (Supplier == null)
                {
                    return "导入失败！第" + (i + 1) + "行中" + "供应商编码不存在！";
                }
                var Product = BLLFactory<Mst_Product>.Instance.FindSingle(string.Format("F_EnCode='{0}'", dt.Rows[i]["产品编码"].ToString()));
                if (Product == null)
                {
                    return "导入失败！第" + (i + 1) + "行中" + "产品编码不存在！";
                }
                var Warehouse = BLLFactory<Mst_Warehouse>.Instance.FindSingle(string.Format("F_EnCode='{0}'", dt.Rows[i]["仓库编码"].ToString()));
                if (Warehouse == null)
                {
                    return "导入失败！第" + (i + 1) + "行中" + "仓库编码不存在！";
                }
                var Position = BLLFactory<Mst_Position>.Instance.FindSingle(string.Format("F_EnCode='{0}'", dt.Rows[i]["货位编码"].ToString()));
                if (Position == null)
                {
                    return "导入失败！第" + (i + 1) + "行中" + "货位编码不存在！";
                }
            }
            return "";
        }
     
    }
}
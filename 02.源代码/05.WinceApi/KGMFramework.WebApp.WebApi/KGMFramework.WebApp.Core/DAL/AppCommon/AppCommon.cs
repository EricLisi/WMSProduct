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
    /// 行政区域表
    /// </summary>
    public class AppCommon : BaseDALSQL<AppBaseEntity>, IAppCommon
    {
        #region 对象实例及构造函数

        public static AppCommon Instance
        {
            get
            {
                return new AppCommon();
            }
        }
        public AppCommon()
            : base("AppCommon", "F_Id")
        {
        }

        #endregion

        /// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override AppBaseEntity DataReaderToEntity(IDataReader dataReader)
        {
            AppBaseEntity info = new AppBaseEntity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_ParentId = reader.GetString("F_ParentId");
           
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
         
            info.F_SortCode = reader.GetInt32Nullable("F_SortCode");
            info.F_DeleteMark = reader.GetBooleanNullable("F_DeleteMark");
            info.F_EnabledMark = reader.GetBooleanNullable("F_EnabledMark");
            info.F_Description = reader.GetString("F_Description");
            info.F_CreatorTime = reader.GetDateTimeNullable("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyTime = reader.GetDateTimeNullable("F_LastModifyTime");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_DeleteTime = reader.GetDateTimeNullable("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(AppBaseEntity obj)
        {
            AppBaseEntity info = obj as AppBaseEntity;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_ParentId", info.F_ParentId);
           
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
  
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
        /// 获取属性结构
        /// </summary>
        /// <param name="entity">参数对象</param>
        /// <returns></returns>
        public DataSet LIST_GETDATA(string ORDERNO, string orderType)
        {

            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, ORDERNO));
            paramList.Add(CreateInSmartDbParameter("ORDERTYPE", DbType.String, orderType));
            return base.ExecuteDataSetByProc("[LIST_GETDATA]", paramList);
        }


        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataSet SaveTempScan(SaveTempScanEntity entity)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, entity.ORDERNO));
            paramList.Add(CreateInSmartDbParameter("ORDERTYPE", DbType.String, entity.ORDERTYPE));
            paramList.Add(CreateInSmartDbParameter("CWHCODE", DbType.String, entity.CWHCODE));
            paramList.Add(CreateInSmartDbParameter("BARCODE", DbType.String, entity.BARCODE));
            paramList.Add(CreateInSmartDbParameter("CPOSCODE", DbType.String, entity.CPOSCODE));
            paramList.Add(CreateInSmartDbParameter("OPERUSER", DbType.String, entity.OPERUSER));
            paramList.Add(CreateInSmartDbParameter("QTY", DbType.Decimal, entity.QTY));
            paramList.Add(CreateInSmartDbParameter("BDEL", DbType.Boolean, entity.BDEL));

            return base.ExecuteDataSetByProc("[TEMPSCAN_SAVE]", paramList);
        }


        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataTable GetTempScan(string orderNo,string operUser)
        {
            string sql = "SELECT * FROM Sys_TempScan WHERE ORDERNO = @ORDERNO "; 
            Hashtable hash = new Hashtable();
            hash.Add("ORDERNO", orderNo);
            hash.Add("OPERUSER", operUser);

            return base.ExecuteTable(sql, hash);
        }

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataSet GetTempScanCy(string orderNo, string orderType)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, orderNo));
            paramList.Add(CreateInSmartDbParameter("ORDERTYPE", DbType.String, orderType));

            return base.ExecuteDataSetByProc("[LIST_GETCY]", paramList);
        }

        /// <summary>
        /// 单据扫描完成
        /// </summary>
        /// <param name="dto">完成参数</param>
        /// <returns></returns>
        public DataSet TempScanFinish(FinishTempScanDto dto)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, dto.OrderNo));
            paramList.Add(CreateInSmartDbParameter("ORDERTYPE", DbType.String, dto.OrderType));
            paramList.Add(CreateInSmartDbParameter("CMPOSCODE", DbType.String, dto.CMPosCode));
            paramList.Add(CreateInSmartDbParameter("CMCWHCODE", DbType.String, dto.CMCWHCode));
            return base.ExecuteDataSetByProc("[TEMPSCAN_FINISH]", paramList);
        }


        ///// <summary>
        ///// 获取资产卡片打印信息
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public DataSet GetBarcodeInfo(VerifyListEntity entity)
        //{
        //    List<SmartDbParameter> paramList = new List<SmartDbParameter>();
        //    paramList.Add(CreateInSmartDbParameter("ORDERID", DbType.String, entity.orderId));
        //    paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, entity.orderNo));
        //    paramList.Add(CreateInSmartDbParameter("USER", DbType.String, entity.userId));
        //    paramList.Add(CreateInSmartDbParameter("COMPID", DbType.String, entity.corpId));

        //    return base.ExecuteDataSetByProc("[ASSET_GETBARCODEINFO]", paramList);
        //}


        //public DataSet GetAssetInfo(string corpId, string deptId, string status, string condition, int pageindex = -1, int pagesize = 50)
        //{
        //    List<SmartDbParameter> paramList = new List<SmartDbParameter>();
        //    paramList.Add(CreateInSmartDbParameter("CONDITION", DbType.String, condition));
        //    paramList.Add(CreateInSmartDbParameter("STATUS", DbType.String, status));
        //    paramList.Add(CreateInSmartDbParameter("COMPID", DbType.String, corpId));
        //    paramList.Add(CreateInSmartDbParameter("DEPTID", DbType.String, deptId));
        //    paramList.Add(CreateInSmartDbParameter("PAGEINDEX", DbType.Int32, pageindex));
        //    paramList.Add(CreateInSmartDbParameter("PAGESIZE", DbType.Int32, pagesize));

        //    return base.ExecuteDataSetByProc("[ASSET_GETINFO]", paramList);
        //}


        //public DataSet GetPreVerify(string corpId)
        //{
        //    List<SmartDbParameter> paramList = new List<SmartDbParameter>();
        //    paramList.Add(CreateInSmartDbParameter("CorpId", DbType.String, corpId));

        //    return base.ExecuteDataSetByProc("[Asset_GetPreVerfy]", paramList);
        //}

        //public DataSet Asset_GetStatusReport(string corpId)
        //{
        //    List<SmartDbParameter> paramList = new List<SmartDbParameter>();
        //    paramList.Add(CreateInSmartDbParameter("CorpId", DbType.String, corpId));

        //    return base.ExecuteDataSetByProc("[Asset_GetStatusReport]", paramList);
        //}

        //public DataSet Asset_GetRecordReport(string corpId)
        //{
        //    List<SmartDbParameter> paramList = new List<SmartDbParameter>();
        //    paramList.Add(CreateInSmartDbParameter("CorpId", DbType.String, corpId));

        //    return base.ExecuteDataSetByProc("[Asset_GetRecordReport]", paramList);
        //}


        /// <summary>
        /// 获取临时扫描信息
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型</param>
        /// <returns></returns>
        public DataSet GetTempScanList(string orderNo, string orderType)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, orderNo));
            paramList.Add(CreateInSmartDbParameter("ORDERTYPE", DbType.String, orderType));

            return base.ExecuteDataSetByProc("[TEMPSCAN_GETLIST]", paramList);
        }


        /// <summary>
        /// 获取临时扫描信息
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型</param>
        /// <returns></returns>
        public DataSet GetScanCyList(string orderNo, string orderType)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, orderNo));
            paramList.Add(CreateInSmartDbParameter("ORDERTYPE", DbType.String, orderType));

            return base.ExecuteDataSetByProc("[TEMPSCAN_GETDIFFLIST]", paramList);
        }


        /// <summary>
        /// 保存临时扫描表
        /// </summary>
        /// <param name="dto">保存参数</param>
        /// <returns></returns>
        public DataSet SaveTempScan(SaveTempScanModel dto)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, dto.OrderNo));
            paramList.Add(CreateInSmartDbParameter("ORDERTYPE", DbType.String, dto.OrderType));
            paramList.Add(CreateInSmartDbParameter("CMCHWCODE", DbType.String, dto.DesWarehouse));           
            paramList.Add(CreateInSmartDbParameter("CWHCODE", DbType.String, dto.Warehouse));
            paramList.Add(CreateInSmartDbParameter("CPOSCODE", DbType.String, dto.Position));
            paramList.Add(CreateInSmartDbParameter("CMPOSCODE", DbType.String, dto.DesPosition));
            paramList.Add(CreateInSmartDbParameter("BARCODE", DbType.String, dto.Barcode));
            paramList.Add(CreateInSmartDbParameter("OPERUSER", DbType.String, dto.OperUser));
            paramList.Add(CreateInSmartDbParameter("QTY", DbType.Int32, dto.Qty));
            paramList.Add(CreateInSmartDbParameter("BDEL", DbType.Int32, dto.DeleteMark==true?1:0));

            return base.ExecuteDataSetByProc("[TEMPSCAN_SAVE]", paramList);
        }
    }
}
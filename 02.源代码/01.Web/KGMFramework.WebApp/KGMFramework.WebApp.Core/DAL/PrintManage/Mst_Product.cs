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
    /// 产品信息表
    /// </summary>
    public class Mst_Product : BaseDALSQL<Mst_ProductInfo>, IMst_Product
    {
        #region 对象实例及构造函数

        public static Mst_Product Instance
        {
            get
            {
                return new Mst_Product();
            }
        }
        public Mst_Product()
            : base("Mst_Product", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Mst_ProductInfo DataReaderToEntity(IDataReader dataReader)
        {
            Mst_ProductInfo info = new Mst_ProductInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            info.F_FullName = reader.GetString("F_FullName");
            info.F_PROTOCOL_ID = reader.GetString("F_PROTOCOL_ID");
            info.F_LABEL_ID = reader.GetString("F_LABEL_ID");
            info.F_VERSION = reader.GetString("F_VERSION");
            info.F_COUNTRY = reader.GetString("F_COUNTRY");
            info.F_CONTENT1 = reader.GetString("F_CONTENT1");
            info.F_CONTENT2 = reader.GetString("F_CONTENT2");
            info.F_CONTENT3 = reader.GetString("F_CONTENT3");
            info.F_CONTENT4 = reader.GetString("F_CONTENT4");
            info.F_CONTENT5 = reader.GetString("F_CONTENT5");
            info.F_CONTENT6 = reader.GetString("F_CONTENT6");
            info.F_CONTENT7 = reader.GetString("F_CONTENT7");
            info.F_CONTENT8 = reader.GetString("F_CONTENT8");
            info.F_CONTENT9 = reader.GetString("F_CONTENT9");
            info.F_CONTENT10 = reader.GetString("F_CONTENT10");
            info.F_CONTENT11 = reader.GetString("F_CONTENT11");
            info.F_CONTENT12 = reader.GetString("F_CONTENT12");
            info.F_CONTENT13 = reader.GetString("F_CONTENT13");
            info.F_CONTENT14 = reader.GetString("F_CONTENT14");
            info.F_CONTENT15 = reader.GetString("F_CONTENT15");
            info.F_CONTENT16 = reader.GetString("F_CONTENT16");
            info.F_CONTENT17 = reader.GetString("F_CONTENT17");
            info.F_CONTENT18 = reader.GetString("F_CONTENT18");
            info.F_CONTENT19 = reader.GetString("F_CONTENT19");
            info.F_CONTENT20 = reader.GetString("F_CONTENT20");
            info.F_CONTENT21 = reader.GetString("F_CONTENT21");
            info.F_CONTENT22 = reader.GetString("F_CONTENT22");
            info.F_CONTENT23 = reader.GetString("F_CONTENT23");
            info.F_CONTENT24 = reader.GetString("F_CONTENT24");
            info.F_CONTENT25 = reader.GetString("F_CONTENT25");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_Description = reader.GetString("F_Description");
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
        protected override Hashtable GetHashByEntity(Mst_ProductInfo obj)
        {
            Mst_ProductInfo info = obj as Mst_ProductInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_EnCode", info.F_EnCode);
            hash.Add("F_FullName", info.F_FullName);
            hash.Add("F_PROTOCOL_ID", info.F_PROTOCOL_ID);
            hash.Add("F_LABEL_ID", info.F_LABEL_ID);
            hash.Add("F_VERSION", info.F_VERSION);
            hash.Add("F_COUNTRY", info.F_COUNTRY);
            hash.Add("F_CONTENT1", info.F_CONTENT1);
            hash.Add("F_CONTENT2", info.F_CONTENT2);
            hash.Add("F_CONTENT3", info.F_CONTENT3);
            hash.Add("F_CONTENT4", info.F_CONTENT4);
            hash.Add("F_CONTENT5", info.F_CONTENT5);
            hash.Add("F_CONTENT6", info.F_CONTENT6);
            hash.Add("F_CONTENT7", info.F_CONTENT7);
            hash.Add("F_CONTENT8", info.F_CONTENT8);
            hash.Add("F_CONTENT9", info.F_CONTENT9);
            hash.Add("F_CONTENT10", info.F_CONTENT10);
            hash.Add("F_CONTENT11", info.F_CONTENT11);
            hash.Add("F_CONTENT12", info.F_CONTENT12);
            hash.Add("F_CONTENT13", info.F_CONTENT13);
            hash.Add("F_CONTENT14", info.F_CONTENT14);
            hash.Add("F_CONTENT15", info.F_CONTENT15);
            hash.Add("F_CONTENT16", info.F_CONTENT16);
            hash.Add("F_CONTENT17", info.F_CONTENT17);
            hash.Add("F_CONTENT18", info.F_CONTENT18);
            hash.Add("F_CONTENT19", info.F_CONTENT19);
            hash.Add("F_CONTENT20", info.F_CONTENT20);
            hash.Add("F_CONTENT21", info.F_CONTENT21);
            hash.Add("F_CONTENT22", info.F_CONTENT22);
            hash.Add("F_CONTENT23", info.F_CONTENT23);
            hash.Add("F_CONTENT24", info.F_CONTENT24);
            hash.Add("F_CONTENT25", info.F_CONTENT25);
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
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "编码");
            dict.Add("F_FullName", "名称");
            dict.Add("FProtocolId", "项目号");
            dict.Add("FLabelId", "标签号");
            dict.Add("FVersion", "版本号");
            dict.Add("FCountry", "语言版本");
            dict.Add("FContent1", "");
            dict.Add("FContent2", "");
            dict.Add("FContent3", "");
            dict.Add("FContent4", "");
            dict.Add("FContent5", "");
            dict.Add("FContent6", "");
            dict.Add("FContent7", "");
            dict.Add("FContent8", "");
            dict.Add("FContent9", "");
            dict.Add("FContent10", "");
            dict.Add("FContent11", "");
            dict.Add("FContent12", "");
            dict.Add("FContent13", "");
            dict.Add("FContent14", "");
            dict.Add("FContent15", "");
            dict.Add("FContent16", "");
            dict.Add("FContent17", "");
            dict.Add("FContent18", "");
            dict.Add("FContent19", "");
            dict.Add("FContent20", "");
            dict.Add("FContent21", "");
            dict.Add("FContent22", "");
            dict.Add("FContent23", "");
            dict.Add("FContent24", "");
            dict.Add("FContent25", "");
            dict.Add("F_SortCode", "排序码");
            dict.Add("F_DeleteMark", "删除标志");
            dict.Add("F_EnabledMark", "有效标志");
            dict.Add("F_Description", "描述");
            dict.Add("F_CreatorTime", "创建时间");
            dict.Add("F_CreatorUserId", "创建用户");
            dict.Add("F_LastModifyTime", "最后修改时间");
            dict.Add("F_LastModifyUserId", "最后修改用户");
            dict.Add("F_DeleteTime", "删除时间");
            dict.Add("F_DeleteUserId", "删除用户");
            #endregion

            return dict;
        }

        public DataSet GetTree()
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            return base.ExecuteDataSetByProc("SYS_TREE", paramList);
        }

        public DataTable GetPrint(string filter)
        {
            string[] arry = filter.Split(',');
            string f = "";
            for (int i = 0; i < arry.Length; i++)
            {
                f += "'" + arry[i].ToString() + "',";
            }
            f = f.Substring(0, f.Length - 1);
            string sql = string.Format("SELECT * FROM Mst_Product WHERE F_Id IN({0})", f);
            return base.ExecuteTable(sql);
        }

        public bool Audit(string F_Id, int state)
        {
            string[] arry = F_Id.Split(',');
            string f = "";
            for (int i = 0; i < arry.Length; i++)
            {
                f += "'" + arry[i].ToString() + "',";
            }
            f = f.Substring(0, f.Length - 1);
            string sql = string.Format("UPDATE Mst_Product SET F_EnabledMark={0} WHERE F_Id IN({1})", state, f);
            return base.ExecuteNonQuery(sql);
        }

        public bool DataRecovery(string F_Id)
        {
            string sql = "UPDATE Mst_Product SET F_DeleteMark=0 WHERE F_Id=@F_Id";
            Hashtable hash = new Hashtable();
            hash.Add("F_Id", F_Id);
            return base.ExecuteNonQuery(sql, hash);
        }

    }
}
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
using System.Data.SqlClient;
using System.Data.SQLite;

namespace KGMFramework.WebApp.DALSQL
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Sys_User : BaseDALSQL<Sys_UserInfo>, ISys_User
    {
        #region 对象实例及构造函数

        public static Sys_User Instance
        {
            get
            {
                return new Sys_User();
            }
        }
        public Sys_User()
            : base("Sys_User", "F_Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_UserInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_UserInfo info = new Sys_UserInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_Id = reader.GetString("F_Id");
            info.F_WarehouseId = reader.GetString("F_WarehouseId");
            info.F_Account = reader.GetString("F_Account");
            info.F_UserPassword = reader.GetString("F_UserPassword");
            info.F_RealName = reader.GetString("F_RealName");
            info.F_NickName = reader.GetString("F_NickName");
            info.F_HeadIcon = reader.GetString("F_HeadIcon");
            info.F_Gender = reader.GetBooleanNullable("F_Gender");
            info.F_Birthday = reader.GetDateTimeNullable("F_Birthday");
            info.F_MobilePhone = reader.GetString("F_MobilePhone");
            info.F_Email = reader.GetString("F_Email");
            info.F_WeChat = reader.GetString("F_WeChat");
            info.F_ManagerId = reader.GetString("F_ManagerId");
            info.F_SecurityLevel = reader.GetInt32Nullable("F_SecurityLevel");
            info.F_Signature = reader.GetString("F_Signature");
            info.F_OrganizeId = reader.GetString("F_OrganizeId");
            info.F_DepartmentId = reader.GetString("F_DepartmentId");
            info.F_RoleId = reader.GetString("F_RoleId");
            info.F_DutyId = reader.GetString("F_DutyId");
            info.F_IsAdministrator = reader.GetBooleanNullable("F_IsAdministrator");
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
        protected override Hashtable GetHashByEntity(Sys_UserInfo obj)
        {
            Sys_UserInfo info = obj as Sys_UserInfo;
            Hashtable hash = new Hashtable();

            hash.Add("F_Id", info.F_Id);
            hash.Add("F_Account", info.F_Account);
            hash.Add("F_UserPassword", info.F_UserPassword);
            hash.Add("F_RealName", info.F_RealName);
            hash.Add("F_NickName", info.F_NickName);
            hash.Add("F_HeadIcon", info.F_HeadIcon);
            hash.Add("F_Gender", info.F_Gender);
            hash.Add("F_Birthday", info.F_Birthday);
            hash.Add("F_MobilePhone", info.F_MobilePhone);
            hash.Add("F_Email", info.F_Email);
            hash.Add("F_WeChat", info.F_WeChat);
            hash.Add("F_ManagerId", info.F_ManagerId);
            hash.Add("F_SecurityLevel", info.F_SecurityLevel);
            hash.Add("F_Signature", info.F_Signature);
            hash.Add("F_OrganizeId", info.F_OrganizeId);
            hash.Add("F_DepartmentId", info.F_DepartmentId);
            hash.Add("F_RoleId", info.F_RoleId);
            hash.Add("F_DutyId", info.F_DutyId);
            hash.Add("F_IsAdministrator", info.F_IsAdministrator);
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
            hash.Add("F_WarehouseId", info.F_WarehouseId);
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
            dict.Add("F_Id", "用户主键");
            dict.Add("F_Account", "账户");
            dict.Add("F_RealName", "姓名");
            dict.Add("F_NickName", "呢称");
            dict.Add("F_HeadIcon", "头像");
            dict.Add("F_Gender", "性别");
            dict.Add("F_Birthday", "生日");
            dict.Add("F_MobilePhone", "手机");
            dict.Add("F_Email", "邮箱");
            dict.Add("F_WeChat", "微信");
            dict.Add("F_ManagerId", "主管主键");
            dict.Add("F_SecurityLevel", "安全级别");
            dict.Add("F_Signature", "个性签名");
            dict.Add("F_OrganizeId", "组织主键");
            dict.Add("F_DepartmentId", "部门主键");
            dict.Add("F_RoleId", "角色主键");
            dict.Add("F_DutyId", "岗位主键");
            dict.Add("F_IsAdministrator", "是否管理员");
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

        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet LoginSystem(LoginModel model)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ACCOUNT", DbType.String, model.Account));
            paramList.Add(CreateInSmartDbParameter("PASSWORD", DbType.String, model.Password));
            paramList.Add(CreateInSmartDbParameter("IPADDRESS", DbType.String, model.IPAddress));
            paramList.Add(CreateInSmartDbParameter("IPADDRESSNAME", DbType.String, model.IPAddressName));
            paramList.Add(CreateInSmartDbParameter("LOGINSYSTEM", DbType.String, model.LoginSystem));

            return base.ExecuteDataSetByProc("[SYS_LOGINSYSTEM]", paramList);
        }

        /// <summary>
        /// 变更部门
        /// </summary>
        /// <param name="user"></param>
        /// <param name="deptId"></param>
        /// <param name="dt"></param>
        public void ChangeDepartment(string user, string deptId, DataTable dt)
        {
            SqlParameter[] paramList = new SqlParameter[] { 
                new SqlParameter("@USER",user),
                new SqlParameter("@DEPTID",deptId),
                new SqlParameter("@PARM_USER_CHAGNEDEPARTMENT",dt)
            };
            base.ExecuteNonQueryByProc("[USER_CHAGNEDEPARTMENT]", paramList);
        }

        #region api
        public DataSet GetSingleTableInfo(string tableName, string valueMember, string displayMember, string filedName, string where, string dbName, bool bDistinct, string sortFiled)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@TABLE",tableName),
                new SqlParameter("@VALUEMENBER",valueMember),
                new SqlParameter("@DISPLAYMENBER",displayMember),
                new SqlParameter("@FILEDNAME",filedName),
                new SqlParameter("@WHERE",where),
                new SqlParameter("@DBNAME",dbName),
                new SqlParameter("@BDISTINCT",bDistinct),
                new SqlParameter("@SORTFILED",sortFiled),
            };

            return base.ExecuteDataSetByProc("[KGM_GETSINGLETABLEINFO]", parm);
        }

        public DataSet BarcodeAnalyze(string OPERORDER, string BARCODE, string DBNAME)
        {
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@OPERORDER",OPERORDER),
                new SqlParameter("@BARCODE",BARCODE),
                new SqlParameter("@DBNAME",DBNAME),  
                new SqlParameter("@BSHOWLIST",true), 
            };

            return base.ExecuteDataSetByProc("[BARCODE_ANALYZE]", parms);
        }

        public DataSet GetVouchModel(string condition)
        {
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@CONDITION",condition)
             };
            return base.ExecuteDataSetByProc("[VOUCH_GETMODEL]", parms);
        }

        public DataSet GetFeedingTips(string orderNo)
        {
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@ORDERNO",orderNo)
            };

            return base.ExecuteDataSetByProc("[REPORT_GETFEEDINGTIPS]", parms);
        }

        public DataSet GetTempScanHead(string condition)
        {
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@CONDITION",condition)
             };

            return base.ExecuteDataSetByProc("[TEMPSCAN_GETHEAD]", parms);

        }

        public DataSet SaveTempScanHead(DataRow dr,string userid)
        {
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@OPERORDER",dr["OPERORDER"]),
                new SqlParameter("@CVOUCHID",dr["CVOUCHID"]),
                new SqlParameter("@CSOURCECODE",dr["CSOURCECODE"]),
                new SqlParameter("@CWHCODE",dr["CWHCODE"]),
                new SqlParameter("@CTVWHCODE",dr["CTVWHCODE"]),
                new SqlParameter("@CRDTYPE",dr["CRDCODE"]),
                new SqlParameter("@CTVRDTYPE",dr["CTVRDCODE"]),
                new SqlParameter("@CDEPCODE",dr["CDEPCODE"]),
                new SqlParameter("@CTVDEPCODE",dr["CTVDEPCODE"]),
                new SqlParameter("@CMAKER",userid),
                new SqlParameter("@DDATE",dr["DDATE"]),
                new SqlParameter("@CDEFINE1",dr["CDEFINE1"]),
                new SqlParameter("@CDEFINE2",dr["CDEFINE2"]),
                new SqlParameter("@CDEFINE3",dr["CDEFINE3"]),
                new SqlParameter("@CDEFINE4",dr["CDEFINE4"]),
                new SqlParameter("@CDEFINE5",dr["CDEFINE5"]),
                new SqlParameter("@CDEFINE6",dr["CDEFINE6"]),
                new SqlParameter("@CDEFINE7",dr["CDEFINE7"]),
                new SqlParameter("@CDEFINE8",dr["CDEFINE8"]),
                new SqlParameter("@CDEFINE9",dr["CDEFINE9"]),
                new SqlParameter("@CDEFINE10",dr["CDEFINE10"]),
                new SqlParameter("@CDEFINE11",dr["CDEFINE11"]),
                new SqlParameter("@CDEFINE12",dr["CDEFINE12"]),
                new SqlParameter("@CDEFINE13",dr["CDEFINE13"]),
                new SqlParameter("@CDEFINE14",dr["CDEFINE14"]),
                new SqlParameter("@CDEFINE15",dr["CDEFINE15"]),
                new SqlParameter("@CDEFINE16",dr["CDEFINE16"]),
             };

            return base.ExecuteDataSetByProc("[TEMPSCAN_SAVEHEAD]", parms);

        }


        public DataSet SaveTempScanBody(DataRow dr, bool bDel, string OPERORDER, string CVOUCHID, string CWHCODE, string userid, string baseName)
        {
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@OPERORDER",OPERORDER),
                new SqlParameter("@CVOUCHID",CVOUCHID),
                new SqlParameter("@BARCODE",dr["BARCODE"]),
                new SqlParameter("@CWHCODE",CWHCODE),
                new SqlParameter("@CPOSCODE",dr["CPOSCODE"]),
                new SqlParameter("@CMPPOSCODE",dr["CMPPOSCODE"]),
                new SqlParameter("@QTY",dr["QTY"]),
                new SqlParameter("@OPERUSER",userid),
                new SqlParameter("@BDEL",bDel),
                new SqlParameter("@CDEFINE1",dr["CDEFINE1"]),
                new SqlParameter("@CDEFINE2",dr["CDEFINE2"]),
                new SqlParameter("@CDEFINE3",dr["CDEFINE3"]),
                new SqlParameter("@CDEFINE4",dr["CDEFINE4"]),
                new SqlParameter("@CDEFINE5",dr["CDEFINE5"]),
                new SqlParameter("@CDEFINE6",dr["CDEFINE6"]),
                new SqlParameter("@CDEFINE7",dr["CDEFINE7"]),
                new SqlParameter("@CDEFINE8",dr["CDEFINE8"]),
                new SqlParameter("@CDEFINE9",dr["CDEFINE9"]),
                new SqlParameter("@CDEFINE10",dr["CDEFINE10"]),
                new SqlParameter("@CDEFINE11",dr["CDEFINE11"]),
                new SqlParameter("@CDEFINE12",dr["CDEFINE12"]),
                new SqlParameter("@CDEFINE13",dr["CDEFINE13"]),
                new SqlParameter("@CDEFINE14",dr["CDEFINE14"]),
                new SqlParameter("@CDEFINE15",dr["CDEFINE15"]),
                new SqlParameter("@CDEFINE16",dr["CDEFINE16"]),
                new SqlParameter("@DBNAME",baseName),
             };

            return base.ExecuteDataSetByProc("[TEMPSCAN_SAVEBODY]", parms);

        }

        public DataSet GetScanInfo(string operOrder)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@OPERORDER",operOrder)
            };
            return base.ExecuteDataSetByProc("[TEMPSCAN_GETBODY]", parm);
        }

        public DataSet bFIFO(string BARCODE, string operOrder, string baseName, string CWHCODE)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@OPERORDER",operOrder),
                new SqlParameter("@DBNAME",baseName),
                new SqlParameter("@CWHCODE",CWHCODE),
                new SqlParameter("@BARCODE",BARCODE),
            };
            return base.ExecuteDataSetByProc("[SWITCH_FIFO]", parm);
        }

        public DataSet GetScanCY(string operOrder)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@OPERORDER",operOrder)
            };
            return base.ExecuteDataSetByProc("[TEMPSCAN_GETCYLIST]", parm);
        }

        public object ScanFinish(string operOrder, string baseName)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@OPERORDER",operOrder),
                new SqlParameter("@DBNAME",baseName)
            };
            return base.ExecuteScalar("[TEMPSCAN_FINISH]", parm);
        }

        public void ClearTempScan(string operOrder)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@OPERORDER",operOrder),
            };

            string sql = "DELETE FROM TEMPSCAN_HEAD WHERE OPERORDER = @OPERORDER ";
            base.ExecuteNonQuery(sql, parm);
            sql = "DELETE FROM TEMPSCAN_SOURCEORDER WHERE OPERORDER = @OPERORDER ";
            base.ExecuteNonQuery(sql, parm);
            sql = "DELETE FROM TEMPSCAN_BODY WHERE OPERORDER = @OPERORDER ";
            base.ExecuteNonQuery(sql, parm);

        }

        public void ConnectDataBase(string DatabaseConnString)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = DatabaseConnString;
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public void ConnectDataBaseU8(string u8DatabaseConnString)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = u8DatabaseConnString;
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }


        public void ConnectSqlite(string Sqlitestr)
        {
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn.ConnectionString = Sqlitestr;
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public DateTime GetServerTime()
        {
            try
            {
                string procName = "Kgm_GetServerTime";
                SqlParameter[] parm = new SqlParameter[] { };
                DataSet ds = base.ExecuteDataSetByProc(procName, parm);

                return Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public DataSet GetLoginUserModule(string userid,string ADMINNAME,string userpwd,string ADMINPWD)
        {
            bool bAdmin = false;
            if (userid == ADMINNAME && userpwd == ADMINPWD)
            {
                bAdmin = true;
            }
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@userID",userid),
                new SqlParameter("@bAdmin",bAdmin),
                new SqlParameter("@moduleFlag","子系统")
            };
            return base.ExecuteDataSetByProc("[KGM_GETUSERMOUDEL]", parm);
        }

        public string GetTermUIVerson()
        {
            //获取当前版本
            string sql = "SELECT VERSION FROM SYS_UIVERSION";
            object myVersion = base.ExecuteScalar(sql);
            if (myVersion == null || myVersion.ToString() == string.Empty)
            {
                return "-1";
            }

            return myVersion.ToString();
        }

        public DataSet GetUIUpdate(string myVersion)
        {
            //获取数据库最新UI版本
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@UITYPE",1),
                new SqlParameter("@VERSION",myVersion),
            };
            return base.ExecuteDataSetByProc("[UI_GETDOWNLOAD]", parm);
        }

        public void SyncUI(DataSet ds, string myVersion, string connectionString)
        {
            //更新当前UI信息 在一个事务中进行
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            SQLiteTransaction tx = null;
            SQLiteCommand cmd = null;
            try
            {
                conn.Open();
                tx = conn.BeginTransaction();

                cmd = conn.CreateCommand();
                cmd.Transaction = tx;

                #region 更新当前版本号
                cmd.CommandType = CommandType.Text;
                if (myVersion == "-1")
                {
                    cmd.CommandText = "INSERT INTO SYS_UIVERSION(VERSION) VALUES (@VERSION) ";
                }
                else
                {
                    cmd.CommandText = "UPDATE SYS_UIVERSION SET VERSION = @VERSION";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SQLiteParameter("@VERSION", ds.Tables[0].Rows[0][0]));
                cmd.ExecuteNonQuery();
                #endregion

                #region 下载列信息
                //全删除
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM KGM_COLUMN";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();

                //循环添加信息
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO KGM_COLUMN(ID,FORMNAME,GRIDNAME,ORDERTYPE,CVOUCHID,COLTITLE,COLMAPPING,COLWIDTH,COLINDEX,CUSTOMEREDIT,CONTROLEDIT,TEXTAGLIN,EDITMODE,BEDIT)
                                        VALUES (@ID,@FORMNAME,@GRIDNAME,@ORDERTYPE,@CVOUCHID,@COLTITLE,@COLMAPPING,@COLWIDTH,@COLINDEX,@CUSTOMEREDIT,@CONTROLEDIT,@TEXTAGLIN,@EDITMODE,@BEDIT)";

                    SQLiteParameter[] parameters = 
                    {
                            new SQLiteParameter("@ID", Guid.NewGuid().ToString()),
                            new SQLiteParameter("@FORMNAME", dr["FORMNAME"]),
                            new SQLiteParameter("@GRIDNAME",  dr["GRIDNAME"]),
                            new SQLiteParameter("@ORDERTYPE",  dr["ORDERTYPE"]),
                            new SQLiteParameter("@CVOUCHID",  dr["CVOUCHID"]),
                            new SQLiteParameter("@COLTITLE",  dr["COLTITLE"]),
                            new SQLiteParameter("@COLMAPPING",  dr["COLMAPPING"]),
                            new SQLiteParameter("@COLWIDTH",  dr["COLWIDTH"]),
                            new SQLiteParameter("@COLINDEX",  dr["COLINDEX"]),
                            new SQLiteParameter("@CUSTOMEREDIT",  dr["CUSTOMEREDIT"]),
                            new SQLiteParameter("@CONTROLEDIT",  dr["CONTROLEDIT"]),
                            new SQLiteParameter("@TEXTAGLIN",  dr["TEXTAGLIN"]),
                            new SQLiteParameter("@EDITMODE",  dr["EDITMODEL"]),
                            new SQLiteParameter("@BEDIT",  dr["BEDIT"]),
                    };

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }

                #endregion

                #region 下载行信息
                //全删除
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM KGM_ROW";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();

                //循环添加信息
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO KGM_ROW(ID,FORMNAME,GRIDNAME,ORDERTYPE,CVOUCHID,ROWTITLE,ROWMAPPINGVALUE,
                                            ROWMAPPINGTEXT,ROWSHINETABLE,ROWSHINEVALUE,ROWSHINETEXT,ROWFILTER,BOUTTABLE,VALUEMEMBER,
                                            DISPLAYMEMBER,CUSTOMEREDIT,CONTROLEDIT,EDITMODE,BMINUS,MAXVALUE,MINVALUE,NUMDIG,BEDIT,
                                            BDOCUMENT,BNOTNULL,ROWINDEX,TEXTAGLIN)
                                        VALUES(@ID,@FORMNAME,@GRIDNAME,@ORDERTYPE,@CVOUCHID,@ROWTITLE,@ROWMAPPINGVALUE,@ROWMAPPINGTEXT,
                                            @ROWSHINETABLE,@ROWSHINEVALUE,@ROWSHINETEXT,@ROWFILTER,@BOUTTABLE,@VALUEMEMBER,@DISPLAYMEMBER,
                                            @CUSTOMEREDIT,@CONTROLEDIT,@EDITMODE,@BMINUS,@MAXVALUE,@MINVALUE,@NUMDIG,@BEDIT,@BDOCUMENT,
                                            @BNOTNULL,@ROWINDEX,@TEXTAGLIN)";

                    SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", Guid.NewGuid().ToString()),
					new SQLiteParameter("@FORMNAME", dr["FORMNAME"]),
                    new SQLiteParameter("@GRIDNAME",  dr["GRIDNAME"]),
                    new SQLiteParameter("@ORDERTYPE",  dr["ORDERTYPE"]),
                    new SQLiteParameter("@CVOUCHID",  dr["CVOUCHID"]),
					new SQLiteParameter("@ROWTITLE", dr["ROWTITLE"]),
					new SQLiteParameter("@ROWMAPPINGVALUE", dr["ROWMAPPINGVALUE"]),
					new SQLiteParameter("@ROWMAPPINGTEXT", dr["ROWMAPPINGTEXT"]),
					new SQLiteParameter("@ROWSHINETABLE", dr["ROWSHINETABLE"]),
					new SQLiteParameter("@ROWSHINEVALUE", dr["ROWSHINEVALUE"]),
					new SQLiteParameter("@ROWSHINETEXT", dr["ROWSHINETEXT"]),
					new SQLiteParameter("@ROWFILTER", dr["ROWFILTER"]),
					new SQLiteParameter("@BOUTTABLE", dr["BOUTTABLE"]),
					new SQLiteParameter("@VALUEMEMBER", dr["VALUEMEMBER"]),
					new SQLiteParameter("@DISPLAYMEMBER", dr["DISPLAYMEMBER"]),
					new SQLiteParameter("@CUSTOMEREDIT", dr["CUSTOMEREDIT"]),
					new SQLiteParameter("@CONTROLEDIT", dr["CONTROLEDIT"]),
					new SQLiteParameter("@EDITMODE", dr["EDITMODEL"]),
					new SQLiteParameter("@BMINUS", dr["BMINUS"]),
					new SQLiteParameter("@MAXVALUE", dr["MAXVALUE"]),
					new SQLiteParameter("@MINVALUE", dr["MINVALUE"]),
					new SQLiteParameter("@NUMDIG", dr["NUMDIG"]),
					new SQLiteParameter("@BEDIT", dr["BEDIT"]),
					new SQLiteParameter("@BDOCUMENT", dr["BDOCUMENT"]),
					new SQLiteParameter("@BNOTNULL", dr["BNOTNULL"]),
					new SQLiteParameter("@ROWINDEX", dr["ROWINDEX"]),
					new SQLiteParameter("@TEXTAGLIN", dr["TEXTAGLIN"])};

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }

                #endregion

                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Clone();
                    conn.Dispose();
                }
            }
        }


        public DataSet GetGridColumn(string formName, string gridName, string orderType, string cVouchID)
        {
            string sql = "SELECT * FROM KGM_COLUMN WHERE FORMNAME = @FORMNAME AND GRIDNAME = @GRIDNAME AND ORDERTYPE = @ORDERTYPE AND CVOUCHID = @CVOUCHID ORDER BY COLINDEX";

            SQLiteParameter[] parm = new SQLiteParameter[]{
                new SQLiteParameter("@FORMNAME",formName == null ?"":formName),
                new SQLiteParameter("@GRIDNAME",gridName == null ?"":gridName),
                new SQLiteParameter("@ORDERTYPE",orderType == null ?"":orderType),
                new SQLiteParameter("@CVOUCHID",cVouchID == null ?"":cVouchID),
            };

            return base.ExecuteDataSetByProc(sql, parm);
        }

        public DataSet GetGridRow(string formName, string gridName, string orderType, string cVouchID)
        {
            string sql = "SELECT * FROM KGM_ROW WHERE FORMNAME = @FORMNAME AND GRIDNAME = @GRIDNAME AND ORDERTYPE = @ORDERTYPE AND CVOUCHID = @CVOUCHID  ORDER BY ROWINDEX ";

            SQLiteParameter[] parm = new SQLiteParameter[]{
                new SQLiteParameter("@FORMNAME",formName == null ?"":formName),
                new SQLiteParameter("@GRIDNAME",gridName == null ?"":gridName),
                new SQLiteParameter("@ORDERTYPE",orderType == null ?"":orderType),
                new SQLiteParameter("@CVOUCHID",cVouchID == null ?"":cVouchID),
            };
            return base.ExecuteDataSetByProc(sql, parm);
        }


        public bool Login(string userID, string userPwd, out string errorInfo, string DatabaseConnString)
        {
            SqlConnection conn = new SqlConnection(DatabaseConnString);
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[KGM_LOGIN]";
                cmd.CommandTimeout = 300000;
                SqlParameter[] para = new SqlParameter[4];
                para[0] = new SqlParameter();
                para[0].ParameterName = "@USERID";
                para[0].Value = userID;

                para[1] = new SqlParameter();
                para[1].ParameterName = "@USERPWD";
                para[1].Value = userPwd;

                para[2] = new SqlParameter();
                para[2].ParameterName = "@BSUCCESS";
                para[2].SqlDbType = SqlDbType.Bit;
                para[2].Direction = ParameterDirection.Output;

                para[3] = new SqlParameter();
                para[3].ParameterName = "@ERRORINFO";
                para[3].SqlDbType = SqlDbType.NVarChar;
                para[3].Size = 500;
                para[3].Direction = ParameterDirection.Output;

                foreach (SqlParameter spara in para)
                {
                    cmd.Parameters.Add(spara);
                }

                cmd.CommandTimeout = 30000;
                cmd.ExecuteNonQuery();
                errorInfo = Convert.IsDBNull(cmd.Parameters["@ERRORINFO"].Value) == true ? "" : cmd.Parameters["@ERRORINFO"].Value.ToString();
                return Convert.IsDBNull(cmd.Parameters["@BSUCCESS"].Value) == true ? false : Convert.ToBoolean(cmd.Parameters["@BSUCCESS"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public DataSet GetTrayInfo(string trayNo, bool bGetHead, bool bGetBody, string U8DatabaseName)
        {
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@TRAYNO",trayNo),
                new SqlParameter("@BGETHEAD",bGetHead),
                new SqlParameter("@BGETBODY",bGetBody),
                new SqlParameter("@DBNAME",U8DatabaseName)
            };

            return base.ExecuteDataSetByProc("[TRAY_GETINFO]", parm);
        }

        public void SaveTrayHead(string trayNo)
        {
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@TRAYNO",trayNo),
            };

            base.ExecuteNonQuery("[TRAY_SAVEHEAD]", parm);
        }

        public Result SaveTrayBody(string trayNo, string barcode, string qty, string iNum, bool bInTray, DataRow dr, string BarcodeDatabaseName, string BarcodeDatabaseConnString)
        {
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@TRAYNO",trayNo),
                new SqlParameter("@BARCODE",barcode),//条码
                new SqlParameter("@CINVCODE",dr["CINVCODE"]),//存货
                new SqlParameter("@CBATCH",dr["CBATCH"]),//批次
                new SqlParameter("@QTY",qty),//数量
                new SqlParameter("@INUM",iNum),//换算率
                new SqlParameter("@CASSUNIT",dr["CINVAUNIT"]),//副计量单位编码
                new SqlParameter("@IMASSDATE",dr["IMASSDATE"]),//保质期天数
                new SqlParameter("@CMASSUNIT",dr["CMASSUNIT"]),//保质期单位
                new SqlParameter("@DMDATE",dr["DMADEDATE"]),//生产日期
                new SqlParameter("@DVDATE",dr["DVDATE"]),//失效日期
                new SqlParameter("@IEXPIRATDATECALCU",""),//dr["IEXPIRATDATECALCU"]),//有效期推算方式
                new SqlParameter("@DEXPIRATIONDATE",Convert.DBNull),//dr["DEXPIRATIONDATE"]),//有效期计算项
                new SqlParameter("@CEXPIRATIONDATE",Convert.DBNull),//dr["CEXPIRATIONDATE"]),//有效期至
                new SqlParameter("@SNNO",dr["FLOWNO"]),//序列号
                new SqlParameter("@CVMIVENCODE",""),//dr["CVMIVENCODE"]),//代管商编码
                new SqlParameter("@CITEM_CLASS",""),//项目大类编码
                new SqlParameter("@CITEMCNAME",""),//项目大类名称
                new SqlParameter("@CITEMCODE",""),//项目编码  
                new SqlParameter("@CNAME",""),//项目名称
                new SqlParameter("@CFREE1",""),//dr["CFREE1"].ToString()),//自由项1
                new SqlParameter("@CFREE2",""),//dr["CFREE2"].ToString()),//自由项2
                new SqlParameter("@CFREE3",""),//dr["CFREE3"].ToString()),//自由项3
                new SqlParameter("@CFREE4",""),//dr["CFREE4"].ToString()),//自由项4
                new SqlParameter("@CFREE5",""),//dr["CFREE5"].ToString()),//自由项5
                new SqlParameter("@CFREE6",""),//dr["CFREE6"].ToString()),//自由项6
                new SqlParameter("@CFREE7",""),//dr["CFREE7"].ToString()),//自由项7
                new SqlParameter("@CFREE8",""),//dr["CFREE8"].ToString()),//自由项8
                new SqlParameter("@CFREE9",""),//dr["CFREE9"].ToString()),//自由项9
                new SqlParameter("@CFREE10",""),//dr["CFREE10"].ToString()),//自由项10
                new SqlParameter("@CDEFINE22",""),//表体自定义项22
                new SqlParameter("@CDEFINE23",""),//表体自定义项23
                new SqlParameter("@CDEFINE24",""),//表体自定义项24
                new SqlParameter("@CDEFINE25",""),//表体自定义项25
                new SqlParameter("@CDEFINE26",""),//表体自定义项26
                new SqlParameter("@CDEFINE27",""),//表体自定义项27 
                new SqlParameter("@CDEFINE28",""),//表体自定义项28
                new SqlParameter("@CDEFINE29",""),//表体自定义项29
                new SqlParameter("@CDEFINE30",""),//表体自定义项30
                new SqlParameter("@CDEFINE31",""),//表体自定义项31
                new SqlParameter("@CDEFINE32",""),//表体自定义项32
                new SqlParameter("@CDEFINE33",""),//表体自定义项33
                new SqlParameter("@CDEFINE34",""),//表体自定义项34
                new SqlParameter("@CDEFINE35",""),//表体自定义项35
                new SqlParameter("@CDEFINE36",""),//表体自定义项36
                new SqlParameter("@CDEFINE37",""),//表体自定义项37
                new SqlParameter("@CBATCHPROPERTY1",Convert.DBNull),// dr["CBATCHPROPERTY1"]),//批次属性1
                new SqlParameter("@CBATCHPROPERTY2",Convert.DBNull),//dr["CBATCHPROPERTY2"]),//批次属性2
                new SqlParameter("@CBATCHPROPERTY3",Convert.DBNull),//dr["CBATCHPROPERTY3"]),//批次属性3
                new SqlParameter("@CBATCHPROPERTY4",Convert.DBNull),//dr["CBATCHPROPERTY4"]),//批次属性4
                new SqlParameter("@CBATCHPROPERTY5",Convert.DBNull),//dr["CBATCHPROPERTY5"]),//批次属性5
                new SqlParameter("@CBATCHPROPERTY6",Convert.DBNull),//dr["CBATCHPROPERTY6"]),//批次属性6
                new SqlParameter("@CBATCHPROPERTY7",Convert.DBNull),//dr["CBATCHPROPERTY7"]),//批次属性7
                new SqlParameter("@CBATCHPROPERTY8",Convert.DBNull),//dr["CBATCHPROPERTY8"]),//批次属性8
                new SqlParameter("@CBATCHPROPERTY9",Convert.DBNull),//dr["CBATCHPROPERTY9"]),//批次属性9
                new SqlParameter("@CBATCHPROPERTY10",Convert.DBNull),//dr["CBATCHPROPERTY10"]),//批次属性10
                new SqlParameter("@ITRACKID",Convert.DBNull),//dr["ITRACKID"]),//对应入库单ID
                new SqlParameter("@ITRACKTYPE",""),//dr["ITRACKTYPE"]),//对应入库单类型
                new SqlParameter("@ISOTYPE",Convert.DBNull),//dr["ISOTYPE"]),//SOTYPE
                new SqlParameter("@ISODID",""),//dr["ISODID"]),//SODID
                new SqlParameter("@CSOCODE",""),//dr["CSOCODE"]),//CSOCODE
                new SqlParameter("@MOID",string.Empty),//MOID
                new SqlParameter("@MODID",string.Empty),//MODID
                new SqlParameter("@BINTRAY",bInTray),
                new SqlParameter("@DBNAME",BarcodeDatabaseName),
            };


            using (SqlConnection conn = new SqlConnection(BarcodeDatabaseConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "TRAY_SAVEBODY";
                cmd.CommandType = CommandType.StoredProcedure;

                #region 赋参数
                foreach (SqlParameter spara in parm)
                {
                    cmd.Parameters.Add(spara);
                }
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter();
                para[0].ParameterName = "@RETURNVALUE";
                para[0].Size = 4;
                para[0].Direction = ParameterDirection.Output;

                para[1] = new SqlParameter();
                para[1].ParameterName = "@RETURNTEXT";
                para[1].Size = 100;
                para[1].Direction = ParameterDirection.Output;

                foreach (SqlParameter spara in para)
                {
                    cmd.Parameters.Add(spara);
                }
                #endregion

                cmd.CommandTimeout = 300000;
                cmd.ExecuteNonQuery();

                int returnValue = Convert.IsDBNull(cmd.Parameters["@RETURNVALUE"].Value) == true ? 0 : int.Parse(cmd.Parameters["@RETURNVALUE"].Value.ToString());
                string returnText = Convert.IsDBNull(cmd.Parameters["@RETURNTEXT"].Value) == true ? "" : cmd.Parameters["@RETURNTEXT"].Value.ToString();

                Result result = new Result();
                result.resultValue = returnValue;
                result.resultText = returnText;

                return result;
            }
        }


        public void TrayFinish(string trayNo)
        {
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@TRAYNO",trayNo),
            };

            base.ExecuteDataSetByProc("[TRAY_FINISH]", parm);
        }

        public void TrayClear(string trayNo)
        {
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@TRAYNO",trayNo),
            };

            base.ExecuteDataSetByProc("[TRAY_CLEAR]", parm);
        }
        #endregion
    }
}
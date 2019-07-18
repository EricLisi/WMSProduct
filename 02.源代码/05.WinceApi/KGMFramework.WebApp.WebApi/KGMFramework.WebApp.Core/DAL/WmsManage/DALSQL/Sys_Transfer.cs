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
    /// 货位表
    /// </summary>
    public class Sys_Transfer : BaseDALSQL<Sys_TransferInfo>, ISys_Transfer
	{
		#region 对象实例及构造函数

        public static Sys_Transfer Instance
		{
			get
			{
                return new Sys_Transfer();
			}
		}
        public Sys_Transfer()
            : base("Sys_Transfer", "F_Id")
		{
		}

		#endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Sys_TransferInfo DataReaderToEntity(IDataReader dataReader)
        {
            Sys_TransferInfo info = new Sys_TransferInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.F_StockId = reader.GetString("F_StockId");
            info.F_GoodsId = reader.GetString("F_GoodsId");
            info.F_GoodsName = reader.GetString("F_GoodsName");
            info.F_CargoPositionName = reader.GetString("F_CargoPositionName");
            info.F_WarehouseName = reader.GetString("F_WarehouseName");
            info.F_Number = reader.GetString("F_Number");
            info.F_TransferNum = reader.GetString("F_TransferNum");
            info.F_TransferCargo = reader.GetString("F_TransferCargo");
            info.F_TransferWarHouse = reader.GetString("F_TransferWarHouse");
            info.F_TransferCargoId = reader.GetString("F_TransferCargoId");
            info.F_TransferWarHouseId = reader.GetString("F_TransferWarHouseId");

            info.F_Id = reader.GetString("F_Id");
            info.F_EnCode = reader.GetString("F_EnCode");
            //info.F_FullName = reader.GetString("F_FullName");
            info.F_SortCode = reader.GetInt32("F_SortCode");
            info.F_DeleteMark = reader.GetBoolean("F_DeleteMark");
            info.F_EnabledMark = reader.GetBoolean("F_EnabledMark");
            info.F_CreatorTime = reader.GetDateTime("F_CreatorTime");
            info.F_CreatorUserId = reader.GetString("F_CreatorUserId");
            info.F_LastModifyUserId = reader.GetString("F_LastModifyUserId");
            info.F_LastModifyTime = reader.GetDateTime("F_LastModifyTime");
            info.F_DeleteTime = reader.GetDateTime("F_DeleteTime");
            info.F_DeleteUserId = reader.GetString("F_DeleteUserId");
            info.F_FreeTerm1 = reader.GetString("F_FreeTerm1");
            info.F_FreeTerm2 = reader.GetString("F_FreeTerm2");
            info.F_FreeTerm3 = reader.GetString("F_FreeTerm3");
            info.F_FreeTerm4 = reader.GetString("F_FreeTerm4"); 
            info.F_FreeTerm5 = reader.GetString("F_FreeTerm5");
            info.F_FreeTerm6 = reader.GetString("F_FreeTerm6");
            info.F_FreeTerm7 = reader.GetString("F_FreeTerm7");
            info.F_FreeTerm8 = reader.GetString("F_FreeTerm8");
            info.F_FreeTerm9 = reader.GetString("F_FreeTerm9");
            info.F_FreeTerm10 = reader.GetString("F_FreeTerm10");
            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Sys_TransferInfo obj)
        {
            Sys_TransferInfo info = obj as Sys_TransferInfo;
            Hashtable hash = new Hashtable();
            hash.Add("F_StockId", info.F_StockId);
            hash.Add("F_GoodsId", info.F_GoodsId);
            hash.Add("F_TransferCargoId", info.F_TransferCargoId);
            hash.Add("F_TransferWarHouseId", info.F_TransferWarHouseId);
            hash.Add("F_TransferWarHouse", info.F_TransferWarHouse);
            hash.Add("F_TransferCargo", info.F_TransferCargo);
            hash.Add("F_TransferNum", info.F_TransferNum);
            hash.Add("F_Number", info.F_Number);
            hash.Add("F_WarehouseName", info.F_WarehouseName);
            hash.Add("F_CargoPositionName", info.F_CargoPositionName);
            hash.Add("F_GoodsName", info.F_GoodsName);
            hash.Add("F_Id", info.F_Id);
            hash.Add("F_FreeTerm1", info.F_FreeTerm1);
            hash.Add("F_FreeTerm2", info.F_FreeTerm2);
            hash.Add("F_FreeTerm3", info.F_FreeTerm3);
            hash.Add("F_FreeTerm4", info.F_FreeTerm4);
            hash.Add("F_FreeTerm5", info.F_FreeTerm5);
            hash.Add("F_FreeTerm6", info.F_FreeTerm6);
            hash.Add("F_FreeTerm7", info.F_FreeTerm7);
            hash.Add("F_FreeTerm8", info.F_FreeTerm8);
            hash.Add("F_FreeTerm9", info.F_FreeTerm9);
            hash.Add("F_FreeTerm10", info.F_FreeTerm10);
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
            dict.Add("F_WarehouseName", "仓库名称");
            dict.Add("F_Acreage", "面积");
            dict.Add("F_Unit", "计量单位");
            dict.Add("F_Regionally", "区域性");
            dict.Add("F_Capacity", "容量");
            dict.Add("F_Layers", "层");
            dict.Add("F_WhatIs", "存放物料描述");
            dict.Add("F_SpecificatModel", "规格型号");

            dict.Add("F_Id", "主键");
            dict.Add("F_EnCode", "货位编码");
            dict.Add("F_FullName", "货位名称");
            dict.Add("F_ParentId", "父节点");
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

        public string SaveTra(Sys_TransferInfo info) {
            try
            {
                  using (DbTransactionScope<Sys_TransferInfo> dbtran = base.CreateTransactionScope())
            {

                int JNum = int.Parse(info.F_Number) - int.Parse(info.F_TransferNum);
                if (JNum<0)
                {
                    return "该产品数量不足";
                }
                else
                {
              
                    //减少库存数量
                    Hashtable has = new Hashtable();
                    this.ExecuteNonQuery(string.Format("update Sys_Stock set F_Number='{0}' where F_Id='{1}'", JNum, info.F_StockId), has);
                     
                    //判断转移的货位是否存在此产品
                    string SelGoods = string.Format("select * from Sys_Stock where F_GoodsId='{0}' and F_WarehouseId='{1}'  and F_CargoPositionId='{2}'", info.F_GoodsId, info.F_TransferWarHouseId, info.F_TransferCargoId);
                    int count=this.GetDataTableBySql(SelGoods).Rows.Count;
                    if (count>0)
                    {
                        //存在则添加库存
                         Hashtable hash=new Hashtable();
                        string UpStockGoodsNum = string.Format("update Sys_Stock set F_Number=F_Number+{0} where  F_GoodsId='{1}' and F_WarehouseId='{2}'  and F_CargoPositionId='{3}'", info.F_TransferNum, info.F_GoodsId, info.F_TransferWarHouseId, info.F_TransferCargoId);
                        this.ExecuteNonQuery(UpStockGoodsNum);
                      // 添加物品转移履历
                        Sys_Transfer.Instance.Insert(info);
                    }
                    else
                    {
                        //获取产品信息
                        DataTable dt = this.GetDataTableBySql("select F_Batch,F_ProDate,F_ExpiratDate,F_CategoryID,F_Unit,F_SellingPrice from Sys_Stock where F_Id='" + info.F_StockId + "'");
                        //否则添加产品
                        Sys_StockInfo StockInfo = new Sys_StockInfo();
                        StockInfo.F_Number = int.Parse(info.F_TransferNum);
                        StockInfo.F_WarehouseId = info.F_TransferWarHouseId;
                        StockInfo.F_WarehouseName = info.F_TransferWarHouse;
                        StockInfo.F_GoodsId = info.F_GoodsId;
                        StockInfo.F_GoodsName = info.F_GoodsName;
                        StockInfo.F_CargoPositionId = info.F_TransferCargoId;
                        StockInfo.F_CargoPositionName = info.F_TransferCargo;
                        StockInfo.F_EnCode = info.F_EnCode;
                        StockInfo.F_Batch = dt.Rows[0][0].ToString();
                        StockInfo.F_ProDate = dt.Rows[0][1].ToString();
                        StockInfo.F_ExpiratDate =dt.Rows[0][2].ToString();
                        StockInfo.F_CategoryID =dt.Rows[0][3].ToString();
                        StockInfo.F_Unit = dt.Rows[0][4].ToString();
                        StockInfo.F_SellingPrice = dt.Rows[0][5].ToString();
                        StockInfo.F_CreatorTime = DateTime.Now;
                        StockInfo.F_CreatorUserId = info.F_CreatorUserId;
   
                        BLLFactory<Sys_Stock>.Instance.Insert(StockInfo);
                        //添加物品转移履历
                        Sys_Transfer.Instance.Insert(info);
                    }
                }                   
                return "转移成功";
            }
            }
            catch (Exception ex)
            {

                return  ex.ToString();
            }

        }

        }
    }

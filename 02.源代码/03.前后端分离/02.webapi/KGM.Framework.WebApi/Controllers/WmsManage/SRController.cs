using KGM.Framework.Application.Dtos;
using KGM.Framework.Application.Services;
using KGM.Framework.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KGM.Framework.WebApi.Controllers
{
    /// <summary>
    /// 拣货单接口
    /// </summary>
    [Route("api/[controller]")]
    //[ApiController]
    public class SRController : ControllerBase
    {
        #region 依赖注入
        ISRMainService _service;
        ISRDetailService  _detailService;
        ICustomerService _customerService;
        IWarehouseService _warehouseService;
        IInventoryService _productService;
        IConfiguration _config;
        IHostingEnvironment _hosting;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        /// <param name="detailService"></param>
        /// <param name="customerService"></param>
        /// <param name="warehouseService"></param>
        /// <param name="productService"></param>
        /// <param name="config"></param>
        /// <param name="hosting"></param>
        public SRController(ISRMainService service, ISRDetailService  detailService, ICustomerService customerService,
        IWarehouseService warehouseService, IInventoryService productService, IConfiguration config, IHostingEnvironment hosting)
        {
            _hosting = hosting;
            _warehouseService = warehouseService;
            _customerService = customerService;
            _service = service;
            _detailService = detailService;
            _productService = productService;
            _config = config;
        }
        #endregion

        #region Post
 
        /// <summary>
        /// 生成到货单
        /// </summary>
        /// <param name="model">新增对象</param>
        /// <returns></returns>
        [HttpPost, Route("GeneratePackList")]
        public async Task<IActionResult> GeneratePackList([FromBody]GeneratePackList model)
        {
            return await Task.Run(() =>
            {
                bool status = true;
                string message = string.Empty;
                int i = 0;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                foreach (string str in model.Ids)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = str;
                    dt.Rows.Add(dr);
                }

                List<PackListModelDto> @return = _service.GeneratePackList(dt, model.User, model.OrderType);
                if (@return.Count() == 1 && @return[0].r == 0)
                {

                    var date = new { Status = status, Message = @return[0].msg };
                    return Ok(date);
                }
                else
                {
                    DataTable dtLogic = new DataTable();
                    dtLogic.Columns.Add("ORDERNO", typeof(string));
                    dtLogic.Columns.Add("LOGISTICCODE", typeof(string));

                    message = string.Format("拣货单生成成功[{0}]<br>", @return[0].msg);
                    KdniaoApiUtil.Instance.ReqURL = _config["KuaidiniaoAddress"];

                    //快递鸟发送快递
                    foreach (PackListModelDto item in @return)
                    {
                        try
                        {
                            KdniaoApiUtil.Instance.AppKey = item.F_ApiKey;
                            KdniaoApiUtil.Instance.EBusinessID = item.F_KDNId;
                            KdniaoElectrionicSurfaceEntity entity = new KdniaoElectrionicSurfaceEntity();
                            entity.OrderCode = item.MAINID;
                            entity.ShipperCode = item.F_KDAccout;
                            entity.CustomerName = item.F_KDMonthAccout;
                            entity.CustomerPwd = item.F_KDPwd;
                            entity.SendSite = string.Empty;
                            entity.ExpNo = item.F_EXPNO;

                            entity.Sender = new KdniaoPersonEntity();
                            entity.Sender.Company = string.Empty;
                            entity.Sender.Name = item.CustomerName;
                            entity.Sender.Mobile = item.SENDERPHONE;
                            entity.Sender.ProvinceName = item.SENDERPROVINCE;
                            entity.Sender.CityName = item.SENDERCITY;
                            entity.Sender.Address = item.CCUSADDRESS;

                            entity.Receiver = new KdniaoPersonEntity();
                            entity.Receiver.Company = string.Empty;
                            entity.Receiver.Name = item.F_sendPerson;
                            entity.Receiver.Mobile = item.F_phone;
                            entity.Receiver.ProvinceName = item.PROVINCE;
                            entity.Receiver.CityName = item.CITY;
                            entity.Receiver.Address = item.F_sendAddress;


                            entity.Weight = 0;
                            entity.Quantity = 0;
                            entity.Volume = 0;
                            entity.Remark = item.NOTES;

                            DataTable expDt = new DataTable();

                            KdniaoApiResult kdniaoApiResult = null;
                            if (!string.IsNullOrEmpty(entity.ExpNo))
                            {
                                expDt = _service.GetExpOrder(entity.OrderCode);
                                //先取消
                                entity.OrderCode = expDt.Rows[0][1].ToString();
                                kdniaoApiResult = KdniaoApiUtil.Instance.ElectronicSurface(entity, true);
                            }

                            if (kdniaoApiResult != null && !kdniaoApiResult.success)
                            {
                                status = false;
                                message += string.Format("单据号[{0}]快递单取消失败<br>", entity.OrderCode);
                            }
                            else
                            {
                                if (expDt != null)
                                {
                                    entity.OrderCode = expDt.Rows[0][0].ToString();
                                }
                                kdniaoApiResult = KdniaoApiUtil.Instance.ElectronicSurface(entity);

                                if (kdniaoApiResult.success)
                                {
                                    DataRow drLogic = dtLogic.NewRow();
                                    drLogic["ORDERNO"] = entity.OrderCode.Split('-')[0];
                                    drLogic["LOGISTICCODE"] = kdniaoApiResult.Order.LogisticCode;
                                    dtLogic.Rows.Add(drLogic);
                                    //文件保存到目录下
                                    SaveLogic(entity.OrderCode.Split('-')[0], kdniaoApiResult.Order.LogisticCode, kdniaoApiResult.printTemplate);
                                }
                                else
                                {
                                    status = false;
                                    message += string.Format("单据号[{0}]快递单生成失败!原因：{1}<br>", entity.OrderCode, kdniaoApiResult.reason);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = false;
                            message += string.Format("单据号[{0}]快递单生成失败!原因：{1}<br>", @return[i].MAINID, ex.Message);
                        }


                    }
                    // 回写快递单

                    _service.ReWriteLogicCode(dtLogic);

                    return Ok(new {Status=status,Message=message });

                }
            });
        }








        #endregion
        
        
        #region Get


         


       

        /// <summary>
        /// 分页查询 + 条件查询
        /// </summary>
        /// <param name="keyword">查询内容</param>
        /// <param name="rows">行数</param>
        /// <param name="page">页码</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">升序降序</param>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        [HttpGet("GatPagerListByWhere/{Id}")]
        public async Task<IActionResult> GatPagerListByWhere(string keyword, int rows, int page, string sidx, string sord, string Id)
        {

            if (string.IsNullOrEmpty(sidx))
            {
                sidx = "SortCode";
            }
            if (string.IsNullOrEmpty(sord))
            {
                sord = "ASC";
            }

            PagerEntity<SRMainGetDto> entity = await _service.QueryByPagesAsync(rows, page,
                      t => t.orderNo.Contains((keyword ?? t.orderNo)) ||
                      t.dpNo.Contains(keyword ?? t.dpNo),
                      _service.Expression(sidx), sord.ToUpper().Equals("ASC"));

            List<SRMainGetDto> list = await _service.QueryAsync();
            if (entity.Entity != null && entity.Entity.Count() > 0)
            {
                foreach (var item in entity.Entity)
                {

                    var customer = await _customerService.QueryByIdAsync(item.CustomerId);
                    var warehouse = await _warehouseService.QueryByIdAsync(item.WarehouseId);

                    item.WarehouseName = warehouse == null ? "" : warehouse.FullName;
                    item.CustomerName = customer == null ? "" : customer.FullName;
                }
            }

            //设置返回格式
            ReturnEntity RtEntity = new ReturnEntity();
            RtEntity.rows = entity.Entity;
            RtEntity.page = page;
            RtEntity.records = entity.Total;
            int Count = entity.Total / rows;//获取除数
            int yu = entity.Total % rows;//获取余数
            if (yu > 0)//如果余数大于0则加一页，否则不加
            {
                RtEntity.total = Count + 1;
            }
            else
            {
                RtEntity.total = Count + 0;
            }
            return Ok(Extensions.ToJson(RtEntity));
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetData()
        {
            DataSet ds = new DataSet();
            DataTable info = new DataTable();
            info.Columns.Add("ORDERNO", typeof(string));
            info.Columns.Add("WAREHOUSEID", typeof(string));
            info.Columns.Add("CUSTORMERID", typeof(string));
            info.Columns.Add("PROPERTY", typeof(string));
            info.Columns.Add("ORDERTYPE", typeof(string));
            info.Columns.Add("SENDTYPE", typeof(string));
            info.Columns.Add("EXPCOMPANY", typeof(string));
            info.Columns.Add("SENDPERSON", typeof(string));
            info.Columns.Add("PHONE", typeof(string));
            info.Columns.Add("MAKER", typeof(string));
            info.Columns.Add("PROVINCE", typeof(string));
            info.Columns.Add("CITY", typeof(string));
            info.Columns.Add("SENDADDRESS", typeof(string));
            info.Columns.Add("DESCRIPTION", typeof(string));
            info.Columns.Add("DEFINE1", typeof(string));
            info.Columns.Add("DEFINE2", typeof(string));
            info.Columns.Add("DEFINE3", typeof(string));
            info.Columns.Add("DEFINE4", typeof(string));
            info.Columns.Add("DEFINE5", typeof(string));
            info.Columns.Add("DEFINE6", typeof(string));
            info.Columns.Add("DEFINE7", typeof(string));
            info.Columns.Add("DEFINE8", typeof(string));
            info.Columns.Add("DEFINE9", typeof(string));
            info.Columns.Add("DEFINE10", typeof(string));
            info.Columns.Add("DEFINE11", typeof(string));
            info.Columns.Add("DEFINE12", typeof(string));
            info.Columns.Add("DEFINE13", typeof(string));
            info.Columns.Add("DEFINE14", typeof(string));
            info.Columns.Add("DEFINE15", typeof(string));
            info.Columns.Add("DEFINE16", typeof(string));
            info.Columns.Add("DEFINE17", typeof(string));
            info.Columns.Add("DEFINE18", typeof(string));
            info.Columns.Add("DEFINE19", typeof(string));
            info.Columns.Add("DEFINE20", typeof(string));
            ds.Tables.Add(info);
            DataTable dInfo = new DataTable();
            dInfo.Columns.Add("ROWNO", typeof(string));
            dInfo.Columns.Add("BOXNO", typeof(string));
            dInfo.Columns.Add("PRODUCTID", typeof(string));
            dInfo.Columns.Add("BARCODE", typeof(string));
            dInfo.Columns.Add("QTY", typeof(int));
            dInfo.Columns.Add("DESCRIPTION", typeof(string));
            dInfo.Columns.Add("DEFINE1", typeof(string));
            dInfo.Columns.Add("DEFINE2", typeof(string));
            dInfo.Columns.Add("DEFINE3", typeof(string));
            dInfo.Columns.Add("DEFINE4", typeof(string));
            dInfo.Columns.Add("DEFINE5", typeof(string));
            dInfo.Columns.Add("DEFINE6", typeof(string));
            dInfo.Columns.Add("DEFINE7", typeof(string));
            dInfo.Columns.Add("DEFINE8", typeof(string));
            dInfo.Columns.Add("DEFINE9", typeof(string));
            dInfo.Columns.Add("DEFINE10", typeof(string));
            dInfo.Columns.Add("DEFINE11", typeof(string));
            dInfo.Columns.Add("DEFINE12", typeof(string));
            dInfo.Columns.Add("DEFINE13", typeof(string));
            dInfo.Columns.Add("DEFINE14", typeof(string));
            dInfo.Columns.Add("DEFINE15", typeof(string));
            dInfo.Columns.Add("DEFINE16", typeof(string));
            dInfo.Columns.Add("DEFINE17", typeof(string));
            dInfo.Columns.Add("DEFINE18", typeof(string));
            dInfo.Columns.Add("DEFINE19", typeof(string));
            dInfo.Columns.Add("DEFINE20", typeof(string));
            ds.Tables.Add(dInfo);

            return ds;
        }


        /// <summary>
        /// 添加或修改发货单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static DataSet GetTableData(GetDPModel model)
        {
            DataSet ds = GetData();
            DataRow dr = ds.Tables[0].NewRow();
            var info = model.info;
            dr["ORDERNO"] = string.IsNullOrEmpty(info.OrderNo) ? string.Empty : info.OrderNo;
            dr["WAREHOUSEID"] = info.WarehouseId;
            dr["CUSTORMERID"] = info.CustomerId;
            dr["PROPERTY"] = info.Property;
            dr["ORDERTYPE"] = info.OrderType;
            dr["SENDTYPE"] = info.sendType;
            dr["EXPCOMPANY"] = info.expCompany;
            dr["SENDPERSON"] = info.sendPerson;
            dr["PHONE"] = info.phone;
            dr["MAKER"] = info.Maker;
            dr["PROVINCE"] = info.Province;
            dr["CITY"] = info.City;
            dr["SENDADDRESS"] = info.sendAddress;
            dr["DESCRIPTION"] = info.Description;
            dr["DEFINE1"] = info.Define1;
            dr["DEFINE2"] = info.Define2;
            dr["DEFINE3"] = info.Define3;
            dr["DEFINE4"] = info.Define4;
            dr["DEFINE5"] = info.Define5;
            dr["DEFINE6"] = info.Define6;
            dr["DEFINE7"] = info.Define7;
            dr["DEFINE8"] = info.Define8;
            dr["DEFINE9"] = info.Define9;
            dr["DEFINE10"] = info.Define10;
            dr["DEFINE11"] = info.Define11;
            dr["DEFINE12"] = info.Define12;
            dr["DEFINE13"] = info.Define13;
            dr["DEFINE14"] = info.Define14;
            dr["DEFINE15"] = info.Define15;
            dr["DEFINE16"] = info.Define16;
            dr["DEFINE17"] = info.Define17;
            dr["DEFINE18"] = info.Define18;
            dr["DEFINE19"] = info.Define19;
            dr["DEFINE20"] = info.Define20;
            ds.Tables[0].Rows.Add(dr);
            var order = ds.Tables[0].Rows[0]["ORDERNO"].ToString();
            for (int i = 0; i < model.dInfo.Count; i++)
            {
                dr = ds.Tables[1].NewRow();
                var dInfo = model.dInfo[i];
                dr["ROWNO"] = i;
                dr["BOXNO"] = dInfo.BoxNo;
                dr["QTY"] = dInfo.qty;
                dr["BARCODE"] = dInfo.BarCode;
                dr["PRODUCTID"] = dInfo.ProductId;
                dr["Description"] = dInfo.Description;
                dr["DEFINE1"] = dInfo.Define1;
                dr["DEFINE2"] = dInfo.Define2;
                dr["DEFINE3"] = dInfo.Define3;
                dr["DEFINE4"] = dInfo.Define4;
                dr["DEFINE5"] = dInfo.Define5;
                dr["DEFINE6"] = dInfo.Define6;
                dr["DEFINE7"] = dInfo.Define7;
                dr["DEFINE8"] = dInfo.Define8;
                dr["DEFINE9"] = dInfo.Define9;
                dr["DEFINE10"] = dInfo.Define10;
                dr["DEFINE11"] = dInfo.Define11;
                dr["DEFINE12"] = dInfo.Define12;
                dr["DEFINE13"] = dInfo.Define13;
                dr["DEFINE14"] = dInfo.Define14;
                dr["DEFINE15"] = dInfo.Define15;
                dr["DEFINE16"] = dInfo.Define16;
                dr["DEFINE17"] = dInfo.Define17;
                dr["DEFINE18"] = dInfo.Define18;
                dr["DEFINE19"] = dInfo.Define19;
                dr["DEFINE20"] = dInfo.Define20;
                ds.Tables[1].Rows.Add(dr);

            }
            return ds;

        }




        private void SaveLogic(string orderNo, string logicCode, string html)
        {
            // string virtualPath = string.Format("~/Content/express/{0}/{1}{2}", orderNo, logicCode, ".html");
            string webRootPath = _hosting.WebRootPath + string.Format("/Content/express/{0}/{1}{2}", orderNo, logicCode, ".html");
            string contentRootPath = _hosting.ContentRootPath + string.Format("/Content/express/{0}/{1}{2}", orderNo, logicCode, ".html");
            // string fullFileName = Server.MapPath(virtualPath);
            //创建文件夹
            string path = Path.GetDirectoryName(contentRootPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Bitmap m_Bitmap = WebSiteThumbnail.GetWebSiteThumbnail(html, 380, 570, 380, 570);
            //m_Bitmap.Save(fullFileName, System.Drawing.Imaging.ImageFormat.Png);

            FileUtil.WriteText(contentRootPath, html, System.Text.Encoding.UTF8);
        }
        #endregion
    }
}
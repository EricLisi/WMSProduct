using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.WebApi.Models;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using KGM.Framework.Commons;
using System.Data;

namespace KGMFramework.WebApp.WebApi.Controllers
{
    /// <summary>
    /// 系统认证模块
    /// </summary> 
    [RoutePrefix("api/scan")]
    public class ScanController : ApiController
    {
        /// <summary>
        /// 获取单据信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        [HttpGet, Route("GetList/{orderNo}/{orderType}")]
        public async Task<DataSet> GetList(string orderNo, string orderType)
        {
            return await Task.Run(() =>
            {

                return BLLFactory<AppCommon>.Instance.LIST_GETDATA(orderNo, orderType);
            });
        }



        /// <summary>
        /// 获取单据信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="operUser"></param>
        /// <returns></returns>
        [HttpGet, Route("GetTempScan/{orderNo}/{operUser}")]
        public async Task<DataTable> GetTempScan(string orderNo, string operUser)
        {
            return await Task.Run(() =>
            {
                return BLLFactory<AppCommon>.Instance.GetTempScan(orderNo, operUser);
            });
        }

        /// <summary>
        /// 获取单据信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        [HttpGet, Route("GetTempScanCy/{orderNo}/{operType}")]
        public async Task<DataTable> GetTempScanCy(string orderNo, string operType)
        {
            return await Task.Run(() =>
            {
                return BLLFactory<AppCommon>.Instance.GetTempScanCy(orderNo, operType);
            });
        }



        /// <summary>
        /// 保存扫描记录
        /// </summary>
        /// <param name="dto">扫描参数</param>
        /// <returns></returns>
        [HttpPost, Route("TempScanFinish")]
        public async Task<KgmApiResultEntity> TempScanFinish(FinishTempScanDto dto)
        {
            KgmApiResultEntity result = new KgmApiResultEntity();
            result.result = true;
            return await Task.Run(() =>
            {
                var dt = BLLFactory<AppCommon>.Instance.TempScanFinish(dto);
                if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                {
                    result.result = false;
                }

                result.message = dt.Rows[0][1].ToString();
                return result;
            });
        }
    }
}

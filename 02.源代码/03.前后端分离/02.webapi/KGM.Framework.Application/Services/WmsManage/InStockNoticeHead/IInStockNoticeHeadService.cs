using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;

using System;
using System.Data;
using System.Threading.Tasks;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 入库通知单主表服务接口
    /// </summary>
    public interface IInStockNoticeHeadService : IService<InStockNoticeHeadEntity, InStockNoticeHeadGetDto>
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Func<InStockNoticeHeadEntity, string> Expression(string keyValue);

        /// <summary>
        /// 添加或修改入库通知单
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        ReturnModel InsUpdateInStockNotice(DataSet ds);
       
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
         ReturnModel DeleteInStockNotice(string Id);

      

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        ReturnModel VerifyList(string ID, string User, int orderType);

        /// <summary>
        /// 快速上架
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="PositionCode"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        ReturnModel QuickShelf(string orderNo, string PositionCode, string User);


        /// <summary>
        /// 到货完成
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        ReturnModel QuickPU(DataTable dt, string User);
    }
}

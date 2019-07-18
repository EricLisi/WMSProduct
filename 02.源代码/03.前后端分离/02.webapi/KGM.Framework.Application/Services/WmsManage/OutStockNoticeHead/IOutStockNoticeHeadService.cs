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
    public interface IOutStockNoticeHeadService : IService<OutStockNoticeHeadEntity, OutStockNoticeHeadGetDto>
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Func<OutStockNoticeHeadEntity, string> Expression(string keyValue);

        /// <summary>
        /// 添加或修改入库通知单
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        ReturnModel InsUpdateOutStockNotice(DataSet ds);
       
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
         ReturnModel DeleteOutStockNotice(string Id);

      

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        ReturnModel VerifyList(string ID, string User, int orderType);
    }
}

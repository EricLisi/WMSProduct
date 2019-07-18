using KGM.Framework.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace KGM.Framework.Domain
{
    public interface IInStockNoticeHeadRepository : IRepository<InStockNoticeHeadEntity>
    {


        /// <summary>
        /// 添加或修改入库通知单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GetResultModel InsUpdateInStockNotice(DataSet ds);



 
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        GetResultModel DeleteInStockNotice(string Id);


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        GetResultModel VerifyList(string ID, string User, int orderType);

        /// <summary>
        /// 快速上架
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="PositionCode"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        GetResultModel QuickShelf(string orderNo, string PositionCode, string User);


        /// <summary>
        /// 到货完成
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        GetResultModel QuickPU(DataTable dt, string User);

    }    
}

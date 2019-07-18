using KGM.Framework.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace KGM.Framework.Domain
{
    public interface ISRMainRepository : IRepository<SRMainEntity>
    {



        /// <summary>
        /// 生成拣货单
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        List<PackListModel> GeneratePackList(DataTable dt, string User, int orderType);


        /// <summary>
        /// 回写快递单号
        /// </summary>
        /// <param name="dt"></param>
        void ReWriteLogicCode(DataTable dt);

        /// <summary>
        /// 创建快递单订单号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        DataTable GetExpOrder(string orderNo);



    }    
}

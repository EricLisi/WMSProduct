using KGM.Framework.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace KGM.Framework.Domain
{
    public interface IDPMainRepository : IRepository<DPMainEntity>
    {


        /// <summary>
        /// 添加或修改入库通知单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GetResultModel InsUpdateDP(DataSet ds);



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        GetResultModel DeleteDP(string Id);


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        GetResultModel VerifyList(string ID, string User, int orderType);



    }    
}

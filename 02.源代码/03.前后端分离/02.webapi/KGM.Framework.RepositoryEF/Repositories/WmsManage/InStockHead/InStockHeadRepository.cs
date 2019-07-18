using KGM.Framework.Domain;
using KGM.Framework.RepositoryEF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KGM.Framework.RepositoryEF.Repositories
{
    public class InStockHeadRepository : BaseRepository<InStockHeadEntity>, IInStockHeadRepository
    {
        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public GetResultModel VerifyList(string ID, string User, int orderType)
        {
            SqlParameter[] sqlParams = {
                     new SqlParameter("@ID", ID),
                     new SqlParameter("@USERNAME", User),
                     new SqlParameter("@ORDERTYPE", orderType)
                    };

            var result = base.ExcuteStoredProcedureToList<GetResultModel>("[VERIFYLIST_INSTOCK]", sqlParams).ToList();
            GetResultModel model = result[0] as GetResultModel;
            return model;
        }

        /// <summary>
        /// 快速上架
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="PositionCode"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public GetResultModel QuickShelf(string orderNo, string PositionCode, string User)
        {
            SqlParameter[] sqlParams = {
                        new SqlParameter("@ORDERNO",orderNo),
                    new SqlParameter("@CPOSCODE",PositionCode),
                    new SqlParameter("@OPERUSER",User),
                    };
            var result = base.ExcuteStoredProcedureToList<GetResultModel>("[PI_QUICKSHELF]", sqlParams).ToList();
            GetResultModel model = result[0] as GetResultModel;
            return model;
        }


        /// <summary>
        /// 到货完成
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public GetResultModel QuickPU(DataTable dt, string User)
        {

            SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@PARM_PU_QUICKFINISH",dt),
                    new SqlParameter("@USERNAME",User),
                };

            var result = base.ExcuteStoredProcedureToList<GetResultModel>("[PU_QUICKFINISH]", sqlParams).ToList();
            GetResultModel model = result[0] as GetResultModel;
            return model;
        }
        ///// <summary>
        ///// 添加或修改入库通知单
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public  GetResultModel InsUpdateInStockHead(DataSet ds)
        //{

        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("PARM_SAVELIST_InStock_HEAD",ds.Tables[0]),
        //        new SqlParameter("PARM_SAVELIST_BARCODERULE_BODY",ds.Tables[1]),

        //    };

        //        var result = base.ExcuteStoredProcedureToList<GetResultModel>("[SAVELIST_BARCODERULE]", sqlParams).ToList();
        //        return result[0] as GetResultModel;


        //}

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //public GetResultModel DeleteInStockHead(string Id)
        //{
        //           SqlParameter[] sqlParams = {
        //                new SqlParameter("@ID", Id),
        //            };

        //    var result = base.ExcuteStoredProcedureToList<GetResultModel>("DELETE_BARCODERULE", sqlParams).ToList();
        //    GetResultModel del = result[0] as GetResultModel;
        //    return del;

        //}
    }
}

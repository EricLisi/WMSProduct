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
    public class OutStockNoticeHeadRepository : BaseRepository<OutStockNoticeHeadEntity>, IOutStockNoticeHeadRepository
    {
        /// <summary>
        /// 添加或修改入库通知单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public  GetResultModel InsUpdateOutStockNotice(DataSet ds)
        {

            SqlParameter[] sqlParams = {
                new SqlParameter("PARM_SAVELIST_OutSTOCKNOTICE_HEAD",ds.Tables[0]),
                new SqlParameter("PARM_SAVELIST_OutSTOCKNOTICE_BODY",ds.Tables[1]),

            };
        
                var result = base.ExcuteStoredProcedureToList<GetResultModel>("[SAVELIST_OutSTOCKNOTICE]", sqlParams).ToList();
                return result[0] as GetResultModel;
           

        }
       
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GetResultModel DeleteOutStockNotice(string Id)
        {
                   SqlParameter[] sqlParams = {
                        new SqlParameter("@ID", Id),
                    };

            var result = base.ExcuteStoredProcedureToList<GetResultModel>("DELETE_OUTSTOCKNOTICE", sqlParams).ToList();
            GetResultModel del = result[0] as GetResultModel;
            return del;

        }

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

            var result  = base.ExcuteStoredProcedureToList<GetResultModel>("[VERIFYLIST_OUTSTOCKNOTICE]", sqlParams).ToList();
            GetResultModel model = result[0] as GetResultModel;
            return model;
        }
        
    }
}

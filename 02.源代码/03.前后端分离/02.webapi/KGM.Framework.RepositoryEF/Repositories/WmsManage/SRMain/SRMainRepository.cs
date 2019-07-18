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
    public class SRMainRepository : BaseRepository<SRMainEntity>, ISRMainRepository
    {

        /// <summary>
        /// 生成拣货单
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public List<PackListModel> GeneratePackList(DataTable dt, string User, int orderType)
        {

            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@PARM_SAVELIST_PACKLIST",dt),
                new SqlParameter("@USERNAME",User),
                new SqlParameter("@ORDERTYPE",orderType)
            };
            var result = base.ExcuteStoredProcedureToList<PackListModel>("[SAVELIST_PACKLIST]", sqlParams).ToList();


            return result as List<PackListModel>;


        }
        /// <summary>
        /// 创建快递单订单号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public DataTable GetExpOrder(string orderNo)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Prefix",orderNo),

            };

            DataTable dt = new DataTable();
            dt.Columns.Add("NEWORDERNO", typeof(string));
            dt.Columns.Add("OLDORDERNO", typeof(string));
            //  var result=base.ExcuteStoredProcedureToList<GetExpOrderModel>("[KGM_CREATEEXPORDER]", sqlParams);
            var result = base.ExcuteStoredProcedureToDataSet("[KGM_CREATEEXPORDER]", sqlParams);
            return result.Tables[0];
        }
        /// <summary>
        /// 回写快递单号
        /// </summary>
        /// <param name="dt"></param>
        public void ReWriteLogicCode(DataTable dt)
        {
            SqlParameter[] paramlist = new SqlParameter[]{
                new SqlParameter("@PARM_REWRITER_LOGICCODE",dt),
            };

            base.ExcuteStoredProcedureNoQuery<GetResultModel>("[REWRITER_LOGICCODE]", paramlist);
        }

    }
}

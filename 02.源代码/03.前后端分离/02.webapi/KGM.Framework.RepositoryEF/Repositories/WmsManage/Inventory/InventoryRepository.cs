
using KGM.Framework.Domain;

using System.Data;
using System.Data.SqlClient;



namespace KGM.Framework.RepositoryEF.Repositories
{
    public class InventoryRepository : BaseRepository<InventoryEntity>, IInventoryRepository
    {


        public string GetSku(int len)
        {
            return "";
          

        }

    }
}

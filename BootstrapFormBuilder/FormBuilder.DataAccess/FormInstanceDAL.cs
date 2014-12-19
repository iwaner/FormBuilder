using System.Data;
using System.Data.SqlClient;

namespace FormBuilder.DataAccess
{
    public class FormInstanceDAL: DataAccessBase
    {
        public static void InsertFormInstance(DataTable tb, DataTable registerEventDt)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                
            }
        }
    }
}

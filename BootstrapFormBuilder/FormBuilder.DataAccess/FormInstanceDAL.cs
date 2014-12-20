using System;
using System.Data;
using System.Data.SqlClient;
using FormBuilder.DataModel;

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

        public static FormInstanceModel GetFormInstanceById(Int64 formInstanceId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("[dbo].[SP_GETFormInstanceById]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var param = new SqlParameter
                {
                    ParameterName = "@FormInstanceId",
                    Value = formInstanceId,
                    SqlDbType = SqlDbType.BigInt
                };
                cmd.Parameters.Add(param);

                conn.Open();
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds, "BaseData");
                conn.Close();
                var tempData = new FormInstanceModel();
                return tempData;
            }
        }
    }
}

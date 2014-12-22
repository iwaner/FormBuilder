using System;
using System.Data;
using System.Data.SqlClient;
using FormBuilder.DataModel;

namespace FormBuilder.DataAccess
{
    public class FormInstanceDAL : DataAccessBase
    {
        public void InsertOrUpdateFormInstance(Int64 formInstanceId, string formDataFields, Int64 formTemplateId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("[dbo].[SP_AddOrUpdateFormInstance]", conn)
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

                param = new SqlParameter
                {
                    ParameterName = "@FormDataFields",
                    Value = formDataFields,
                    SqlDbType = SqlDbType.NVarChar
                };
                cmd.Parameters.Add(param);

                param = new SqlParameter
                {
                    ParameterName = "@FormTemplateId",
                    Value = formTemplateId,
                    SqlDbType = SqlDbType.BigInt
                };
                cmd.Parameters.Add(param);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void DeleteFormInstance(Int64 formInstanceId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("[dbo].[SP_DeleteFormInstance]", conn)
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
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public FormInstanceModel GetFormInstanceById(Int64 formInstanceId)
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
                da.Fill(ds, "FormInstance");
                conn.Close();
                var tempData = FormInstanceModeMapping.MapDataTableToFormTemplateModel(ds);
                return tempData;
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using FormBuilder.DataModel;

namespace FormBuilder.DataAccess
{
    public class FormTemplateDAL : DataAccessBase
    {
        public void InsertOrUpdateFormTemplate(Int64 formTemplateId, string formName, string formDescription, Int64 formHtmlTemplate, DataTable dt)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("[dbo].[SP_AddOrUpdateFormTemplate]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var param = new SqlParameter
                {
                    ParameterName = "@FormTemplateId",
                    Value = formTemplateId,
                    SqlDbType = SqlDbType.BigInt
                };
                cmd.Parameters.Add(param);

                param = new SqlParameter
                {
                    ParameterName = "@FormName",
                    Value = formName,
                    SqlDbType = SqlDbType.NVarChar
                };
                cmd.Parameters.Add(param);

                param = new SqlParameter
                {
                    ParameterName = "@FormDescription",
                    Value = formDescription,
                    SqlDbType = SqlDbType.NVarChar
                };
                cmd.Parameters.Add(param);

                param = new SqlParameter
                {
                    ParameterName = "@FormHtmlTemplate",
                    Value = formDescription,
                    SqlDbType = SqlDbType.BigInt
                };
                cmd.Parameters.Add(param);

                param = new SqlParameter
                {
                    ParameterName = "@FormControlGroup",
                    Value = dt,
                    SqlDbType = SqlDbType.Structured
                };
                cmd.Parameters.Add(param);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteFormTemplate(Int64 formTemplateId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("[dbo].[SP_DeleteFormTemplate]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var param = new SqlParameter
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

        public FormTemplateModel GetFormTemplateByTemplateId(Int64 templateId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("[dbo].[SP_GETFormTemplateById]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var param = new SqlParameter
                {
                    ParameterName = "@FormTemplateId",
                    Value = templateId,
                    SqlDbType = SqlDbType.BigInt
                };
                cmd.Parameters.Add(param);

                conn.Open();
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds, "FormTemplate");
                conn.Close();
                var tempData = FormTemplateModeMapping.MapDataTableToFormTemplateModel(ds.Tables[0], ds.Tables[1]);
                return tempData;
            }
        }
    }
}

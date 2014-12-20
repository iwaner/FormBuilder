using System;
using System.Data;
using System.Data.SqlClient;
using FormBuilder.DataModel;

namespace FormBuilder.DataAccess
{
    public class FormTemplateDAL : DataAccessBase
    {
        public static void InsertFormTemplate(string formName, string formDescription, Int64 formHtmlTemplateId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmdTxt = "INSERT INTO [dbo].[FormTemplate] ( FormName, FormDescription, FormHtmlTemplate )" +
                              " VALUES" +
                              " ( " + formName + " ," + formDescription + " ," + formHtmlTemplateId + " )";
                var cmd = new SqlCommand(cmdTxt, conn)
                {
                    CommandType = CommandType.Text
                };
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void UpdateFormTemplate(Int64 formId, string formName, string formDescription, Int64 formHtmlTemplateId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmdTxt = "UPDATE [dbo].[FormTemplate] SET" +
                             "FormName = " + formName +
                             " , FormDescription = " + formDescription +
                             " , FormHtmlTemplate = " + formHtmlTemplateId +
                             " WHERE FormId = " + formId;
                var cmd = new SqlCommand(cmdTxt, conn)
                {
                    CommandType = CommandType.Text
                };
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }


        public static void DeleteFormTemplate(Int64 formId, string formName, string formDescription, Int64 formHtmlTemplateId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmdTxt = "UPDATE [dbo].[FormTemplate] SET" +
                             "FormName = " + formName +
                             " , FormDescription = " + formDescription +
                             " , FormHtmlTemplate = " + formHtmlTemplateId +
                             " WHERE FormId = " + formId;
                var cmd = new SqlCommand(cmdTxt, conn)
                {
                    CommandType = CommandType.Text
                };
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static FormTemplateModel GetFormTemplateByTemplateId(Int64 templateId)
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
                da.Fill(ds, "BaseData");
                conn.Close();
                var tempData = new FormTemplateModel();
                return tempData;
            }
        }
    }
}

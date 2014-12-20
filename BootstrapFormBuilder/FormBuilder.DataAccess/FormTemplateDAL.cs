using System;
using System.Data;
using System.Data.SqlClient;

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

        public static void GetFormTemplateByTemplateId(Int64 templateId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmdTxt = "SELECT * FROM [dbo].[FormTemplate] WHERE FormId = " + templateId +
                             "; SELECT * FROM [dbo].[FormControlGroup] WHERE FormTemplateId =  " + templateId;
                var cmd = new SqlCommand(cmdTxt, conn)
                {
                    CommandType = CommandType.Text
                };
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

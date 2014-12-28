using System.Data;
using FormBuilder.Utility;
namespace FormBuilder.DataModel
{
    public static class FormInstanceModeMapping
    {
        static public FormInstanceModel MapDataTableToFormTemplateModel(DataSet ds)
        {
            var formInstanceTb = ds.Tables[0];
            var formTemplateTb = ds.Tables[1];
            var formTemplateModel = new FormInstanceModel
            {
                FormTemplateId = formInstanceTb.Rows[0]["FormTemplateId"].ToString().ToInt64(),
                FormInstanceId = formInstanceTb.Rows[0]["FormInstanceId"].ToString().ToInt64(),
                CreateDate = formInstanceTb.Rows[0]["CreateDate"].ToString().ToDateTime(),
                CreateUser = formInstanceTb.Rows[0]["CreateUser"].ToString(),
                UpdateDate = formInstanceTb.Rows[0]["UpdateDate"].ToString().ToDateTime(),
                UpdateUser = formInstanceTb.Rows[0]["UpdateUser"].ToString(),
                FormData = formInstanceTb.Rows[0]["FormData"].ToString(),
                FormTemplateModel = FormTemplateModeMapping.MapDataTableToFormTemplateModel(formTemplateTb),
            };
            return formTemplateModel;
        }
    }
}

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
            var formControlGroupTb = ds.Tables[2];
            var formTemplateModel = new FormInstanceModel
            {
                FormTemplateId = formInstanceTb.Rows[0]["FormTemplateId"].ToString().ToInt64(),
                FormInstanceId = formInstanceTb.Rows[0]["FormInstanceId"].ToString().ToInt64(),
                WorkflowId = formInstanceTb.Rows[0]["WorkflowId"].ToString().ToInt64(),
                CreateTime = formInstanceTb.Rows[0]["CreateTime"].ToString().ToDateTime(),
                CreateUser = formInstanceTb.Rows[0]["CreateUser"].ToString(),
                ModifyTime = formInstanceTb.Rows[0]["CreateTime"].ToString().ToDateTime(),
                ModifyUser = formInstanceTb.Rows[0]["ModifyUser"].ToString().ToDateTime(),
                FormTemplateModel = FormTemplateModeMapping.MapDataTableToFormTemplateModel(formTemplateTb, formControlGroupTb)
            };
            return formTemplateModel;
        }
    }
}

using System.Data;
using FormBuilder.Utility;

namespace FormBuilder.DataModel
{
    public static class FormTemplateModeMapping
    {
        static public FormTemplateModel MapDataTableToFormTemplateModel(DataTable formTemplateTb, DataTable controlGroupTb)
        {
            var formTemplateModel = new FormTemplateModel
            {
                FormTemplateId = formTemplateTb.Rows[0]["FormTemplateId"].ToString().ToInt64(),
                FormDescription = formTemplateTb.Rows[0]["FormDescription"].ToString(),
                FormHtmlTemplate = formTemplateTb.Rows[0]["FormHtmlTemplate"].ToString().ToInt64(),
                FormName = formTemplateTb.Rows[0]["FormName"].ToString(),
                ControlGroups = FormControlGroupModelMapping.MapDataTableToFormGroupModel(controlGroupTb)
            };
            return formTemplateModel;
        }
    }
}

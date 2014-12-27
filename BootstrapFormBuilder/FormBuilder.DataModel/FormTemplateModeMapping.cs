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
                FormTemplateData = formTemplateTb.Rows[0]["FormTemplateData"].ToString(),
                FormName = formTemplateTb.Rows[0]["FormName"].ToString(),
            };
            return formTemplateModel;
        }
    }
}

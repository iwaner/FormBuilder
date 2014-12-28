using System.Collections.Generic;
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

        static public List<FormTemplateModel> MapDataTableToFormTemplateModels(DataTable formTemplateTb)
        {
            var templateModels = new List<FormTemplateModel>();
            foreach (DataRow row in formTemplateTb.Rows)
            {
                var formTemplateModel = new FormTemplateModel
                {
                    FormTemplateId = row["FormTemplateId"].ToString().ToInt64(),
                    FormDescription = row["FormDescription"].ToString(),
                    FormTemplateData = row["FormTemplateData"].ToString(),
                    FormName = row["FormName"].ToString(),
                };
                templateModels.Add(formTemplateModel);
            }

            return templateModels;
        }
    }
}

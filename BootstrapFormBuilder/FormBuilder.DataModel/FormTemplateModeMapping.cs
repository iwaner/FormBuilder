using System.Collections.Generic;
using System.Data;
using System.Web;
using FormBuilder.Utility;

namespace FormBuilder.DataModel
{
    public static class FormTemplateModeMapping
    {
        static public FormTemplateModel MapDataTableToFormTemplateModel(DataTable formTemplateTb)
        {
            var formTemplateModel = new FormTemplateModel
            {
                FormTemplateId = formTemplateTb.Rows[0]["FormTemplateId"].ToString().ToInt64(),
                FormDescription = formTemplateTb.Rows[0]["FormDescription"].ToString(),
                FormTemplateData = formTemplateTb.Rows[0]["FormTemplateData"],
                FormName = formTemplateTb.Rows[0]["FormName"].ToString(),
                WorkflowId = formTemplateTb.Rows[0]["WorkflowId"].ToString().ToInt64(),
                CreateDate = formTemplateTb.Rows[0]["CreateDate"].ToString().ToDateTime(),
                CreateUser = formTemplateTb.Rows[0]["CreateUser"].ToString(),
                UpdateDate = formTemplateTb.Rows[0]["UpdateDate"].ToString().ToDateTime(),
                UpdateUser = formTemplateTb.Rows[0]["UpdateUser"].ToString(),
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
                    WorkflowId = row["WorkflowId"].ToString().ToInt64(),
                    CreateDate = row["CreateDate"].ToString().ToDateTime(),
                    CreateUser = row["CreateUser"].ToString(),
                    UpdateDate = row["UpdateDate"].ToString().ToDateTime(),
                    UpdateUser = row["UpdateUser"].ToString(),
                };
                templateModels.Add(formTemplateModel);
            }

            return templateModels;
        }
    }
}

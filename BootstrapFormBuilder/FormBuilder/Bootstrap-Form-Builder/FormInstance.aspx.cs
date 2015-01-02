using System;
using System.Collections;
using System.Web.Services;
using FormBuilder.BLL;
using FormBuilder.DataModel;
using FormBuilder.Utility;

namespace FormBuilder.Bootstrap_Form_Builder
{
    public partial class FormInstance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static ArrayList ShowInstance(string instanceId, string templateId)
        {
            var values = new ArrayList();
            if (!string.IsNullOrEmpty(instanceId))
            {
                var instanceBll = new FormInstanceBLL();
                var instanceMode = instanceBll.GetFormInstance(instanceId.ToInt64());
                values.Add(instanceMode.FormTemplateModel.ToJason());
                values.Add(instanceMode.FormData);
            }
            else
            {
                var instanceBll = new FormTemplateBLL();
                var instanceMode = instanceBll.GetFormTemplate(templateId.ToInt64());
                values.Add(instanceMode.ToJason());
            }
            return values;
        }

        [WebMethod]
        public static string SaveFormData(string instanceId, string formData)
        {
            if (!string.IsNullOrEmpty(formData))
            {
                var instanceMode = formData.ToModeBase<FormInstanceModel>();
                if (instanceMode == null) return string.Empty;
                var instanceBll = new FormInstanceBLL();
                instanceMode = instanceBll.InsertOrUpdateFormInstance(instanceMode);
                return instanceMode.FormData;
            }
            return string.Empty;
        }
    }
}
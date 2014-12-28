using System.IO;
using System.Web;
using FormBuilder.BLL;
using FormBuilder.DataModel;
using FormBuilder.Utility;

namespace FormBuilder.FormBuilderHander
{
    public class FormTemplateHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var templateBll = new FormTemplateBLL();
            if ("post".Equals(context.Request.HttpMethod.ToLower()))
            {
                using (var reader = new StreamReader(context.Request.InputStream))
                {
                    string templateJson = HttpUtility.UrlDecode(reader.ReadToEnd());
                    if (!string.IsNullOrEmpty(templateJson))
                    {
                        var templateMode = templateJson.ToModeBase<FormTemplateModel>();
                        if (templateMode == null) return;
                        templateMode = templateBll.AddOrUpdateFormTemplateModel(templateMode);
                    }
                }
            }
            else
            {
                var formTemplateId = context.Request["formTemplateId"].ToInt64();
                var templateMode = templateBll.GetFormTemplate(formTemplateId);
                var result = templateMode.ToJason();
            }
            
        }
    }
}
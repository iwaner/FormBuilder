using System;
using System.Web;
using FormBuilder.BLL;
using FormBuilder.Utility;

namespace FormBuilder.FormBuilderHander
{
    public class FormTemplateHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            string templateId = context.Request["TemplateId"];
            if (!string.IsNullOrEmpty(templateId))
            {
                var templateBll = new FormTemplateBLL();
                var instanceMode = templateBll.GetFormInstance(templateId.ToInt64());
            }
            
        }
    }
}
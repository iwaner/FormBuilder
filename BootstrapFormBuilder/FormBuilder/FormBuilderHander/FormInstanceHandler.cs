using System.Web;
using FormBuilder.BLL;
using FormBuilder.Utility;

namespace FormBuilder.FormBuilderHander
{
    public class FormInstanceHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string templateId = context.Request["templateId"];
            string instanceId = context.Request["InstanceId"];
            if (!string.IsNullOrEmpty(instanceId))
            {
                var instanceBll = new FormInstanceBLL();
                var instanceMode = instanceBll.GetFormInstance(instanceId.ToInt64());
            }
            else
            {
                var instanceBll = new FormTemplateBLL();
                var instanceMode = instanceBll.GetFormTemplate(templateId.ToInt64());
            }          
        }
    }
}
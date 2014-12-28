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
            string templateId = context.Request["InstanceId"];
            if (!string.IsNullOrEmpty(templateId))
            {
                var instanceBll = new FormInstanceBLL();
                var instanceMode = instanceBll.GetFormInstance(templateId.ToInt64());
            }
           
        }
    }
}
using System;
using System.Web;
using System.Web.SessionState;
using FormBuilder.DataModel;
using FormBuilder.BLL;
using FormBuilder.Utility;

namespace FormBuilder.FormBuilderHander
{
    public class FormInstanceHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            string templateId = context.Request["InstanceId"];
            var instanceBll = new FormInstanceBLL();
            var instanceMode = instanceBll.GetFormInstance(templateId.ToInt64());
        }
    }
}
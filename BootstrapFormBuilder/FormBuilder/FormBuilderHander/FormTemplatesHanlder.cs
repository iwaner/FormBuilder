using System.Web;
using FormBuilder.BLL;
using FormBuilder.DataModel;

namespace FormBuilder.FormBuilderHander
{
    public class FormTemplatesHanlder : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }
        //get all templates
        public void ProcessRequest(HttpContext context)
        {
            var templateBll = new FormTemplateBLL();
            if ("get".Equals(context.Request.HttpMethod.ToLower()))
            {
               var templateModes = templateBll.GetFormTemplates();
               string result = templateModes.ToJason();
            }
        }
    }
}
using System.IO;
using System.Web;
using FormBuilder.BLL;
using FormBuilder.DataModel;
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
            if ("post".Equals(context.Request.HttpMethod.ToLower()))
            {
                using (var reader = new StreamReader(context.Request.InputStream))
                {
                    string instanceJson = HttpUtility.UrlDecode(reader.ReadToEnd());
                    if (!string.IsNullOrEmpty(instanceJson))
                    {
                        var instanceMode = instanceJson.ToModeBase<FormInstanceModel>();
                        if (instanceMode == null) return;
                        var instanceBll = new FormInstanceBLL();
                        instanceMode = instanceBll.InsertOrUpdateFormInstance(instanceMode);
                    }
                }
            }
        }
    }
}
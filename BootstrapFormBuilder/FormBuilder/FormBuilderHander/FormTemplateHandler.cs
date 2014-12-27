using System;
using System.IO;
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
            string templateJson = string.Empty;
            if ("post".Equals(context.Request.HttpMethod.ToLower()))
            {
                var reader = new StreamReader(context.Request.InputStream);
                templateJson = HttpUtility.UrlDecode(reader.ReadToEnd());
               
            } 
            else
            { 
                string json = HttpUtility.UrlDecode(context.Request.QueryString.ToString());
                context.Response.Write(json);
            }
            if (!string.IsNullOrEmpty(templateJson))
            {
                
            }
            
        }
    }
}
using System;
using System.Web.Services;
using FormBuilder.DataModel;
using Newtonsoft.Json;
namespace FormBuilder.Bootstrap_Form_Builder
{
    public partial class FormBuilderMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var formTemplate = new FormTemplateModel();
            string formTemplateJsonStr = JsonConvert.SerializeObject(formTemplate);
        }

        [WebMethod]
        public static void InsertoUpdateFormTemplate(string formTemplate)
        {

        }

        [WebMethod]
        public static void InsertoUpdateFormInstance(string formInstance)
        {

        }
    }
}
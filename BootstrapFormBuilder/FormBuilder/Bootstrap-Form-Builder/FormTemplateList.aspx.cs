using System;
using System.Web.Services;
using FormBuilder.BLL;
using FormBuilder.DataModel;

namespace FormBuilder.Bootstrap_Form_Builder
{
    public partial class FormTemplateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }
        [WebMethod]
        public static string ShowAllTemplates()
        {
            var templateBll = new FormTemplateBLL();
            var templateModes = templateBll.GetFormTemplates();
            string result = templateModes.ToJason();
            return result;
        }
    }
}
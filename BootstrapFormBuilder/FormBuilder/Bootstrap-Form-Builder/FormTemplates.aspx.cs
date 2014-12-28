using System;
using FormBuilder.BLL;
using FormBuilder.DataModel;

namespace FormBuilder.Bootstrap_Form_Builder
{
    public partial class FormTemplates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var templateBll = new FormTemplateBLL();
                var templateModes = templateBll.GetFormTemplates();
                string result = templateModes.ToJason();
            }
        }
    }
}
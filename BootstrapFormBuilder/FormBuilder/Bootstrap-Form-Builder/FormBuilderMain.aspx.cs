using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FormBuilder.Model;
using Newtonsoft.Json;
namespace FormBuilder.Bootstrap_Form_Builder
{
    public partial class FormBuilderMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormTemplateModel formTemplate = new FormTemplateModel();
            string formTemplateJsonStr = JsonConvert.SerializeObject(formTemplate);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBuilder.DataModel
{
    public class FormTemplateModel : ModeBase
    {
        public FormTemplateModel()
        {
            ControlGroups = new List<FormControlGroupModel>();
        }

        public Int64 FormId { get; set; }

        public string FormName { get; set; }

        public List<FormControlGroupModel> ControlGroups { get; set; }
    }
}

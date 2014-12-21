using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBuilder.DataModel
{
    public class FormControlGroupModel : ModeBase
    {
        public Int64 ControlGroupId { get; set; }
        public string ControlType { get; set; }
        public int OrderInForm { get; set; }
        public string FormFieldMapKey { get; set; }
        public string ControlGroupTemplateModel { get; set; }
        public string FormControlGroupPropertys { get; set; }
        public string FormTemplateId { get; set; }
        public List<FormControlGroupPropertyModel> ControlPropertys { get; set; }
    }
}

using System;
using System.Collections.Generic;

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
        public Int64 FormTemplateId { get; set; }
        public List<FormControlGroupPropertyModel> ControlPropertys { get; set; }
    }
}

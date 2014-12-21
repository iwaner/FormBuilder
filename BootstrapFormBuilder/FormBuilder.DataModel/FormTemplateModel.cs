using System;
using System.Collections.Generic;

namespace FormBuilder.DataModel
{
    public class FormTemplateModel : ModeBase
    {
        public Int64 FormTemplateId { get; set; }
        public string FormDescription { get; set; }
        public string FormName { get; set; }
        public Int64 FormHtmlTemplate { get; set; }
        public List<FormControlGroupModel> ControlGroups { get; set; }
    }
}

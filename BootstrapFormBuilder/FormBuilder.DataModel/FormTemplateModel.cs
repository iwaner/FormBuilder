using System;

namespace FormBuilder.DataModel
{
    public class FormTemplateModel : ModeBase
    {
        public Int64 FormTemplateId { get; set; }
        public string FormDescription { get; set; }
        public string FormName { get; set; }
        public object FormTemplateData { get; set; }
        public Int64 WorkflowId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}

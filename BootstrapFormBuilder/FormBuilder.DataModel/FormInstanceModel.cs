using System;

namespace FormBuilder.DataModel
{
    public class FormInstanceModel : ModeBase
    {
        public Int64 FormInstanceId { get; set; }
        public Int64 FormTemplateId { get; set; }
        public Int64 WorkflowId { get; set; }
        public string CreateTime { get; set; }
        public string CreateUser { get; set; }
        public string ModifyTime { get; set; }
        public string ModifyUser { get; set; }
        public string FormData { get; set; }
    }
}

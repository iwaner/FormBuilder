using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBuilder.DataModel
{
    public class FormInstanceModel : ModeBase
    {
        public Int64 FormInstanceId { get; set; }
        public Int64 FormTemplateId { get; set; }
        public Int64 WorkflowId { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime ModifyTime { get; set; }
        public string ModifyUser { get; set; }
    }
}

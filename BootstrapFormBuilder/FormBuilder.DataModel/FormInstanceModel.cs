using System;

namespace FormBuilder.DataModel
{
    public class FormInstanceModel : ModeBase
    {
        public Int64 FormInstanceId { get; set; }
        public Int64 FormTemplateId { get; set; }
        public string FormData { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime UpdateDate { get; set; }  
        public string UpdateUser { get; set; }

        public FormTemplateModel FormTemplateModel { get; set; }
    }
}

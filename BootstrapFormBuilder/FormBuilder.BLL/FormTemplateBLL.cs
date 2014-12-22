using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormBuilder.DataAccess;
using FormBuilder.DataModel;


namespace FormBuilder.BLL
{
    public class FormTemplateBLL
    {
        public FormTemplateModel GetFormInstance(Int64 formTemplateId)
        {
            var templateDal = new FormTemplateDAL();
            var templateMode = templateDal.GetFormTemplateByTemplateId(formTemplateId);
            return templateMode;
        }
    }
}

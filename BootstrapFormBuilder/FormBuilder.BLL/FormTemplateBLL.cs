using System;
using System.Collections.Generic;
using FormBuilder.DataAccess;
using FormBuilder.DataModel;


namespace FormBuilder.BLL
{
    public class FormTemplateBLL
    {
        public FormTemplateModel GetFormTemplate(Int64 formTemplateId)
        {
            var templateDal = new FormTemplateDAL();
            var templateMode = templateDal.GetFormTemplateByTemplateId(formTemplateId);
            return templateMode;
        }
        public FormTemplateModel AddOrUpdateFormTemplateModel(FormTemplateModel formTemplateModel)
        {
            var templateDal = new FormTemplateDAL();
            return templateDal.InsertOrUpdateFormTemplate(formTemplateModel);
        }

        public List<FormTemplateModel> GetFormTemplates()
        {
            var templateDal = new FormTemplateDAL();
            var templateMode = templateDal.GetFormTemplates();
            return templateMode;
        }
    }
}

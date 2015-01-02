using System;
using FormBuilder.DataAccess;
using FormBuilder.DataModel;

namespace FormBuilder.BLL
{
    public class FormInstanceBLL
    {
        public FormInstanceModel GetFormInstance(Int64 formInstanceId)
        {
            var instanceDal = new FormInstanceDAL();
            var instanceMode = instanceDal.GetFormInstanceById(formInstanceId);
            return instanceMode;
        }

        public FormInstanceModel InsertOrUpdateFormInstance(FormInstanceModel instanceModel)
        {
            var instanceDal = new FormInstanceDAL();
            var instanceMode = instanceDal.InsertOrUpdateFormInstance(instanceModel);
            return instanceMode;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}

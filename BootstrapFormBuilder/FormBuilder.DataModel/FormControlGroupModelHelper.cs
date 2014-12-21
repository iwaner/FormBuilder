using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormBuilder.DataModel
{
    public static class FormControlGroupModelHelper
    {
        static private DataTable MapIemsEventSubjectToDataTable(List<FormControlGroupModel> controlGroups)
        {
            var tb = new DataTable();
            tb.Columns.Add("ControlType", typeof(string));
            tb.Columns.Add("OrderInForm", typeof(int));
            tb.Columns.Add("FormFieldMapKey", typeof(string));
            tb.Columns.Add("ControlGroupTemplateModel", typeof(string));
            tb.Columns.Add("FormTemplateId", typeof(Int64));
            tb.Columns.Add("FormControlGroupPropertys", typeof(string));
            if (controlGroups != null && controlGroups.Count > 0)
            {
                foreach (var controlGroup in controlGroups)
                {
                    DataRow row = tb.NewRow();
                    row["ControlType"] = controlGroup.ControlType;
                    row["OrderInForm"] = controlGroup.OrderInForm;
                    row["FormFieldMapKey"] = controlGroup.FormFieldMapKey;
                    row["ControlGroupTemplateModel"] = controlGroup.ControlGroupTemplateModel;
                    row["FormTemplateId"] = controlGroup.FormTemplateId;
                    controlGroup.FormControlGroupPropertys = controlGroup.ToJason(controlGroup.ControlPropertys);
                    row["FormControlGroupPropertys"] = controlGroup.FormControlGroupPropertys;
                    tb.Rows.Add(row);
                }
            }
            return tb;
        }
    }
}

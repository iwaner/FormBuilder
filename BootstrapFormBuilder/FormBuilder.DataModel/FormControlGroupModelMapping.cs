using System;
using System.Collections.Generic;
using System.Data;

namespace FormBuilder.DataModel
{
    public static class FormControlGroupModelMapping
    {
        static public DataTable MapFormGroupModelToDataTable(List<FormControlGroupModel> controlGroups)
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
                    var row = tb.NewRow();
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

        static public List<FormControlGroupModel> MapDataTableToFormGroupModel(DataTable dt)
        {
            var controlGroups = new List<FormControlGroupModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var controlGroup = new FormControlGroupModel
                    {
                        ControlType = row["ControlType"].ToString(),
                        OrderInForm = row["OrderInForm"].ToString().ToInt(),
                        FormFieldMapKey = row["FormFieldMapKey"].ToString(),
                        ControlGroupTemplateModel = row["ControlGroupTemplateModel"].ToString(),
                        FormTemplateId = row["FormTemplateId"].ToString().ToInt64(),
                        FormControlGroupPropertys = row["FormControlGroupPropertys"].ToString()
                    };
                    controlGroup.ControlPropertys = controlGroup.FormControlGroupPropertys.ToModelBaseObject<FormControlGroupPropertyModel>();
                    controlGroups.Add(controlGroup);
                }
            }
            return controlGroups;
        }
    }
}

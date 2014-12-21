using System;

namespace FormBuilder.DataModel
{
    public class FormControlGroupPropertyModel : ModeBase
    {
        public Int64 ControlPropertyId { get; set; }

        public string ControlPropertyKey { get; set; }

        public string ControlPropertyValue { get; set; }

        public Int64 ControlGroupId { get; set; }

    }
}

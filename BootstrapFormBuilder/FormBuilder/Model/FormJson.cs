using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft;

namespace FormBuilder.Model
{
    /// <summary>
    /// 表单model(Json格式)
    /// </summary>
    public class FormModel
    {
        //public ControlSnipptCollection ControlCollection { get; set; }
        public List<ControlSnipptModel> ControlSnippts { get; set; }
    }

    //public class ControlSnipptCollection
    //{
    //    public List<ControlSnipptModel> ControlSnippts { get; set; }
    //}

    /// <summary>
    /// 控件类型
    /// </summary>
    public class ControlSnipptModel
    {
        /// <summary>
        /// input/select ...
        /// </summary>
        public string ControlType { get; set; }

        /// <summary>
        /// 在表单中的排序
        /// 
        /// </summary>
        public int OrderInForm { get; set; }

        /// <summary>
        /// 对应表单的某个字段的key，用来和表单保存的数据做关联
        /// 表单的数据将根据key还原到表单上（不同于控件的Id,这里的key是一个控件组的概念）
        /// </summary>
        public string FormFieldMapKey { get; set; }

        /// <summary>
        /// 控件的属相，属性值，格式为json
        /// </summary>
        public FormFieldDataJson FieldData { get; set; }
    }

    /// <summary>
    /// 控件的属性和属性值参考input.json
    /// </summary>
    public class FormFieldDataJson
    {
        public string ControlType { get; set; }

        /// <summary>
        /// 每种控件的field value 不尽相同，例如input和select是不同的，input只需要保存单个值，
        /// select需要保存所有选项的值和状态
        /// </summary>
        public string FieldValue { get; set; }

        
        #region Field value示例
          //  input-----------
          //   "id": {
          //  "type": "input",
          //  "label": "ID / Name",
          //  "value": "passwordinput"
          //}
        //  select-----------
          //  "inputsize": {
          //  "type": "select",
          //  "label": "Input Size",
          //  "value": [
          //    {
          //      "label": "Mini",
          //      "value": "input-mini",
          //      "selected": false
          //    },
          //    {
          //      "label": "Small",
          //      "value": "input-small",
          //      "selected": false
          //    },
          //    {
          //      "label": "Medium",
          //      "value": "input-medium",
          //      "selected": false
          //    },
          //    {
          //      "label": "Large",
          //      "value": "input-large",
          //      "selected": false
          //    },
          //    {
          //      "label": "Xlarge",
          //      "value": "input-xlarge",
          //      "selected": true
          //    },
          //    {
          //      "label": "Xxlarge",
          //      "value": "input-xxlarge",
          //      "selected": false
          //    }
          //  ]
          //}
        //}
        #endregion
        /// <summary>
        /// 根据控件类型获得不同格式的控件值
        /// </summary>
        /// <param name="ctrType"></param>
        /// <returns></returns>
        public string GetFieldValue(ControlTypeEnum ctrType)
        {
            string valueJsonStr = string.Empty;
            //根据控件类型返回不同格式的控件值
            switch (ControlTypeEnum.Input)
            {
                case ControlTypeEnum.Input:

                    break;
                case ControlTypeEnum.Select:
                    break;
                default:
                    break;
            }
            return valueJsonStr;
        }
    }

    public enum ControlTypeEnum
    { 
        Input,
        Select
    }
}
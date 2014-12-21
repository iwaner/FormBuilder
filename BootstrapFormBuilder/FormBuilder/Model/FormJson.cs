using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;

namespace FormBuilder.Model
{
    /// <summary>
    /// 表单模板model
    /// </summary>
    public class FormTemplateModelBak
    {
        public FormTemplateModelBak()
        {
            ControlGroups = new List<ControlGroupModelBak>();
        }

        public Int64 FormId { get; set; }

        public string FormName { get; set; }

        public List<ControlGroupModelBak> ControlGroups { get; set; }
    }

    /// <summary>
    /// 表单数据model
    /// </summary>
    public class FormInstanceModelBak
    {
        public FormInstanceModelBak()
        {
            DataFields = new List<FormFieldDataModelBak>();
        }


        /// <summary>
        /// 实例Id
        /// </summary>
        public Int64 FormInstanceId { get; set; }
        /// <summary>
        /// 表单对应的模板ID
        /// </summary>
        public Int64 FormTemplateId { get; set; }

        public List<FormFieldDataModelBak> DataFields{ get; set; }
    }

    /// <summary>
    /// 控件组类型，Form temlate级别，和一个form template记录挂钩，对于该template值来说，这个值是一样的
    /// 控件组：
    /// 一个控件组是若干个控件组合成的，在表单中作为最小的拖动/添加/移除单元，
    /// 一个控件组中有一个控件是表单业务数据真正保存和编辑的，这个控件有id，有data-attr表示控件是哪种业务数据（请假日期，请假天数）;
    /// 控件组的model:
    /// 一个控件组对应一个model{title:"",formFieldKey:"",orderInForm:1,fields:{}},model绑定到模板上，输出html
    /// 
    /// </summary>
    public class ControlGroupModelBak
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
        public string ControlGroupTemplateModel { get; set; }

        /// <summary>
        /// 根据控件类型获得不同格式的控件model格式
        /// </summary>
        /// <param name="ctrType"></param>
        /// <returns></returns>
        public string GetControlGroupTemplateModel(ControlTypeEnum ctrType)
        {
            string valueJsonStr = string.Empty;
            //根据控件类型返回不同格式的控件值
            switch (ControlTypeEnum.input)
            {
                case ControlTypeEnum.input:

                    break;
                case ControlTypeEnum.select:
                    break;
                default:
                    break;
            }
            return valueJsonStr;
        }

    }



    /// <summary>
    /// 表单真正的业务数据保存在此，和一个具体的form instance挂钩
    /// 控件的属性和属性值参考input.json
    /// </summary>
    public class FormFieldDataModelBak
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
      
    }

    public enum ControlTypeEnum
    { 
        input,
        select
    }
    /// <summary>
    /// 控件组类型
    /// </summary>
    public enum ControlGroupTypeEnum
    {
        textinput,
        passwordinput,
        searchinput,
        prependedtext,
        appendedtext,
        prependedcheckbox,
        appendedcheckbox,
        buttondropdown,
        textarea,

        multipleradios,
        multipleradiosinline,
        multiplecheckboxes,
        multiplecheckboxesinline,

        filebutton,
        singlebutton,
        doubleButton,

        selectbasic,
        selectmultiple,
    }
}
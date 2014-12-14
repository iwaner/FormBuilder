using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Model
{
    /// <summary>
    /// 表单模板表
    /// </summary>
    public class FormTemplate
    {
        public Int64 FormId { get; set; }
        public string FormName { get; set; }
        public string FormDescription { get; set; }
        /// <summary>
        /// varchar(max)表单的html模板
        /// 示例（有占位符）：<form class='form-horizontal span6' id='temp'><%= text %></form>
        /// </summary>
        public string FormHtmlTemplate { get; set; }

        /// <summary>
        /// 表单的model，json格式的字符串，结构为FormBuilder.Model.FormModel
        /// <form class='form-horizontal span6' id='temp'><%= text %></form>
        /// </summary>
        public string FormModel { get; set; }

        /// <summary>
        /// --int64对应一个工作流
        /// </summary>
        public Int64 WorkFlowId { get; set; }

        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime ModifyTime { get; set; }
        public string ModifyUser { get; set; }
    }
    /// <summary>
    /// 具体的表单实例，关联到具体某个workflow instan
    /// </summary>
    public class FormInstance
    {
        /// <summary>
        /// 实例Id
        /// </summary>
        public Int64 FormInstanceId { get; set; }
        /// <summary>
        /// 表单对应的模板ID
        /// </summary>
        public Int64 FormTemplateId { get; set; }
        /// <summary>
        /// --表单保存的数据，json格式
        /// </summary>
        public string FormData { get; set; }
        public Int64 WorkflowId { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime ModifyTime { get; set; }
        public string ModifyUser { get; set; }
    }

    /// <summary>
    /// 表单所用控件表
    /// </summary>
    public class FormControl
    {
        public Int32 ControlId { get; set; }
        /// <summary>
        /// 控件的类型,在表中的值是唯一的，比如：Input,passwordinput,button,single select
        /// </summary>
        public string ControlType { get; set; }
        /// <summary>
        ///控件html模板
        /// </summary>
        public string ControlTemplate { get; set;
            #region  示例：<!-- Button -->
            // 示例：<!-- Button -->
            //<div class="control-group">
            //  <label class="control-label" for="<%- id %>"><%- label %></label>
            //  <div class="controls">
            //    <button id="<%- id %>" name="<%- id %>" class='btn <%- buttontype %>'><%- buttonlabel %></button>
            //  </div>
            //</div>
            #endregion
        }
        /// <summary>
        /// 控件model，json格式的字符串,示例：
        /// </summary>
        public string ControlModel { get; set;
            #region ControlModel示例格式
            //          "fields": {
            //    "buttontype": {
            //      "type": "select",
            //      "label": "Button Type",
            //      "value": [
            //        {
            //          "label": "Default",
            //          "value": "btn-default",
            //          "selected": false
            //        },
            //        {
            //          "label": "Primary",
            //          "value": "btn-primary",
            //          "selected": true
            //        },
            //        {
            //          "label": "Info",
            //          "value": "btn-info",
            //          "selected": false
            //        },
            //        {
            //          "label": "Success",
            //          "value": "btn-success",
            //          "selected": false
            //        },
            //        {
            //          "label": "Warning",
            //          "value": "btn-warning",
            //          "selected": false
            //        },
            //        {
            //          "label": "Danger",
            //          "value": "btn-danger",
            //          "selected": false
            //        },
            //        {
            //          "label": "Inverse",
            //          "value": "btn-inverse",
            //          "selected": false
            //        }
            //      ]
            //    },
            //    "id": {
            //      "type": "input",
            //      "label": "ID / Name",
            //      "value": "singlebutton"
            //    },
            //    "label": {
            //      "type": "input",
            //      "label": "Label Text",
            //      "value": "Single Button"
            //    },
            //    "buttonlabel": {
            //      "type": "input",
            //      "label": "Button Label",
            //      "value": "Button"
            //    }
            //  },
            //  "title": "Single Button"
            //}

            #endregion
        }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime ModifyTime { get; set; }
        public string ModifyUser { get; set; }
    }
    /// <summary>
    /// 表单操作日志
    /// </summary>
    public class FormTemplateHistory
    {
        public Int64 FormId { get; set; }
        public string FormName { get; set; }
        public string FormDescription { get; set; }
        /// <summary>
        /// varchar(max)表单的html模板
        /// 示例（有占位符）：<form class='form-horizontal span6' id='temp'><%= text %></form>
        /// </summary>
        public string FormTemplate { get; set; }

        /// <summary>
        /// 表单的model，json格式的字符串
        /// <form class='form-horizontal span6' id='temp'><%= text %></form>
        /// </summary>
        public string FormModel { get; set; }

        /// <summary>
        /// 表单的实际html格式(辅助使用)
        /// </summary>
        public string FormHtml { get; set; }
        /// <summary>
        /// --int64对应一个工作流
        /// </summary>
        public Int64 WorkflowId { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        /// <summary>
        /// 增删改查
        /// </summary>
        public string OperationType { get; set; }
    }
}
/*
此model通过给全局变量赋值用来保存页面中的全局数据
*/
define([
      'jquery', 'underscore', 'backbone'
      , "text!data/buildform.json", "text!data/forminstance.json"
      , "collections/save-form-snippets"
], function (
  $, _, Backbone
  , buildFormJSON,formInstanceJSON
  , SaveFormSnippetCollection
) {
    return {
        initialize: function () {
            g_globalModel = {};
            //if(!g_globalModel.GlobalModelRef)
            //{
            //  g_globalModel.GlobalModelRef=this;//将当前model加入全局变量
            //}
            g_globalModel.FormTemplate = JSON.parse(buildFormJSON);//表单模板保存的结构（和数据库对应）
            g_globalModel.FormData = JSON.parse(formInstanceJSON);//表单数据保存的结构（和数据库对应）
            this.FormTemplate = JSON.parse(buildFormJSON);
            this.saveFormControlGroups = new SaveFormSnippetCollection();
        }
        //保存表单的数据，此数据将被传回服务器
    , FormTemplate: {}
    , setFormName: function (formName) {
        g_globalModel.FormTemplate.FormTemplateData.FormName = formName;
    }
        //,setControlGroups:function (ctrGroups) {
        //  g_globalModel.FormTemplate.FormTemplateData.ControlGroups=ctrGroups;
        //}
    , addControlGroup: function (ctrGroup) {
        this.saveFormControlGroups.add(ctrGroup);
        //g_globalModel.FormTemplate.FormTemplateData.ControlGroups.push(ctrGroup);
    }
    , removeControlGroup: function (ctrGroup) {
        this.saveFormControlGroups.remove(ctrGroup);
    }
    , saveFormControlGroups: {}
    , saveFormTempalte: function () {
        /**/
        //保存model到全局变量
        //formTemplateData
        var ctrGroups = this.saveFormControlGroups.models;
        var postData=this.buildFormTemplateForPostJson(ctrGroups);
        $("#formTemplateData").val(JSON.stringify(postData));
        /*
        $.ajax({
            type: "post",
            url: "../FormBuilderMainajax.aspx",
            data: postData,
            contentType: "text/json;",
            success: function () {
                alert("保存表单模板");
            }
        });
*/
    }
    , saveFormData: function (formData) {
        //保存表单数据
        var postData=this.buildFormDataForPostJson(formData);
        $("#formDataJsonText").val(JSON.stringify(postData));
        $.ajax({
            type: "post",
            url: "../FormBuilderMainajax.aspx",
            data: postData,
            contentType: "text/json;",
            success: function () {
                alert("保存表单数据");
            }
        });
    }
    , buildFormTemplateForPostJson: function (ctrGroups) {
       g_globalModel.FormTemplate.FormTemplateData.ControlGroups=ctrGroups;
       return g_globalModel.FormTemplate;
    }
    , buildFormDataForPostJson: function (dataFields) {
       g_globalModel.FormData.DataFields=dataFields;
       return g_globalModel.FormData;
    }
   
    };
});
//postData.FormTemplateData.FormTemplateData.ControlGroups
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
            g_globalModel.FormDataPost = JSON.parse(formInstanceJSON);//表单数据保存的结构（和数据库对应）
            this.FormTemplate = JSON.parse(buildFormJSON);
            this.formControlGroupsToSave = new SaveFormSnippetCollection();
        }
        //保存表单的数据，此数据将被传回服务器
        , FormTemplate: {}
        , addControlGroup: function (ctrGroup,options) {
             this.formControlGroupsToSave.add(ctrGroup,options);
            //g_globalModel.FormTemplate.FormTemplateData.ControlGroups.push(ctrGroup);
        }
        , removeControlGroup: function (ctrGroup,options) {
            this.formControlGroupsToSave.remove(ctrGroup);
        }
        , formControlGroupsToSave: {
           
        }
        , saveFormTempalte: function () {
            /**/
            //保存model到全局变量
            //formTemplateData
            if(g_globalModel.MyFormViewRef)
            {
                this.formControlGroupsToSave=new SaveFormSnippetCollection(g_globalModel.MyFormViewRef.collection.toJSON());
            }
            var ctrGroups = this.formControlGroupsToSave.models;
            var postData = this.buildFormTemplateForPostJson(ctrGroups);
            var templateJson = JSON.stringify(postData);
            $("#formTemplateData").val(templateJson);
            $.ajax({
                type: "post",
                url: "../../FormBuilderMainajax.aspx",
                data: templateJson,
                contentType: "text/json;",
                success: function () {
                    alert("保存表单模板");
                }
            });
        }
        , saveFormData: function (formData) {
            //保存表单数据
            var postData = this.buildFormDataForPostJson(formData);
                var instanceJson = JSON.stringify(postData);
                $("#formDataJsonText").val(instanceJson);
            $.ajax({
                type: "post",
                url: "../../FormInstanceajax.aspx",
                data: instanceJson,
                contentType: "text/json;",
                success: function () {
                    alert("保存表单数据");
                }
            });
        }
        , buildFormTemplateForPostJson: function (ctrGroups) {//构建表结构对应的post数据
           g_globalModel.FormTemplate.FormTemplateData.ControlGroups=ctrGroups;
           if(ctrGroups&&ctrGroups.length>0)
           {
                if(ctrGroups[0].get("title")=="Form Name")
                {
                    var formName=ctrGroups[0].get("fields").name.value;
                    var formDesc=ctrGroups[0].get("fields").description.value;
                    g_globalModel.FormTemplate.FormName=formName;
                    g_globalModel.FormTemplate.FormDescription=formDesc;
                    g_globalModel.FormTemplate.FormTemplateData.FormName=formName;
                    g_globalModel.FormTemplate.FormTemplateData.FormDescription=formDesc;
                }
           }
           var formSnippet=ctrGroups[0];

           return g_globalModel.FormTemplate;
        }
        , buildFormDataForPostJson: function (formData) {//构建表结构对应的post数据
           g_globalModel.FormDataPost.FormData = formData;
           return g_globalModel.FormDataPost;
           /*
             {
    "FormInstanceId":"0",
    "FormTemplateId":"0",
    "WorkflowId":"0",
    "FormData":{
      "DataFields": [{
        "ControlType": "",
        "ControlGroupType":"",
        "FormFieldMapKey":"",
        "FieldValue": ""
        }
      ]
    }
  }
           */
        }
   
    };
});
//postData.FormTemplateData.FormTemplateData.ControlGroups
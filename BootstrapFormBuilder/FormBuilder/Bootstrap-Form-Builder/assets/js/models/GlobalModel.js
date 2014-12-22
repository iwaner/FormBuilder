/*
此model通过给全局变量赋值用来保存页面中的全局数据
*/
define([
      'jquery', 'underscore', 'backbone'
      ,"text!data/buildform.json"
      ,"collections/save-form-snippets"
], function(
  $, _, Backbone
  ,buildFormJSON
  ,SaveFormSnippetCollection
) {
    return {
    initialize: function() {
      g_globalModel={};
      g_globalModel.GlobalModelRef=this;
      g_globalModel.FormTemplate=JSON.parse(buildFormJSON);
      this.FormTemplate=JSON.parse(buildFormJSON);
      this.saveFormControlGroups=new SaveFormSnippetCollection();
    }
    //保存表单的数据，此数据将被传回服务器
    , FormTemplate: {}
    ,setFormName:function (formName) {
      g_globalModel.FormTemplate.FormTemplateData.FormName=formName;
    }
    //,setControlGroups:function (ctrGroups) {
    //  g_globalModel.FormTemplate.FormTemplateData.ControlGroups=ctrGroups;
    //}
    ,addControlGroup:function (ctrGroup) {
      this.saveFormControlGroups.push(ctrGroup);
      //g_globalModel.FormTemplate.FormTemplateData.ControlGroups.push(ctrGroup);
    }
    ,removeControlGroup:function (ctrGroup) {
     
    }
    ,saveFormControlGroups:{}
    ,save: function (){
      /**/
    	//保存model到全局变量
      //formTemplateData
      $("#formTemplateData").val(JSON.stringify(this.saveFormControlGroups.models));
      //console.log(JSON.stringify(g_globalModel.FormTemplate));
    }
};
});

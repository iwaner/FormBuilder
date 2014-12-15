var g_globalModel={};

/*
此model通过给全局变量赋值用来保存页面中的全局数据
*/
define([
      'jquery', 'underscore', 'backbone'
      ,"models/FormSaveModel"
], function(
  $, _, Backbone
  ,FormSaveModel
) {
    return Backbone.Model.extend({
    initialize: function() {
     
    }
    //保存表单的数据，此数据将被传回服务器
    , formSaveModel: new FormSaveModel());
    ,save: function (){
    	//保存model到全局变量
    	g_globalModel.FormSaveModel=this.formSaveModel;
    }
});

/*
保存表单的数据，此数据将被传回服务器
*/
define([
      'jquery', 'underscore', 'backbone'
], function($, _, Backbone) {
  return Backbone.Model.extend({
    initialize: function() {
     	this.intialFormData();
    }
    //保存表单的数据，此数据将被传回服务器
    , FormSaveModel: {}
    ,intialFormData:function(){
    	this.FormSaveModel=
    	{
	    	ControlSnippts:[
	    	{
	    		ControlType:"input"
	    		,OrderInForm:"1"
	    		,FormFieldMapKey:"input1"
	    		,FieldData:{}
	    	},
	    	{
	    		ControlType:"input"
	    		,OrderInForm:"2"
	    		,FormFieldMapKey:"input2"
	    		,FieldData:{}
	    	}
	    	]

	    }

    }
    );
});

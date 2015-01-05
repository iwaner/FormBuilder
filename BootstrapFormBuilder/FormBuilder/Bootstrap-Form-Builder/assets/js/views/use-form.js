/*
表单instance填写的view
*/
define([
       "jquery", "underscore", "backbone"
      , "views/temp-snippet"
      , "helper/pubsub"
      , "text!templates/app/renderform.html"
      ,"models/test"
      ,"collections/my-form-snippets","views/my-form"
], function(
  $, _, Backbone
  , TempSnippetView
  , PubSub
  , _renderForm
  ,testModel
  ,MyFormSnippetsCollection,MyFormView
){
  return Backbone.View.extend({
    tagName: "fieldset"
    , initialize: function(){
      this.collection.on("add", this.render, this);
      this.collection.on("remove", this.render, this);
      var that=this;
      $("#saveFormData").bind("click", function (argument) {
          //保存表单数据
          //hide all popovers
          $(".popover").hide();
          that.saveFormData();

      });
      $("#loadFormData").bind("click", function (argument) {
          //加载表单数据
          //hide all popovers
          $(".popover").hide();
          var formData=JSON.parse($("#formDataJsonText").val()).FormData;
          that.loadFormData(formData);

      });
      this.renderForm = _.template(_renderForm);
      this.render();
    }
    , render: function(){
      //Render Snippet Views
      this.$el.empty();
      var that = this;
      _.each(this.collection.renderAll(), function(snippet){
        that.$el.append(snippet);
      });
      this.delegateEvents();
 
    }
    , saveFormData:function(){//保存表单数据
      
      
    }
    , loadFormData: function (formData) {//加载表单数据
      
    }
  })

});
/*
//获取第一个option的值
$('#test option:first').val();

//最后一个option的值
$('#test option:last').val();

//获取第二个option的值
$('#test option:eq(1)').val();

//获取选中的值
$('#test').val();
$('#test option:selected').val();

//设置值为2的option为选中状态
$('#test').attr('value','2');

//设置最后一个option为选中
$('#test option:last').attr('selected','selected');
$("#test").attr('value' , $('#test option:last').val());
$("#test").attr('value' , $('#test option').eq($('#test option').length - 1).val());

//获取select的长度
$('#test option').length;

//添加一个option
$("#test").append("<option value='n+1'>第N+1项</option>");
$("<option value='n+1'>第N+1项</option>").appendTo("#test");

//添除选中项
$('#test option:selected').remove();

//删除项选中(这里删除第一项)
$('#test option:first').remove();、

//指定值被删除
$('#test option').each(function(){
    if( $(this).val() == '5'){
         $(this).remove();
     }
});
$('#test option[value=5]').remove();

//获取第一个Group的标签
$('#test optgroup:eq(0)').attr('label');

//获取第二group下面第一个option的值
$('#test optgroup:eq(1) : option:eq(0)').val();
 */
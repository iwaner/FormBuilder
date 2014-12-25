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
      console.log("saveFormData");
      //hide all popovers
      $(".popover").hide();
      //获取表单中的业务数据控件
      var dataControls=$("#useForm [data-isbizfield='true']");
      var dataFields=_.map(dataControls, function(v,k){
        var controlType=$(v).attr("data-controltype");
        var fieldValue="";
        switch(controlType) {
            case "checkbox":
              //boundContext.model.setField(name, $e.is(":checked"));
              break;
            case "input":
              //boundContext.model.setField(name, $e.val());
              fieldValue=e.val();
              break;
            case "textarea":
              //boundContext.model.setField(name, $e.val());
              fieldValue=e.val();
              break;
            case "textarea-split":
            /*
              boundContext.model.setField(name,
                _.chain($e.val().split("\n"))
                  .map(function(t){return $.trim(t)})
                  .filter(function(t){return t.length > 0})
                  .value()
                  );
*/
              break;
            case "select":
            /*
              var valarr = _.map($e.find("option"), function(e){
                return {value: e.value, selected: e.selected, label:$(e).text()};
              });
              boundContext.model.setField(name, valarr);
              */
              break;
          }

        return {
        //"ControlType": "",
        //"ControlGroupType":"",
        "FormFieldMapKey":v.attr("data-formfieldmapkey"),
        "FieldValue": fieldValue
        };
      });
      g_globalModel.GlobalModelRef.saveFormData(null);
    
    }
  })

});


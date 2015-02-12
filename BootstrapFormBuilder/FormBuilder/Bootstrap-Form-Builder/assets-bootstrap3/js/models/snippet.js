define([
      'jquery', 'underscore', 'backbone'
], function($, _, Backbone) {
  return Backbone.Model.extend({
    initialize: function() {
      this.set("fresh", true);
    }
    , getValues: function(){
      //获取控件模板model中真正的数据部分（即fields字段的各个属性）
      var modelValues=_.reduce(this.get("fields"), function(o, v, k){
        if (v["type"] == "select") {
          o[k] = _.find(v["value"], function(o){return o.selected})["value"];
        } else {
          o[k]  = v["value"];
        }
        return o;
      }, {});
      //添加一些额外的字段给model用于模板绑定
      modelValues["controltype"]=this.get("ControlType");
      modelValues["OrderInForm"]=this.get("OrderInForm");
      modelValues["FormFieldMapKey"]=this.get("FormFieldMapKey");
      modelValues["ControlGroupType"]=this.get("ControlGroupType");
      modelValues["fieldvalue"]=this.get("fieldvalue");
      if($("#isFormEditable").val()=="false")
      {
        modelValues["iseditable"]=false;
      }
      return modelValues;
    }
    , idFriendlyTitle: function(){//移除非单词字符后的title：字符数字之外的字符
      return this.get("title").replace(/\W/g,'').toLowerCase();
    }
    , setField: function(name, value) {
      var fields = this.get("fields")
      fields[name]["value"] = value;
      this.set("fields", fields);
    }
    , getField: function(name) {
      var fields = this.get("fields")
      if(fields[name])
      {
        return fields[name]["value"];
      }
      else
      {
        return null;
      }
    }
    , setFieldMapKey: function(value) {
      this.set("FormFieldMapKey", value);
    }

  });
});

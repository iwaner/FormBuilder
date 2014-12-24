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
      //modelValues["iseditable"]=this.get("IsEditable");
      modelValues["OrderInForm"]=this.get("OrderInForm");
      modelValues["FormFieldMapKey"]=this.get("FormFieldMapKey");
      modelValues["ControlGroupType"]=this.get("ControlGroupType");

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
  });
});

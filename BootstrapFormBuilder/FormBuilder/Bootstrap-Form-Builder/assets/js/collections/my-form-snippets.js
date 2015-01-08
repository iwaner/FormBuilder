define([
       "jquery" , "underscore" , "backbone"
       , "models/snippet"
       , "collections/snippets"
       , "views/my-form-snippet"
], function(
  $, _, Backbone
  , SnippetModel
  , SnippetsCollection
  , MyFormSnippetView
){
  return SnippetsCollection.extend({
    model: SnippetModel
    , initialize: function() {
      this.counter = {};
      this.nameCounter = {};
      this.fieldkeyCounter = {};
      this.on("add", this.giveUniqueId);
    }

    , giveUniqueId: function(snippet){
      if(!snippet.get("fresh")) {
        return;
      }
      snippet.set("fresh", false);
      var snippetType = snippet.attributes.fields.id ? snippet.attributes.fields.id.value : snippet.attributes.fields.name.value;

      if(typeof this.counter[snippetType] === "undefined") {
        this.counter[snippetType] = 0;
      } else {
        this.counter[snippetType] += 1;
      }
      if(snippet.getField("id"))
      {
        snippet.setField("id", snippetType + "-" + this.counter[snippetType]);
      }
      
      //给控件赋予唯一的业务数据字段key
      snippet.setFieldMapKey(snippetType + "-" + this.counter[snippetType]);
      //如果是radion/checkbox，给它们的(group) name赋值,保证没一个checkbox和radion控件有自己独立的group
      if(snippet.getField("name"))
      {
        snippet.setField("name", snippetType + "-" + this.counter[snippetType]);
      }
      
    }
    , giveUniqueName: function(snippet){
      if(!snippet.get("fresh")) {
        return;
      }
      snippet.set("fresh", false);
      var snippetType = snippet.attributes.fields.name.value;

      if(typeof this.counter[snippetType] === "undefined") {
        this.nameCounter[snippetType] = 0;
      } else {
        this.nameCounter[snippetType] += 1;
      }
      //如果是radion/checkbox，给它们的(group) name赋值,保证没一个checkbox和radion控件有自己独立的group
      snippet.setField("name", snippetType + "-" + this.nameCounter[snippetType]);
      //给控件赋予唯一的业务数据字段key
      snippet.setFieldMapKey(snippetType + "-" + this.nameCounter[snippetType]);
     
    }
    , renderAll: function(){
      return this.map(function(snippet){
        return new MyFormSnippetView({model: snippet}).render(true);
      })
    }
    , renderAllClean: function(){
      return this.map(function(snippet){
        return new MyFormSnippetView({model: snippet}).render(false);
      });
    }
  });
});

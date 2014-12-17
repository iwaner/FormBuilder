//表单设计器的view
define([
       "jquery", "underscore", "backbone"
      , "views/temp-snippet"
      , "helper/pubsub"
      , "text!templates/app/renderform.html"
      ,"models/test","models/GlobalModel"
      ,"collections/my-form-snippets","views/my-form"
], function(
  $, _, Backbone
  , TempSnippetView
  , PubSub
  , _renderForm
  ,testModel,GlobalModel
  ,MyFormSnippetsCollection,MyFormView
){
  return Backbone.View.extend({
    tagName: "fieldset"
    , initialize: function(){
      this.collection.on("add", this.render, this);
      this.collection.on("remove", this.render, this);
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
  })
});


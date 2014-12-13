define([
       "jquery", "underscore", "backbone"
       , "models/snippet"
       , "views/snippet", "views/temp-snippet"
       , "helper/pubsub"
], function(
  $, _, Backbone
  , SnippetModel
  , SnippetView, TempSnippetView
  , PubSub
){//tab-snippet扩展(继承)了snippet
  return SnippetView.extend({
    events:{
      "mousedown" : "mouseDownHandler"
    }
    , mouseDownHandler: function(mouseDownEvent){
      mouseDownEvent.preventDefault();
      mouseDownEvent.stopPropagation();
      //hide all popovers
      $(".popover").hide();
      $("body").append(new TempSnippetView({model: new SnippetModel($.extend(true,{},this.model.attributes))}).render());
      PubSub.trigger("newTempPostRender", mouseDownEvent);
    }
  });
});

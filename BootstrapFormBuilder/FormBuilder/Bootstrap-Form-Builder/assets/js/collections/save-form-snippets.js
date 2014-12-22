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
  //表单保存
  return SnippetsCollection.extend({
    model: SnippetModel
    , initialize: function() {
 
    }


  });
});

define([
      'jquery', 'underscore', 'backbone'
], function($, _, Backbone) {
  return Backbone.Model.extend({
    initialize: function() {
    }
    , name:"Initial name"
    ,setName: function (e){
      this.name=e;
    }
  });
});

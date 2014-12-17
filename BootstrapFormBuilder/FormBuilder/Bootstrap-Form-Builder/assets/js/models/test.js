define([
      'jquery', 'underscore', 'backbone'
], function($, _, Backbone) {
  return {
    initialize: function() {
    }
    , name:"Initial name"
    ,setName: function (e){
      this.name=e;
    }
  };
});

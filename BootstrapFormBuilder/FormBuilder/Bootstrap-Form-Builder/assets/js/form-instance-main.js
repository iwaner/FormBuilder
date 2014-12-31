require.config({
    baseUrl: "assets/js/lib/"
  , shim: {
      'backbone': {
          deps: ['underscore', 'jquery'],
          exports: 'Backbone'
      },
      'underscore': {
          exports: '_'
      },
      'bootstrap': {
          deps: ['jquery'],
          exports: '$.fn.popover'
      }
  }
  , paths: {
      app: ".."
    , collections: "../collections"
    , data: "../data"
    , models: "../models"
    , helper: "../helper"
    , templates: "../templates"
    , views: "../views"
  }
});
require(['models/GlobalModel','app/form-instance'], function (globalModual,formInstance) {
    globalModual.initialize();//需要比formInstance先初始化
    formInstance.initialize();

});

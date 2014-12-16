define([
       "jquery" , "underscore" , "backbone"
       , "collections/snippets" , "collections/my-form-snippets"
       , "views/tab" , "views/my-form"
       , "text!data/input.json", "text!data/radio.json", "text!data/select.json", "text!data/buttons.json"
       , "text!templates/app/render.html",  "text!templates/app/about.html", "text!templates/app/user-doc.html","text!templates/app/preview.html"
       ,"models/test"
], function(
  $, _, Backbone
  , SnippetsCollection, MyFormSnippetsCollection
  , TabView, MyFormView
  , inputJSON, radioJSON, selectJSON, buttonsJSON
  , renderTab, aboutTab,userDocTab,preViewTab
  ,testModel
){
  return {
    initialize: function(){
      /*
      var testM=new testModel();
      console.log(testM.name);
      testM.setName("New name");
      console.log(testM.name);
      console.log(testModel);
      console.log(typeof testModel);
      console.log(testModel.constructor);
      console.log(testModel.prototype);
      */
      //Bootstrap tabs from json.
      new TabView({
        title: "Input文本框"
        , collection: new SnippetsCollection(JSON.parse(inputJSON))
      });
      new TabView({
        title: "Radios / Checkboxes单选/复选框"
        , collection: new SnippetsCollection(JSON.parse(radioJSON))
      });
      new TabView({
        title: "Select下拉选择"
        , collection: new SnippetsCollection(JSON.parse(selectJSON))
      });
      new TabView({
        title: "Buttons按钮"
        , collection: new SnippetsCollection(JSON.parse(buttonsJSON))
      });
      new TabView({
        title: "Rendered生成代码"
        , content: renderTab
      });
      new TabView({
        title: "PreView表单预览"
        , content: preViewTab
      });

      new TabView({
        title: "About关于"
        , content: aboutTab
      });
      /**/
      new TabView({
        title: "UserDoc用户文档"
        , content: userDocTab
      });
      
      //Make the first tab active!
      $("#components .tab-pane").first().addClass("active");
      $("#formtabs li").first().addClass("active");
      // Bootstrap "My Form" with 'Form Name' snippet.
      new MyFormView({
        title: "Original"
        , collection: new MyFormSnippetsCollection([
          { "title" : "Form Name"
            , "fields": {
              "name" : {
                "label"   : "Form Name"
                , "type"  : "input"
                , "value" : "Form Name"
              }
            }
          }
        ])
      });
    }
  }
});

//console.log(appModual);
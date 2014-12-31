define([
       "jquery" , "underscore" , "backbone"
       , "collections/snippets" , "collections/my-form-snippets"
       , "views/tab" , "views/my-form"
       , "text!data/input.json", "text!data/radio.json", "text!data/select.json", "text!data/buttons.json"
       , "text!templates/app/render.html",  "text!templates/app/about.html", "text!templates/app/user-doc.html","text!templates/app/preview.html","text!templates/app/viewFormTemplateData.html"
       ,"models/test","models/GlobalModel"
], function(
  $, _, Backbone
  , SnippetsCollection, MyFormSnippetsCollection
  , TabView, MyFormView
  , inputJSON, radioJSON, selectJSON, buttonsJSON
  , renderTab, aboutTab,userDocTab,preViewTab,formTemplateDataTab
  ,testModel,GlobalModel
){
  return {
    initialize: function(){
      //初始化话global变量
      if(!g_globalModel.GlobalModelRef)
      {
        g_globalModel.GlobalModelRef=GlobalModel;
        //将当前model加入全局变量
      }

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
        title: "Rendered代码"
        , content: renderTab
      });
      new TabView({
        title: "PreView表单预览"
        , content: preViewTab
      });
      new TabView({
        title: "ViewFormTemplateData表单模板数据"
        , content: formTemplateDataTab
      });

      /*
      new TabView({
        title: "About关于"
        , content: aboutTab
      });
      */
      new TabView({
        title: "UserDoc帮助文档"
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
                , "value" : "表单名称"
              },
              "description" : {
                "label"   : "Form Description"
                , "type"  : "input"
                , "value" : "表单描述"
              }
              
            }
          }
        ])
      });
      
      
    }
  }
});
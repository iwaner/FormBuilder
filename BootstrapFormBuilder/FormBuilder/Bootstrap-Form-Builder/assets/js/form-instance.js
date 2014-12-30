define([
       "jquery", "underscore", "backbone"
       , "collections/snippets", "collections/my-form-snippets"
       , "views/tab", "views/my-form", "views/use-form"
       , "text!data/input.json", "text!data/radio.json", "text!data/select.json", "text!data/buttons.json"
       , "text!templates/app/render.html", "text!templates/app/about.html", "text!templates/app/user-doc.html", "text!templates/app/preview.html", "text!templates/app/viewFormTemplateData.html"
       , "models/test", "models/GlobalModel"
], function (
  $, _, Backbone
  , SnippetsCollection, MyFormSnippetsCollection
  , TabView, MyFormView, UseFormView
  , inputJSON, radioJSON, selectJSON, buttonsJSON
  , renderTab, aboutTab, userDocTab, preViewTab, formTemplateDataTab
  , testModel, GlobalModel
) {
    return {
        initialize: function () {
            this.loadFormInstance();

        },
        loadFormInstance: function(){
            //////////使用表单
            $("#btnUseForm").bind("click", function (argument) {
                //hide all popovers
                $(".popover").hide();
                var userFormTabIndex = $("#viewformtemplatedata").index();
                $("#formtabs li").eq(userFormTabIndex).find("a").tab('show');
                //将保存的表单数据展示为form
                var useformView = new UseFormView({
                    title: "Original"
            , collection: new MyFormSnippetsCollection(JSON.parse($("#formTemplateData").val()).FormTemplateData.ControlGroups)
                });
                $("#useForm").html(useformView.renderForm({
                    text: _.map(useformView.collection.renderAllClean(), function (e) { return e.html() }).join("\n")
                }));

            });
        }
    }
});
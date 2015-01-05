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
            //初始化话global变量
            if (!g_globalModel.GlobalModelRef) {
                g_globalModel.GlobalModelRef = GlobalModel;
                //将当前model加入全局变量
            }
            this.loadFormInstance();
        },
        loadFormInstance: function () {

            var that = this;
            $("#saveFormData").bind("click", function (argument) {
                //保存表单数据
                //hide all popovers
                $(".popover").hide();
                that.saveFormData();

            });
            $("#loadFormData").bind("click", function (argument) {
                //加载表单数据
                //hide all popovers
                $(".popover").hide();
                var formData = JSON.parse($("#formDataJsonText").val()).FormData;
                that.loadFormData(formData);
            });
            $("#renderFormWithData").bind("click", function (argument) {
                var ctrGroups=that.getFormViewCollection();
                var useformView = new UseFormView({
                    title: "Original"
                , collection: new MyFormSnippetsCollection(ctrGroups)
                });
                $("#useForm").html(useformView.renderForm({
                    text: _.map(useformView.collection.renderAllClean(), function (e) { return e.html() }).join("\n")
                }));
            });
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
            this.ShowInstance();
        },
        ShowInstance: function () {
            var templateId = getQueryStringByName("templateId");
            var instanceId = getQueryStringByName("instanceId");
            $.ajax({
                type: "get",
                url: "FormInstance.aspx/ShowInstance",
                data: "{instanceId:'" + instanceId + "',templateId:'" + templateId + "}",
                contentType: "text/json;",
                success: function (result) {
                    if (result != null && result.d != null && result.d != "") {
                        $("#formTemplateData").val(result.d[1]);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(XMLHttpRequest.status);
                    alert(XMLHttpRequest.readyState);
                    alert(textStatus);
                },
            });
            function getQueryStringByName(name) {
                var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
                if (result == null || result.length < 1) {
                    return "";
                }
                return decodeURIComponent(result[1]);
            }
        }
        , saveFormData: function () {//保存表单数据
            //获取表单中的业务数据控件
            var dataControls = $("#useForm [data-isbizfield='true']");
            //取出表单数据
            var dataFields = _.map(dataControls, function (v, k) {
                var controlType = $(v).attr("data-controltype");
                var formfieldmapkey = $(v).attr("data-formfieldmapkey");
                var fieldValue = "";
                switch (controlType) {
                    case "checkbox":
                        var checkboxItems=$(v).find(":checkbox");
                        var valarr = _.map($(v).find(":checkbox"), function (e) {
                            return { value: e.value, selected: $(e).is(":checked") };
                        });
                        fieldValue = valarr;
                        break;
                    case "input":
                        //boundContext.model.setField(name, $e.val());
                        fieldValue = $(v).val();
                        break;
                    case "textarea":
                        //boundContext.model.setField(name, $e.val());
                        fieldValue = $(v).val();
                        break;
                    case "textarea-split":
                        /*
                          boundContext.model.setField(name,
                            _.chain($e.val().split("\n"))
                              .map(function(t){return $.trim(t)})
                              .filter(function(t){return t.length > 0})
                              .value()
                              );
              */
                        break;
                    case "select":
                        /**/
                        var valarr = _.map($(v).find("option"), function (e) {
                            return { value: e.value, selected: e.selected };
                        });
                        fieldValue = valarr;

                        break;
                }

                return {
                    //"ControlType": "",
                    //"ControlGroupType":"",
                    "FormFieldMapKey": formfieldmapkey,
                    "FieldValue": fieldValue
                };
            });
            g_globalModel.GlobalModelRef.saveFormData({ "DataFields": dataFields, "FormInstanceId": 0, "FormTemplateId": 0 });

        }
      , getFormViewCollection: function(){//获得表单的model

          return JSON.parse($("#loadFormDataJsonText").val());
      }
      , loadFormData: function (formData) {//加载表单数据
          var formTemplateStr = $("#formTemplateData").val();
          var formTemplateModel = JSON.parse(formTemplateStr);
          var ctrGroups = formTemplateModel.FormTemplateData.ControlGroups;
          _.each(ctrGroups, function (ctrGroup) {
            if(ctrGroup["title"]!="Form Name")
            {
              var fieldKey = ctrGroup["FormFieldMapKey"];
              var fieldVal = _.findWhere(formData.DataFields, { "FormFieldMapKey": fieldKey })["FieldValue"];
              ctrGroup["fieldvalue"]=fieldVal;
            }
            
          });
          $("#loadFormDataJsonText").val(JSON.stringify(ctrGroups));
          //获取表单中的业务数据控件
          /*
          var dataControls = $("#useForm [data-isbizfield='true']");
          _.each(dataControls, function (dataCtr) {
              var fieldKey = $(dataCtr).attr("data-formfieldmapkey");
              var fieldVal = _.findWhere(formData.DataFields, { "FormFieldMapKey": fieldKey });
              var controlType = $(dataCtr).attr("data-controltype");
              switch (controlType) {
                  case "checkbox":
                      //dataCtr.model.setField(name, $e.is(":checked"));
                      break;
                  case "input":
                      dataCtr.val(fieldVal);
                      break;
                  case "textarea":
                      dataCtr.val(fieldVal);
                      break;
                  case "textarea-split":
                      dataCtr.val(fieldVal);
                      break;
                  case "select":
                      break;
              }
          });
*/
      }
    }
});
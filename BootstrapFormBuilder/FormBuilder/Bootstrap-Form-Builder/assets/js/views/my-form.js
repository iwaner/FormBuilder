//表单设计器的view
define([
       "jquery", "underscore", "backbone"
      , "views/temp-snippet"
      , "helper/pubsub"
      , "text!templates/app/renderform.html"
      ,"models/test"
      ,"collections/my-form-snippets","views/my-form","views/use-form"
], function(
  $, _, Backbone
  , TempSnippetView
  , PubSub
  , _renderForm
  ,testModel
  ,MyFormSnippetsCollection,MyFormView,UseFormView
){
  return Backbone.View.extend({
    tagName: "fieldset"
    , initialize: function(){
      this.collection.on("add", this.render, this);
      this.collection.on("remove", this.render, this);
      this.collection.on("change", this.render, this);
      PubSub.on("mySnippetDrag", this.handleSnippetDrag, this);
      PubSub.on("tempMove", this.handleTempMove, this);
      PubSub.on("tempDrop", this.handleTempDrop, this);

      //////////保存表单(之后考虑已backcone的事件定义方式来实现)
      $("#saveForm").bind("click", function (argument) {
          //hide all popovers
          $(".popover").hide();
          var userFormTabIndex=$("#viewformtemplatedata").index();
          $("#formtabs li").eq(userFormTabIndex).find("a").tab('show');

          g_globalModel.GlobalModelRef.saveFormTempalte();
        });
       //////////使用表单
      $("#btnUseForm").bind("click", function (argument) {
        //hide all popovers
        $(".popover").hide();
        var userFormTabIndex=$("#viewformtemplatedata").index();
        $("#formtabs li").eq(userFormTabIndex).find("a").tab('show');
        //将保存的表单数据展示为form
        var useformView=new UseFormView({
            title: "Original"
            , collection: new MyFormSnippetsCollection(JSON.parse($("#formTemplateData").val()).FormTemplateData.ControlGroups)
          });
        $("#useForm").html(useformView.renderForm({
            text: _.map(useformView.collection.renderAllClean(), function (e) { return e.html() }).join("\n")
        }));

        });
      

      this.$build = $("#build");//待build的目标表单
      this.renderForm = _.template(_renderForm);
      this.render();
    }
    , render: function(){
      //Render Snippet Views
      this.$el.empty();
      var that = this;
      //el元素赋值
      _.each(this.collection.renderAll(), function(snippet){
        that.$el.append(snippet);
      });
      //展示比较干净的html(移除了某些html元素的自定义属性)
      $("#render").val(that.renderForm({
        text: _.map(this.collection.renderAllClean(), function(e){return e.html()}).join("\n")
      }));
      //表单预览
      $("#previewContent").html(that.renderForm({
          text: _.map(this.collection.renderAllClean(), function (e) { return e.html() }).join("\n")
      }));
      this.$el.appendTo("#build form");
      this.delegateEvents();
      //保存表单数据
      //g_globalModel.GlobalModelRef.setControlGroups(this.collection.models);
      //g_globalModel.GlobalModelRef.save();
      //
    }

    , getBottomAbove: function(eventY){//找出满足条件的组件：拖动组件插入表单时，判断当前拖动的组件应该插入到表单中哪个组件的位置
      var myFormBits = $(this.$el.find(".component"));
      var topelement = _.find(myFormBits, function(renderedSnippet) {
        if (($(renderedSnippet).position().top + $(renderedSnippet).height()) > eventY  - 90) {
          return true;
        }
        else {
          return false;
        }
      });
      if (topelement){
        return topelement;
      } else {
        return myFormBits[0];
      }
    }

    , handleSnippetDrag: function(mouseEvent, snippetModel) {//在目标表单中拖动组件时的event handler
      $("body").append(new TempSnippetView({model: snippetModel}).render());
      this.collection.remove(snippetModel);
      //g_globalModel.GlobalModelRef.removeControlGroup(snippetModel);//
      PubSub.trigger("newTempPostRender", mouseEvent);
    }

    , handleTempMove: function(mouseEvent){//被拖动控件（随着鼠标移动的snippt）的移动事件handler
      $(".target").removeClass("target");
      if(mouseEvent.pageX >= this.$build.position().left &&
          mouseEvent.pageX < (this.$build.width() + this.$build.position().left) &&
          mouseEvent.pageY >= this.$build.position().top &&
          mouseEvent.pageY < (this.$build.height() + this.$build.position().top)){//判断是否处在目标表单的范文内
        $(this.getBottomAbove(mouseEvent.pageY)).addClass("target");
      } else {
        $(".target").removeClass("target");
      }
    }

    , handleTempDrop: function(mouseEvent, model, index){//放下拖动控件的事件handler，在此可以处理保存加入表单的控件
      if(mouseEvent.pageX >= this.$build.position().left &&
         mouseEvent.pageX < (this.$build.width() + this.$build.position().left) &&
         mouseEvent.pageY >= this.$build.position().top &&
         mouseEvent.pageY < (this.$build.height() + this.$build.position().top)) {
        var index = $(".target").index();
        $(".target").removeClass("target");
        this.collection.add(model,{at: index+1});//将model添加进目标表单的collection，
        /*
        //第一次时，插入表单本身的snippet对象
        if(!g_globalModel.GlobalModelRef.saveFormControlGroups||g_globalModel.GlobalModelRef.saveFormControlGroups.length==0)
        {
          g_globalModel.GlobalModelRef.addControlGroup(this.collection.at(0),{at:0});
        }
        g_globalModel.GlobalModelRef.addControlGroup(model);//
        */
      } else {
        $(".target").removeClass("target");
      }
    }
    ,cleanForm:function(){//清除掉表单及其事件
      this.remove();
      this.$el.empty();
      this.undelegateEvents();
      this.collection.off("add");
      this.collection.off("remove");
      this.off("change");
      PubSub.off("mySnippetDrag", this.handleSnippetDrag, this);
      PubSub.off("tempMove", this.handleTempMove, this);
      PubSub.off("tempDrop", this.handleTempDrop, this);

    }
    ,useExistingForm:function(formTemplateData){
      //根据保存的表单数据查看和使用表单

    }
    ,editFormTemplate:function(formTemplateData){
      //编辑表单模板

    }
    ,saveFormHandler:function(formTemplateData){
      //保存表单
    }
    
  })
});


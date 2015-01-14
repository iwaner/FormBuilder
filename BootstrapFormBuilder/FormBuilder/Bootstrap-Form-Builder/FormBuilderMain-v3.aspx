<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormBuilderMain-v3.aspx.cs" Inherits="FormBuilder.Bootstrap_Form_Builder.FormBuilderMain_v3" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>表单设计器</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <link href="assets/css/lib/bootstrap.min.css" rel="stylesheet">
    <link href="assets/css/lib/bootstrap-responsive.min.css" rel="stylesheet">
    <link href="assets/css/custom.css" rel="stylesheet">
    <!--[if lt IE 9]>
    <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <link rel="shortcut icon" href="images/favicon.ico">
    <link rel="apple-touch-icon" href="images/apple-touch-icon.png">
    <link rel="apple-touch-icon" sizes="72x72" href="images/apple-touch-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon-114x114.png">
  </head>

  <body>
    <a href="###"><img style="z-index: 100000; position: absolute; top: 0; right: 0; border: 0;" src="" alt="put your logo here"></a>
    <div class="navbar navbar-fixed-top">
      <div class="navbar-inner">
        <div class="container">
          <a class="brand" href="#">表单设计器</a>
        </div>
      </div>
    </div>
    <div class="container">
      <div class="row clearfix">
        <!-- Building Form. -->
        <div class="col-md-6">
          <div class="clearfix">
            <h2>当前表单</h2>
            <hr>
            <div id="build">
              <form id="target" class="form-horizontal">
              </form>
               <button id="saveForm" class="btn btn-info">保存表单</button>
               <button id="btnUseForm" class="btn btn-info">使用表单</button>
               <button id="loadFormTemplate" class="btn btn-info" type="button">加载可编辑表单模板</button>
            </div>
           
          </div>
        </div>
        <!-- / Building Form. -->

        <!-- Components -->
        <div class="col-md-6">
          <h2>拖放组件</h2>
          <hr>
          <div class="tabbable">
            <ul class="nav nav-tabs" id="formtabs">
              <!-- Tab nav -->
            </ul>
            <form class="form-horizontal" id="components">
              <fieldset>
                <div class="tab-content">
                  <!-- Tabs of snippets go here -->
                </div>
              </fieldset>
            </form>
          </div>
        </div>
        <!-- / Components -->

      </div>

      <div class="row clearfix">
        <div class="col-md-12">
          <hr>
          By xxx (<a href="### ></a>).<br/>
          Source on (<a href="### ></a>).
        </div>
      </div>

    </div> <!-- /container -->
    <script type="text/javascript" >
        var g_globalModel = {};

    </script>
    <script data-main="assets/js/main.js" src="assets/js/lib/require.js" ></script>

  </body>
</html>

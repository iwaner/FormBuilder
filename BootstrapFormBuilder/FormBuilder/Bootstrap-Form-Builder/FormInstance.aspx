<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormInstance.aspx.cs" Inherits="FormBuilder.Bootstrap_Form_Builder.FormInstance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
    <meta charset="utf-8">
    <title>表单</title>
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
    <div class="span8">
        <h3>表单模板JSON，数据库中，模板将会被保存成这种格式
        可直接输入符合格式的json数据，然后点击“使用表单”查看效果
        </h3>
        <textarea id="formTemplateData" class="span6"></textarea>
        <button id="btnUseForm" class="btn btn-info">使用表单</button>
	    <form id="useForm" class="form-horizontal">
	    </form>
	    <br />
	    <button id="saveFormData" class="btn btn-info" type="button">保存表单数据</button>
	    <br />
	    <textarea id="formDataJsonText" class="span6"></textarea>
	    <br />
	    <button id="loadFormData" class="btn btn-info" type="button">加载表单数据</button>
    </div>
    <input type="hidden" id="formId" />
    <script data-main="assets/js/form-instance-main.js" src="assets/js/lib/require.js" ></script>
</body>
</html>

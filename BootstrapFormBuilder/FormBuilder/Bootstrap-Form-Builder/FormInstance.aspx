<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormInstance.aspx.cs" Inherits="FormBuilder.Bootstrap_Form_Builder.FormInstance" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>表单</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="assets/css/lib/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/lib/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="assets/css/custom.css" rel="stylesheet" />
 
    <!--[if lt IE 9]>
    <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <link href="../Styles/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <link rel="apple-touch-icon" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="images/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon-114x114.png" />

    <link href="../styles/css/plugins/datapicker/datepicker3.css" rel="stylesheet" />

    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    
    <script type="text/javascript">
        var g_globalModel = {};
    </script>

</head>
<body>
    <div class="span8">
        <div class="form-group" id="data_1">
            <label class="font-noraml">简单示例</label>
            <div class="input-group date">
                <span class="input-group-addon"><i class="fa fa-calendar"></i></span><input type="text" class="form-control" value="2014-11-11">
            </div>
        </div>
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
        <button id="renderFormWithData" class="btn btn-info" type="button">展示表单和表单数据</button>
        <br />
        <textarea id="loadFormDataJsonText" class="span6"></textarea>
    </div>
    <input type="hidden" id="formId" />

    <script data-main="assets/js/form-instance-main.js" src="assets/js/lib/require.js"></script>

     <script src="../Scripts/plugins/datapicker/bootstrap-datepicker.js"></script>
     <script >
        $(document).ready(function(){

            $('#data_1 .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
            });

        });
    </script>
</body>
</html>

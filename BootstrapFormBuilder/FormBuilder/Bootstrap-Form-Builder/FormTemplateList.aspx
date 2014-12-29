<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormTemplateList.aspx.cs" Inherits="FormBuilder.Bootstrap_Form_Builder.FormTemplateList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- Data Tables -->
    <link href="../Styles/css/plugins/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="../Styles/css/animate.css" rel="stylesheet" />
    <link href="../Styles/css/style.css" rel="stylesheet" />
     <!-- Mainly scripts -->
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../Scripts/plugins/jeditable/jquery.jeditable.js"></script>
    <!-- Data Tables -->
    <script src="../Scripts/plugins/dataTables/jquery.dataTables.js"></script>
    <script src="../Scripts/plugins/dataTables/dataTables.bootstrap.js"></script>
    <!-- Custom and plugin javascript -->
    <script src="../Scripts/inspinia.js"></script>
    <script src="../Scripts/plugins/pace/pace.min.js"></script>
    <!-- Page-Level Scripts -->
    <script>
        $(document).ready(function () {
            ShowFormTemplates();
            $('.dataTables-example').dataTable();
            var oTable = $('#editable').dataTable();
            oTable.$('td').editable('../example_ajax.php', {
                "callback": function (sValue, y) {
                    var aPos = oTable.fnGetPosition(this);
                    oTable.fnUpdate(sValue, aPos[0], aPos[1]);
                },
                "submitdata": function (value, settings) {
                    return {
                        "row_id": this.parentNode.getAttribute('id'),
                        "column": oTable.fnGetPosition(this)[2]
                    };
                },
                "width": "90%",
                "height": "100%"
            });
        });

        var ShowFormTemplates = function () {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "FormTemplateList.aspx/ShowAllTemplates",
                data: null,
                dataType: 'json',
                success: function (result) {
                    if (result != null && result.d != null) {
                        $("#tbTemplates tbody").empty();
                        var templateList = JSON.parse(result.d);
                        $(templateList).each(function (index, template) {
                            if (template != null) {
                                AppendTemplateTable(template);
                            }
                        });
                    }
                }
            });
        }
        var AppendTemplateTable = function (template) {
            $("#tbTemplates tbody").append("<tr class='gradeA'>" +
                           "<td>" + template.FormTemplateId + "</td>" +
                           "<td>" + template.FormName + "</td>" +
                           "<td>" + template.WorkflowId + "</td>" +
                           "<td class='center'>" + template.UpdateDate + "</td>" +
                           "<td class='center'>" + template.UpdateUser + "</td>" +
                       "</tr>");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="row wrapper border-bottom white-bg page-heading">
                    <div class="col-lg-10">
                        <h2>表单集合</h2>
                        <ol class="breadcrumb">
                            <li>
                                <a href="index.html">主页</a>
                            </li>
                            <li>
                                <a>表格</a>
                            </li>
                            <li>
                                <strong>表单集合</strong>
                            </li>
                        </ol>
                    </div>
                    <div class="col-lg-2">
                    </div>
                </div>
                <div class="wrapper wrapper-content animated fadeInRight">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="ibox float-e-margins">
                                <div class="ibox-title">
                                    <h5>基本 <small>分类，查找</small></h5>
                                    <div class="ibox-tools">
                                        <a class="collapse-link">
                                            <i class="fa fa-chevron-up"></i>
                                        </a>
                                        <a class="dropdown-toggle" data-toggle="dropdown" href="table_data_tables.html#">
                                            <i class="fa fa-wrench"></i>
                                        </a>
                                        <ul class="dropdown-menu dropdown-user">
                                            <li>
                                                <a href="table_data_tables.html#">选项1</a>
                                            </li>
                                            <li>
                                                <a href="table_data_tables.html#">选项2</a>
                                            </li>
                                        </ul>
                                        <a class="close-link">
                                            <i class="fa fa-times"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="ibox-content">
                                    <table id="tbTemplates" class="table table-striped table-bordered table-hover dataTables-example">
                                        <thead>
                                            <tr>
                                                <th>模板编号</th>
                                                <th>模板名称</th>
                                                <th>工作流名称</th>
                                                <th>更新时间</th>
                                                <th>更新用户</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>模板编号</th>
                                                <th>模板名称</th>
                                                <th>工作流名称</th>
                                                <th>更新时间</th>
                                                <th>更新用户</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer">
                    <div class="pull-right">
                        By：<a href="http://www.zi-han.net" target="_blank">zihan's blog</a>
                    </div>
                    <div>
                        <strong>Copyright</strong> H+ &copy; 2014
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="WebQLPH.DangNhap" %>

<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="favicon.ico" />
    <title>Đăng Nhập :: Quản lý tài sản</title>
    <link href="Content/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/theme.css" rel="stylesheet" />
    <link href="Content/css/Site.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" media="screen" href="Content/css/site-datetimepicker.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="Content/css/bootstrap-datetimepicker.css" />
    <link href="Content/css/bootstrap-select.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/myjs.js"></script>
</head>
<body role="document">
    <form id="Form1" runat="server">
        <!-- Fixed navbar -->
        <div class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="Default.aspx">Quản lý phòng học</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li <%if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MuonPhong.aspx")) Response.Write("class=\"active\""); %>><a href="MuonPhong.aspx"><span class="glyphicon glyphicon-edit"></span>&nbsp;Mượn phòng</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="glyphicon glyphicon-list-alt"></span>&nbsp;Quản lý phòng <span class="caret"></span></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="ViTri.aspx"><span class="glyphicon glyphicon-map-marker"></span>&nbsp;Vị trí</a></li>
                                <li><a href="Phong.aspx"><span class="glyphicon glyphicon-tasks"></span>&nbsp;Phòng</a></li>
                                <li><a href="PhongThietBi.aspx"><span class="glyphicon glyphicon-credit-card"></span>&nbsp;Phòng - Thiết bị</a></li>
                                <li><a href="ThietBi.aspx"><span class="glyphicon glyphicon-phone"></span>&nbsp;Thiết bị</a></li>
                                <li><a href="LoaiThietBi.aspx"><span class="glyphicon glyphicon-briefcase"></span>&nbsp;Loại thiết bị</a></li>
                                <li><a href="NhanVien.aspx"><span class="glyphicon glyphicon-user"></span>&nbsp;Nhân viên</a></li>
                                <li><a href="SuCo.aspx"><span class="glyphicon glyphicon-inbox"></span>&nbsp;Sự cố</a></li>
                            </ul>
                        </li>
                        <li><a href="ThongTin.aspx"><span class="glyphicon glyphicon-info-sign"></span>&nbsp;Thông tin</a></li>
                        <li><a href="LienHe.aspx"><span class="glyphicon glyphicon-envelope"></span>&nbsp;Liên hệ</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="DangNhap.aspx"><span class="glyphicon glyphicon glyphicon-user"></span>&nbsp;Đăng nhập</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>

        <div class="container theme-showcase" role="main">
            <div class="center">
                <uc:ucDangNhap runat="server" ID="ucDangNhap" />
            </div>
        </div>
    </form>
    <!-- /container -->
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/docs.min.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
    <script src="Scripts/bootstrap-select.js"></script>
</body>
</html>


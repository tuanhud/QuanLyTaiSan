<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Web.Test" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Bootswatch: Cerulean</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://bootswatch.com/cerulean/bootstrap.css" media="screen">
    <link rel="stylesheet" href="http://bootswatch.com/assets/css/bootswatch.min.css">
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="http://bootswatch.com/bower_components/html5shiv/dist/html5shiv.js"></script>
      <script src="http://bootswatch.com/bower_components/respond/dest/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <div class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Quản lý tài sản</a>
            </div>
            <div class="navbar-collapse navbar-responsive-collapse collapse in" style="">
                <ul class="nav navbar-nav">
                    <li <%if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("ViTri.aspx")) Response.Write("class=\"active\""); %>>
                        <a href="ViTri.aspx">Vị trí</a>
                    </li>
                    <li <%if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("PhongHoc.aspx")) Response.Write("class=\"active\""); %>>
                        <a href="PhongHoc.aspx">Phòng</a>
                    </li>
                    <li <%if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("PhongThietBi.aspx")) Response.Write("class=\"active\""); %>>
                        <a href="PhongThietBi.aspx">Phòng thiết bị</a>
                    </li>
                    <li <%if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("ThietBi.aspx")) Response.Write("class=\"active\""); %>>
                        <a href="ThietBi.aspx">Thiết bị</a>
                    </li>
                    <li <%if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("LoaiThietBi.aspx")) Response.Write("class=\"active\""); %>>
                        <a href="ThietBi.aspx">Loại thiết bị</a>
                    </li>
                    <li <%if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("NhanVien.aspx")) Response.Write("class=\"active\""); %>>
                        <a href="NhanVien.aspx">Nhân viên</a>
                    </li>
                    <li <%if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("QuanTriVien.aspx")) Response.Write("class=\"active\""); %>>
                        <a href="QuanTriVien.aspx">Quản trị viên</a>
                    </li>
                </ul>
                <form class="navbar-form navbar-left" runat="server">
                    <asp:TextBox ID="txtSearch" placeholder="Tìm kiếm" CssClass="form-control col-lg-8" runat="server"></asp:TextBox>
                </form>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#">Chào Admin</a></li>
                </ul>
            </div>
        </div>
    </div>





    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="http://bootswatch.com/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="http://bootswatch.com/assets/js/bootswatch.js"></script>
</body>
</html>

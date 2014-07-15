<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="Web.DangNhap" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Đăng nhập :: Quản lý tài sản</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
    <link rel="stylesheet" href="Css/bootstrap.css" media="screen">
    <link rel="stylesheet" href="Css/bootswatch.min.css">
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="Js/html5shiv.js"></script>
      <script src="Js/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="Form1" runat="server">
        <div class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="Default.aspx">Quản lý tài sản</a>
                </div>
                <div class="navbar-collapse navbar-responsive-collapse collapse all" style="">
                    <ul class="nav navbar-nav">
                        <li>
                            <a href="ViTri.aspx">Vị trí</a>
                        </li>
                        <li>
                            <a href="Phong.aspx">Phòng</a>
                        </li>
                        <li>
                            <a href="PhongThietBi.aspx">Phòng thiết bị</a>
                        </li>
                        <li>
                            <a href="ThietBis.aspx">Thiết bị</a>
                        </li>
                        <li>
                            <a href="LoaiThietBi.aspx">Loại thiết bị</a>
                        </li>
                        <li>
                            <a href="NhanVien.aspx">Nhân viên</a>
                        </li>
                        <li>
                            <a href="QuanTriVien.aspx">Quản trị viên</a>
                        </li>
                    </ul>
                    <p class="navbar-form navbar-left">
                        <asp:TextBox ID="txtSearch" placeholder="Tìm kiếm" CssClass="form-control col-lg-8" runat="server"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="container">
            <h2 class="form-signin-heading">Đăng nhập</h2>
            <asp:Label ID="lblThongBao" runat="server" Text="" CssClass="text-danger"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Tài khoản" required="true" autofocus="true"></asp:TextBox><br />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Mật khẩu" TextMode="Password" required="true"></asp:TextBox>
            <div class="checkbox">
                <label>
                    <asp:CheckBox ID="cbRemember" value="remember-me" runat="server" />
                    Nhớ đăng nhập lần sau
                </label>
            </div>
            <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnDangNhap_Click" />
        </div>
        <div class="footer">
            <div class="container">
                <p class="text-muted">&copy 2014 Quản lý tài sản.</p>
            </div>
        </div>
    </form>
    <script src="Js/jquery-1.10.2.min.js"></script>
    <script src="Js/bootstrap.min.js"></script>
    <script src="Js/bootswatch.js"></script>
</body>
</html>

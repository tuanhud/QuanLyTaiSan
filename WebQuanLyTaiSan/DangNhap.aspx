<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="WebQuanLyTaiSan.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!-- start: Meta -->
    <meta charset="utf-8" />
    <title>Đăng nhập :: Quản lý tài sản</title>
    <meta name="description" content="SimpliQ - Flat & Responsive Bootstrap Admin Template." />
    <meta name="author" content="Łukasz Holeczek" />
    <meta name="keyword" content="SimpliQ, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina" />
    <!-- end: Meta -->
    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->
    <!-- start: CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="css/style.min.css" rel="stylesheet" />
    <link href="css/style-responsive.min.css" rel="stylesheet" />
    <link href="css/retina.css" rel="stylesheet" />
    <!-- end: CSS -->
    <!-- The HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	  	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
		<link id="ie-style" href="css/ie.css" rel="stylesheet">
	<![endif]-->
    <!--[if IE 9]>
		<link id="ie9style" href="css/ie9.css" rel="stylesheet">
	<![endif]-->
    <!-- start: Favicon and Touch Icons -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="ico/apple-touch-icon-144-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="ico/apple-touch-icon-114-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="ico/apple-touch-icon-72-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" href="ico/apple-touch-icon-57-precomposed.png" />
    <link rel="shortcut icon" href="ico/favicon.png" />
    <!-- end: Favicon and Touch Icons -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid-full">
                    <div class="row-fluid">
                        <div class="row-fluid">
                            <div class="login-box">
                                <h2>Đăng nhập vào tài khoản của bạn</h2>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <img src="img/loading.gif" alt="xử lý" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="input-large span12"></asp:TextBox>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="input-large span12" TextMode="Password"></asp:TextBox>
                                <div class="clearfix"></div>
                                <label class="remember" for="remember">
                                    <asp:CheckBox ID="cbRemember" runat="server" />Nhớ đăng nhập lần sau</label>
                                <div class="clearfix"></div>
                                <asp:Button ID="btnDangNhap" runat="server" CssClass="btn btn-primary span12" Text="Đăng nhập" OnClick="btnDangNhap_Click" />
                                <hr />
                                <h3>Quên password?</h3>
                                <p>
                                    <a href="#">Click vào đây</a> để lấy mật khẩu mới.				
                                </p>
                            </div>
                        </div>
                        <!--/row-->
                    </div>
                    <!--/fluid-row-->
                </div>
                <!--/.fluid-container-->
                <!-- start: JavaScript-->
                <script src="js/jquery-1.10.2.min.js"></script>
                <script src="js/jquery-migrate-1.2.1.min.js"></script>
                <script src="js/jquery-ui-1.10.3.custom.min.js"></script>
                <script src="js/jquery.ui.touch-punch.js"></script>
                <script src="js/modernizr.js"></script>
                <script src="js/bootstrap.min.js"></script>
                <script src="js/jquery.cookie.js"></script>
                <script src='js/fullcalendar.min.js'></script>
                <script src='js/jquery.dataTables.min.js'></script>
                <script src="js/excanvas.js"></script>
                <script src="js/jquery.flot.js"></script>
                <script src="js/jquery.flot.pie.js"></script>
                <script src="js/jquery.flot.stack.js"></script>
                <script src="js/jquery.flot.resize.min.js"></script>
                <script src="js/jquery.flot.time.js"></script>
                <script src="js/jquery.chosen.min.js"></script>
                <script src="js/jquery.uniform.min.js"></script>
                <script src="js/jquery.cleditor.min.js"></script>
                <script src="js/jquery.noty.js"></script>
                <script src="js/jquery.elfinder.min.js"></script>
                <script src="js/jquery.raty.min.js"></script>
                <script src="js/jquery.iphone.toggle.js"></script>
                <script src="js/jquery.uploadify-3.1.min.js"></script>
                <script src="js/jquery.gritter.min.js"></script>
                <script src="js/jquery.imagesloaded.js"></script>
                <script src="js/jquery.masonry.min.js"></script>
                <script src="js/jquery.knob.modified.js"></script>
                <script src="js/jquery.sparkline.min.js"></script>
                <script src="js/counter.min.js"></script>
                <script src="js/raphael.2.1.0.min.js"></script>
                <script src="js/justgage.1.0.1.min.js"></script>
                <script src="js/jquery.autosize.min.js"></script>
                <script src="js/retina.js"></script>
                <script src="js/jquery.placeholder.min.js"></script>
                <script src="js/wizard.min.js"></script>
                <script src="js/core.min.js"></script>
                <script src="js/charts.min.js"></script>
                <script src="js/custom.min.js"></script>
                <!-- end: JavaScript-->
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TSCD_WEB.Default" %>

<%@ Register Src="~/UserControl/TimKiem/ucTimKiem.ascx" TagPrefix="uc" TagName="ucTimKiem" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/css/metro/metro.css" />
    <link rel="stylesheet" type="text/css" href="Content/css/metro/metro_mobile.css" media="screen and (max-height: 500px), screen and (orientation:portrait)" />
    <link rel="stylesheet" type="text/css" href="Content/css/metro/website.css" />
    <script type="text/javascript" src="Scripts/scriptgates.js"></script>
    <div class="row timkiem">
        <div class="input-group <%Response.Write(isMobile ? "col-xs-12 col-sm-12 col-md-12" : "col-lg-3"); %> pull-right">
            <uc:ucTimKiem runat="server" ID="ucTimKiem" />
        </div>
    </div>
    <div class="panel-body fixpanel">
        <div class="row">
            <h3 class="title_orange fix">Tài sản cố định</h3>
        </div>
        <div class="row">
            <div class="widget_container full">
                <div class="widget widget2x2 widget_orange animation unloaded">
                    <a href="ViTri.aspx">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/vitri.png');">
                                <span>VỊ TRÍ</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="widget widget2x2 widget_red animation unloaded">
                    <a href="Phong.aspx">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/phong.png');">
                                <span>PHÒNG</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="widget widget2x2 widget_darkblue animation unloaded">
                    <a href="DonVi.aspx">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/phongthietbi.png');">
                                <span>ĐƠN VỊ</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="widget widget4x2 widget_darkgreen animation unloaded">
                    <a href="javascript:;" onclick="alert('Đang xây dựng');">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/loaithietbi.png');">
                                <span>TÀI SẢN</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="widget widget4x2 widget_blue animation unloaded">
                    <a href="DonViTaiSan.aspx">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/quanlymuonphong.png');">
                                <span>ĐƠN VỊ - TÀI SẢN</span>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div class="row">
            <h3 class="title_green fix">Loại tài sản cố định</h3>
        </div>
        <div class="row">
            <div class="widget_container full">
                <div class="widget widget2x2 widget_blue animation unloaded">
                    <a href="javascript:;" onclick="alert('Đang xây dựng');">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/muonphong.png');">
                                <span>LOẠI PHÒNG</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="widget widget4x2 widget_darkgreen animation unloaded">
                    <a href="javascript:;" onclick="alert('Đang xây dựng');">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/loaidonvi.png');">
                                <span>LOẠI ĐƠN VỊ</span>
                            </div>
                        </div>
                    </a>
                </div>
                 <div class="widget widget4x2 widget_darkblue animation unloaded">
                    <a href="javascript:;" onclick="alert('Đang xây dựng');">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/thietbi.png');">
                                <span>LOẠI TÀI SẢN</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="widget widget2x2 widget_red animation unloaded">
                    <a href="javascript:;" onclick="alert('Đang xây dựng');">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/thongtin.png');">
                                <span>THÔNG TIN</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="widget widget2x2 widget_orange animation unloaded">
                    <a href="javascript:;" onclick="alert('Đang xây dựng');">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/lienhe.png');">
                                <span>LIÊN HỆ</span>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div class="row">
            <h3 class="title_blue fix">Bảng điều khiển</h3>
        </div>
        <div class="row">
            <div class="widget widget4x2 widget_blue animation unloaded">
                    <a href="ThongTinCaNhan.aspx">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/thongtincanhan.png');">
                                <span>THÔNG TIN CÁ NHÂN</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="widget widget2x2 widget_red animation unloaded">
                    <a href="?op=thoat" onclick="return confirm('Bạn muốn thoát?');">
                        <div class="widget_content">
                            <div class="main" style="background-image: url('Images/metro/thoat.png');">
                                <span>THOÁT RA</span>
                            </div>
                        </div>
                    </a>
                </div>
        </div>
    </div>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

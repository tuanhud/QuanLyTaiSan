<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default1" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ :: Quản lý tài sản</title>
    <%--<link rel="stylesheet" href="Css/metro/bootstrap.blue.css">--%>
    <link rel="stylesheet" href="Css/metro/bootstrap-responsive.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="plus-metro-nav span9 well" style="min-width:400px">
            <a href="Default.aspx">
                <div class="span3 box red height2">
                    <h5><i class="icon-home"></i>Trang chủ</h5>
                </div>
            </a>
            <a href="ViTri.aspx">
                <div class="span3 box lightblue">
                    <h5><i class="icon-info-sign"></i>Xem vị trí</h5>
                </div>
            </a>
            <a href="Phong.aspx">
                <div class="span3 box purple">
                    <h5><i class="icon-pencil"></i>Xem phòng</h5>
                </div>
            </a>
            <a href="PhongThietBi.aspx">
                <div class="span3 box brown">
                    <h5><i class="icon-pencil"></i>Xem phòng - thiết bị</h5>
                </div>
            </a>
            <a href="ThietBis.aspx">
                <div class="span3 box deviant">
                    <h5><i class="icon-pencil"></i>Xem thiết bị</h5>
                </div>
            </a>
            <a href="LoaiThietBi.aspx">
                <div class="span3 box facebook">
                    <h5><i class="icon-pencil"></i>Xem loại thiết bị</h5>
                </div>
            </a>
            <a href="NhanVien.aspx">
                <div class="span3 box green">
                    <h5><i class="icon-map-marker"></i>Xem nhân viên</h5>
                </div>
            </a>
            <a href="QuanTriVien.aspx">
                <div class="span3 box pink">
                    <h5><i class="icon-edit"></i>Xem quản trị viên</h5>
                </div>
            </a>
        </div>
</asp:Content>

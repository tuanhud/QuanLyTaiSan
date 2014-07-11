<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ :: Quản lý tài sản</title>
    <%--<link rel="stylesheet" href="Css/metro/bootstrap.blue.css">--%>
    <link rel="stylesheet" href="Css/metro/bootstrap-responsive.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="plus-metro-nav span9 well">
            <a href="Default.aspx">
                <div class="span3 box red height3">
                    <h5><i class="icon-home"></i>Trang chủ</h5>
                </div>
            </a>
            <a href="ViTri.aspx">
                <div class="span3 box lightblue">
                    <h5><i class="icon-info-sign"></i>Vị Trí</h5>
                </div>
            </a>
            <a href="PhongHoc.aspx">
                <div class="span3 box purple">
                    <h5><i class="icon-pencil"></i>Phòng Học</h5>
                </div>
            </a>
            <a href="NhanVien.aspx">
                <div class="span3 box green">
                    <h5><i class="icon-map-marker"></i>Nhân Viên</h5>
                </div>
            </a>
            <a href="QuanTriVien.aspx">
                <div class="span3 box pink">
                    <h5><i class="icon-edit"></i>Quản Trị Viên</h5>
                </div>
            </a>
        </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="WebQLPH.DangNhap" %>
<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng Nhập :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center">
        <asp:Panel ID="PanelDangNhap" runat="server">
            <uc:ucDangNhap runat="server" ID="ucDangNhap" />
        </asp:Panel>
    </div>
</asp:Content>

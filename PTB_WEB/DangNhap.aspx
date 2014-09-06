<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="PTB_WEB.DangNhap" %>

<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Đăng Nhập :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center">
        <uc:ucDangNhap runat="server" ID="ucDangNhap" />
    </div>
</asp:Content>

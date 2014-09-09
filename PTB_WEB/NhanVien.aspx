<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NhanVien.aspx.cs" Inherits="PTB_WEB.NhanVien" %>

<%@ Register Src="~/UserControl/NhanVien/ucNhanVien_Web.ascx" TagPrefix="uc" TagName="ucNhanVien_Web" %>
<%@ Register Src="~/UserControl/NhanVien/ucNhanVien_Mobile.ascx" TagPrefix="uc" TagName="ucNhanVien_Mobile" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Nhân viên phụ trách :: Phòng Thiết bị :.</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel_Web" runat="server" Visible="false">
        <uc:ucNhanVien_Web runat="server" ID="_ucNhanVien_Web" />
    </asp:Panel>
    <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
        <uc:ucNhanVien_Mobile runat="server" ID="_ucNhanVien_Mobile" />
    </asp:Panel>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

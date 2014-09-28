<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoaiTaiSan.aspx.cs" Inherits="TSCD_WEB.LoaiTaiSan" %>

<%@ Register Src="~/UserControl/LoaiTaiSan/ucLoaiTaiSan_Web.ascx" TagPrefix="uc" TagName="ucLoaiTaiSan_Web" %>
<%@ Register Src="~/UserControl/LoaiTaiSan/ucLoaiTaiSan_Mobile.ascx" TagPrefix="uc" TagName="ucLoaiTaiSan_Mobile" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Đơn vị :: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:ucLoaiTaiSan_Web runat="server" ID="ucLoaiTaiSan_Web" Visible="false" />
    <uc:ucLoaiTaiSan_Mobile runat="server" ID="ucLoaiTaiSan_Mobile" Visible="false" />
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

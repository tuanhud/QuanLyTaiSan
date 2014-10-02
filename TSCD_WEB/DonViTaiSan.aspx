﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonViTaiSan.aspx.cs" Inherits="TSCD_WEB.DonViTaiSan" %>
<%@ Register Src="~/UserControl/DonViTaiSan/ucDonViTaiSan_Web.ascx" TagPrefix="uc" TagName="ucDonViTaiSan_Web" %>
<%@ Register Src="~/UserControl/DonViTaiSan/ucDonViTaiSan_Mobile.ascx" TagPrefix="uc" TagName="ucDonViTaiSan_Mobile" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Đơn vị - Tài sản :: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:ucDonViTaiSan_Web runat="server" ID="ucDonViTaiSan_Web" Visible="false" />
    <uc:ucDonViTaiSan_Mobile runat="server" ID="ucDonViTaiSan_Mobile" Visible="false" />
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>
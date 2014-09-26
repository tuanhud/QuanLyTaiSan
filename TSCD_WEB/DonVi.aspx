<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonVi.aspx.cs" Inherits="TSCD_WEB.DonVi" %>

<%@ Register Src="~/UserControl/DonVi/ucDonVi_Web.ascx" TagPrefix="uc" TagName="ucDonVi_Web" %>
<%@ Register Src="~/UserControl/DonVi/ucDonVi_Mobile.ascx" TagPrefix="uc" TagName="ucDonVi_Mobile" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Đơn vị :: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:ucDonVi_Web runat="server" ID="ucDonVi_Web" Visible="false" />
    <uc:ucDonVi_Mobile runat="server" ID="ucDonVi_Mobile" Visible="false" />
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ThietBis.aspx.cs" Inherits="PTB_WEB.ThietBis" %>

<%@ Register Src="~/UserControl/ThietBi/ucThietBi_Web.ascx" TagPrefix="uc" TagName="ucThietBi_Web" %>
<%@ Register Src="~/UserControl/ThietBi/ucThietBi_Mobile.ascx" TagPrefix="uc" TagName="ucThietBi_Mobile" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Thiết bị :: Quản lý Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel_Web" runat="server" Visible="false">
        <uc:ucThietBi_Web runat="server" ID="ucThietBi_Web" />
    </asp:Panel>
    <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
        <uc:ucThietBi_Mobile runat="server" ID="ucThietBi_Mobile" />
    </asp:Panel>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

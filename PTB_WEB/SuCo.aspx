<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SuCo.aspx.cs" Inherits="PTB_WEB.SuCo" %>

<%@ Register Src="~/UserControl/SuCo/ucSuCo_Web.ascx" TagPrefix="uc" TagName="ucSuCo_Web" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_Mobile.ascx" TagPrefix="uc" TagName="ucSuCo_Mobile" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Sự cố :: Quản lý Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel_Web" runat="server" Visible="false">
        <uc:ucSuCo_Web runat="server" ID="ucSuCo_Web" />
    </asp:Panel>
    <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
        <uc:ucSuCo_Mobile runat="server" ID="ucSuCo_Mobile" />
    </asp:Panel>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

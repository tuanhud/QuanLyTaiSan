<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LoaiThietBis.aspx.cs" Inherits="PTB_WEB.LoaiThietBis" %>

<%@ Register Src="~/UserControl/LoaiThietBi/ucLoaiThietBi_Web.ascx" TagPrefix="uc1" TagName="ucLoaiThietBi_Web" %>
<%@ Register Src="~/UserControl/LoaiThietBi/ucLoaiThietBi_Mobile.ascx" TagPrefix="uc1" TagName="ucLoaiThietBi_Mobile" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Loại thiết bị :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel_Web" runat="server" Visible="false">
        <uc1:ucLoaiThietBi_Web runat="server" ID="ucLoaiThietBi_Web" />
    </asp:Panel>
    <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
        <uc1:ucLoaiThietBi_Mobile runat="server" ID="ucLoaiThietBi_Mobile" />
    </asp:Panel>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

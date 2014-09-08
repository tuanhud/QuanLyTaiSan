<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ThietBis.aspx.cs" Inherits="PTB_WEB.ThietBis" %>

<%@ Register Src="~/UserControl/ThietBi/ucThietBi_Web.ascx" TagPrefix="uc" TagName="ucThietBi_Web" %>
<%@ Register Src="~/UserControl/ThietBi/ucThietBi_Mobile.ascx" TagPrefix="uc" TagName="ucThietBi_Mobile" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Thiết bị :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucThietBi_Web runat="server" id="ucThietBi_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc:ucThietBi_Mobile runat="server" id="ucThietBi_Mobile" />
        </asp:Panel>
    </div>
    <uc:ucFooter runat="server" id="ucFooter" />
</asp:Content>

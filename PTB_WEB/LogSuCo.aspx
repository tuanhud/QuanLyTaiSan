<%@ Page Language="C#" MasterPageFile="~/PopupMasterPage.Master" AutoEventWireup="true" CodeBehind="LogSuCo.aspx.cs" Inherits="PTB_WEB.UserControl.PhongThietBi.LogSuCo" %>

<%@ Register Src="~/UserControl/LogSuCo/ucLogSuCo_Web.ascx" TagPrefix="uc" TagName="ucLogSuCo_Web" %>
<%@ Register Src="~/UserControl/LogSuCo/ucLogSuCo_Mobile.ascx" TagPrefix="uc" TagName="ucLogSuCo_Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Log sự cố :: Quản lý Thiết bị :.</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucLogSuCo_Web runat="server" ID="_ucLogSuCo_Web" />
        </asp:Panel>
    </div>
    <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
        <uc:ucLogSuCo_Mobile runat="server" ID="_ucLogSuCo_Mobile" />
    </asp:Panel>
</asp:Content>

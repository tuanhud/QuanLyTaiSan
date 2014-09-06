<%@ Page Language="C#" MasterPageFile="~/PopupMasterPage.Master" AutoEventWireup="true" CodeBehind="LogThietBi.aspx.cs" Inherits="WebQLPH.UserControl.PhongThietBi.LogThietBi" %>

<%@ Register Src="~/UserControl/LogThietBi/ucLogThietBi_Web.ascx" TagPrefix="uc" TagName="ucLogThietBi_Web" %>
<%@ Register Src="~/UserControl/LogThietBi/ucLogThietBi_Mobile.ascx" TagPrefix="uc" TagName="ucLogThietBi_Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Log thiết bị :: Phòng Thiết bị :.</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucLogThietBi_Web runat="server" ID="_ucLogThietBi_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc:ucLogThietBi_Mobile runat="server" ID="_ucLogThietBi_Mobile" />
        </asp:Panel>
    </div>
</asp:Content>

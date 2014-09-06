<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SuCo.aspx.cs" Inherits="PTB_WEB.SuCo" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_Web.ascx" TagPrefix="uc" TagName="ucSuCo_Web" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_Mobile.ascx" TagPrefix="uc" TagName="ucSuCo_Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Sự cố :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucSuCo_Web runat="server" id="ucSuCo_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc:ucSuCo_Mobile runat="server" id="ucSuCo_Mobile" />
        </asp:Panel>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="WebQLPH.LienHe" %>

<%@ Register Src="~/UserControl/LienHe/ucLienHe_Web.ascx" TagPrefix="uc1" TagName="ucLienHe_Web" %>
<%@ Register Src="~/UserControl/LienHe/ucLienHe_Mobile.ascx" TagPrefix="uc1" TagName="ucLienHe_Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Liên hệ :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc1:ucLienHe_Web runat="server" id="ucLienHe_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc1:ucLienHe_Mobile runat="server" id="ucLienHe_Mobile" />
        </asp:Panel>
    </div>
</asp:Content>
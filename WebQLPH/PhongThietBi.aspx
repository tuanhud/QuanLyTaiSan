<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PhongThietBi.aspx.cs" Inherits="WebQLPH.PhongThietBi" %>

<%@ Register Src="~/UserControl/PhongThietBi/ucPhongThietBi_Web.ascx" TagPrefix="uc" TagName="ucPhongThietBi_Web" %>
<%@ Register Src="~/UserControl/PhongThietBi/ucPhongThietBi_Mobile.ascx" TagPrefix="uc" TagName="ucPhongThietBi_Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Phòng - Thiết bị</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucPhongThietBi_Web runat="server" ID="_ucPhongThietBi_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc:ucPhongThietBi_Mobile runat="server" ID="_ucPhongThietBi_Mobile" />
        </asp:Panel>
    </div>
</asp:Content>
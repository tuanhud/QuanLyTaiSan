<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ViTri.aspx.cs" Inherits="PTB_WEB.ViTri" %>

<%@ Register Src="~/UserControl/ViTri/ucViTri_Web.ascx" TagPrefix="uc" TagName="ucViTri_Web" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_Mobile.ascx" TagPrefix="uc" TagName="ucViTri_Mobile" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Vị trí :: Phòng Thiết bị :.</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucViTri_Web runat="server" ID="_ucViTri_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc:ucViTri_Mobile runat="server" ID="_ucViTri_Mobile" />
        </asp:Panel>
    </div>
    <uc:ucFooter runat="server" id="ucFooter" />
</asp:Content>

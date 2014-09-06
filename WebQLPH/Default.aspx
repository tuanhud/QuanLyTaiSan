<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebQLPH.Default1" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/TrangChu/ucTrangChu_Web.ascx" TagPrefix="uc" TagName="ucTrangChu_Web" %>
<%@ Register Src="~/UserControl/TrangChu/ucTrangChu_Mobile.ascx" TagPrefix="uc" TagName="ucTrangChu_Mobile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucTrangChu_Web runat="server" id="ucTrangChu_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc:ucTrangChu_Mobile runat="server" id="ucTrangChu_Mobile" />
        </asp:Panel>
    </div>
</asp:Content>

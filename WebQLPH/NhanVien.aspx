<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NhanVien.aspx.cs" Inherits="WebQLPH.NhanVien" %>

<%@ Register Src="~/UserControl/NhanVien/ucNhanVien_Web.ascx" TagPrefix="uc" TagName="ucNhanVien_Web" %>
<%@ Register Src="~/UserControl/NhanVien/ucNhanVien_Mobile.ascx" TagPrefix="uc" TagName="ucNhanVien_Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nhân viên phụ trách</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucNhanVien_Web runat="server" ID="_ucNhanVien_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc:ucNhanVien_Mobile runat="server" ID="_ucNhanVien_Mobile" />
        </asp:Panel>
    </div>
</asp:Content>

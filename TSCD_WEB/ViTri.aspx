<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViTri.aspx.cs" Inherits="TSCD_WEB.ViTri" %>

<%@ Register Src="~/UserControl/ViTri/ucViTri_Web.ascx" TagPrefix="uc" TagName="ucViTri_Web" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_Mobile.ascx" TagPrefix="uc" TagName="ucViTri_Mobile" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Vị trí :: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:ucViTri_Web runat="server" ID="ucViTri_Web" Visible="false"/>
    <uc:ucViTri_Mobile runat="server" ID="ucViTri_Mobile" Visible="false"/>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

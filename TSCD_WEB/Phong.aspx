<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Phong.aspx.cs" Inherits="TSCD_WEB.Phong" %>

<%@ Register Src="~/UserControl/Phong/ucPhong_Web.ascx" TagPrefix="uc" TagName="ucPhong_Web" %>
<%@ Register Src="~/UserControl/Phong/ucPhong_Mobile.ascx" TagPrefix="uc" TagName="ucPhong_Mobile" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Phòng :: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:ucPhong_Web runat="server" ID="ucPhong_Web" Visible="false"/>
    <uc:ucPhong_Mobile runat="server" ID="ucPhong_Mobile" Visible="false" />
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

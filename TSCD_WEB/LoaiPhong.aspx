<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoaiPhong.aspx.cs" Inherits="TSCD_WEB.LoaiPhong" %>
<%@ Register Src="~/UserControl/LoaiPhong/ucLoaiPhong_Web.ascx" TagPrefix="uc" TagName="ucLoaiPhong_Web" %>
<%@ Register Src="~/UserControl/LoaiPhong/ucLoaiPhong_Mobile.ascx" TagPrefix="uc" TagName="ucLoaiPhong_Mobile" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Loại phòng :: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:ucLoaiPhong_Web runat="server" ID="ucLoaiPhong_Web" Visible="false"/>
    <uc:ucLoaiPhong_Mobile runat="server" ID="ucLoaiPhong_Mobile" Visible="false"/>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>
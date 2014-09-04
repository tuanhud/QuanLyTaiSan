<%@ Page Title="" Language="C#" MasterPageFile="~/PopupMasterPage.Master" AutoEventWireup="true" CodeBehind="HinhAnh.aspx.cs" Inherits="WebQLPH.HinhAnh" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Hình ảnh</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxImageSlider ID="ASPxImageSlider" runat="server" BinaryImageCacheFolder="~\Thumb\" ShowNavigationBar="False">
        <Styles>
            <PassePartout BackColor="Transparent" />
        </Styles>
    </dx:ASPxImageSlider>
</asp:Content>

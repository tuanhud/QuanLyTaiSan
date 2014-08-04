<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default2" %>

<%@ Register Src="~/UserControl/Search.ascx" TagPrefix="uc1" TagName="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Search runat="server" ID="Search" />
</asp:Content>

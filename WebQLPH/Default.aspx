<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebQLPH.Default1" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/TimKiem.ascx" TagPrefix="uc1" TagName="TimKiem" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Tìm kiếm</h1>
    </div>
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-search"></span></span>
        <uc1:TimKiem runat="server" id="TimKiem" />
    </div>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_BreadCrumb.ascx.cs" Inherits="PTB_WEB.UserControl.ViTri.ucViTri_BreadCrumb" %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="ViTri.aspx">Vị trí</a></li>    
    <% if (Request.QueryString["key"] != null) { %>
        <li><a href="ViTri.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); %>"><asp:Label ID="Label_TenViTri" runat="server"></asp:Label></a></li>
    <% } %>
</ol>


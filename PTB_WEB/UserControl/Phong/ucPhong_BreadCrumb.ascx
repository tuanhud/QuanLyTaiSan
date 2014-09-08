<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_BreadCrumb.ascx.cs" Inherits="PTB_WEB.UserControl.Phong.ucPhong_BreadCrumb" %>

<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="Phong.aspx">Phòng</a></li>
    <% if (Request.QueryString["key"] != null)
       { %>
    <li><a href="Phong.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); if (Request.QueryString["Page"] != null) Response.Write("&Page=" + Request.QueryString["Page"].ToString());%>">
        <asp:Label ID="Label_TenViTri" runat="server"></asp:Label></a></li>
    <% } %>
    <% if (Request.QueryString["id"] != null)
       { %>
    <li><a href="Phong.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); %>&id=<% Response.Write(Request.QueryString["id"].ToString()); %>">
        <asp:Label ID="Label_TenPhong" runat="server"></asp:Label></a></li>
    <% } %>
</ol>

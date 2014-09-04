<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien_BreadCrumb.ascx.cs" Inherits="WebQLPH.UserControl.NhanVien.ucNhanVien_BreadCrumb" %>

<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li <%# Request.QueryString["id"] != null?"":"class=\"active\"" %>><a href="NhanVien.aspx<% if (Request.QueryString["Page"] != null) Response.Write("?Page=" + Request.QueryString["Page"]); %>">Nhân viên</a></li>
    <% if (Request.QueryString["id"] != null)
       { %>
    <li><a href="<%# Request.Url.AbsoluteUri %>">
        <asp:Label ID="Label_TenNhanVien" runat="server"></asp:Label></a></li>
    <%} %>
</ol>

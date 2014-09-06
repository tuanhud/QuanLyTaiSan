<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_BreadCrumb.ascx.cs" Inherits="PTB_WEB.UserControl.Phong.ucPhong_BreadCrumb" %>

<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li <%# Request.QueryString["id"] != null?"":"class=\"active\"" %>><a href="Phong.aspx<% if (Request.QueryString["key"] != null) Response.Write("?key=" + Request.QueryString["key"]); if (Request.QueryString["Page"] != null) Response.Write("&Page=" + Request.QueryString["Page"]); %>">Vị trí</a></li>
    <% if (Request.QueryString["id"] != null)
       { %>
    <li><a href="<%# Request.Url.AbsoluteUri %>"><% Response.Write(Session["TenThietBi"].ToString()); %></a></li>
    <%} %>
</ol>
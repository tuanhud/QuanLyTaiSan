<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThietBi_BreadCrumb.ascx.cs" Inherits="WebQLPH.UserControl.ThietBi.ucThietBi_BreadCrumb" %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li <%# Request.QueryString["id"] != null?"":"class=\"active\"" %>><a href="ThietBis.aspx<% if (Request.QueryString["key"] != null) Response.Write("?key=" + Request.QueryString["key"]); if (Request.QueryString["Page"] != null) Response.Write("&Page=" + Request.QueryString["Page"]); %>">Thiết bị</a></li>
    <% if (Request.QueryString["id"] != null)
       { %>
    <li><a href="<%# Request.Url.AbsoluteUri %>"><% Response.Write(Session["TenThietBi"].ToString()); %></a></li>
    <%} %>
</ol>

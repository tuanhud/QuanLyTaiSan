<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoaiThietBi_BreadCrumb.ascx.cs" Inherits="WebQLPH.UserControl.LoaiThietBi.ucLoaiThietBi_BreadCrumb" %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="LoaiThietBis.aspx">Loại thiết bị</a></li>
    <%if (Request.QueryString["key"] != null){ %>
    <li><a href="LoaiThietBis.aspx<% if (Request.QueryString["key"] != null) Response.Write("?key=" + Request.QueryString["key"]); else Response.Write("?key=1"); %>"><% Response.Write(Session["TenLoaiThietBi"].ToString()); %></a></li>
    <%} %>
</ol>

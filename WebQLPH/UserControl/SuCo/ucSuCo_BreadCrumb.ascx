﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_BreadCrumb.ascx.cs" Inherits="WebQLPH.UserControl.SuCo.ucSuCo_BreadCrumb" %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li>
        <% if(Request.QueryString["key"] != null){ %>
        <a href="SuCo.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); %>">Sự cố phòng <% Response.Write(Session["TenPhong"].ToString()); %></a>
        <%} else{ %>
        <a href="SuCo.aspx">Sự cố</a>
        <%} %>
    </li>
    <% if(Request.QueryString["id"] != null){ %>
    <li><a href="SuCo.aspx?key=<% Response.Write(Request.QueryString["key"].ToString() + "&id=" + Request.QueryString["id"].ToString()); %>"><% Response.Write(Session["TenSuCo"].ToString()); %></a></li>
    <%} %>
</ol>

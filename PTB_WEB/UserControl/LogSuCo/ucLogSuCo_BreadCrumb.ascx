<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogSuCo_BreadCrumb.ascx.cs" Inherits="PTB_WEB.UserControl.LogSuCo.ucLogSuCo_BreadCrumb" %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="SuCo.aspx">Sự cố</a></li>
    <li><a href="SuCo.aspx?key=<% Response.Write(Session["KEYSUCO"].ToString()); %>"><% Response.Write(Session["TenPhong"].ToString()); %></a></li>
    <li><a href="SuCo.aspx?key=<% Response.Write(Session["KEYSUCO"].ToString() + "&id=" + Session["IDSUCO"].ToString()); %>"><% Response.Write(Session["TenSuCo"].ToString()); %></a></li>
    <li><a href="LogSuCo.aspx?id=<% Response.Write(Request.QueryString["id"].ToString()); %>">Log sự cố của <% Response.Write(Session["TenSuCo"].ToString()); %></a></li>

    <%--<li><a href="SuCo.aspx?key=<% Response.Write(PTB_WEB.Default._KEYSUCO.ToString()); %>"><% Response.Write(PTB_WEB.Default._TENPHONG.ToString()); %></a></li>
    <li><a href="SuCo.aspx?key=<% Response.Write(PTB_WEB.Default._KEYSUCO.ToString() + "&id=" + PTB_WEB.Default._IDSUCO.ToString()); %>"><% Response.Write(PTB_WEB.Default._TENSUCO.ToString()); %></a></li>
    <li><a href="LogSuCo.aspx?id=<% Response.Write(Request.QueryString["id"].ToString()); %>">Log sự cố của <% Response.Write(PTB_WEB.Default._TENSUCO.ToString()); %></a></li>--%>

</ol>

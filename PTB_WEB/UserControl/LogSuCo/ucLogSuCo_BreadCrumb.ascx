<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogSuCo_BreadCrumb.ascx.cs" Inherits="PTB_WEB.UserControl.LogSuCo.ucLogSuCo_BreadCrumb" %>

<%@ Register Src="~/UserControl/Search/ucTimKiem_Mobile.ascx" TagPrefix="uc" TagName="ucTimKiem_Mobile" %>

<% if (isMobile)
   {  %>
<uc:ucTimKiem_Mobile runat="server" ID="_ucTimKiem_Mobile" />
<%} %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="#">Log sự cố</a></li>
    <li><a href="SuCo.aspx<% if (Session["KEYSUCO"] != null) Response.Write("?key=" + Session["KEYSUCO"].ToString()); %>"><% if (Session["TenPhong"] != null) Response.Write(Session["TenPhong"].ToString()); %></a></li>
    <li><a href="SuCo.aspx<% if (Session["KEYSUCO"] != null && Session["IDSUCO"] != null) Response.Write("?key=" + Session["KEYSUCO"].ToString() + "&id=" + Session["IDSUCO"].ToString()); %>">
        <asp:Label ID="Label_TenSuCo1" runat="server"></asp:Label>
    </a>
    </li>
    <% if (Request.QueryString["idLog"] != null)
       { %>
    <li>
        <a href="<% Response.Write(PTB_WEB.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "idLog", (Request.QueryString["idLog"].ToString()))); %>">
            <asp:Label ID="Label_TenSuCo2" runat="server"></asp:Label>
        </a>
    </li>
    <%} %>
    <%--<li><a href="SuCo.aspx?key=<% Response.Write(PTB_WEB.Default._KEYSUCO.ToString()); %>"><% Response.Write(PTB_WEB.Default._TENPHONG.ToString()); %></a></li>
    <li><a href="SuCo.aspx?key=<% Response.Write(PTB_WEB.Default._KEYSUCO.ToString() + "&id=" + PTB_WEB.Default._IDSUCO.ToString()); %>"><% Response.Write(PTB_WEB.Default._TENSUCO.ToString()); %></a></li>
    <li><a href="LogSuCo.aspx?id=<% Response.Write(Request.QueryString["id"].ToString()); %>">Log sự cố của <% Response.Write(PTB_WEB.Default._TENSUCO.ToString()); %></a></li>--%>
</ol>

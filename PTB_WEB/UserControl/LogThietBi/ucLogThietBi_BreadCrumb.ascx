<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogThietBi_BreadCrumb.ascx.cs" Inherits="PTB_WEB.UserControl.LogThietBi.ucLogThietBi_BreadCrumb" %>

<%@ Register Src="~/UserControl/Search/ucTimKiem_Mobile.ascx" TagPrefix="uc" TagName="ucTimKiem_Mobile" %>

<% if (isMobile)
   {  %>
<uc:ucTimKiem_Mobile runat="server" ID="_ucTimKiem_Mobile" />
<%} %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="#">Log thiết bị</a></li>
    <% if (Request.QueryString["id"] != null && Request.QueryString["idp"] != null)
       { %>
    <li><a href="LogThietBi.aspx?id=<% Response.Write(Request.QueryString["id"].ToString()); Response.Write("&idp=" + Request.QueryString["idp"].ToString()); if (Request.QueryString["type"] != null) Response.Write("&type=" + Request.QueryString["type"].ToString()); if (Request.QueryString["Page"] != null) Response.Write("&Page=" + Request.QueryString["Page"].ToString());%>">
        <asp:Label ID="Label_TenThietBi" runat="server"></asp:Label>
    </a></li>
    <%} %>
    <% if (Request.QueryString["idLog"] != null)
       { %>
    <li><a href="<% Response.Write(PTB_WEB.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "idLog", (Request.QueryString["idLog"].ToString()))); %>">
        <asp:Label ID="Label_LogNgay" runat="server"></asp:Label>
    </a></li>
    <%} %>
</ol>

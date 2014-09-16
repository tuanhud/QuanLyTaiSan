<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien_BreadCrumb.ascx.cs" Inherits="PTB_WEB.UserControl.NhanVien.ucNhanVien_BreadCrumb" %>

<%@ Register Src="~/UserControl/TimKiem.ascx" TagPrefix="uc" TagName="TimKiem" %>
<%@ Register Src="~/UserControl/Search/ucTimKiem_Mobile.ascx" TagPrefix="uc" TagName="ucTimKiem_Mobile" %>

<% if (isMobile)
   {  %>
<uc:ucTimKiem_Mobile runat="server" ID="_ucTimKiem_Mobile" />
<%} %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li <%# Request.QueryString["id"] != null?"":"class=\"active\"" %>><a href="NhanVien.aspx<% if (Request.QueryString["Page"] != null) Response.Write("?Page=" + Request.QueryString["Page"]); %>">Nhân viên</a></li>
    <% if (Request.QueryString["id"] != null)
       { %>
    <li><a href="<%# Request.Url.AbsoluteUri %>">
        <asp:Label ID="Label_TenNhanVien" runat="server"></asp:Label></a></li>
    <%} %>
    <%if (!isMobile)
      {%>
    <span>
        <li class="pull-right rowfix input-group col-lg-3">
            <uc:TimKiem runat="server" ID="TimKiem" />
        </li>
    </span>
    <%}%>
</ol>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_BreadCrumb.ascx.cs" Inherits="TSCD_WEB.UserControl.Phong.ucPhong_BreadCrumb" %>
<%@ Register Src="~/UserControl/TimKiem/ucTimKiem.ascx" TagPrefix="uc" TagName="ucTimKiem" %>
<% if (isMobile)
   {  %>
<div class="row timkiem">
    <div class="input-group col-xs-12 col-sm-12 col-md-12 pull-right">
        <uc:ucTimKiem runat="server" ID="ucTimKiem_Mobile" />
    </div>
</div>
<%} %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="Phong.aspx">Phòng</a></li>
    <% if (Request.QueryString["key"] != null)
       { %>
    <li><a href="Phong.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); if (Request.QueryString["Page"] != null) Response.Write("&Page=" + Request.QueryString["Page"].ToString());%>">
        <asp:Label ID="Label_TenViTri" runat="server"></asp:Label></a></li>
    <% } %>
    <% if (Request.QueryString["id"] != null && Request.QueryString["key"] != null)
       { %>
    <li><a href="Phong.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); %>&id=<% Response.Write(Request.QueryString["id"].ToString()); %>">
        <asp:Label ID="Label_TenPhong" runat="server"></asp:Label></a></li>
    <% } %>
    <%if (!isMobile)
      {%>
    <span>
        <li class="pull-right rowfix input-group col-lg-3">
            <uc:ucTimKiem runat="server" ID="ucTimKiem_Web" />
        </li>
    </span>
    <%}%>
</ol>
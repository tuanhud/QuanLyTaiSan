<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhongThietBi_BreadCrumb.ascx.cs" Inherits="PTB_WEB.UserControl.Phong.ucPhongThietBi_BreadCrumb" %>
<%@ Register Src="~/UserControl/TimKiem.ascx" TagPrefix="uc" TagName="TimKiem" %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="PhongThietBi.aspx">Phòng - Thiết bị</a></li>
    <% if (Request.QueryString["key"] != null)
       { %>
    <li><a href="PhongThietBi.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); %>">
        <asp:Label ID="Label_TenPhong" runat="server"></asp:Label></a></li>
    <% } %>
    <% if (Request.QueryString["id"] != null && Request.QueryString["key"] != null)
       { %>
    <li><a href="PhongThietBi.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); %>&id=<% Response.Write(Request.QueryString["id"].ToString()); %>">
        <asp:Label ID="Label_TenThietBi" runat="server"></asp:Label></a></li>
    <% } %>
    <%if (!isMobile)
      {%>
    <span>
        <li class="pull-right rowfix input-group col-lg-3">
            <uc:TimKiem runat="server" ID="TimKiem" />
        </li>
    </span>
    <%}%>
</ol>

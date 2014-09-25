<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_BreadCrumb.ascx.cs" Inherits="TSCD_WEB.UserControl.ViTri.ucViTri_BreadCrumb" %>
<%@ Register Src="~/UserControl/TimKiem/ucTimKiem.ascx" TagPrefix="uc" TagName="ucTimKiem" %>

<%if (isMobile)
  { %>
<uc:ucTimKiem runat="server" ID="ucTimKiem_Mobile" />
<%} %>
<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="ViTri.aspx">Vị trí</a></li>
    <% if (Request.QueryString["key"] != null)
       { %>
    <li><a href="ViTri.aspx?key=<% Response.Write(Request.QueryString["key"].ToString()); %>">
        <asp:Label ID="Label_TenViTri" runat="server"></asp:Label></a></li>
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


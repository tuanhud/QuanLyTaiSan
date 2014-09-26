<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoaiPhong_BreadCrumb.ascx.cs" Inherits="TSCD_WEB.UserControl.LoaiPhong.ucLoaiPhong_BreadCrumb" %>
<%@ Register Src="~/UserControl/TimKiem/ucTimKiem.ascx" TagPrefix="uc" TagName="ucTimKiem" %>

<div class="row timkiem" runat="server" id="_MOBILE" visible="false">
    <div class="input-group col-xs-12 col-sm-12 col-md-12 pull-right">
        <uc:ucTimKiem runat="server" ID="ucTimKiem_Mobile" />
    </div>
</div>

<ol class="breadcrumb">
    <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
    <li><a href="LoaiPhong.aspx">Loại phòng</a></li>
    <li runat="server" id="_KEY" visible="false">
        <a href="Phong.aspx?key=<%=key%><%=page==""?page:"&Page="+page%>">
            <asp:Label ID="Label_TenLoaiPhong" runat="server"></asp:Label>
        </a>
    </li>
    <li runat="server" id="_ID" visible="false">
        <a href="Phong.aspx?key=<%=key%>&id=<%=id%><%=page==""?page:"&Page="+page%>">
        <asp:Label ID="Label_TenPhong" runat="server"></asp:Label>
        </a>
    </li>
    <span runat="server" id="_WEB" visible="false">
        <li class="pull-right rowfix input-group col-lg-3">
            <uc:ucTimKiem runat="server" ID="ucTimKiem_Web" />
        </li>
    </span>
</ol>
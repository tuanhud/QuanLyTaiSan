<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTimKiem_Web.ascx.cs" Inherits="PTB_WEB.UserControl.Search.ucTimKiem_Web" %>
<%@ Register Src="~/UserControl/TimKiem.ascx" TagPrefix="uc" TagName="TimKiem" %>
<div class="row timkiem">
    <div class="input-group col-lg-3 pull-right">
        <uc:TimKiem runat="server" id="_TimKiem" />
    </div>
</div>
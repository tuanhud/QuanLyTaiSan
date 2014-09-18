<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTimKiem_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.Search.ucTimKiem_Mobile" %>
<%@ Register Src="~/UserControl/TimKiem.ascx" TagPrefix="uc" TagName="TimKiem" %>
<%--<div class="row rowmobile">
    <div class="input-group col-lg-2 pull-right">
        <uc:TimKiem runat="server" id="TimKiem" />
        <span class="input-group-addon"><span class="glyphicon glyphicon-search"></span></span>
    </div>
</div>--%>

<div class="row timkiem">
    <div class="input-group col-xs-12 col-sm-12 col-md-12 pull-right">
        <uc:TimKiem runat="server" id="TimKiem" />
    </div>
</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTimKiem_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.Search.ucTimKiem_Mobile" %>
<%@ Register Src="~/UserControl/TimKiem.ascx" TagPrefix="uc" TagName="TimKiem" %>
<div class="row rowmobile">
    <div class="input-group col-lg-3 pull-right">
        <uc:TimKiem runat="server" id="TimKiem" />
        <span class="input-group-addon"><span class="glyphicon glyphicon-search"></span></span>
    </div>
</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucWarning.ascx.cs" Inherits="PTB_WEB.UserControl.Alert.ucWarning" %>
<div class="alert alert-warning alert-dismissible" role="alert">
    <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
    <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label>
</div>
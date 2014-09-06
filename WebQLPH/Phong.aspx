<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Phong.aspx.cs" Inherits="WebQLPH.Phong" %>

<%@ Register Src="~/UserControl/Phong/ucPhong_Web.ascx" TagPrefix="uc" TagName="ucPhong_Web" %>
<%@ Register Src="~/UserControl/Phong/ucPhong_Mobile.ascx" TagPrefix="uc" TagName="ucPhong_Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Phòng :: Phòng Thiết bị :.</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">
        <asp:Panel ID="Panel_Web" runat="server" Visible="false">
            <uc:ucPhong_Web runat="server" ID="_ucPhong_Web" />
        </asp:Panel>
        <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
            <uc:ucPhong_Mobile runat="server" ID="_ucPhong_Mobile" />
        </asp:Panel>
    </div>
</asp:Content>

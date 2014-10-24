<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ViTri.aspx.cs" Inherits="PTB_WEB.ViTri" %>

<%@ Register Src="~/UserControl/ViTri/ucViTri_Web.ascx" TagPrefix="uc" TagName="ucViTri_Web" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_Mobile.ascx" TagPrefix="uc" TagName="ucViTri_Mobile" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Vị trí :: Quản lý Thiết bị :.</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel_Web" runat="server" Visible="false">
        <script type="text/javascript">
            var showPopup = true;
            var iframe;

            function OnPopupInit(s, e) {
                iframe = popup.GetContentIFrame();

                /* the "load" event is fired when the content has been already loaded */
                ASPxClientUtils.AttachEventToElement(iframe, 'load', OnContentLoaded);
            }

            function OnPopupShown(s, e) {
                if (showPopup)
                    lp.ShowInElement(iframe);
            }

            function OnContentLoaded(e) {
                showPopup = false;
                lp.Hide();
            }

            function OnButtonClick(s, e) {
                showPopup = true;
                popup.SetContentUrl("https://www.google.com/maps/embed/v1/place?key=AIzaSyB2ryXlc0dNmczXS7O6E5htyRpkR4zvmVo&q=sdsaasd");

                popup.Show();
            }

            function _ShowMaps(_UrlMaps) {
                showPopup = true;
                popup.SetContentUrl(_UrlMaps);

                popup.Show();
            }
        </script>
        <uc:ucViTri_Web runat="server" ID="_ucViTri_Web" />
    </asp:Panel>
    <asp:Panel ID="Panel_Mobile" runat="server" Visible="false">
        <uc:ucViTri_Mobile runat="server" ID="_ucViTri_Mobile" />
    </asp:Panel>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonViTaiSan.aspx.cs" Inherits="TSCD_WEB.DonViTaiSan" %>
<%@ Register Src="~/UserControl/DonViTaiSan/ucDonViTaiSan_Web.ascx" TagPrefix="uc" TagName="ucDonViTaiSan_Web" %>
<%@ Register Src="~/UserControl/DonViTaiSan/ucDonViTaiSan_Mobile.ascx" TagPrefix="uc" TagName="ucDonViTaiSan_Mobile" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Đơn vị - Tài sản :: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

        function _ShowFull(_Url) {
            showPopup = true;
            popup.SetContentUrl(_Url);

            popup.Show();
        }
    </script>
    <uc:ucDonViTaiSan_Web runat="server" ID="ucDonViTaiSan_Web" Visible="false" />
    <uc:ucDonViTaiSan_Mobile runat="server" ID="ucDonViTaiSan_Mobile" Visible="false" />
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>
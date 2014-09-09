<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucASPxImageSlider_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.ucASPxImageSlider_Mobile" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>

<div class="image_center_mobile">
    <dx:ASPxImageSlider ID="ASPxImageSlider_Object" runat="server" BinaryImageCacheFolder="~\Thumb\" ShowNavigationBar="False" Width="200px" Height="200px">
        <Styles>
            <PassePartout BackColor="Transparent" />
        </Styles>
    </dx:ASPxImageSlider>
</div>

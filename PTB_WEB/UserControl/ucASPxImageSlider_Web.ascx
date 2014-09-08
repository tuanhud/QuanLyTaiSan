<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucASPxImageSlider_Web.ascx.cs" Inherits="PTB_WEB.UserControl.ucASPxImageSlider" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<script type="text/javascript">
    var clickCount = 0;
    function Show(url_img) {
        clickCount++;
        setTimeout(function () { clickCount = 0; }, 300);
        if (clickCount == 2) {
            if (url_img != "") {
                PopupControlImage.SetContentUrl(url_img);
                PopupControlImage.Show();
                clickCount = 0;
            }
        }
    }
</script>

<div class="image_center_web" <% if (!(ASPxImageSlider_Object.Items.ToList().Count == 1 && Object.Equals(ASPxImageSlider_Object.Items[0].ImageUrl, "~/Images/NoImage.jpg"))) { Response.Write(urlHinhAnh != "" ? string.Format("onclick=\"Show('{0}');\"", urlHinhAnh) : ""); } %>>
    <dx:ASPxImageSlider ID="ASPxImageSlider_Object" runat="server" BinaryImageCacheFolder="~\Thumb\" ShowNavigationBar="False" Width="350px" Height="350px">
        <Items>
            <dx:ImageSliderItem ImageUrl="~/Images/NoImage.jpg" Name="Không có ảnh">
            </dx:ImageSliderItem>
        </Items>
        <Styles>
            <PassePartout BackColor="Transparent" />
        </Styles>
    </dx:ASPxImageSlider>
</div>

<dx:ASPxPopupControl ID="ASPxPopupControl" runat="server" ClientInstanceName="PopupControlImage" CloseAction="CloseButton" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Hình ảnh" Theme="PlasticBlue" AllowResize="True" AutoUpdatePosition="True" Width="800px" Height="600px">
    <ContentCollection>
        <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>

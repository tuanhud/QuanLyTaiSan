<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Web.ascx.cs" Inherits="PTB_WEB.UserControl.ViTri.ucViTri_Web" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxLoadingPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_BreadCrumb.ascx" TagPrefix="uc" TagName="ucViTri_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>


<uc:ucViTri_BreadCrumb runat="server" ID="ucViTri_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 210px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                </td>
                <td>
                    <%if (Request.QueryString["key"] == null)
                      { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <asp:Label ID="Label_ChuaChon" runat="server" Visible="false"></asp:Label>
                    </div>
                    <%}
                      else
                      { %>
                    <h3 class="title_green fix">
                        <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
                        <%if (!strSrc.Equals(string.Empty))
                          { %>
                        <asp:LinkButton ID="LinkButtonBanDo" CssClass="pull-right" runat="server">Bản đồ</asp:LinkButton>
                        <%} %>
                    </h3>
                    <asp:Panel ID="Panel_ThongTinViTri" runat="server" Visible="False">
                        <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                        <table class="table table-striped">
                            <tbody>
                                <tr>
                                    <td>Tên:</td>
                                    <td>
                                        <asp:Label ID="Label_Ten" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Thuộc:</td>
                                    <td>
                                        <asp:Label ID="Label_Thuoc" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <asp:Panel ID="Panel_DiaChi" runat="server" Visible="False">
                                    <tr>
                                        <td>Đia chỉ:</td>
                                        <td>
                                            <asp:Label ID="Label_DiaChi" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td>Mô tả:</td>
                                    <td>
                                        <asp:Label ID="Label_MoTa" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                    <%} %>
                </td>
            </tr>
        </tbody>
    </table>
    <dx:ASPxLoadingPanel ID="lp" runat="server" Theme="Moderno" ClientInstanceName="lp"></dx:ASPxLoadingPanel>
    <dx:ASPxPopupControl ID="popup" runat="server" ClientInstanceName="popup" CloseAction="CloseButton" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Bản đồ" Theme="PlasticBlue" AllowResize="True" AllowDragging="true" AutoUpdatePosition="True" Width="800px" Height="600px" ContentUrl="javascript:void(0);">
        <ClientSideEvents Init="OnPopupInit" Shown="OnPopupShown" />
    </dx:ASPxPopupControl>
</asp:Panel>

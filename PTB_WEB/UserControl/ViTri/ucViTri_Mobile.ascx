<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.ViTri.ucViTri_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_BreadCrumb.ascx" TagPrefix="uc" TagName="ucViTri_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucViTri_BreadCrumb runat="server" ID="ucViTri_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_TreeViTri" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 210px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
<asp:Panel ID="Panel_ThongTinObj" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <h3 class="title_green fix">
                        <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
                    </h3>
                    <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
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
                            <tr>
                                <td colspan="2" class="tdcenter">
                                    <asp:Button ID="Button_Map" CssClass="btn btn-success" runat="server" Text="Xem bản đồ" OnClick="Button_Map_Click" Width="100px" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

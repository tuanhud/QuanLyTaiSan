<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoaiThietBi_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.LoaiThietBis.ucLoaiThietBi_Mobile" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/LoaiThietBi/ucLoaiThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucLoaiThietBi_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucLoaiThietBi_BreadCrumb runat="server" ID="ucLoaiThietBi_BreadCrumb" />
    <asp:Panel ID="Panel_TreeList" runat="server" Visible="False">
        <table class="table largetable">
            <tbody>
                <tr>
                    <td>
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
                        <table class="table table-striped">
                            <tbody>
                                <tr>
                                    <td style="width: 120px">Tên loại:</td>
                                    <td>
                                        <asp:Label ID="Label_TenLoai" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Kiểu quản lý:</td>
                                    <td>
                                        <asp:Label ID="Label_KieuQuanLy" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Mô tả:</td>
                                    <td>
                                        <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Thuộc:</td>
                                    <td>
                                        <asp:Label ID="Label_Thuoc" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Panel>

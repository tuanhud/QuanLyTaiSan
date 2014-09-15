<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoaiThietBi_Web.ascx.cs" Inherits="PTB_WEB.UserControl.LoaiThietBis.ucLoaiThietBi_Web" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/LoaiThietBi/ucLoaiThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucLoaiThietBi_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>


<uc:ucLoaiThietBi_BreadCrumb runat="server" ID="ucLoaiThietBi_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <table class="table largetable">
        <tr>
            <td style="width: 210px" class="border_right">
                <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
            </td>
            <td>
                <uc:ucWarning runat="server" ID="ucWarning" Visible="false" />
                <asp:Panel ID="Panel_ThongTinLoaiThietBi" runat="server" Visible="False">
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
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>

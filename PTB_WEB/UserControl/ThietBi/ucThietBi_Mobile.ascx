<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThietBi_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.ThietBi.ucThietBi_Mobile" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ThietBi/ucThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucThietBi_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucThietBi_BreadCrumb runat="server" ID="ucThietBi_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_TreeList" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 210px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                    <% if (RepeaterThietBi.Items.Count == 0)
                       { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <asp:Label ID="Label_TextDanhSachThietBi" runat="server"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
                    <h3 class="title_blue fix">Danh sách thiết bị</h3>
                    <table class="table table-bordered table-striped table-hover valign_middle">
                        <thead class="centered">
                            <tr>
                                <th>#</th>
                                <th>Mã thiết bị</th>
                                <th>Tên thiết bị</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterThietBi" runat="server">
                                <ItemTemplate>
                                    <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                        <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.PageSize) %></td>
                                        <td><%# Eval("subid") %></td>
                                        <td><%# Eval("ten") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachThietBi" />
                    <% } %>
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
                        <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label>
                    </h3>
                    <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td style="width: 120px">Mã thiết bị:</td>
                                <td>
                                    <asp:Label ID="Label_MaThietBi" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Tên thiết bị:</td>
                                <td>
                                    <asp:Label ID="Label_TenThietBi" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Loại thiết bị:</td>
                                <td>
                                    <asp:Label ID="Label_LoaiThietBi" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Ngày mua:</td>
                                <td>
                                    <asp:Label ID="Label_NgayMua" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Mô tả:</td>
                                <td>
                                    <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

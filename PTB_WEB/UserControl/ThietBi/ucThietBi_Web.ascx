<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThietBi_Web.ascx.cs" Inherits="PTB_WEB.UserControl.ThietBi.ucThietBi_Web" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ThietBi/ucThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucThietBi_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>


<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucThietBi_BreadCrumb runat="server" ID="ucThietBi_BreadCrumb" />
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 300px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                </td>
                <td class="border_right">
                    <h3 class="title_green fix">Danh sách thiết bị</h3>
                    <% if (RepeaterThietBi.Items.Count == 0)
                       { %>
                    <div class="panel-body">
                        <asp:Label ID="Label_TextDanhSachThietBi" runat="server"></asp:Label></div>
                    <% }
                       else
                       { %>
                    <table class="table table-bordered table-striped table-hover valign_middle">
                        <thead class="centered">
                            <tr>
                                <th>#</th>
                                <th>Mã thiết bị</th>
                                <th>Tên thiết bị</th>
                                <th>Loại thiết bị</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterThietBi" runat="server">
                                <ItemTemplate>
                                    <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idThietBi.ToString()?" class=\"focusrow\"":"" %>>
                                        <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.PageSize) %></td>
                                        <td><%# Eval("subid") %></td>
                                        <td><%# Eval("ten") %></td>
                                        <td><%# Eval("loaithietbi") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <% } %>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachThietBi" />
                </td>
                <td style="width: 400px">
                    <h3 class="title_blue fix">
                        <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label></h3>
                    <asp:Panel ID="Panel_ThietBi" runat="server" Visible="False">
                        <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                        <table class="table table-striped">
                            <tbody>
                                <tr>
                                    <td style="width: 100px;">Mã thiết bị:</td>
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
                    </asp:Panel>
                    <asp:Label ID="Label_ThietBi" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    <dx:ASPxPopupControl ID="ASPxPopupControl" runat="server" ClientInstanceName="PopupControlImage" CloseAction="CloseButton" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Hình ảnh" Theme="PlasticBlue" AllowResize="True" AutoUpdatePosition="True" Width="800px" Height="600px">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Panel>

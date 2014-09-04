<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Web.ascx.cs" Inherits="WebQLPH.UserControl.Phong.ucPhong_Web" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
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

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <table class="table" style="border-top: white solid 2px">
        <tbody>
            <tr>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Vị trí
                        </div>
                        <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách phòng
                        </div>
                        <% if (RepeaterDanhSachPhong.Items.Count == 0)
                           { %>
                        <div class="panel-body">Vị trí này không có phòng</div>
                        <% }
                           else
                           { %>
                        <table class="table table-bordered table-striped table-hover">
                            <thead class="centered">
                                <tr>
                                    <th>#</th>
                                    <th>Tên phòng</th>
                                    <th>Mô tả</th>
                                    <th>Nhân viên phụ trách</th>
                                </tr>
                            </thead>
                            <tbody class="centered">
                                <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                                    <ItemTemplate>
                                        <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idPhong.ToString()?" class=\"focusrow\"":"" %>>
                                            <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachPhong.CurrentPage - 1)*CollectionPagerDanhSachPhong.PageSize) %></td>
                                            <td><%# Eval("ten") %></td>
                                            <td><%# Eval("subid") %></td>
                                            <td><%# Eval("nhanvienpt") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <% } %>
                    </div>

                    <div class="leftCollectionPager">
                        <div class="CollectionPager">
                            <cp:CollectionPager ID="CollectionPagerDanhSachPhong" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                        </div>
                    </div>
                </td>
                <td style="width: 400px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinPhong" runat="server" Text="Thông tin phòng"></asp:Label>
                        </div>

                        <div class="panel-body">
                            <asp:Panel ID="Panel_Phong" runat="server" Visible="False">
                                <table class="table table-bordered">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                                <div class="center">
                                                    <dx:ASPxImageSlider ID="ASPxImageSlider_Phong" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"><Styles><PassePartout BackColor="Transparent" /></Styles></dx:ASPxImageSlider>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Mã phòng</th>
                                            <td>
                                                <asp:Label ID="Label_MaPhong" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Tên phòng</th>
                                            <td>
                                                <asp:Label ID="Label_TenPhong" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Vị trí</th>
                                            <td>
                                                <asp:Label ID="Label_ViTriPhong" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Mô tả</th>
                                            <td>
                                                <asp:Label ID="Label_MoTaPhong" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Nhân viên phụ trách</th>
                                            <td>
                                                <asp:Label ID="Label_NhanVienPhuTrach" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Label ID="Label_Phong" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinNhanVien" runat="server" Text="Thông tin nhân viên"></asp:Label>
                        </div>

                        <div class="panel-body">
                            <asp:Panel ID="Panel_NhanVienPT" runat="server" Visible="False">
                                <table class="table table-bordered">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                                <div class="center">
                                                    <dx:ASPxImageSlider ID="ASPxImageSlider_NhanVienPT" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"><Styles><PassePartout BackColor="Transparent" /></Styles><Styles><PassePartout BackColor="Transparent" /></Styles></dx:ASPxImageSlider>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Mã nhân viên</th>
                                            <td>
                                                <asp:Label ID="Label_MaNhanVien" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Họ tên</th>
                                            <td>
                                                <asp:Label ID="Label_HoTen" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Số điện thoại</th>
                                            <td>
                                                <asp:Label ID="Label_SoDienThoai" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Label ID="Label_NhanVienPT" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

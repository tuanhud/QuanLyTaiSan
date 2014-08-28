<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhongThietBi_Web.ascx.cs" Inherits="WebQLPH.UserControl.PhongThietBi.ucPhongThietBi_Web" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>
    <table class="table" style="border-top: white solid 2px">
        <tbody>
            <tr>
                <td width="200px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Chọn phòng
                        </div>
                        <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                    </div>
                </td>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách thiết bị
                        </div>
                        <% if (RepeaterDanhSachThietBi.Items.Count == 0)
                           { %>
                        <div class="panel-body">
                            <asp:Label ID="Label_DanhSachThietBi" runat="server"></asp:Label>
                        </div>
                        <% }
                           else
                           { %>
                        <table class="table table-bordered table-striped table-hover">
                            <thead class="centered">
                                <tr>
                                    <th>#</th>
                                    <th>Tên</th>
                                    <th>Tình trạng</th>
                                    <th>Số lượng</th>
                                    <th>Xem Log</th>
                                </tr>
                            </thead>
                            <tbody class="centered">
                                <asp:Repeater ID="RepeaterDanhSachThietBi" runat="server">
                                    <ItemTemplate>
                                        <tr <%# Eval("id").ToString() == idThietBi.ToString()?" class=\"focusrow\"":"" %>>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachThietBi.CurrentPage - 1)*CollectionPagerDanhSachThietBi.PageSize) %></td>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ten") %></td>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("tinhtrang") %></td>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("soluong") %></td>
                                            <td>
                                                <button class="btn btn-default" onclick="OnMoreInfoClick('<%# Eval("urlLog") %>'); return false;">Xem log</button>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <% } %>
                    </div>
                    <div class="leftCollectionPager">
                        <div class="CollectionPager">
                            <cp:CollectionPager ID="CollectionPagerDanhSachThietBi" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                        </div>
                    </div>
                </td>
                <td width="400px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:Panel ID="Panel_ThietBi" runat="server" Visible="False">
                                <table class="table table-bordered">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                                <div class="center">
                                                    <dx:ASPxImageSlider ID="ASPxImageSlider_ThietBi" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Mã thiết bị</th>
                                            <td>
                                                <asp:Label ID="Label_MaThietBi" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Tên thiết bị</th>
                                            <td>
                                                <asp:Label ID="Label_TenThietBi" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Loại thiết bị</th>
                                            <td>
                                                <asp:Label ID="Label_LoaiThietBi" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Kiểu quản lý</th>
                                            <td>
                                                <asp:Label ID="Label_KieuQuanLy" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Thuộc phòng</th>
                                            <td>
                                                <asp:Label ID="Label_Phong" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="Panel_NgayMua" runat="server" Visible="False">
                                            <tr>
                                                <th style="width: 120px" class="warning">Ngày mua</th>
                                                <td>
                                                    <asp:Label ID="Label_NgayMua" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <th style="width: 120px" class="warning">Ngày lắp</th>
                                            <td>
                                                <asp:Label ID="Label_NgayLap" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Mô tả</th>
                                            <td>
                                                <asp:Label ID="Label_MoTa" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 120px" class="warning">Xem log</th>
                                            <td>
                                                <asp:Button ID="Button_XemLog" runat="server" Text="Xem log" CssClass="btn btn-default" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Label ID="Label_ThietBi" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <dx:ASPxPopupControl ID="ASPxPopupControl_ThietBi" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="600px" Modal="True" Width="1000px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Log thiết bị" Theme="MetropolisBlue">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Panel>

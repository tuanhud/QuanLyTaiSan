<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien_Web.ascx.cs" Inherits="WebQLPH.UserControl.NhanVien.ucNhanVien_Web" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <table class="table table-bordered table-striped">
        <tbody>
            <tr>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách nhân viên
                        </div>

                        <% if (RepeaterQuanLyNhanVien.Items.Count == 0)
                           { %>
                        <div class="panel-body">Chưa có nhân viên</div>
                        <% }
                           else
                           {%>
                        <table class="table table-bordered table-striped table-hover">
                            <thead class="centered">
                                <tr>
                                    <th>#</th>
                                    <th>Mã nhân viên</th>
                                    <th>Họ tên</th>
                                    <th>Số điện thoại</th>
                                </tr>
                            </thead>
                            <tbody class="centered">
                                <asp:Repeater ID="RepeaterQuanLyNhanVien" runat="server">
                                    <ItemTemplate>
                                        <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idNhanVien.ToString()?" class=\"focusrow\"":"" %>>
                                            <td><%# Container.ItemIndex + 1 + ((CollectionPagerQuanLyNhanVien.CurrentPage - 1)*CollectionPagerQuanLyNhanVien.PageSize) %></td>
                                            <td><%# Eval("subid") %></td>
                                            <td><%# Eval("hoten") %></td>
                                            <td><%# Eval("sodienthoai") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <%} %>
                    </div>

                    <div class="leftCollectionPager">
                        <div class="CollectionPager">
                            <cp:CollectionPager ID="CollectionPagerQuanLyNhanVien" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="20" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static"></cp:CollectionPager>
                        </div>
                    </div>
                </td>

                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <table class="table table-bordered">
                                <tr>
                                    <td colspan="2">
                                        <div class="center">
                                            <dx:ASPxImageSlider ID="ASPxImageSlider_NhanVienPT" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
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
                            </table>
                        </div>
                    </div>

                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách phòng
                        </div>

                        <% if (RepeaterDanhSachPhong.Items.Count == 0)
                           { %>
                        <div class="panel-body">Không có phòng nào</div>
                        <% }
                           else
                           {%>
                        <ul class="list-group">
                            <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                                <ItemTemplate>
                                    <li class="list-group-item"><%# Eval("ten") %></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <%} %>
                    </div>

                    <div class="leftCollectionPager">
                        <div class="CollectionPager">
                            <cp:CollectionPager ID="CollectionPagerDanhSachPhong" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="PageRoom" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static"></cp:CollectionPager>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

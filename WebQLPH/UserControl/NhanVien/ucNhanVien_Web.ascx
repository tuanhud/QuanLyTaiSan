<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien_Web.ascx.cs" Inherits="WebQLPH.UserControl.NhanVien.ucNhanVien_Web" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxImageSlider" tagprefix="dx" %>
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
                        <table class="table table-bordered table-striped">
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
                                        <tr>
                                            <td<%# Eval("id").ToString()==idNhanVien.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Container.ItemIndex + 1 + ((CollectionPagerQuanLyNhanVien.CurrentPage - 1)*CollectionPagerQuanLyNhanVien.PageSize) %></a></td>
                                            <td<%# Eval("id").ToString()==idNhanVien.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("subid") %></a></td>
                                            <td<%# Eval("id").ToString()==idNhanVien.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("hoten") %></a></td>
                                            <td<%# Eval("id").ToString()==idNhanVien.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("sodienthoai") %></a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <% if (RepeaterQuanLyNhanVien.Items.Count == 0)
                           { %>   
                        <div class="panel-body">Chưa có nhân viên</div>
                        <% } %>
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

                        <asp:Panel ID="PanelThongBao" runat="server" Visible="False">
                            <div>
                                <div class="alert alert-danger" role="alert">
                                    <span class="glyphicon glyphicon-exclamation-sign"></span>
                                    <asp:Label ID="LabelThongBao" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
        
                        <div class="panel-body">
                            <div class="center">
                                <dx:ASPxImageSlider ID="ImageSliderNhanVienPhuTrach" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                            </div>
                            <br />
                            <div>
                                <asp:Label ID="Label1" runat="server" Text="Mã nhân viên"></asp:Label>
                                <asp:TextBox ID="TextBox_MaNhanVien" CssClass="form-control" placeholder="Mã nhân viên" runat="server" Enabled="False"></asp:TextBox>
                                <br />

                                <asp:Label ID="Label2" runat="server" Text="Họ tên"></asp:Label>
                                <asp:TextBox ID="TextBox_HoTen" CssClass="form-control" placeholder="Họ tên nhân viên" runat="server" Enabled="False"></asp:TextBox>
                                <br />

                                <asp:Label ID="Label3" runat="server" Text="Số điện thoại"></asp:Label>
                                <asp:TextBox ID="TextBox_SoDienThoai" CssClass="form-control" placeholder="Số điện thoại" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách phòng
                        </div>
                        <ul class="list-group">
                            <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                                <ItemTemplate>
                                    <li class="list-group-item"><%# Eval("ten") %></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <% if (RepeaterDanhSachPhong.Items.Count == 0)
                           { %>   
                        <div class="panel-body">Không có phòng nào</div>
                        <% } %>
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
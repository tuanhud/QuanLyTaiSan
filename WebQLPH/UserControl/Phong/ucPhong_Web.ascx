<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Web.ascx.cs" Inherits="WebQLPH.UserControl.Phong.ucPhong_Web" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
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

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <table class="table table-bordered table-striped">
        <tbody>
            <tr>
                <td width="600px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Vị trí
                        </div>
                        <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" KeyFieldName="id_c" ParentFieldName="id_p" Theme="MetropolisBlue" ClientInstanceName="treeList" Width="100%" EnableTheming="True" EnableCallbacks="False">
                            <Columns>
                                <dx:TreeListTextColumn Caption="Tên" Name="colten" VisibleIndex="0">
                                    <DataCellTemplate>
                                        <a href="<%# Request.Url.AbsolutePath %>?idObj=<%# Eval("id")  %>&type=<%# Eval("loai") %>"><%# Eval("ten") %></a>
                                    </DataCellTemplate>
                                </dx:TreeListTextColumn>
                                <dx:TreeListTextColumn Caption="Mô tả" Name="colmota" VisibleIndex="1">
                                    <DataCellTemplate>
                                        <a href="<%# Request.Url.AbsolutePath %>?idObj=<%# Eval("id")  %>&type=<%# Eval("loai") %>"><%# Eval("mota") %></a>
                                    </DataCellTemplate>
                                </dx:TreeListTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedNode="True" />
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        </dx:ASPxTreeList>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách phòng
                        </div>
                        <table class="table table-bordered table-striped">
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
                                        <tr>
                                            <td<%# Eval("id").ToString() == idPhong.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachPhong.CurrentPage - 1)*CollectionPagerDanhSachPhong.PageSize) %></a></td>
                                            <td<%# Eval("id").ToString() == idPhong.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("ten") %></a></td>
                                            <td<%# Eval("id").ToString() == idPhong.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("subid") %></a></td>
                                            <td<%# Eval("id").ToString() == idPhong.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("nhanvienpt") %></a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <% if (RepeaterDanhSachPhong.Items.Count == 0)
                           { %>   
                        <div class="panel-body">Vị trí này không có phòng</div>
                        <% } %>
                    </div>
            
                    <div class="leftCollectionPager">
                        <div class="CollectionPager">
                            <cp:CollectionPager ID="CollectionPagerDanhSachPhong" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="1" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static"></cp:CollectionPager>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinPhong" runat="server" Text="Thông tin"></asp:Label>
                        </div>

                        <asp:Panel ID="PanelThongBao_Phong" runat="server" Visible="False">
                            <div>
                                <div class="alert alert-danger" role="alert">
                                    <span class="glyphicon glyphicon-exclamation-sign"></span>
                                    <asp:Label ID="LabelThongBao_Phong" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
        
                        <div class="panel-body">
                            <div class="center">
                                <dx:ASPxImageSlider ID="ASPxImageSlider_Phong" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                            </div>
                            <br />
                            <div>
                                <div class="row">
                                    <div class="col-lg-4">Mã phòng</div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox_MaPhong" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-4">Tên phòng</div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox_TenPhong" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-4">Vị trí</div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox_ViTriPhong" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-4">Mô tả</div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox_MoTaPhong" CssClass="form-control" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-4">Nhân viên phụ trách</div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox_NhanVienPhuTrach" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinNhanVien" runat="server" Text="Thông tin"></asp:Label>
                        </div>

                        <asp:Panel ID="PanelThongBao_NhanVien" runat="server" Visible="False">
                            <div>
                                <div class="alert alert-danger" role="alert">
                                    <span class="glyphicon glyphicon-exclamation-sign"></span>
                                    <asp:Label ID="LabelThongBao_NhanVien" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
        
                        <div class="panel-body">
                            <div class="center">
                                <dx:ASPxImageSlider ID="ASPxImageSlider_NhanVien" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                            </div>
                            <br />
                            <div>
                                <div class="row">
                                    <div class="col-lg-4">Mã nhân viên</div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox_MaNhanVien" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-4">Họ tên</div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox_TenNhanVien" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-4">Số điện thoại</div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox_SoDienThoai" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
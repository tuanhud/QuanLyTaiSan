<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhongThietBi_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.PhongThietBi.ucPhongThietBi_Mobile" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_TreeListViTri" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Chọn phòng cần xem
        </div>
        <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" KeyFieldName="id" ParentFieldName="parent_id" Theme="MetropolisBlue" ClientInstanceName="treeList" Width="100%" OnCustomDataCallback="ASPxTreeList_ViTri_CustomDataCallback" OnHtmlDataCellPrepared="ASPxTreeList_ViTri_HtmlDataCellPrepared" Font-Size="10.5pt">
            <Columns>
                <dx:TreeListTextColumn Caption="Tên" FieldName="ten" Name="colten" VisibleIndex="0">
                </dx:TreeListTextColumn>
            </Columns>
            <Settings ShowColumnHeaders="False" />
            <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" />
            <SettingsCookies Enabled="True" StoreExpandedNodes="True" StorePaging="True" />
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            <ClientSideEvents
                Init="function(s, e) {
                                    s.SetFocusedNodeKey('');
                                }"
                CustomDataCallback="function(s, e) {
                                if(e.result != '')
                                    document.location = e.result;
                                }"
                NodeClick="function(s, e) {
	                                var key = e.nodeKey;
                                    treeList.PerformCustomDataCallback(key); 
                                }" />
        </dx:ASPxTreeList>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_DanhSachThietBi" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_DanhSachThietBiTitle" runat="server" Text="Danh sách thiết bị"></asp:Label>
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
                        <tr>
                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachThietBi.CurrentPage - 1)*CollectionPagerDanhSachThietBi.PageSize) %></td>
                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ten") %></td>
                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("tinhtrang") %></td>
                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("soluong") %></td>
                            <td>
                                <button class="btn btn-default" onclick="location.href='<%# Eval("urlLog") %>'; return false;">Xem log</button>
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
    <asp:Button ID="ButtonBack_DanhSachThietBi" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_DanhSachThietBi_Click" />
</asp:Panel>

<asp:Panel ID="Panel_ThietBi" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label>
        </div>
        <div class="panel-body">
            <div class="center200">
                <dx:ASPxImageSlider ID="ASPxImageSlider_ThietBi" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="200px" ShowNavigationBar="False" Width="200px"></dx:ASPxImageSlider>
            </div>
            <br />
            <div>
                <div class="row">
                    <div class="col-lg-4">Mã thiết bị</div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox_MaThietBi" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4">Tên thiết bị</div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox_Ten" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4">Loại thiết bị</div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox_LoaiThietBi" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4">Kiểu quản lý</div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox_KieuQuanLy" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4">Phòng</div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox_Phong" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:Panel ID="Panel_NgayMua" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-lg-4">Ngày mua</div>
                        <div class="col-lg-8">
                            <asp:TextBox ID="TextBox_NgayMua" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                </asp:Panel>
                <div class="row">
                    <div class="col-lg-4">Ngày lắp</div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox_NgayLap" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4">Mô tả</div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox_MoTa" CssClass="form-control" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="ButtonBack_ThietBi" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_ThietBi_Click" />
</asp:Panel>

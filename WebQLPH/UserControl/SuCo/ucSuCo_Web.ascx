<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_Web.ascx.cs" Inherits="WebQLPH.UserControl.SuCo.ucSuCo_Web" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
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
                <td width="200">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Vị trí
                        </div>
                        <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" KeyFieldName="id_c" ParentFieldName="id_p" AutoGenerateColumns="False" Theme="MetropolisBlue" ClientInstanceName="treeList" Width="100%" OnCustomDataCallback="ASPxTreeList_ViTri_CustomDataCallback" OnFocusedNodeChanged="ASPxTreeList_ViTri_FocusedNodeChanged" OnHtmlDataCellPrepared="ASPxTreeList_ViTri_HtmlDataCellPrepared">
                            <Columns>
                                <dx:TreeListTextColumn Caption="(Cơ sở, dãy, tầng)" FieldName="ten" Name="colten" VisibleIndex="0" ShowInCustomizationForm="True">
                                </dx:TreeListTextColumn>
                            </Columns>
                            <Settings ShowTreeLines="False" SuppressOuterGridLines="true" />
                            <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" />
                            <SettingsCookies Enabled="True" StoreExpandedNodes="True" StorePaging="True" />
                            <ClientSideEvents 
                                CustomDataCallback="function(s, e) {
                                if(e.result != '')
                                    document.location = e.result;
                                }"
                                FocusedNodeChanged="function(s, e) { 
                                var key = treeList.GetFocusedNodeKey();
                                treeList.PerformCustomDataCallback(key); 
                            }" />                        
                        </dx:ASPxTreeList>
                    </div>
                </td>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách sự cố
                        </div>
                        <% if (RepeaterSuCo.Items.Count == 0)
                           { %>   
                        <div class="panel-body">Chưa có sự cố</div>
                        <% } else { %>
                        <table class="table table-bordered table-striped">
                            <thead class="centered">
                                <tr>
                                    <th>#</th>
                                    <th>Tên sự cố</th>
                                    <th>Tình trạng</th>
                                    <th>Ghi chú</th>
                                    <th>Ngày</th>
                                </tr>
                            </thead>
                            <tbody class="centered">
                                <asp:Repeater ID="RepeaterSuCo" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td<%# Eval("id").ToString() == idSuCo.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachSuCo.CurrentPage - 1)*CollectionPagerDanhSachSuCo.PageSize) %></a></td>
                                            <td<%# Eval("id").ToString() == idSuCo.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("ten") %></a></td>
                                            <td<%# Eval("id").ToString() == idSuCo.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("tinhtrang") %></a></td>
                                            <td<%# Eval("id").ToString() == idSuCo.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("mota") %></a></td>
                                            <td<%# Eval("id").ToString() == idSuCo.ToString()?" style=\"background: #d9edf7;\"":"" %>><a href="<%# Eval("url") %>"><%# Eval("ngay") %></a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <% } %>
                    </div>
            
                    <div class="leftCollectionPager">
                        <div class="CollectionPager">
                            <cp:CollectionPager ID="CollectionPagerDanhSachSuCo" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                        </div>
                    </div>
                </td>
                <td width="350">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinSuCo" runat="server" Text="Thông tin thiết bị"></asp:Label>
                        </div>

                        <div class="panel-body">
                            <asp:Label ID="Label_ThongBao" runat="server" Text=""></asp:Label>
                            <asp:Panel ID="PanelThongBao_SuCo" runat="server" Visible="False">
                                <div>
                                    <div class="alert alert-danger" role="alert">
                                        <span class="glyphicon glyphicon-exclamation-sign"></span>
                                        <asp:Label ID="LabelThongBao_SuCo" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="Panel_SuCo" runat="server" Visible="False">
                                <div class="center">
                                    <dx:ASPxImageSlider ID="ASPxImageSlider_SuCo" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                                </div>
                                <br />
                                <div>
                                    <div class="row">
                                        <div class="col-lg-4">Mã thiết bị</div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBox_MaSuCo" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">Tên thiết bị</div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBox_TenSuCo" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">Loại thiết bị</div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBox_LoaiSuCo" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">Ngày mua</div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBox_NgayMua" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">Mô tả</div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBox_MoTaSuCo" CssClass="form-control" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Label ID="Label_SuCo" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
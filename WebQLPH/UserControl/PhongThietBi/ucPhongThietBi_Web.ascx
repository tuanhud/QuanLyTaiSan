<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhongThietBi_Web.ascx.cs" Inherits="WebQLPH.UserControl.PhongThietBi.ucPhongThietBi_Web" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

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
    <table class="table table-bordered table-striped">
        <tbody>
            <tr>
                <td width="300px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Chọn phòng
                        </div>
                        <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" KeyFieldName="id_c" ParentFieldName="id_p" Theme="MetropolisBlue" ClientInstanceName="treeList" Width="100%" OnCustomDataCallback="ASPxTreeList_ViTri_CustomDataCallback" OnHtmlDataCellPrepared="ASPxTreeList_ViTri_HtmlDataCellPrepared">
                            <Columns>
                                <dx:TreeListTextColumn Caption="Tên" FieldName="ten" Name="colten" VisibleIndex="0">
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
                            Danh sách thiết bị
                        </div>
                        <% if (RepeaterDanhSachThietBi.Items.Count == 0)
                           { %>   
                        <div class="panel-body">
                            <asp:Label ID="Label_DanhSachThietBi" runat="server"></asp:Label>
                        </div>
                        <% } else { %>
                        <table class="table table-bordered table-striped table-hover">
                            <thead class="centered">
                                <tr>
                                    <th>#</th>
                                    <th>Tên</th>
                                    <th>Mã thiết bị</th>
                                    <th>Loại thiết bị</th>
                                    <th>Tình trạng</th>
                                    <th>Số lượng</th>
                                    <th>Kiểu quản lí</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody class="centered">
                                <asp:Repeater ID="RepeaterDanhSachThietBi" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachThietBi.CurrentPage - 1)*CollectionPagerDanhSachThietBi.PageSize) %></td>
                                            <td><%# Eval("ten") %></td>
                                            <td><%# Eval("subId") %></td>
                                            <td><%# Eval("tenloai") %></td>
                                            <td><%# Eval("tinhtrang") %></td>
                                            <td><%# Eval("soluong") %></td>
                                            <td><%# Eval("kieuQL") %></td>
                                            <td>
                                                <a href="javascript:void(0);" onclick="OnMoreInfoClick('<%# Eval("url") %>');" title="Xem log của <%# Eval("ten") %>">Xem log</a>
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
                            <cp:CollectionPager ID="CollectionPagerDanhSachThietBi" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="3" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <dx:ASPxPopupControl ID="ASPxPopupControl_ThietBi" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="800px" Modal="True" Width="1000px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Log thiết bị" Theme="MetropolisBlue">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Panel>
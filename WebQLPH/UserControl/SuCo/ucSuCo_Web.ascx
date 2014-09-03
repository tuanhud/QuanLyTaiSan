<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_Web.ascx.cs" Inherits="WebQLPH.UserControl.SuCo.ucSuCo_Web" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_BreadCrumb.ascx" TagPrefix="uc" TagName="ucSuCo_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <script type="text/javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>
    <uc:ucSuCo_BreadCrumb runat="server" ID="ucSuCo_BreadCrumb" />
    <table class="table" style="border-top: white solid 2px">
        <tr>
            <td style="width: 200px">
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
                        Danh sách sự cố
                    </div>
                    <% if (RepeaterSuCo.Items.Count == 0)
                       { %>
                    <div class="panel-body">
                        <asp:Label ID="Label_DanhSachSuCo" runat="server" Text="Phòng chưa có sự cố"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="centered">
                            <tr>
                                <th>#</th>
                                <th>Tên sự cố</th>
                                <th>Tình trạng</th>
                                <th>Mô tả</th>
                                <th>Xem Log</th>
                            </tr>
                        </thead>
                        <tbody class="centered">
                            <asp:Repeater ID="RepeaterSuCo" runat="server">
                                <ItemTemplate>
                                    <tr <%# Eval("id").ToString() == idSuCo.ToString()?" class=\"focusrow\"":"" %>>
                                        <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachSuCo.CurrentPage - 1)*CollectionPagerDanhSachSuCo.PageSize) %></td>
                                        <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ten") %></td>
                                        <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("tinhtrang") %></td>
                                        <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ngay") %></td>
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
                        <cp:CollectionPager ID="CollectionPagerDanhSachSuCo" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                    </div>
                </div>
            </td>
            <td style="width: 400px">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <asp:Label ID="Label_ThongTinSuCo" runat="server" Text="Thông tin sự cố"></asp:Label>
                    </div>

                    <div class="panel-body">
                        <asp:Panel ID="Panel_SuCo" runat="server" Visible="False">
                            <table class="table table-bordered">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <div class="center">
                                                <dx:ASPxImageSlider ID="ASPxImageSlider_SuCo" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"><Styles><PassePartout BackColor="Transparent" /></Styles></dx:ASPxImageSlider>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Tên sự cố</th>
                                        <td>
                                            <asp:Label ID="Label_TenSuCo" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="warning">Tình trạng</th>
                                        <td>
                                            <asp:Label ID="Label_TinhTrang" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="warning">Ngày tạo</th>
                                        <td>
                                            <asp:Label ID="Label_NgayTao" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="warning">Mô tả</th>
                                        <td>
                                            <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="warning">Xem log</th>
                                        <td>
                                            <asp:Button ID="Button_XemLog" runat="server" Text="Xem log" CssClass="btn btn-default" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        <asp:Label ID="Label_SuCo" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <dx:ASPxPopupControl ID="ASPxPopupControl_SuCo" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="600px" Modal="True" Width="1000px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Log sự cố" Theme="PlasticBlue">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Panel>

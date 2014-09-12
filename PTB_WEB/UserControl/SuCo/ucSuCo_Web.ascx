<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_Web.ascx.cs" Inherits="PTB_WEB.UserControl.SuCo.ucSuCo_Web" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_BreadCrumb.ascx" TagPrefix="uc" TagName="ucSuCo_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucSuCo_BreadCrumb runat="server" ID="ucSuCo_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <script type="text/javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>
    <table class="table largetable">
        <tr>
            <td style="width: 210px" class="border_right">
                <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
            </td>
            <td>
                <% if (RepeaterSuCo.Items.Count == 0)
                   { %>
                <div class="alert alert-warning alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <asp:Label ID="Label_DanhSachSuCo" runat="server" Text="Phòng chưa có sự cố"></asp:Label>
                </div>
                <% }
                   else
                   { %>
                <ul class="nav nav-tabs" role="tablist" id="myTab">
                    <li class="active"><a href="#danhsach" role="tab" data-toggle="tab">Danh sách sự cố</a></li>
                    <%if (Request.QueryString["id"] != null)
                      { %>
                    <li><a href="#thongtin" role="tab" data-toggle="tab">
                        <asp:Label ID="Label_ThongTinSuCo" runat="server" Text="Thông tin sự cố"></asp:Label></a></li>
                    <script>
                        $(function () {
                            $('#myTab a:last').tab('show')
                        })
                    </script>
                    <%} %>
                </ul>
                <asp:Panel ID="PanelChangePage" runat="server" Visible="false">
                    <script>
                        $(function () {
                            $('#myTab a:first').tab('show')
                        })
                    </script>
                </asp:Panel>
                <div class="tab-content">
                    <div class="tab-pane active" id="danhsach">
                        <table class="table table-bordered table-striped table-hover valign_middle">
                            <thead>
                                <tr>
                                    <th class="tdcenter">#</th>
                                    <th>Tên sự cố</th>
                                    <th>Tình trạng</th>
                                    <th>Ngày tạo</th>
                                    <th class="tdcenter">Log</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterSuCo" runat="server">
                                    <ItemTemplate>
                                        <tr <%# Eval("id").ToString() == idSuCo.ToString()?" class=\"focusrow\"":"" %>>
                                            <td class="tdcenter" onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachSuCo.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachSuCo.CollectionPager_Object.PageSize) %></td>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ten") %></td>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("tinhtrang") %></td>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ngay") %></td>
                                            <td class="tdcenter">
                                                <button class="btn btn-default" onclick="OnMoreInfoClick('<%# Eval("urlLog") %>'); return false;"><span class="glyphicon glyphicon-tasks"></span></button>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachSuCo" />
                    </div>
                    <div class="tab-pane" id="thongtin">
                        <asp:Panel ID="Panel_SuCo" runat="server" Visible="False">
                            <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                            <table class="table table-striped">
                                <tbody>
                                    <tr>
                                        <td>Tên sự cố:</td>
                                        <td>
                                            <asp:Label ID="Label_TenSuCo" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tình trạng:</td>
                                        <td>
                                            <asp:Label ID="Label_TinhTrang" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ngày tạo:</td>
                                        <td>
                                            <asp:Label ID="Label_NgayTao" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Mô tả:</td>
                                        <td>
                                            <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="tdcenter">
                                            <asp:Button ID="Button_XemLog" runat="server" Text="Xem log" CssClass="btn btn-default" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        <asp:Label ID="Label_SuCo" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <% } %>
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

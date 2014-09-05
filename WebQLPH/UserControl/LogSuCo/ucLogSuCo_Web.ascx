<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogSuCo_Web.ascx.cs" Inherits="WebQLPH.UserControl.LogSuCo.ucLogSuCo_Web" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>

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
                            <asp:Label ID="Label_LogSuCo" runat="server" Text="Log"></asp:Label>
                        </div>
                        <% if (RepeaterDanhSachLogSuCo.Items.Count == 0)
                           { %>
                        <div class="panel-body">
                            <asp:Label ID="Label_DanhSachLogSuCo" runat="server"></asp:Label>
                        </div>
                        <% }
                           else
                           { %>
                        <table class="table table-bordered table-striped table-hover">
                            <thead class="centered">
                                <tr>
                                    <th>#</th>
                                    <th>Tình trạng</th>
                                    <th>Phòng</th>
                                    <th>Ngày</th>
                                </tr>
                            </thead>
                            <tbody class="centered">
                                <asp:Repeater ID="RepeaterDanhSachLogSuCo" runat="server">
                                    <ItemTemplate>
                                        <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idLog.ToString()?" class=\"focusrow\"":"" %>>
                                            <td><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachLogSuCo.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachLogSuCo.CollectionPager_Object.PageSize) %></td>
                                            <td><%# Eval("tinhtrang") %></td>
                                            <td><%# Eval("phong") %></td>
                                            <td><%# Eval("ngay") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <% } %>
                    </div>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachLogSuCo" />
                </td>
                <td style="width: 400px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinLog" runat="server" Text="Thông tin nhân viên"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                            <table class="table table-bordered">
                                <tbody>
                                    <tr>
                                        <th style="width: 120px" class="warning">Tên sự cố</th>
                                        <td>
                                            <asp:Label ID="Label_TenSuCo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Tình trạng</th>
                                        <td>
                                            <asp:Label ID="Label_TinhTrang" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Ngày</th>
                                        <td>
                                            <asp:Label ID="Label_Ngay" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Phòng</th>
                                        <td>
                                            <asp:Label ID="Label_Phong" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Quản trị viên</th>
                                        <td>
                                            <asp:Label ID="Label_QuanTriVien" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Ghi chú</th>
                                        <td>
                                            <asp:Label ID="Label_GhiChu" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

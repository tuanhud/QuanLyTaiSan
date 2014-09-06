<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.SuCo.ucSuCo_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_BreadCrumb.ascx" TagPrefix="uc" TagName="ucSuCo_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
<button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucSuCo_BreadCrumb runat="server" ID="ucSuCo_BreadCrumb" />
    <asp:Panel ID="Panel_TreeViTri" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Chọn phòng
            </div>
            <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel_DanhSachSuCo" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_DanhSachSuCoTitle" runat="server" Text="Danh sách sự cố"></asp:Label>
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
                        <th>Log</th>
                    </tr>
                </thead>
                <tbody class="centered">
                    <asp:Repeater ID="RepeaterSuCo" runat="server">
                        <ItemTemplate>
                            <tr <%# Eval("id").ToString() == idSuCo.ToString()?" class=\"focusrow\"":"" %>>
                                <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachSuCo.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachSuCo.CollectionPager_Object.PageSize) %></td>
                                <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ten") %></td>
                                <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("tinhtrang") %></td>
                                <td>
                                    <button class="btn btn-default" onclick="location.href='<%# Eval("urlLog") %>'; return false;"><span class="glyphicon glyphicon-tasks"></span></button>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <% } %>
        </div>
        <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachSuCo" />
        <asp:Button ID="ButtonBack_DanhSachSuCo" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_DanhSachSuCo_Click" />
    </asp:Panel>
    <asp:Panel ID="Panel_SuCo" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTinSuCo" runat="server" Text="Thông tin sự cố"></asp:Label>
            </div>

            <div class="panel-body">
                <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
                <table class="table table-bordered">
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
                            <td>Xem log:</td>
                            <td>
                                <asp:Button ID="Button_XemLog" runat="server" Text="Xem log" CssClass="btn btn-default" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <asp:Button ID="ButtonBack_SuCo" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_SuCo_Click" />
    </asp:Panel>
</asp:Panel>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien_Web.ascx.cs" Inherits="PTB_WEB.UserControl.NhanVien.ucNhanVien_Web" %>

<%@ Register Src="~/UserControl/NhanVien/ucNhanVien_BreadCrumb.ascx" TagPrefix="uc" TagName="ucNhanVien_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucNhanVien_BreadCrumb runat="server" ID="_ucNhanVien_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <% if (RepeaterDanhSachNhanVien.Items.Count == 0)
                       {%>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        Chưa có nhân viên
                    </div>
                    <%}
                       else
                       {%>
                    <ul class="nav nav-tabs" role="tablist" id="myTab">
                        <li class="active"><a href="#danhsach" role="tab" data-toggle="tab">Danh sách nhân viên</a></li>
                        <%if (Request.QueryString["id"] != null)
                          {%>
                        <li><a href="#thongtin" role="tab" data-toggle="tab">
                            <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin nhân viên"></asp:Label></a></li>
                        <script>
                            $(function () {
                                $('#myTab a:last').tab('show')
                            })
                        </script>
                        <%}%>
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
                                <thead class="centered">
                                    <tr>
                                        <th>#</th>
                                        <th>Mã nhân viên</th>
                                        <th>Họ tên</th>
                                        <th>Số điện thoại</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterDanhSachNhanVien" runat="server">
                                        <ItemTemplate>
                                            <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idNhanVien.ToString()?" class=\"focusrow\"":"" %>>
                                                <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachPhong.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachPhong.CollectionPager_Object.PageSize) %></td>
                                                <td><%# Eval("subid") %></td>
                                                <td><%# Eval("hoten") %></td>
                                                <td><%# Eval("sodienthoai") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachNhanVien" />
                        </div>
                        <%if (Request.QueryString["id"] != null)
                          {%>
                        <div class="tab-pane" id="thongtin">
                            <table class="table largetable">
                                <tr>
                                    <td style="width: 50%">
                                        <h3 class="title_green fix">Thông tin nhân viên</h3>
                                        <asp:Panel ID="Panel_NhanVienPT" runat="server" Visible="false">
                                            <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                                            <table class="table table-striped">
                                                <tbody>
                                                    <tr>
                                                        <td>Mã nhân viên:</td>
                                                        <td>
                                                            <asp:Label ID="Label_MaNhanVien" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Họ tên:</td>
                                                        <td>
                                                            <asp:Label ID="Label_HoTen" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Số điện thoại:</td>
                                                        <td>
                                                            <asp:Label ID="Label_SoDienThoai" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <asp:Label ID="Label_NhanVienPT" runat="server" Visible="false"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <%if (RepeaterDanhSachPhong.Items.Count < 1)
                                          {%>
                                        <div class="alert alert-warning alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            Nhân viên này chưa quản lý phòng nào
                                        </div>
                                        <%}
                                          else
                                          {%>
                                        <h3 class="title_green fix">Danh sách phòng được phân công</h3>
                                        <ul class="list-group">
                                            <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                                                <ItemTemplate>
                                                    <a href="javascript:;" class="list-group-item" onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                                        <%# Eval("ten") %>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                        <%} %>
                                        <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachPhong" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%}
                       }%>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

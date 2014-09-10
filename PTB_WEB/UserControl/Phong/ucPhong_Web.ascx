<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Web.ascx.cs" Inherits="PTB_WEB.UserControl.Phong.ucPhong_Web" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/Phong/ucPhong_BreadCrumb.ascx" TagPrefix="uc" TagName="ucPhong_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>


<uc:ucPhong_BreadCrumb runat="server" ID="ucPhong_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 210px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                </td>
                <td>
                    <% if (RepeaterDanhSachPhong.Items.Count == 0)
                       { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <asp:Label ID="Label_TextDanhSachPhong" runat="server"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
                    <ul class="nav nav-tabs" role="tablist" id="myTab">
                        <li class="active"><a href="#danhsach" role="tab" data-toggle="tab">Danh sách phòng</a></li>
                        <%if (Request.QueryString["id"] != null)
                          { %>
                        <li><a href="#thongtin" role="tab" data-toggle="tab">
                            <asp:Label ID="Label_ThongTinPhong" runat="server" Text="Thông tin phòng"></asp:Label></a></li>
                        <script>
                            $(function () {
                                $('#myTab a:last').tab('show')
                            })
                        </script>
                        <%} %>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="danhsach">
                            <table class="table table-bordered table-striped table-hover valign_middle">
                                <thead class="centered">
                                    <tr>
                                        <th>#</th>
                                        <th>Tên phòng</th>
                                        <th>Mô tả</th>
                                        <th>Nhân viên phụ trách</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                                        <ItemTemplate>
                                            <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idPhong.ToString()?" class=\"focusrow\"":"" %>>
                                                <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachPhong.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachPhong.CollectionPager_Object.PageSize) %></td>
                                                <td><%# Eval("ten") %></td>
                                                <td><%# Eval("subid") %></td>
                                                <td><%# Eval("nhanvienpt") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachPhong" />
                        </div>
                        <div class="tab-pane" id="thongtin">
                            <table class="table largetable" style="height:auto">
                                <tr>
                                    <td style="width: 50%">
                                        <h3 class="title_green fix">Thông tin phòng</h3>
                                        <asp:Panel ID="Panel_Phong" runat="server" Visible="False">
                                            <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web_Phong" />
                                            <table class="table table-striped">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 120px">Mã phòng:</td>
                                                        <td>
                                                            <asp:Label ID="Label_MaPhong" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Tên phòng:</td>
                                                        <td>
                                                            <asp:Label ID="Label_TenPhong" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Vị trí:</td>
                                                        <td>
                                                            <asp:Label ID="Label_ViTriPhong" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Mô tả:</td>
                                                        <td>
                                                            <asp:Label ID="Label_MoTaPhong" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Phụ trách:</td>
                                                        <td>
                                                            <asp:Label ID="Label_NhanVienPhuTrach" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label_Phong" runat="server" Visible="false"></asp:Label>
                                        <h3 class="title_green fix">Thông tin nhân viên</h3>
                                        <asp:Panel ID="Panel_NhanVienPT" runat="server" Visible="False">
                                            <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web_NhanVienPT" />
                                            <table class="table table-striped">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 120px">Mã nhân viên:</td>
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
                                        </asp:Panel>
                                        <asp:Label ID="Label_NhanVienPT" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <% } %>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

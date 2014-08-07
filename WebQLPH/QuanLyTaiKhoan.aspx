<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="QuanLyTaiKhoan.aspx.cs" Inherits="WebQLPH.QuanLyTaiKhoan" %>

<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc1" TagName="ucDangNhap" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản lý tài khoản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="PanelDangNhap" runat="server" Visible="false">
        <div class="center">
            <uc1:ucDangNhap runat="server" ID="ucDangNhap" />
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelKhongPhaiQuanTriVien" runat="server" Visible="false">
        <div class="alert alert-warning alert-dismissible" role="alert">
            <span class="glyphicon glyphicon-info-sign"></span>
            Vui lòng đăng nhập bằng tài khoản quản trị viên để quản lý.
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelQuanLyTaiKhoan" runat="server" Visible="false">
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <div class="panel">
                    <asp:Button ID="ButtonThemMoiTaiKhoan" runat="server" Text="Thêm mới" CssClass="btn btn-primary" ClientIDMode="Static" />
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b>DANH SÁCH TÀI KHOẢN GIẢNG VIÊN MƯỢN PHÒNG</b></h3>
                    </div>
                    <table class="table table-bordered table-striped">
                        <thead class="centered">
                            <tr>
                                <th>STT</th>
                                <th>HỌ TÊN</th>
                                <th>EMAIL</th>
                                <th>TÀI KHOẢN</th>
                                <th>KHOA</th>
                                <th>NGÀY TẠO</th>
                                <th>MÔ TẢ</th>
                                <th>CÔNG CỤ</th>
                            </tr>
                        </thead>
                        <tbody class="centered">
                            <asp:Repeater ID="RepeaterQuanLyTaiKhoan" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1 %></td>
                                        <td id="hoten<%#Eval("id")%>"><%# Eval("hoten") %></td>
                                        <td><%# Eval("email") %></td>
                                        <td><%# Eval("username") %></td>
                                        <td><%# Eval("khoa") %></td>
                                        <td><%# NgayTao() %></td>
                                        <td><%# Eval("mota") %></td>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">
                                                    Công cụ
      <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu" role="menu">
                                                    <li><a href="#" onclick="CapNhat(<%#Eval("id")%>);"><span class="glyphicon glyphicon-pencil"></span>&nbsp;Cập nhật</a></li>
                                                    <li><a href="?op=xoa&id=<%#Eval("id")%>" onclick="return confirm('Bạn chắc chắn muốn xóa tài khoản <%#Eval("username")%>?');"><span class="glyphicon glyphicon-remove"></span>&nbsp;Xóa</a></li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <div class="centerCollectionPager">
                    <div class="CollectionPager">
                        <cp:CollectionPager ID="CollectionPagerQuanLyTaiKhoan" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="1" PagingMode="QueryString" QueryStringKey="Trang" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static">
                        </cp:CollectionPager>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- Popup Duyệt -->
        <div class="modal fade" id="PopupTaiKhoan" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" id="myModalLabel">Đổi mật khẩu mới cho tài tài khoản <b id="hotentaikhoan">abc</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <asp:HiddenField ID="HiddenFieldID" ClientIDMode="Static" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col-lg-2">Mật khẩu mới</div>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxMatKhauMoi" runat="server" CssClass="form-control" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
                        <asp:Button ID="ButtonLuuMatKhau" CssClass="btn btn-primary" runat="server" Text="Lưu" OnClick="ButtonLuu_Click" OnClientClick="return KiemTraDoiMatKhauTruocKhiLuu();" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

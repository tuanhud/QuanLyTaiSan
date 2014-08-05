<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="QuanLyMuonPhong.aspx.cs" Inherits="WebQLPH.QuanLyMuonPhong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản lý mượn phòng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="center">
        <asp:Panel ID="PanelDangNhap" runat="server" Visible="False">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h3 class="panel-title">Đăng nhập</h3>
                </div>
                <div class="panel-body">
                    <div class="col-lg-12">
                        <asp:Panel ID="PanelThongBao" runat="server" Visible="False">
                            <div class="row">
                                <div class="alert alert-danger" role="alert">
                                    <span class="glyphicon glyphicon-exclamation-sign"></span>
                                    <asp:Label ID="LabelThongBao" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="row">
                            <asp:TextBox ID="TextBoxTaiKhoan" runat="server" CssClass="form-control" placeholder="Tài khoản"></asp:TextBox>
                        </div>
                        <br />
                        <div class="row">
                            <asp:TextBox ID="TextBoxMatKhau" runat="server" CssClass="form-control" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div class="row">
                            <asp:CheckBox ID="CheckBoxNhoDangNhap" runat="server" />
                            Nhớ đăng nhập lần sau
                        </div>
                        <br />
                        <asp:Button ID="ButtonDangNhap" runat="server" Text="Đăng nhập" CssClass="btn btn-success center-block" />
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <asp:Panel ID="PanelQuanLyMuonPhong" runat="server" Visible="True">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title"><b>DANH SÁCH 10 PHÒNG MƯỢN GẦN NHẤT</b></h3>
            </div>
            <table class="table table-bordered table-striped">
                <thead class="centered">
                    <tr>
                        <th rowspan="2">STT</th>
                        <th rowspan="2">NGÀY TẠO</th>
                        <th rowspan="2">KHOA(PHÒNG) MƯỢN</th>
                        <th rowspan="2">NGÀY MƯỢN</th>
                        <th colspan="2">THỜI GIAN</th>
                        <th colspan="2">SỐ LƯỢNG</th>
                        <th rowspan="2">LỚP</th>
                        <th rowspan="2">LÝ DO SỬ DỤNG</th>
                        <th colspan="3">XỬ LÝ</th>
                    </tr>
                    <tr>
                        <th><i>Từ</i></th>
                        <th><i>Đến</i></th>
                        <th><i>Phòng</i></th>
                        <th><i>SV/Phòng</i></th>
                        <th><i>Duyệt</i></th>
                        <th><i>Ghi chú</i></th>
                        <th><i>Người duyệt</i></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RepeaterQuanLyMuonPhong" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("id") %></td>
                                <td><%# NgayTao() %></td>
                                <td><%# Eval("khoaphongmuon") %></td>
                                <td><%# NgayMuon() %></td>
                                <td><%# Tu() %></td>
                                <td><%# Den() %></td>
                                <td><%# Eval("sophong") %></td>
                                <td><%# Eval("soluongsv") %></td>
                                <td><%# Eval("lop") %></td>
                                <td><%# Eval("lydomuon") %></td>
                                <td><%# Duyet() %></td>
                                <td><%# Eval("ghichu") %></td>
                                <td><%# Eval("quantrivien.hoten") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <!-- Popup Duyệt -->
        <div class="modal fade" id="PopupDuyet" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" id="myModalLabel">Duyệt mượn phòng</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <asp:HiddenField ID="HiddenFieldID" ClientIDMode="Static" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col-lg-2">Trạng thái</div>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListTrangThai" runat="server" CssClass="selectpicker">
                                    <asp:ListItem Text="Chờ duyệt" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Chấp nhận" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Hủy bỏ" Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                                <script type="text/javascript">
                                    window.onload = function () {
                                        $('.selectpicker').selectpicker();
                                    };
                                </script>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-2">Ghi chú</div>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxGhiChu" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Phòng C.A107" Height="100px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
                        <asp:Button ID="ButtonLuu" CssClass="btn btn-primary" runat="server" Text="Lưu" OnClick="ButtonLuu_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

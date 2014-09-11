<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="QuanLyMuonPhong.aspx.cs" Inherits="PTB_WEB.QuanLyMuonPhong" %>

<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Quản lý mượn phòng :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
        <li><a href="QuanLyMuonPhong.aspx">Quản lý mượn phòng</a></li>
    </ol>
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <asp:Panel ID="PanelDangNhap" runat="server" Visible="false">
                        <div class="center">
                            <uc:ucDangNhap runat="server" ID="ucDangNhap" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelQuanLyPhongMuon" runat="server" Visible="False">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist" id="myTab">
                            <li class="active"><a href="#danhsachphongbandamuon" role="tab" data-toggle="tab" onclick="document.cookie='tab=danhsachphongbandamuon';"><b>Danh sách phòng bạn đã mượn</b></a></li>
                            <li id="lidanhsachgiangvienmuonphong" runat="server" visible="false"><a href="#danhsachgiangvienmuonphong" role="tab" data-toggle="tab" onclick="document.cookie='tab=danhsachgiangvienmuonphong';"><b>Danh sách giảng viên mượn phòng</b></a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="danhsachphongbandamuon">
                                <asp:Panel ID="PanelQuanLyPhongBanMuon" runat="server" Visible="false" ScrollBars="Auto">
                                    <div class="panel panel-info">
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
                                                <asp:Repeater ID="RepeaterQuanLyPhongBanMuon" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="tdcenter"><%# Container.ItemIndex + 1 + ((CollectionPagerQuanLyPhongBanMuon.CurrentPage - 1) * CollectionPagerQuanLyPhongBanMuon.PageSize) %></td>
                                                            <td><%# NgayTao() %></td>
                                                            <td><%# Eval("donvi") %></td>
                                                            <td><%# NgayMuon() %></td>
                                                            <td><%# Tu() %></td>
                                                            <td><%# Den() %></td>
                                                            <td><%# Eval("sophong") %></td>
                                                            <td><%# Eval("soluongsv") %></td>
                                                            <td><%# Eval("lop") %></td>
                                                            <td><%# Eval("lydomuon") %></td>
                                                            <td><%# TrangThai() %></td>
                                                            <td id='GhiChu<%#Eval("id")%>'><%# Eval("ghichu") %></td>
                                                            <td><%# Eval("nguoiduyet.hoten") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="centerCollectionPager">
                                        <div class="CollectionPager">
                                            <cp:CollectionPager ID="CollectionPagerQuanLyPhongBanMuon" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="20" PagingMode="QueryString" QueryStringKey="pta" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static">
                                            </cp:CollectionPager>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="tab-pane face" id="danhsachgiangvienmuonphong">
                                <asp:Panel ID="PanelQuanLyMuonPhong" runat="server" Visible="false" ScrollBars="Auto">
                                    <asp:UpdatePanel ID="UpdatePanelQuanLyMuonPhong" runat="server">
                                        <ContentTemplate>
                                            <div class="panel panel-info">
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
                                                                    <td class="tdcenter"><%# Container.ItemIndex + 1 + ((CollectionPagerQuanLyMuonPhong.CurrentPage - 1) * CollectionPagerQuanLyMuonPhong.PageSize) %></td>
                                                                    <td><%# NgayTao() %></td>
                                                                    <td><%# Eval("donvi") %></td>
                                                                    <td><%# NgayMuon() %></td>
                                                                    <td><%# Tu() %></td>
                                                                    <td><%# Den() %></td>
                                                                    <td><%# Eval("sophong") %></td>
                                                                    <td><%# Eval("soluongsv") %></td>
                                                                    <td><%# Eval("lop") %></td>
                                                                    <td><%# Eval("lydomuon") %></td>
                                                                    <td><%# Duyet() %></td>
                                                                    <td id='GhiChu<%#Eval("id")%>'><%# Eval("ghichu") %></td>
                                                                    <td><%# Eval("nguoiduyet.hoten") %></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div class="centerCollectionPager">
                                                <div class="CollectionPager">
                                                    <cp:CollectionPager ID="CollectionPagerQuanLyMuonPhong" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="20" PagingMode="QueryString" QueryStringKey="ptb" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static">
                                                    </cp:CollectionPager>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                                                            <asp:DropDownList ID="DropDownListTrangThai" runat="server" CssClass="form-control" ClientIDMode="Static">
                                                                <asp:ListItem Text="Chờ duyệt" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Chấp nhận" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Hủy bỏ" Value="-1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-lg-2">Ghi chú</div>
                                                        <div class="col-lg-10">
                                                            <asp:TextBox ID="TextBoxGhiChu" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Phòng C.A107" Height="100px" ClientIDMode="Static"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:CheckBox ID="CheckBoxGuiMailThongBao" runat="server" Checked="true" />&nbsp;Gửi mail thông báo
                        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
                                                    <asp:Button ID="ButtonLuu" CssClass="btn btn-primary" runat="server" Text="Lưu" OnClick="ButtonLuu_Click" OnClientClick="return KiemTraTruocKhiLuu();" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                        <script>
                            $(function () {
                                var x = document.cookie;
                                if (x.indexOf("danhsachgiangvienmuonphong") > -1)
                                    $('#myTab a:last').tab('show');
                                else
                                    $('#myTab a:first').tab('show');
                            })
                        </script>
                    </asp:Panel>
                </td>
            </tr>
        </tbody>
    </table>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

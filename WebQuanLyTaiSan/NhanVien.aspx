<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NhanVien.aspx.cs" Inherits="WebQuanLyTaiSan.NhanVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản lý nhân viên :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start: Content -->
    <div id="content" class="span10">
        <div class="row-fluid">
            <div class="box span12">
                <div class="box-header" data-original-title="">
                    <h2><i class="icon-list"></i><span class="break"></span>Danh sách nhân viên</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-striped table-bordered bootstrap-datatable datatable">
                        <thead>
                            <tr>
                                <th>Mã nhân viên</th>
                                <th>Tên nhân viên</th>
                                <th>Số điện thoại</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterNhanVienPT" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("subId") %></td>
                                        <th><%# Eval("hoten") %></th>
                                        <td><%# Eval("sodienthoai") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <!--/span-->
        </div>
        <!--/row-->
    </div>
</asp:Content>

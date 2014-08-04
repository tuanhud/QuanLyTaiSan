<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="BieuMauMuonPhong.aspx.cs" Inherits="Web.BieuMauMuonPhong" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Biểu mẫu mượn phòng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <asp:Panel ID="PanelDone" runat="server" Width="100%">
        <div class="alert alert-dismissable alert-success">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <strong>Quá trình mượn phòng đang được xem xét!</strong> Bạn sẽ nhận được thông báo trong thời gian sớm nhất <a href="BieuMauMuonPhong.aspx" class="alert-link">Click vào đây nếu muốn mượn thêm phòng</a>.
        </div>
    </asp:Panel>

    <asp:Panel ID="PanelFails" runat="server" Width="100%">
        <div class="alert alert-dismissable alert-danger">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <strong>Có lỗi xảy ra!</strong> Xem lỗi bên dưới, sửa lại cho đúng và click vào mượn phòng.
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelProcess" runat="server" Width="100%">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title">Biểu mẫu mượn phòng</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-lg-2 control-label">Từ ngày</label>
                    <div class="col-lg-10">
                        <dx:ASPxDateEdit ID="ASPxDateEditNgayMuon" runat="server"></dx:ASPxDateEdit>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label class="col-lg-2 control-label">Đến ngày</label>
                    <div class="col-lg-10">
                        <dx:ASPxDateEdit ID="ASPxDateEditNgayTra" runat="server"></dx:ASPxDateEdit>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label class="col-lg-2 control-label">Phòng cần mượn</label>
                    <div class="col-lg-10">
                        <dx:ASPxTextBox ID="ASPxTextBoxPhong" runat="server" Width="170px"></dx:ASPxTextBox>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label class="col-lg-2 control-label">Số lượng sinh viên</label>
                    <div class="col-lg-10">
                        <dx:ASPxTextBox ID="ASPxTextBoxSoLuong" runat="server" Width="170px"></dx:ASPxTextBox>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label class="col-lg-2 control-label">Lớp</label>
                    <div class="col-lg-10">
                        <dx:ASPxTextBox ID="ASPxTextBoxLop" runat="server" Width="170px"></dx:ASPxTextBox>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label class="col-lg-2 control-label">Lý do sử dụng</label>
                    <div class="col-lg-10">
                        <dx:ASPxMemo ID="ASPxMemoLyDoMuon" runat="server" Height="71px" Width="170px"></dx:ASPxMemo>
                    </div>
                </div>
                <center><asp:Button ID="ButtonMuonPhong" runat="server" Text="Mượn phòng" CssClass="btn btn-success" OnClick="ButtonMuonPhong_Click" /></center>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

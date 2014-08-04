<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="BieuMauMuonPhong.aspx.cs" Inherits="Web.BieuMauMuonPhong" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Biểu mẫu mượn phòng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="panel panel-success">
        <div class="panel-heading">
            <h3 class="panel-title">Biểu mẫu mượn phòng</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="col-lg-2 control-label">Từ ngày</label>
                <div class="col-lg-10">
                    <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server"></dx:ASPxDateEdit>
                </div>
            </div>
            <br />
            <div class="form-group">
                <label class="col-lg-2 control-label">Đến ngày</label>
                <div class="col-lg-10">
                    <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server"></dx:ASPxDateEdit>
                </div>
            </div>
            <br />
            <div class="form-group">
                <label class="col-lg-2 control-label">Phòng cần mượn</label>
                <div class="col-lg-10">
                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                </div>
            </div>
            <br />
            <div class="form-group">
                <label class="col-lg-2 control-label">Số lượng sinh viên</label>
                <div class="col-lg-10">
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px"></dx:ASPxTextBox>
                </div>
            </div>
            <br />
            <div class="form-group">
                <label class="col-lg-2 control-label">Lớp</label>
                <div class="col-lg-10">
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="170px"></dx:ASPxTextBox>
                </div>
            </div>
            <br />
            <div class="form-group">
                <label class="col-lg-2 control-label">Lý do sử dụng</label>
                <div class="col-lg-10">
                    <dx:ASPxMemo ID="ASPxMemo1" runat="server" Height="71px" Width="170px"></dx:ASPxMemo>
                </div>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Mượn phòng" CssClass="btn btn-success" />
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="QuanLyHinhAnh.aspx.cs" Inherits="WebQLPH.QuanLyHinhAnh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản lý hình ảnh</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading"><b>TẢI ẢNH LÊN</b></div>
        <div class="panel-body">
            <asp:FileUpload ID="ImageUpload" runat="server" CssClass="btn btn-success" AllowMultiple="True" ClientIDMode="Static" /><br />
            <asp:Button ID="ButtonTaiLen" CssClass="btn btn-success" runat="server" Text="Tải lên" OnClick="ButtonTaiLen_Click" />
        </div>
    </div>
    <div class="panel panel-info">
        <div class="panel-heading"><b>DANH SÁCH HÌNH ẢNH</b></div>
        <div class="panel-body">
            <div class="row">
                <asp:Repeater ID="RepeaterHinhAnh" runat="server">
                    <ItemTemplate>
                        <div class="col-xs-6 col-md-4">
                            <a href="<%#Url(Container.DataItem.ToString())%>" class="thumbnail">
                                <img src="<%#Url(Container.DataItem.ToString())%>" alt="<%# Container.DataItem %>" title="<%# Container.DataItem %>" />
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>

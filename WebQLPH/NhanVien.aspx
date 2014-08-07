<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NhanVien.aspx.cs" Inherits="WebQLPH.NhanVien" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxImageSlider" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nhân viên phụ trách</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel-body">
        <asp:Panel ID="PanelThongBao" runat="server" Visible="False">
            <div class="row">
                <div class="alert alert-danger" role="alert">
                    <span class="glyphicon glyphicon-exclamation-sign"></span>
                    <asp:Label ID="LabelThongBao" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>

    <div class="panel-body">
        <asp:Panel ID="PanelThongTinNhanVienPhuTrach" runat="server" Visible="False">
            <dx:ASPxImageSlider ID="ImageSliderNhanVienPhuTrach" runat="server" BinaryImageCacheFolder="~\Thumb\">
            </dx:ASPxImageSlider>
            <br />

            <asp:Label ID="Label1" runat="server" Text="Mã nhân viên"></asp:Label>
            <asp:TextBox ID="TextBox_MaNhanVien" CssClass="form-control" placeholder="Mã nhân viên" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Label2" runat="server" Text="Họ tên"></asp:Label>
            <asp:TextBox ID="TextBox_HoTen" CssClass="form-control" placeholder="Họ tên nhân viên" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Label3" runat="server" Text="Số điện thoại"></asp:Label>
            <asp:TextBox ID="TextBox_SoDienThoai" CssClass="form-control" placeholder="Số điện thoại" runat="server"></asp:TextBox>
        </asp:Panel>
    </div>
    
    <div class="panel-body">
        <asp:Panel ID="PanelDanhSachNhanVienPhuTrach" runat="server" Visible="False">
            <dx:ASPxGridView ID="GridViewNhanVienPhuTrach" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Mã nhân viên" VisibleIndex="1" FieldName="subId">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Họ tên" VisibleIndex="2" FieldName="hoten">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Số điện thoại" VisibleIndex="3" FieldName="sodienthoai">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn Caption="Hình ảnh" FieldName="imageURL" VisibleIndex="4">
                        <PropertiesImage ImageAlign="Middle" ImageHeight="50px" ImageWidth="50px">
                        </PropertiesImage>
                    </dx:GridViewDataImageColumn>
                </Columns>
            </dx:ASPxGridView>
        </asp:Panel>
    </div>

</asp:Content>
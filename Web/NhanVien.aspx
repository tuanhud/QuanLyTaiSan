<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NhanVien.aspx.cs" Inherits="Web.NhanVien" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nhân Viên :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title">Danh sách nhân viên phụ trách</h3>
        </div>
        <div class="panel-body">
            <dx:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" Theme="Youthful" Width="100%" KeyFieldName="id">
                <Columns>
                    <dx:GridViewDataImageColumn FieldName="hinhanhs.First().path" VisibleIndex="1" Caption="Hình ảnh">
                        <PropertiesImage ImageUrlFormatString="http://hoangthanhit.com/qlts/{0}">
                        </PropertiesImage>
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn Caption="Họ tên" FieldName="hoten" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Số điện thoại" FieldName="sodienthoai" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="id" Visible="False" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Settings ShowFilterRow="True" />
                <SettingsBehavior AllowSelectByRowClick="True" />
                <SettingsPager PageSize="10">
                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                </SettingsPager>
                <Styles>
                    <SelectedRow BackColor="#C0FFC0" ForeColor="#0033FF"></SelectedRow>
                </Styles>
                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>

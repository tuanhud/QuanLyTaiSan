<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ThietBis.aspx.cs" Inherits="Web.ThietBis" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thiết Bi :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="btn-group btn-group-justified">
        <asp:LinkButton ID="lblLoaiChung" CssClass="btn btn-warning" runat="server" OnClick="lblLoaiChung_Click" Enabled="false">Thiết bị quản lý theo số lượng</asp:LinkButton>
        <asp:LinkButton ID="lblLoaiRieng" CssClass="btn btn-success" runat="server" OnClick="lblLoaiRieng_Click">Thiết bị quản lý riêng lẻ</asp:LinkButton>
    </div>
    <br />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="lblInfo" runat="server" Text=""></asp:Label></h3>
        </div>
        <div class="panel-body">
            <dx:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" Theme="Youthful" Width="100%" KeyFieldName="id">
                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="id" VisibleIndex="0" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tên thiết bị" FieldName="ten" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Loại thiết bị" FieldName="loai" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ngày mua" FieldName="ngaymua" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                </Columns>
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

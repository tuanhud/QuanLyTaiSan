<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PhongThietBi.aspx.cs" Inherits="Web.PhongThietBi" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thiết bị của Phòng :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title">Danh sách thiết bị theo phòng</h3>
        </div>
        <div class="panel-body">
            <dx:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" Theme="Youthful" Width="100%" KeyFieldName="id">
                <Settings ShowFilterRow="True" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Cơ sở" FieldName="phong.vitri.coso.ten" VisibleIndex="0" GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Dãy" FieldName="phong.vitri.day.ten" VisibleIndex="1" GroupIndex="1" SortIndex="1" SortOrder="Ascending">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tầng" FieldName="phong.vitri.tang.ten" VisibleIndex="2" GroupIndex="2" Name="vitri.tang.ten" SortIndex="2" SortOrder="Ascending">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Phòng" FieldName="phong.ten" VisibleIndex="3" GroupIndex="3" Name="vitri.day.ten" SortIndex="3" SortOrder="Ascending">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tên thiết bị" FieldName="thietbi.ten" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Loại thiết bị" FieldName="thietbi.loaithietbi.ten" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tình trạng" FieldName="tinhtrang.value" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Số lượng" FieldName="soluong" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="id" VisibleIndex="8" Visible="false">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowSelectByRowClick="True" />
                <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" HorizontalScrollBarMode="Auto" />
                <%--<SettingsPager PageSize="10">
                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                </SettingsPager>--%>
                <SettingsPager Mode="EndlessPaging" PageSize="20"></SettingsPager>
                <Styles>
                    <SelectedRow BackColor="#C0FFC0" ForeColor="#0033FF"></SelectedRow>
                </Styles>
                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>

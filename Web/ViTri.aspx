<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ViTri.aspx.cs" Inherits="Web.ViTri" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Phòng :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title">Danh sách vị trí (Cơ sở - dãy - tầng)</h3>
        </div>
        <div class="panel-body">
            <dx:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" Theme="Youthful" Width="100%" KeyFieldName="id">
                <Settings ShowFilterRow="True" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Cơ sở" FieldName="vitri.coso.ten" GroupIndex="0" SortIndex="0" SortOrder="Ascending" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Dãy" FieldName="vitri.day.ten" VisibleIndex="1" GroupIndex="1" SortIndex="1" SortOrder="Ascending">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tầng" FieldName="ten_tang" VisibleIndex="2" GroupIndex="2" Name="vitri.tang.ten" SortIndex="2" SortOrder="Ascending">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="id" Visible="False" VisibleIndex="6">
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

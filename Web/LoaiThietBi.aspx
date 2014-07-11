<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LoaiThietBi.aspx.cs" Inherits="Web.LoaiThietBis" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Loại Thiết Bi :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title">Danh sách loại thiết bị</h3>
        </div>
        <div class="panel-body">
            <dx:ASPxTreeList ID="TreeListLoaiThietBi" runat="server" KeyFieldName="id" ParentFieldName="parent_id" AutoGenerateColumns="False" Theme="Youthful" Width="100%">
                <columns>
                    <dx:TreeListTextColumn Caption="Loại thiết bị" FieldName="ten" VisibleIndex="0" Width="20%">
                    </dx:TreeListTextColumn>
                    <dx:TreeListTextColumn Caption="Mô tả" FieldName="mota" VisibleIndex="1" CellStyle-Wrap="True">
                    </dx:TreeListTextColumn>
                </columns>
                <settingsdatasecurity allowdelete="False" allowedit="False" allowinsert="False" />
            </dx:ASPxTreeList>
        </div>
    </div>
</asp:Content>

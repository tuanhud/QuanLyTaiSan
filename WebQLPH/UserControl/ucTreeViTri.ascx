<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTreeViTri.ascx.cs" Inherits="WebQLPH.UserControl.ucTreeViTri" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" KeyFieldName="id" ParentFieldName="parent_id" Theme="Aqua" ClientInstanceName="treeList" Width="100%" OnCustomDataCallback="ASPxTreeList_ViTri_CustomDataCallback">
    <Columns>
        <dx:TreeListTextColumn Caption="Tên" Name="colten" VisibleIndex="0" FieldName="ten">
        </dx:TreeListTextColumn>
    </Columns>
    <Settings ShowColumnHeaders="False" />
    <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" />
    <SettingsCookies Enabled="True" StoreExpandedNodes="True" StorePaging="True" />
    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
    <ClientSideEvents
        CustomDataCallback="function(s, e) {
                                if(e.result != '')
                                    document.location = e.result;
                                }"
        NodeClick="function(s, e) {
	                var key = e.nodeKey;
	                treeList.PerformCustomDataCallback(key);
                }" />
</dx:ASPxTreeList>

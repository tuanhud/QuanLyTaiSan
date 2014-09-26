<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTreeViTri.ascx.cs" Inherits="TSCD_WEB.UserControl.TreeViTri.ucTreeViTri" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
        <h3 class="title_orange fix">
            <asp:Label ID="Label_TenViTri" runat="server"></asp:Label>
            <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="UpdatePanel" DisplayAfter="0" DynamicLayout="false" ClientIDMode="Static">
                <ProgressTemplate>
                    <img alt="Đang xử lý..." src="/Images/loading.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:LinkButton ID="LinkButton_Expand" runat="server" ToolTip="Expand All" OnClick="LinkButton_Expand_Click"><span class="pull-right" style="cursor: pointer;"><img src="/Images/ExpandAllIcon.png" alt="Expand All" /></span></asp:LinkButton>
            <asp:LinkButton ID="LinkButton_Collapse" runat="server" ToolTip="Collapse All" OnClick="LinkButton_Collapse_Click"><span class="pull-right" style="cursor: pointer"><img src="/Images/CollapseAllIcon.png" alt="Collapse All" style="padding-right:10px;" /></span></asp:LinkButton>
            <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" ClientInstanceName="treeList" KeyFieldName="id" OnCustomDataCallback="ASPxTreeList_ViTri_CustomDataCallback" ParentFieldName="parent_id" Theme="Aqua" Width="100%">
                <Columns>
                    <dx:TreeListTextColumn Caption="Tên" FieldName="ten" Name="colten" VisibleIndex="0">
                    </dx:TreeListTextColumn>
                </Columns>
                <Settings ShowColumnHeaders="False" />
                <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" />
                <SettingsCookies StoreExpandedNodes="True" StorePaging="True" />
                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                <ClientSideEvents CustomDataCallback="function(s, e) {
                                if(e.result != '')
                                    document.location = e.result;
                                }" NodeClick="function(s, e) {
	                var key = e.nodeKey;
	                treeList.PerformCustomDataCallback(key);
                }" />
            </dx:ASPxTreeList>
        </h3>
    </ContentTemplate>
</asp:UpdatePanel>

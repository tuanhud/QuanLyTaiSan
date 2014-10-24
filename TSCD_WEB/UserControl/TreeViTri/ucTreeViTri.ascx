<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTreeViTri.ascx.cs" Inherits="TSCD_WEB.UserControl.TreeViTri.ucTreeViTri" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<dx:ASPxTreeList ID="ASPxTreeList1" runat="server" AutoGenerateColumns="False" Visible="False">
    <Columns>
        <dx:TreeListTextColumn VisibleIndex="0">
        </dx:TreeListTextColumn>
        <dx:TreeListCheckColumn VisibleIndex="1">
        </dx:TreeListCheckColumn>
    </Columns>
    <Settings ShowColumnHeaders="False" />
    <SettingsPager Mode="ShowPager" NumericButtonCount="2">
    </SettingsPager>
    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
</dx:ASPxTreeList>

<asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
        <h3 class="title_orange fix">
            <asp:Label ID="Label_TenViTri" runat="server"></asp:Label>
            <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="UpdatePanel" DisplayAfter="0" DynamicLayout="false" ClientIDMode="Static">
                <ProgressTemplate>
                    <img alt="Đang xử lý..." src="/Images/loading.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <span class="pull-right">
                <asp:LinkButton ID="LinkButton_Expand" runat="server" ToolTip="Mở rộng tất cả" OnClick="LinkButton_Expand_Click"><i class="glyphicon glyphicon-plus"></i></asp:LinkButton>
                <asp:LinkButton ID="LinkButton_Collapse" runat="server" ToolTip="Thu gọn tất cả" OnClick="LinkButton_Collapse_Click"><i class="glyphicon glyphicon-minus"></i></asp:LinkButton>
            </span>
            <h3></h3>
            <asp:Panel ID="PanelTreeList" runat="server"></asp:Panel>
            <h3></h3>
            <h3></h3>
        </h3>
    </ContentTemplate>
</asp:UpdatePanel>

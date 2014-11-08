<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTimKiem.ascx.cs" Inherits="TSCD_WEB.UserControl.TimKiem.ucTimKiem" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxNavBar" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<script src="../Scripts/custom.js"></script>
<dx:ASPxTextBox ID="TbSearch" runat="server" CssClass="form-control" Native="True" ClientIDMode="Static" ClientInstanceName="SearchBox" AutoCompleteType="Disabled" placeholder="Nhập nội dung cần tìm">
    <ClientSideEvents KeyUp="DXDemo.Search.onSearchBoxKeyPress" KeyDown="DXDemo.Search.onSearchBoxKeyDown" GotFocus="DXDemo.Search.onSearchBoxGotFocus" />
</dx:ASPxTextBox>
<div id="SearchPanel" style="margin-top:33px">
</div>
<dx:ASPxPopupControl runat="server" ID="SearchPopup" ClientInstanceName="SearchPopup" OnWindowCallback="SearchPopup_WindowCallback" EnableTheming="false" ShowHeader="false" PopupAlignCorrection="Disabled" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" CssClass="SearchPopup" LoadingPanelText="Đang tìm..." Width="95%">
    <ClientSideEvents BeginCallback="DXDemo.Search.onSearchPopupBeginCallback" EndCallback="DXDemo.Search.onSearchPopupEndCallback" />
    <ContentCollection>
        <dx:PopupControlContentControl>
            <div runat="server" id="ResultsPanel" visible="false" class="ResultsPanel">
                <dx:ASPxNavBar runat="server" ID="SearchResultsNavBar" ClientInstanceName="SearchResultsNavBar" CssClass="ResultsNavBar" EnableTheming="false"
                    EnableViewState="false" EnableClientSideAPI="true" AllowSelectItem="true"
                    Width="100%" ShowExpandButtons="false" AccessibilityCompliant="true" EncodeHtml="false">
                    <ItemTextTemplate>
                        <div id="sr_<%# Container.Item.Group.Index %>_<%# Container.Item.Index %>"><%# Container.Item.Text %></div>
                    </ItemTextTemplate>
                </dx:ASPxNavBar>
            </div>
            <div runat="server" id="NoResultsPanel" class="NoResultsPanel" visible="false">
                Không tìm thấy nội dung phù hợp với <b runat="server" id="RequestText"></b>.
            </div>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <LoadingDivStyle CssClass="LoadingDiv"></LoadingDivStyle>
    <LoadingPanelStyle CssClass="SearchLoadingPanel"></LoadingPanelStyle>
    <LoadingPanelImage Url="/Images/loading.gif"></LoadingPanelImage>
</dx:ASPxPopupControl>
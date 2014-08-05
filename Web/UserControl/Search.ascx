<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="Web.UserControl.Search" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxNavBar" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<script type="text/javascript" src="../Js/Demo.js"></script>
<link rel="stylesheet" href="../Content/Site.css" />
<div class="Search" id="SearchPanel">
    <dx:ASPxImage runat="server" ID="PicSearch" SpriteCssClass="Pic">
        <ClientSideEvents Click="DXDemo.focusSearch" />
    </dx:ASPxImage>
    <dx:ASPxTextBox Height="23px" runat="server" ID="TbSearch" Width="96%" CssClass="SearchBox"
        EnableTheming="false" ClientInstanceName="SearchBox" AutoCompleteType="Disabled">
        <ClientSideEvents KeyUp="DXDemo.Search.onSearchBoxKeyPress" KeyDown="DXDemo.Search.onSearchBoxKeyDown" GotFocus="DXDemo.Search.onSearchBoxGotFocus" />
    </dx:ASPxTextBox>
    <b class="Clear"></b>
</div>
<dx:ASPxPopupControl runat="server" ID="SearchPopup" ClientInstanceName="SearchPopup" OnWindowCallback="SearchPopup_WindowCallback"
EnableTheming="false" ShowHeader="false" PopupAlignCorrection="Disabled"
    PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" CssClass="SearchPopup" Width="275px" LoadingPanelText="Đang tìm...">
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
    <LoadingPanelImage Url="~/Content/Loading.gif"></LoadingPanelImage>
</dx:ASPxPopupControl>

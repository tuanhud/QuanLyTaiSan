<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCollectionPager.ascx.cs" Inherits="PTB_WEB.UserControl.ucCollectionPager" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<div class="leftCollectionPager">
    <div class="CollectionPager">
        <cp:CollectionPager ID="CollectionPager_Object" runat="server" LabelText="" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="2" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" MaxPages="65536"></cp:CollectionPager>
    </div>
</div>
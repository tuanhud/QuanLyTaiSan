﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCollectionPager.ascx.cs" Inherits="TSCD_WEB.UserControl.CollectionPager.ucCollectionPager" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<div class="leftCollectionPager">
    <div class="CollectionPager">
        <cp:CollectionPager ID="CollectionPager_Object" runat="server" LabelText="" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" MaxPages="65536" SectionPadding="10" SliderSize="5"></cp:CollectionPager>
    </div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDonViTaiSan_Web.ascx.cs" Inherits="TSCD_WEB.UserControl.DonViTaiSan.ucDonViTaiSan_Web" %>
<%@ Register Src="~/UserControl/DonViTaiSan/ucDonViTaiSan_BreadCrumb.ascx" TagPrefix="uc" TagName="ucDonViTaiSan_BreadCrumb" %>
<%@ Register Src="~/UserControl/CollectionPager/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/TreeViTri/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/DangNhap/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>


<uc:ucDonViTaiSan_BreadCrumb runat="server" ID="ucDonViTaiSan_BreadCrumb" />

<table class="table largetable">
    <tbody>
        <tr id="DangNhap" runat="server" visible="false">
            <td>
                <uc:ucDangNhap runat="server" ID="ucDangNhap" />
            </td>
        </tr>
        <tr id="KhongCoDuLieu" runat="server" visible="false">
            <td>
                <uc:ucDanger runat="server" ID="ucDanger_KhongCoDuLieu" />
            </td>
        </tr>
        <tr id="infotr" runat="server" visible="false">
            <td style="width: 300px;" class="border_right">
                <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
            </td>
            <td id="ChuaChonViTri" runat="server" visible="false">
                <uc:ucWarning runat="server" ID="ucWarning_ChuaChon" />
            </td>
            <td id="infotd" runat="server" visible="false">
                <div class="tab-content">
                    <div class="tab-pane active" id="danhsach">
                        <script type="text/javascript">
                            // <![CDATA[
                            var textSeparator = ";";
                            var valueSeparator = ";";
                            function OnListBoxSelectionChanged(listBox, args) {
                                if (args.index == 0)
                                    args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
                                UpdateSelectAllItemState();
                                UpdateText();
                            }
                            function UpdateSelectAllItemState() {
                                IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
                            }
                            function IsAllSelected() {
                                var selectedDataItemCount = checkListBox.GetItemCount() - (checkListBox.GetItem(0).selected ? 0 : 1);
                                return checkListBox.GetSelectedItems().length == selectedDataItemCount;
                            }
                            function UpdateText() {
                                var selectedItems = checkListBox.GetSelectedItems();
                                checkComboBox.SetText(GetSelectedItemsText(selectedItems));
                                $("#HiddenField").val(GetSelectedItemsValue(selectedItems));
                            }
                            function SynchronizeListBoxValues(dropDown, args) {
                                checkListBox.UnselectAll();
                                var texts = dropDown.GetText().split(textSeparator);
                                var values = GetValuesByTexts(texts);
                                checkListBox.SelectValues(values);
                                UpdateSelectAllItemState();
                                UpdateText(); // for remove non-existing texts
                            }
                            function GetSelectedItemsText(items) {
                                var texts = [];
                                for (var i = 0; i < items.length; i++)
                                    if (items[i].index != 0)
                                        texts.push(items[i].text);
                                return texts.join(textSeparator);
                            }
                            function GetSelectedItemsValue(items) {
                                var values = [];
                                for (var i = 0; i < items.length; i++)
                                    if (items[i].index != 0)
                                        values.push(items[i].value);
                                return values.join(valueSeparator);
                            }
                            function GetValuesByTexts(texts) {
                                var actualValues = [];
                                var item;
                                for (var i = 0; i < texts.length; i++) {
                                    item = checkListBox.FindItemByText(texts[i]);
                                    if (item != null)
                                        actualValues.push(item.value);
                                }
                                return actualValues;
                            }
                            // ]]>
                        </script>
                        <table>
                            <tr>
                                <h3 class="title_green fix">Danh sách tài sản</h3>
                                <td>Chọn cột cần hiển thị</td>
                                <td style="padding-left: 10px">
                                    <dx:ASPxDropDownEdit ID="ASPxDropDownEdit" ClientInstanceName="checkComboBox" Width="210px" Height="25px" runat="server" Theme="Aqua">
                                        <DropDownWindowTemplate>
                                            <dx:ASPxListBox Width="100%" ID="listBox" ClientInstanceName="checkListBox" SelectionMode="CheckColumn" runat="server" Theme="Aqua">
                                                <Items>
                                                    <dx:ListEditItem Text="(Chọn tất cả)" />
                                                    <dx:ListEditItem Text="Nước sản xuất" Value="nuocsx" />
                                                    <dx:ListEditItem Text="Nguồn gốc" Value="nguongoc" />
                                                    <dx:ListEditItem Text="Tình trạng" Value="tinhtrang" />
                                                    <dx:ListEditItem Text="Phòng" Value="phong" />
                                                    <dx:ListEditItem Text="Vị trí" Value="vitri" />
                                                    <dx:ListEditItem Text="Đơn vị quản lý" Value="dvquanly" />
                                                    <dx:ListEditItem Text="Đơn vị sử dụng" Value="dvsudung" />
                                                    <dx:ListEditItem Text="Ghi chú" Value="ghichu" />
                                                </Items>
                                                <ClientSideEvents SelectedIndexChanged="OnListBoxSelectionChanged" />
                                            </dx:ASPxListBox>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding: 4px">
                                                        <dx:ASPxButton ID="ASPxButton" runat="server" Text="OK" Style="float: right" Theme="Aqua" OnClick="ASPxButton_Click">
                                                            <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </DropDownWindowTemplate>
                                        <ClientSideEvents TextChanged="SynchronizeListBoxValues" DropDown="SynchronizeListBoxValues" />
                                    </dx:ASPxDropDownEdit>
                                    <asp:HiddenField ID="HiddenField" ClientIDMode="Static" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <dx:ASPxGridView ID="ASPxGridView" KeyFieldName="id" ClientIDMode="Static" ClientInstanceName="ASPxGridView" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Aqua" Width="100%">
                            <Columns>
                                <dx:GridViewBandColumn Caption="">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" Width="25" Visible="False">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="Loại tài sản" FieldName="loaits" GroupIndex="0" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn Caption="Ngày sử dụng" FieldName="ngay" VisibleIndex="2">
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="Chứng từ">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Số hiệu" FieldName="sohieu_ct" VisibleIndex="3">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn Caption="Ngày tháng" FieldName="ngay_ct" VisibleIndex="4">
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Tên TSCĐ" FieldName="ten" VisibleIndex="5" Width="300">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Đơn vị tính" FieldName="donvitinh" VisibleIndex="6">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Số lượng" FieldName="soluong" VisibleIndex="7">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Đơn giá" FieldName="dongia" VisibleIndex="8" Width="150">
                                            <PropertiesTextEdit DisplayFormatString="#,# VNĐ"></PropertiesTextEdit>
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Thành tiền" FieldName="thanhtien" VisibleIndex="9" Width="150">
                                            <PropertiesTextEdit DisplayFormatString="#,# VNĐ"></PropertiesTextEdit>
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Nước sản xuất" FieldName="nuocsx" VisibleIndex="10" Visible="False">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Nguồn gốc" FieldName="nguongoc" VisibleIndex="11" Visible="False">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Tình trạng" FieldName="tinhtrang" VisibleIndex="12" Visible="False">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Phòng" FieldName="phong" VisibleIndex="13" Visible="False">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Vị trí" FieldName="vitri" VisibleIndex="14" Visible="False">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Đơn vị quản lý" FieldName="dvquanly" VisibleIndex="15" Visible="False">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Đơn vị sử dụng" FieldName="dvsudung" VisibleIndex="16" Visible="False">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Ghi chú" FieldName="ghichu" VisibleIndex="17" Visible="False">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                            </Columns>
                            <Styles>
                                <SelectedRow BackColor="#C0FFC0" ForeColor="#0033FF"></SelectedRow>
                            </Styles>
                            <SettingsPager PageSize="20">
                                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsBehavior AllowSelectByRowClick="True" ColumnResizeMode="Control" />
                            <Settings ShowFilterRow="True" ShowFooter="True" HorizontalScrollBarMode="Auto" />
                            <SettingsCookies Enabled="false" />
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        </dx:ASPxGridView>
                    </div>
                </div>
            </td>
        </tr>
    </tbody>
</table>
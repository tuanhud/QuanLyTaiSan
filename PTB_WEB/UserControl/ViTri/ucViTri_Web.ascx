<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Web.ascx.cs" Inherits="PTB_WEB.UserControl.ViTri.ucViTri_Web" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxLoadingPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_BreadCrumb.ascx" TagPrefix="uc" TagName="ucViTri_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>


<uc:ucViTri_BreadCrumb runat="server" ID="ucViTri_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <script type="text/javascript">
        var showPopup = true;
        var iframe;

        function OnPopupInit(s, e) {
            iframe = PopupControlMaps.GetContentIFrame();
            /* the "load" event is fired when the content has been already loaded */
            ASPxClientUtils.AttachEventToElement(iframe, 'load', OnContentLoaded);
        }

        function OnPopupShown(s, e) {
            if (showPopup)
                lp.ShowInElement(iframe);
        }

        function OnContentLoaded(e) {
            showPopup = false;
            lp.Hide();
        }

        function ShowMap(url_maps) {
            showPopup = true;
            PopupControlMaps.SetContentUrl(url_maps);
            PopupControlMaps.Show();
        }
    </script>
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 210px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                </td>
                <td>
                    <%if (Request.QueryString["key"] == null)
                      { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <asp:Label ID="Label_ChuaChon" runat="server" Visible="false"></asp:Label>
                    </div>
                    <%}
                      else
                      { %>
                    <ul class="nav nav-tabs" role="tablist" id="myTab">
                        <li class="active"><a href="#thongtin" role="tab" data-toggle="tab"><asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label></a></li>
                        <%try
                          {
                              if (objCoSo.diachi != null)
                              { %>
                        <li><a href="#bando" role="tab" data-toggle="tab">Bản đồ&nbsp;<span class="glyphicon glyphicon-new-window pull-right" style="cursor: pointer" onclick="ShowMap('<%Response.Write(strSrc);%>')"></span></a></li>
                        <%}
                          }
                          catch (Exception) { } %>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="thongtin">
                            <asp:Panel ID="Panel_ThongTinViTri" runat="server" Visible="False">
                                <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                                <table class="table table-striped">
                                    <tbody>
                                        <tr>
                                            <td>Tên:</td>
                                            <td>
                                                <asp:Label ID="Label_Ten" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Thuộc:</td>
                                            <td>
                                                <asp:Label ID="Label_Thuoc" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="Panel_DiaChi" runat="server" Visible="False">
                                            <tr>
                                                <td>Đia chỉ:</td>
                                                <td>
                                                    <asp:Label ID="Label_DiaChi" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td>Mô tả:</td>
                                            <td>
                                                <asp:Label ID="Label_MoTa" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </div>
                        <div class="tab-pane" id="bando">
                            <asp:Panel ID="Panel_GoogleMap" runat="server" Visible="False">                                
                                <iframe id="Iframe_GoogleMap" width="100%" height="300px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src=""></iframe>
                                <asp:Label ID="Label_Script" runat="server"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                    <%} %>
                </td>
            </tr>
        </tbody>
    </table>
    <dx:ASPxLoadingPanel ID="lp" runat="server" ClientInstanceName="lp" Theme="Moderno"></dx:ASPxLoadingPanel>
    <dx:ASPxPopupControl ID="ASPxPopupControl" runat="server" ClientInstanceName="PopupControlMaps" CloseAction="CloseButton" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Bản đồ" Theme="PlasticBlue" AllowResize="True" AutoUpdatePosition="True" Width="800px" Height="600px">
        <ClientSideEvents Init="OnPopupInit" Shown="OnPopupShown" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Panel>

<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TaiSan.aspx.cs" Inherits="WebQuanLyTaiSan.TaiSan" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Danh sách tài sản :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start: Content -->
    <div id="content" class="span10">
        <div class="row-fluid">
            <div class="box span6">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Danh sách cơ sở</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-striped table-bordered bootstrap-datatable datatable dataTable">
                        <thead>
                            <tr>
                                <th>Hình ảnh</th>
                                <th>Mã cơ sở</th>
                                <th>Tên cơ sở</th>
                                <th>Mô tả</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="center"><img src="img/avatar2.jpg" /></td>
                                <td>C</td>
                                <td>Cơ sở chính</td>
                                <td>Cơ sở chính: 273 An Dương Vương</td>
                            </tr>
                            <tr>
                                <td class="center"><img src="img/avatar3.jpg" /></td>
                                <td>1</td>
                                <td>Cơ sở 1</td>
                                <td>Cơ sở 1: 105 Bà Huyện Thanh Quan</td>
                            </tr>
                            <tr>
                                <td class="center"><img src="img/avatar4.jpg" /></td>
                                <td>2</td>
                                <td>Cơ sở 2</td>
                                <td>Cơ sở 2: 04 Tôn Đức Thằng</td>
                            </tr>
                            <tr>
                                <td class="center"><img src="img/avatar5.jpg" /></td>
                                <td>3</td>
                                <td>Cơ sở 3</td>
                                <td>Cơ sở 3: 20 Ngô Thời Nhiệm</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <!--/span-->
            <div class="box span6">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Danh sách Dãy</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-striped table-bordered bootstrap-datatable datatable dataTable">
                        <thead>
                            <tr>
                                <th>Hình ảnh</th>
                                <th>Tên dãy</th>
                                <th>Mô tả</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="center"><img src="img/avatar2.jpg" /></td>
                                <td>Dãy A</td>
                                <td>Dãy A</td>
                            </tr>
                            <tr>
                                <td class="center"><img src="img/avatar3.jpg" /></td>
                                <td>Dãy B</td>
                                <td>Dãy B</td>
                            </tr>
                            <tr>
                                <td class="center"><img src="img/avatar4.jpg" /></td>
                                <td>Dãy C</td>
                                <td>Dãy C</td>
                            </tr>
                            <tr>
                                <td class="center"><img src="img/avatar5.jpg" /></td>
                                <td>Dãy D</td>
                                <td>Dãy D</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <!--/span-->
        </div>

        <div class="row-fluid">
            <div class="box span12">
                <div class="box-header" data-original-title="">
                    <h2><i class="icon-eye-open"></i><span class="break"></span>Danh sách tài sản</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-striped table-bordered bootstrap-datatable datatable">
                        <thead>
                            <tr>
                                <th>Username</th>
                                <th>Date registered</th>
                                <th>Role</th>
                                <th>Status</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Anton Phunihel</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Alphonse Ivo</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Thancmar Theophanes</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>

                            </tr>
                            <tr>
                                <td>Walerian Khwaja</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Clemens Janko</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Chidubem Gottlob</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Hristofor Sergio</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Tadhg Griogair</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Pollux Beaumont</td>
                                <td class="center">2012/01/21</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Adam Alister</td>
                                <td class="center">2012/01/21</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Carlito Roffe</td>
                                <td class="center">2012/08/23</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Sana Amrin</td>
                                <td class="center">2012/08/23</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Adinah Ralph</td>
                                <td class="center">2012/06/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Dederick Mihail</td>
                                <td class="center">2012/06/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Hipólito András</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Fricis Arieh</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Scottie Maximilian</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Bao Gaspar</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Tullio Luka</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Felice Arseniy</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Finlay Alf</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Theophilus Nala</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Sullivan Robert</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Kristóf Filiberto</td>
                                <td class="center">2012/01/21</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Kuzma Edvard</td>
                                <td class="center">2012/01/21</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Bünyamin Kasper</td>
                                <td class="center">2012/08/23</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Crofton Arran</td>
                                <td class="center">2012/08/23</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Bernhard Shelah</td>
                                <td class="center">2012/06/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Grahame Miodrag</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Innokentiy Celio</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Kostandin Warinhari</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Ajith Hristijan</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="icon-zoom-in "></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="icon-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="icon-trash "></i>

                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <!--/span-->

        </div>
        <!--/row-->

        <div class="row-fluid">
            <div class="box span6">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Simple Table</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Username</th>
                                <th>Date registered</th>
                                <th>Role</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Samppa Nori</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Estavan Lykos</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Chetan Mohamed</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Derick Maximinus</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Friderik Dávid</td>
                                <td class="center">2012/01/21</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="pagination pagination-centered">
                        <ul>
                            <li><a href="#">Prev</a></li>
                            <li class="active">
                                <a href="#">1</a>
                            </li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">Next</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--/span-->

            <div class="box span6">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Striped Table</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Username</th>
                                <th>Date registered</th>
                                <th>Role</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Yiorgos Avraamu</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Avram Tarasios</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Quintin Ed</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Enéas Kwadwo</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Agapetus Tadeáš</td>
                                <td class="center">2012/01/21</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="pagination pagination-centered">
                        <ul>
                            <li><a href="#">Prev</a></li>
                            <li class="active">
                                <a href="#">1</a>
                            </li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">Next</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>
        <!--/row-->

        <div class="row-fluid">
            <div class="box span6">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Bordered Table</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>Username</th>
                                <th>Date registered</th>
                                <th>Role</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Pompeius René</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Paĉjo Jadon</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Micheal Mercurius</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Ganesha Dubhghall</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Hiroto Šimun</td>
                                <td class="center">2012/01/21</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="pagination pagination-centered">
                        <ul>
                            <li><a href="#">Prev</a></li>
                            <li class="active">
                                <a href="#">1</a>
                            </li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">Next</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--/span-->

            <div class="box span6">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Condensed Table</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-condensed">
                        <thead>
                            <tr>
                                <th>Username</th>
                                <th>Date registered</th>
                                <th>Role</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Carwyn Fachtna</td>
                                <td class="center">2012/01/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Nehemiah Tatius</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-important">Banned</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Ebbe Gemariah</td>
                                <td class="center">2012/02/01</td>
                                <td class="center">Admin</td>
                                <td class="center">
                                    <span class="label">Inactive</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Eustorgios Amulius</td>
                                <td class="center">2012/03/01</td>
                                <td class="center">Member</td>
                                <td class="center">
                                    <span class="label label-warning">Pending</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Leopold Gáspár</td>
                                <td class="center">2012/01/21</td>
                                <td class="center">Staff</td>
                                <td class="center">
                                    <span class="label label-success">Active</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="pagination pagination-centered">
                        <ul>
                            <li><a href="#">Prev</a></li>
                            <li class="active">
                                <a href="#">1</a>
                            </li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">Next</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--/span-->

        </div>
        <!--/row-->

        <div class="row-fluid">
            <div class="box span12">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Combined All Table</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        Combined All Table</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                    </div>
                    <div class="box-content">
                        <table class="table table-bordered table-striped table-condensed">
                            <thead>
                                <tr>
                                    <th>
                                    Username               
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Vishnu Serghei</td>
                                    <td class="center">2012/01/01</td>
                                    <td class="center">Member</td>
                                    <td class="center">
                                        <span class="label label-success">Active</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Zbyněk Phoibos</td>
                                    <td class="center">2012/02/01</td>
                                    <td class="center">Staff</td>
                                    <td class="center">
                                        <span class="label label-important">Banned</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Einar Randall</td>
                                    <td class="center">2012/02/01</td>
                                    <td class="center">Admin</td>
                                    <td class="center">
                                        <span class="label">Inactive</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Félix Troels</td>
                                    <td class="center">2012/03/01</td>
                                    <td class="center">Member</td>
                                    <td class="center">
                                        <span class="label label-warning">Pending</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Aulus Agmundr</td>
                                    <td class="center">2012/01/21</td>
                                    <td class="center">Staff</td>
                                    <td class="center">
                                        <span class="label label-success">Active</span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="pagination pagination-centered">
                            <ul>
                                <li><a href="#">Prev</a></li>
                                <li class="active">
                                    <a href="#">1</a>
                                </li>
                                <li><a href="#">2</a></li>
                                <li><a href="#">3</a></li>
                                <li><a href="#">4</a></li>
                                <li><a href="#">Next</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
    </div>
    <!-- end: Content -->
</asp:Content>

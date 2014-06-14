<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebQuanLyTaiSan.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thống kê :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start: Content -->
    <div id="content" class="span10">
        <div class="row-fluid">
            <div class="span3 smallstat box mobileHalf" ontablet="span6" ondesktop="span3">
                <div class="boxchart-overlay blue">
                    <div class="boxchart">5,6,7,2,0,4,2,4,8,2,3,3,2</div>
                </div>
                <span class="title">Tổng tài sản</span>
                <span class="value">4 589</span>
            </div>
            <div class="span3 smallstat box mobileHalf" ontablet="span6" ondesktop="span3">
                <div class="boxchart-overlay red">
                    <div class="boxchart">1,2,6,4,0,8,2,4,5,3,1,7,5</div>
                </div>
                <span class="title">Tổng tài sản sửa chữa</span>
                <span class="value">789</span>
            </div>
            <div class="span3 smallstat box mobileHalf noMargin" ontablet="span6" ondesktop="span3">
                <i class="icon-download-alt green"></i>
                <span class="title">Tổng chi</span>
                <span class="value">99.512.300 Đ</span>
            </div>
            <div class="span3 smallstat mobileHalf box" ontablet="span6" ondesktop="span3">
                <i class="icon-money yellow"></i>
                <span class="title">Tài khoản</span>
                <span class="value">1.000.000.000 Đ</span>
            </div>
        </div>
        
        <div class="row-fluid">		
				<div class="box span12">
					<div class="box-header" data-original-title="">
						<h2><i class="icon-list"></i><span class="break"></span>Danh sách yêu cầu hỗ trợ</h2>
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
								  <th>Tình trạng</th>
								  <th>Ngày yêu cầu</th>
								  <th>Tiêu đề</th>
								  <th>Người yêu cầu</th>
								  <th>ID yêu cầu</th>
							  </tr>
						  </thead>   
						  <tbody>
							<tr>
                                <td class="center"><span class="label label-success">Hoàn thành</span></td>
                                <td class="center">11:09 25-05-2014</td>
								<th>[Yêu cầu thay mới] Ghế sinh viên phòng C.A204 hỏng 3 cái</th>
								<td class="center">Nguyễn Hoàng Thanh</td>
                                <th>[ #199277 ]</th>
							</tr>
                              <tr>
                                <td class="center"><span class="label label-warning">Chờ xử lý</span></td>
                                <td class="center">11:09 24-05-2014</td>
								<th>[Yêu cầu thay mới] Đèn 3U phòng C.A207 không sáng</th>
								<td class="center">Huỳnh Công Khánh</td>
                                <th>[ #199276 ]</th>
							</tr>
                              <tr>
                                <td class="center"><span class="label label-info">Đang xử lý</span></td>
                                <td class="center">11:09 22-05-2014</td>
								<th>[Yêu cầu thay mới] Máy chiếu phòng C.D104 bị mờ</th>
								<td class="center">Nguyễn Quốc Dũng</td>
                                <th>[ #199275 ]</th>
							</tr>
                              <tr>
                                <td class="center"><span class="label label-important">Không nhận</span></td>
                                <td class="center">11:09 21-05-2014</td>
								<th>[Yêu cầu thay mới] Bảng phòng C.D104 bị trầy nhẹ</th>
								<td class="center">Đỗ Thị Thừa</td>
                                <th>[ #199274 ]</th>
							</tr>
                              <tr>
                                <td class="center"><span class="label label-success">Hoàn thành</span></td>
                                <td class="center">11:09 18-05-2014</td>
								<th>[Yêu cầu sửa] Micro phòng C.A507 bị rè</th>
								<td class="center">Vương Xương Nhơn</td>
                                <th>[ #199273 ]</th>
							</tr>
                              <tr>
                                <td class="center"><span class="label label-warning">Chờ xử lý</span></td>
                                <td class="center">11:09 16-05-2014</td>
								<th>[Yêu cầu thay mới] Đèn máy chiếu phòng C.A105 bị nổ</th>
								<td class="center">Nguyễn Hoàng Thanh</td>
                                <th>[ #199272 ]</th>
							</tr>
                              <tr>
                                <td class="center"><span class="label label-info">Đang xử lý</span></td>
                                <td class="center">11:09 15-05-2014</td>
								<th>[Yêu cầu thêm mới] Phòng C.A302 thiếu 3 bàn sinh viên</th>
								<td class="center">Nguyễn Quốc Dũng</td>
                                <th>[ #199271 ]</th>
							</tr>
						  </tbody>
					  </table>            
					</div>
				</div><!--/span-->
			
			</div><!--/row-->
        <div class="row-fluid">

            <div class="box span4" ontablet="span6" ondesktop="span4">
                <div class="box-header">
                    <h2><i class="icon-list"></i>Thống kê tuần 1 tháng 06</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <ul class="dashboard-list">
                        <li>
                            <a href="#">
                                <i class="icon-comment yellow"></i>
                                <span class="yellow">315</span>
                                Tổng số yêu cầu
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="icon-arrow-up green"></i>
                                <span class="green">300</span>
                                Xử lý hoàn thành                                    
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="icon-arrow-down red"></i>
                                <span class="red">5</span>
                                Không nhận xử lý
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="icon-minus blue"></i>
                                <span class="blue">10</span>
                                Chờ xử lý                                    
                            </a>
                        </li>
                    </ul>
                </div>
                <br />
                <div class="box-header">
                    <h2><i class="icon-list"></i>Thống kê tháng 05 năm 2014</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <ul class="dashboard-list">
                        <li>
                            <a href="#">
                                <i class="icon-comment yellow"></i>
                                <span class="yellow">1825</span>
                                Tổng số yêu cầu
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="icon-arrow-up green"></i>
                                <span class="green">1750</span>
                                Xử lý hoàn thành                                    
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="icon-arrow-down red"></i>
                                <span class="red">50</span>
                                Không nhận xử lý
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="icon-minus blue"></i>
                                <span class="blue">25</span>
                                Chờ xử lý                                    
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
            <!--/span-->

            <div class="box span4" ontablet="span6" ondesktop="span4">
                <div class="box-header">
                    <h2><i class="icon-user"></i>Danh sách nhân viên mới</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <ul class="dashboard-list">
                        <li>
                            <a href="#">
                                <img class="avatar" alt="Lucas" src="img/avatar.jpg" />
                            </a>
                            <strong>Name:</strong> <a href="#">Nguyễn Hoàng Thanh</a><br />
                            <strong>Số điện thoại:</strong> 01694466134<br />
                            <strong>Ngày vào làm:</strong> 25-02-2014<br />
                            <strong>Tình trạng:</strong> <span class="label label-success">Đang làm</span>
                        </li>
                        <li>
                            <a href="#">
                                <img class="avatar" alt="Bill" src="img/avatar9.jpg" />
                            </a>
                            <strong>Name:</strong> <a href="#">Huỳnh Công Khánh</a><br />
                            <strong>Số điện thoại:</strong> 01204599010<br />
                            <strong>Ngày vào làm:</strong> 28-02-2014<br />
                            <strong>Tình trạng:</strong> <span class="label label-warning">Chờ xử lý</span>
                        </li>
                        <li>
                            <a href="#">
                                <img class="avatar" alt="Jane" src="img/avatar5.jpg" />
                            </a>
                            <strong>Name:</strong> <a href="#">Đỗ Thị Thừa</a><br />
                            <strong>Số điện thoại:</strong> 09179988777<br />
                            <strong>Ngày vào làm:</strong> 25-05-2014<br />
                            <strong>Tình trạng:</strong> <span class="label label-important">Bị đuổi</span>
                        </li>
                        <li>
                            <a href="#">
                                <img class="avatar" alt="Kate" src="img/avatar6.jpg" />
                            </a>
                            <strong>Name:</strong> <a href="#">Nguyễn Quốc Dũng</a><br />
                            <strong>Số điện thoại:</strong> 0976778899<br />
                            <strong>Ngày vào làm:</strong> 25-02-2014<br />
                            <strong>Tình trạng:</strong> <span class="label label-info">Đã duyệt</span>
                        </li>
                    </ul>
                </div>
            </div>
            <!--/span-->

            <div class="box span4 noMargin" ontablet="span12" ondesktop="span4">
                <div class="box-header">
                    <h2><i class="icon-check"></i>Danh sách công việc</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <div class="todo">
                        <ul class="todo-list">
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">Duyệt [#199278]</span>
                                <span class="label label-important">hôm nay</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">Duyệt [#199277]</span>
                                <span class="label label-important">hôm nay</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">Duyệt [#199276]</span>
                                <span class="label label-warning">hôm qua</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check"></i></a>
                                </span>
                                <span class="desc">Duyệt [#199275]</span>
                                <span class="label label-warning">hôm qua</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check"></i></a>
                                </span>
                                <span class="desc">Duyệt [#199274]</span>
                                <span class="label label-success">tuần trước</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check"></i></a>
                                </span>
                                <span class="desc">Duyệt [#199274]</span>
                                <span class="label label-success">tuần trước</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check"></i></a>
                                </span>
                                <span class="desc">Duyệt [#199273]</span>
                                <span class="label label-info">tháng trước</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check"></i></a>
                                </span>
                                <span class="desc">Duyệt [#199272]</span>
                                <span class="label label-info">tháng trước</span>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-fluid">
            <div class="main-chart">
                <div class="bar">
                    <div class="title">Th1</div>
                    <div class="value">80%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th2</div>
                    <div class="value">60%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th3</div>
                    <div class="value">50%</div>
                </div>
                <div class="bar">
                    <div class="title">Th4</div>
                    <div class="value">40%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th5</div>
                    <div class="value">10%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th6</div>
                    <div class="value">30%</div>
                </div>
                <div class="bar">
                    <div class="title">Th7</div>
                    <div class="value">50%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th8</div>
                    <div class="value">65%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th9</div>
                    <div class="value">40%</div>
                </div>
                <div class="bar">
                    <div class="title">Th10</div>
                    <div class="value">32%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th11</div>
                    <div class="value">20%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th12</div>
                    <div class="value">10%</div>
                </div>
                <div class="bar">
                    <div class="title">Th1</div>
                    <div class="value">100%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th2</div>
                    <div class="value">60%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th3</div>
                    <div class="value">50%</div>
                </div>
                <div class="bar">
                    <div class="title">Th4</div>
                    <div class="value">40%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th5</div>
                    <div class="value">10%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th6</div>
                    <div class="value">30%</div>
                </div>
                <div class="bar">
                    <div class="title">Th7</div>
                    <div class="value">50%</div>
                </div>
                <div class="bar simple">
                    <div class="title">Th8</div>
                    <div class="value">65%</div>
                </div>
            </div>
        </div>
        <div class="row-fluid">
            <div class="span6" ontablet="span12" ondesktop="span6">
                <div class="row-fluid">
                    <div class="span12 multi-stat-box box">
                        <div class="header row-fluid">
                            <div class="left">
                                <h2>Pageviews</h2>
                                <a class="icon-chevron-down"></a>
                            </div>
                            <div class="right">
                                <h2>MAY 15 - MAY 22</h2>
                                <div class="percent"><i class="icon-double-angle-up"></i>22%</div>
                            </div>
                        </div>
                        <div class="content row-fluid">
                            <div class="left">
                                <ul>
                                    <li>
                                        <span class="date">Overall</span>
                                        <span class="value">987,123</span>
                                    </li>
                                    <li class="active">
                                        <span class="date">This week</span>
                                        <span class="value">9,873</span>
                                    </li>
                                    <li>
                                        <span class="date">Yesterday</span>
                                        <span class="value">851</span>
                                    </li>
                                    <li>
                                        <span class="date">Today</span>
                                        <span class="value">184</span>
                                    </li>
                                </ul>
                            </div>
                            <div class="right">
                                <div class="multi-stat-box-chart" style="height: 180px; width: 90%; padding: 10px"></div>
                            </div>
                        </div>
                    </div>
                    <div class="box blue span12 noMarginLeft">
                        <div class="box-header">
                            <h2><i class="icon-bar-chart"></i>Weekly Stat</h2>
                            <div class="box-icon">
                                <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                                <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                            </div>
                        </div>
                        <div class="box-content">
                            <div class="chart-type1" style="height: 170px"></div>
                        </div>
                    </div>
                    <!--/span-->
                </div>
            </div>
            <div class="box blue span6 noMargin" ontablet="span12" ondesktop="span6">
                <div class="box-header">
                    <h2>Revenue</h2>
                </div>
                <div class="box-content">
                    <div class="chart-type2" style="height: 220px"></div>
                    <div class="verticalChart">
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>37%</span>
                                </div>
                            </div>
                            <div class="title">US</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>16%</span>
                                </div>
                            </div>
                            <div class="title">PL</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>12%</span>
                                </div>
                            </div>
                            <div class="title">GB</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>9%</span>
                                </div>
                            </div>
                            <div class="title">DE</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>7%</span>
                                </div>
                            </div>
                            <div class="title">NL</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>6%</span>
                                </div>
                            </div>
                            <div class="title">CA</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>5%</span>
                                </div>
                            </div>
                            <div class="title">FI</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>4%</span>
                                </div>
                            </div>
                            <div class="title">RU</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>3%</span>
                                </div>
                            </div>
                            <div class="title">AU</div>
                        </div>
                        <div class="singleBar">
                            <div class="bar">
                                <div class="value">
                                    <span>1%</span>
                                </div>
                            </div>
                            <div class="title">N/A</div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <!--/span-->
        </div>
        <div class="row-fluid">
            <div class="span8" ontablet="span12" ondesktop="span8">
                <div class="row-fluid">
                    <div class="box calendar span12">
                        <div class="calendar-details">
                            <div class="day">Thứ 2</div>
                            <div class="date">Ngày 22-5</div>
                            <ul class="events">
                                <li>19:30 Cuộc họp, 22-5</li>
                                <li>19:30 Cuộc họp, 22-5</li>
                            </ul>
                            <div class="add-event">
                                <i class="icon-plus"></i>
                                <input type="text" class="new event" value="" />
                            </div>
                        </div>
                        <div class="calendar-small"></div>
                        <div class="clearfix"></div>
                    </div>
                    <!--/span-->
                </div>
            </div>

            <div class="span4" ontablet="span12" ondesktop="span4">
				<div class="row-fluid">
                    <div class="span12 smallchart blue box mobileHalf">
                        <div class="title">Số tiền trong tài khoản</div>
                        <div class="content">
                            <div class="chart-stat">
                                <span class="chart white">7,3,2,6,6,3,9,0,1,4</span>
                            </div>
                        </div>
                        <div class="value">1.000.000.000 Đ</div>
                    </div>
                </div>
				<div class="row-fluid">
					<div class="span12 smallchart red box mobileHalf">
                        <div class="title">Số tiền chi hàng tuần</div>
                        <div class="content">
                            <div class="chart-stat">
                                <span class="chart white">5,8,3,9,2,5,6,2,2,5</span>
                            </div>
                        </div>
                        <div class="value">8.213.200 Đ</div>
                    </div>
				</div>
				<!--
                <div class="contacts">
                    <ul class="list">
                        <li>
                            <img class="avatar" src="img/avatar.jpg" alt="avatar" />
                            <span class="name">Łukasz Holeczek</span>
                            <span class="status online"></span>
                            <span class="important">4</span>
                        </li>
                        <li>
                            <img class="avatar" src="img/avatar2.jpg" alt="avatar" />
                            <span class="name">Łukasz Holeczek</span>
                            <span class="status offline"></span>
                        </li>
                        <li>
                            <img class="avatar" src="img/avatar3.jpg" alt="avatar" />
                            <span class="name">Łukasz Holeczek</span>
                            <span class="status busy"></span>
                        </li>
                    </ul>
                </div>
                <div class="conversation">
                    <div class="actions">
                        <img class="avatar" src="img/avatar.jpg" alt="avatar" />
                        <img class="avatar" src="img/avatar3.jpg" alt="avatar" />
                        <img class="avatar" src="img/avatar4.jpg" alt="avatar" />
                    </div>
                    <ul class="talk">
                        <li>
                            <img class="avatar" src="img/avatar3.jpg" alt="avatar" />
                            <span class="name">Ann Kovalsky</span>
                            <span class="time">1:32PM</span>
                            <div class="message">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</div>
                        </li>
                        <li>
                            <img class="avatar" src="img/avatar4.jpg" alt="avatar" />
                            <span class="name">Megan Abbott</span>
                            <span class="time">1:32PM</span>
                            <div class="message">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</div>
                        </li>
                        <li>
                            <img class="avatar" src="img/avatar3.jpg" alt="avatar" />
                            <span class="name">Ann Kovalsky</span>
                            <span class="time">1:32PM</span>
                            <div class="message">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</div>
                        </li>
                        <li>
                            <img class="avatar" src="img/avatar.jpg" alt="avatar" />
                            <span class="name">Łukasz Holeczek</span>
                            <span class="time">1:32PM</span>
                            <div class="message">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</div>
                        </li>
                        <li>
                            <img class="avatar" src="img/avatar4.jpg" alt="avatar" />
                            <span class="name">Megan Abbott</span>
                            <span class="time">1:32PM</span>
                            <div class="message">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</div>
                        </li>
                    </ul>
                    <div class="form">
                        <input type="text" class="write-message" placeholder="Write Message" />
                    </div>
                </div>-->
            </div>
        </div>
        <div class="row-fluid">
            <div class="box span12" ontablet="span12" ondesktop="span12">
                <div class="box-header">
                    <h2>Thống kê yêu cầu hỗ trợ theo từng tháng năm 2014</h2>
                </div>
                <div class="box-content" style="height: 308px">
                    <div id="stats-chart2" class="span12" style="height: 308px"></div>
                </div>
            </div>
            <!--<div class="box span4 noMargin" ontablet="span12" ondesktop="span4">
                <div class="box-header">
                    <h2><i class="icon-check"></i>To Do List</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <div class="todo">
                        <ul class="todo-list">
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">Windows Phone 8 App</span>
                                <span class="label label-important">today</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">New frontend layout</span>
                                <span class="label label-important">today</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">Hire developers</span>
                                <span class="label label-warning">tommorow</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">Windows Phone 8 App</span>
                                <span class="label label-warning">tommorow</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">New frontend layout</span>
                                <span class="label label-success">this week</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">Hire developers</span>
                                <span class="label label-success">this week</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">New frontend layout</span>
                                <span class="label label-info">this month</span>
                            </li>
                            <li>
                                <span class="todo-actions">
                                    <a href="#"><i class="icon-check-empty"></i></a>
                                </span>
                                <span class="desc">Hire developers</span>
                                <span class="label label-info">this month</span>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>-->
        </div>
        <!--<div class="row-fluid">
            <div class="span12 discussions">
                <ul>
                    <li>
                        <div class="author">
                            <img src="img/avatar.jpg" alt="avatar" />
                        </div>
                        <div class="name">Łukasz Holeczek</div>
                        <div class="date">Today, 1:08 PM</div>
                        <div class="delete"><i class="icon-remove"></i></div>
                        <div class="message">
                            Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.
						
                        </div>
                        <ul>
                            <li>
                                <div class="author">
                                    <img src="img/avatar3.jpg" alt="avatar" />
                                </div>
                                <div class="name">Ann Kovalsky</div>
                                <div class="date">Today, 1:08 PM</div>
                                <div class="delete"><i class="icon-remove"></i></div>
                                <div class="message">
                                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.
								
                                </div>
                            </li>
                            <li>
                                <div class="author">
                                    <img src="img/avatar6.jpg" alt="avatar" />
                                </div>
                                <div class="name">Megan Abbott</div>
                                <div class="date">Today, 1:08 PM</div>
                                <div class="delete"><i class="icon-remove"></i></div>
                                <div class="message">
                                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.
								
                                </div>
                            </li>
                            <li>
                                <div class="author">
                                    <img src="img/avatar.jpg" alt="avatar" />
                                </div>
                                <textarea class="diss-form" placeholder="Write comment"></textarea>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <div class="author">
                            <img src="img/avatar9.jpg" alt="avatar" />
                        </div>
                        <div class="name">Tom Allen</div>
                        <div class="date">Today, 1:08 PM</div>
                        <div class="delete"><i class="icon-remove"></i></div>
                        <div class="message">
                            Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.						
                        </div>
                        <ul>
                            <li>
                                <div class="author">
                                    <img src="img/avatar2.jpg" alt="avatar" />
                                </div>
                                <div class="name">Katie Moss</div>
                                <div class="date">Today, 1:08 PM</div>
                                <div class="delete"><i class="icon-remove"></i></div>
                                <div class="message">
                                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.
								
                                </div>
                            </li>
                            <li>
                                <div class="author">
                                    <img src="img/avatar4.jpg" alt="avatar" />
                                </div>
                                <div class="name">Anna Holn</div>
                                <div class="date">Today, 1:08 PM</div>
                                <div class="delete"><i class="icon-remove"></i></div>
                                <div class="message">
                                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.
								
                                </div>
                            </li>
                            <li>
                                <div class="author">
                                    <img src="img/avatar9.jpg" alt="avatar" />
                                </div>
                                <textarea class="diss-form" placeholder="Write comment"></textarea>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </div>-->
    <!-- end: Content -->
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TacVu.aspx.cs" Inherits="WebQuanLyTaiSan.TacVu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Danh sách yêu cầu :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start: Content -->
    <div id="content" class="span10">


        <div class="row-fluid">

            <div class="span7 task-list">
                <h1>Danh sách yêu cầu hỗ trợ</h1>

                <div class="priority high"><span>Độ ưu tiên cao</span></div>

                <div class="task high">
                    <div class="desc">
                        <div class="title">Công Khánh</div>
                        <div>[Yêu cầu thay mới] Đèn 3U phòng C.A207 không sáng</div>
                    </div>
                    <div class="time">
                        <div class="date">24-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>
                <div class="task high">
                    <div class="desc">
                        <div class="title">Hoàng Thanh</div>
                        <div>[Yêu cầu thay mới] Ghế sinh viên phòng C.A204 hỏng 3 cái</div>
                    </div>
                    <div class="time">
                        <div class="date">25-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>
                <div class="task high">
                    <div class="desc">
                        <div class="title">Quốc Dũng</div>
                        <div>[Yêu cầu thay mới] Máy chiếu phòng C.D104 bị mờ</div>
                    </div>
                    <div class="time">
                        <div class="date">22-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>
                <div class="task high last">
                    <div class="desc">
                        <div class="title"> Xương Nhơn</div>
                        <div>[Yêu cầu sửa] Micro phòng C.A507 bị rè</div>
                    </div>
                    <div class="time">
                        <div class="date">18-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>

                <div class="priority medium"><span>Độ ưu tiên trung bình</span></div>

                <div class="task medium">
                    <div class="desc">
                        <div class="title"> Quốc Dũng</div>
                        <div>[Yêu cầu thêm mới] Phòng C.A302 thiếu 3 bàn sinh viên</div>
                    </div>
                    <div class="time">
                        <div class="date">15-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>
                <div class="task medium last">
                    <div class="desc">
                        <div class="title">Hoàng Thanh</div>
                        <div>[Yêu cầu thay mới] Đèn máy chiếu phòng C.A105 bị nổ</div>
                    </div>
                    <div class="time">
                        <div class="date">16-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>

                <div class="priority low"><span>Độ ưu tiên thấp</span></div>

                <div class="task low">
                    <div class="desc">
                        <div class="title">Công Khánh</div>
                        <div>[Yêu cầu thay mới] Đèn 3U phòng C.A207 không sáng</div>
                    </div>
                    <div class="time">
                        <div class="date">24-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>
                <div class="task low">
                    <div class="desc">
                        <div class="title">Hoàng Thanh</div>
                        <div>[Yêu cầu thay mới] Ghế sinh viên phòng C.A204 hỏng 3 cái</div>
                    </div>
                    <div class="time">
                        <div class="date">25-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>
                <div class="task low">
                    <div class="desc">
                        <div class="title">Quốc Dũng</div>
                        <div>[Yêu cầu thay mới] Máy chiếu phòng C.D104 bị mờ</div>
                    </div>
                    <div class="time">
                        <div class="date">22-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>
                <div class="task low">
                    <div class="desc">
                        <div class="title"> Xương Nhơn</div>
                        <div>[Yêu cầu sửa] Micro phòng C.A507 bị rè</div>
                    </div>
                    <div class="time">
                        <div class="date">18-05-2014</div>
                        <div>11:09</div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>

            <div class="span5 graph">

                <h1>Dòng thời gian</h1>

                <div class="timeline">

                    <div class="timeslot">

                        <div class="task">
                            <span>
                                <span class="type">Thông báo</span>
                                <span class="details">Xương Nhơn đã thoát
									</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-map-marker"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="clearfix"></div>

                    <div class="timeslot alt">

                        <div class="task">
                            <span>
                                <span class="type">Thông báo</span>
                                <span class="details">Hoàng Thanh đã thoát
									</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-map-marker"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="timeslot">

                        <div class="task">
                            <span>
                                <span class="type">Tin nhắn</span>
                                <span class="details">Quốc Dũng
									</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-envelope"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="timeslot alt">

                        <div class="task">
                            <span>
                                <span class="type">Tác vụ</span>
                                <span class="details">Đang xử lý thêm bàn sinh viên phòng C.A504
									</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-calendar"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="timeslot">

                        <div class="task">
                            <span>
                                <span class="type">Thông báo</span>
                                <span class="details">Xương Nhơn đã xóa bàn
									</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-map-marker"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="clearfix"></div>

                    <div class="timeslot alt">

                        <div class="task">
                            <span>
                                <span class="type">Thông báo</span>
                                <span class="details">Quốc Dũng đã đăng nhập
									</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-map-marker"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="timeslot">

                        <div class="task">
                            <span>
                                <span class="type">Tin nhắn</span>
                                <span class="details">Công Khánh
									</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-envelope"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="timeslot alt">

                        <div class="task">
                            <span>
                                <span class="type">Tác vụ</span>
                                <span class="details"> Giải quyết vấn đề phòng C.A307
									</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-calendar"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="timeslot">

                        <div class="task">
                            <span>
                                <span class="type">Tin nhắn</span>
                                <span class="details">Hoàng Thanh</span>
                                
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-envelope"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                </div>

            </div>

        </div>



    </div>
    <!-- end: Content -->
</asp:Content>

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
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task high">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task high">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task high last">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>

                <div class="priority medium"><span>Độ ưu tiên trung bình</span></div>

                <div class="task medium">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task medium last">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>

                <div class="priority low"><span>Độ ưu tiên thấp</span></div>

                <div class="task low">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task low">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task low">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task low">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task low">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>
                <div class="task low">
                    <div class="desc">
                        <div class="title">Lorem Ipsum</div>
                        <div>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</div>
                    </div>
                    <div class="time">
                        <div class="date">Jun 1, 2012</div>
                        <div>1 day</div>
                    </div>
                </div>

                <div class="clearfix"></div>

            </div>

            <div class="span5 graph">

                <h1>Timeline</h1>

                <div class="timeline">

                    <div class="timeslot">

                        <div class="task">
                            <span>
                                <span class="type">appointment</span>
                                <span class="details">Lukasz Holeczek at creativeLabs HQ
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
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
                                <span class="type">phone call</span>
                                <span class="details">Lukasz Holeczek
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
                                </span>
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-phone"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="timeslot">

                        <div class="task">
                            <span>
                                <span class="type">mail</span>
                                <span class="details">Lukasz Holeczek
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
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
                                <span class="type">deadline</span>
                                <span class="details">Fixed PayPal problems
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
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
                                <span class="type">appointment</span>
                                <span class="details">Lukasz Holeczek at creativeLabs HQ
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
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
                                <span class="type">skype call</span>
                                <span class="details">Lukasz Holeczek
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
                                </span>
                            </span>
                            <div class="arrow"></div>
                        </div>
                        <div class="icon">
                            <i class="icon-phone"></i>
                        </div>
                        <div class="time">
                            3:43 PM
						
                        </div>

                    </div>

                    <div class="timeslot">

                        <div class="task">
                            <span>
                                <span class="type">mail</span>
                                <span class="details">Lukasz Holeczek
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
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
                                <span class="type">project deadline</span>
                                <span class="details">Fixed PayPal problems
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
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
                                <span class="type">mail</span>
                                <span class="details">Lukasz Holeczek
									</span>
                                <span>remaining time
									
                                    <span class="remaining">3h 38m 15s
										</span>
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

                </div>

            </div>

        </div>



    </div>
    <!-- end: Content -->
</asp:Content>

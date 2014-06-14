<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TaiSan.aspx.cs" Inherits="WebQuanLyTaiSan.TaiSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Danh sách tài sản :: Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start: Content -->
    <div id="content" class="span12">
        <div class="row-fluid">
            <div class="box span4">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Sơ đồ trường</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="icon-wrench"></i></a>
                        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content clearfix">
                    <menu id="nestable-menu">
						<button class="btn btn-info" type="button" data-action="expand-all">Mở rộng</button>
						<button class="btn btn-danger" type="button" data-action="collapse-all">Thu nhỏ</button>
					</menu>
					<div class="dd" id="nestable3">
						<ol class="dd-list">
							<li class="dd-item dd3-item" data-id="13">
								<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Cơ sở chính</div>
								<ol class="dd-list">
									<li class="dd-item dd3-item" data-id="16">
										<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Dãy A</div>
										<ol class="dd-list">
											<li class="dd-item dd3-item" data-id="16">
												<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Phòng C.A201</div>
											</li>
											<li class="dd-item dd3-item" data-id="17">
												<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Phòng C.A202</div>
											</li>
											<li class="dd-item dd3-item" data-id="18">
												<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Phòng C.A203</div>
											</li>
											<li class="dd-item dd3-item" data-id="18">
												<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Phòng C.A204</div>
											</li>
										</ol>
									</li>
									<li class="dd-item dd3-item" data-id="17">
										<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Dãy B</div>
										<ol class="dd-list">
											<li class="dd-item dd3-item" data-id="16">
												<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Phòng C.B103</div>
											</li>
											<li class="dd-item dd3-item" data-id="17">
												<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Phòng C.B104</div>
											</li>
											<li class="dd-item dd3-item" data-id="18">
												<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Phòng C.B105</div>
											</li>
											<li class="dd-item dd3-item" data-id="18">
												<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Phòng C.B106</div>
											</li>
										</ol>
									</li>
									<li class="dd-item dd3-item" data-id="18">
										<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Dãy C</div>
									</li>
									<li class="dd-item dd3-item" data-id="18">
										<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Dãy D</div>
									</li>
								</ol>
							</li>
							<li class="dd-item dd3-item" data-id="14">
								<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Cơ sở 1</div>
							</li>
							<li class="dd-item dd3-item" data-id="15">
								<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Cơ sở 2</div>
							</li>
							<li class="dd-item dd3-item" data-id="15">
								<div class="dd-handle dd3-handle">Drag</div><div class="dd3-content">Cơ sở 3</div>
							</li>							
						</ol>
					</div>
                </div>
            </div>
            <!--/span-->
            <div class="box span8">
                <div class="box-header">
                    <h2><i class="icon-align-justify"></i><span class="break"></span>Danh sách thiết bị</h2>
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
                                <th>Tên thiết bị</th>
								<th>Hình ảnh</th>
                                <th>Số lượng</th>
								<th>Loại</th>
                                <th>Tình trạng</th>
								<th>Phòng</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Máy chiếu</td>
								<td style="text-align:center;"><img src="img/taisan/maychieu.jpg" /></td>
								<td>1</td>
                                <td>Máy chiếu</td>
								<td><span class="label label-success">Đang sử dụng</span></td>
								<td>C.A201</td>
                            </tr>
							<tr>
                                <td>Màn chiếu</td>
								<td style="text-align:center;"><img src="img/taisan/manchieu.jpg" /></td>
								<td>1</td>
                                <td>Màn chiếu</td>
								<td><span class="label label-success">Đang sử dụng</span></td>
								<td>C.A201</td>
                            </tr>
							<tr>
                                <td>Bàn giáo viên</td>
								<td style="text-align:center;"><img src="img/taisan/bangiaovien.jpg" /></td>
								<td>1</td>
                                <td>Bàn giáo viên</td>
								<td><span class="label label-success">Đang sử dụng</span></td>
								<td>C.A201</td>
                            </tr>
							<tr>
                                <td>Ghế giáo viên</td>
								<td style="text-align:center;"><img src="img/taisan/ghegiaovien.jpg" /></td>
								<td>1</td>
                                <td>Ghế giáo viên</td>
								<td><span class="label label-success">Đang sử dụng</span></td>
								<td>C.A201</td>
                            </tr>
							<tr>
                                <td>Bàn sinh viên</td>
								<td style="text-align:center;"><img src="img/taisan/bansinhvien.jpg" /></td>
								<td>30</td>
                                <td>Bàn sinh viên</td>
								<td><span class="label label-success">Đang sử dụng</span></td>
								<td>C.A201</td>
                            </tr>
							<tr>
                                <td>Bàn sinh viên</td>
								<td style="text-align:center;"><img src="img/taisan/bansinhvien.jpg" /></td>
								<td>2</td>
                                <td>Bàn sinh viên</td>
								<td><span class="label label-important">Hỏng</span></td>
								<td>C.A201</td>
                            </tr>							
							<tr>
                                <td>Ghế sinh viên</td>
								<td style="text-align:center;"><img src="img/taisan/ghesinhvien.jpg" /></td>
								<td>28</td>
                                <td>Ghế sinh viên</td>
								<td><span class="label label-success">Đang sử dụng</span></td>
								<td>C.A201</td>
                            </tr>							
							<tr>
                                <td>Ghế sinh viên</td>
								<td style="text-align:center;"><img src="img/taisan/ghesinhvien.jpg" /></td>
								<td>4</td>
                                <td>Ghế sinh viên</td>
								<td><span class="label label-important">Hỏng</span></td>
								<td>C.A201</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!-- end: Content -->
	<script>
		$(document).ready(function()
		{

			var updateOutput = function(e)
			{
				var list   = e.length ? e : $(e.target),
					output = list.data('output');
				if (window.JSON) {
					output.val(window.JSON.stringify(list.nestable('serialize')));//, null, 2));
				} else {
					output.val('JSON browser support required for this demo.');
				}
			};

			// activate Nestable for list 1
			$('#nestable').nestable({
				group: 1
			})
			.on('change', updateOutput);
			
			// activate Nestable for list 2
			$('#nestable2').nestable({
				group: 1
			})
			.on('change', updateOutput);

			// output initial serialised data
			updateOutput($('#nestable').data('output', $('#nestable-output')));
			updateOutput($('#nestable2').data('output', $('#nestable2-output')));

			$('#nestable-menu').on('click', function(e)
			{
				var target = $(e.target),
					action = target.data('action');
				if (action === 'expand-all') {
					alert('sasa');
					$('.dd').nestable('expandAll');
				}
				if (action === 'collapse-all') {
					$('.dd').nestable('collapseAll');
				}
			});

			$('#nestable3').nestable();

		});
	</script>
</asp:Content>

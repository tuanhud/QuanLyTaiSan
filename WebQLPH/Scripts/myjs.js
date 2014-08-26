$("#ButtonLuu").show();
$("#ButtonThemMoi").hide();
$("#ThongBao").hide();
var taikhoan;
function Duyet(id, trangthai) {
    document.getElementById("HiddenFieldID").value = id;
    document.getElementById("DropDownListTrangThai").value = trangthai;
    var ghichu = "GhiChu" + id;
    ghichu = document.getElementById(ghichu).innerHTML;
    document.getElementById("TextBoxGhiChu").value = ghichu;
    return false;
}
function KiemTraTruocKhiLuu() {
    var TextBoxGhiChu = document.getElementById("TextBoxGhiChu").value;
    if (TextBoxGhiChu == "") {
        alert("Ghi chú không được rỗng");
        document.getElementById("TextBoxGhiChu").focus();
        return false;
    }
    return true;
}
function KiemTraDoiMatKhauTruocKhiLuu() {
    var TextBoxMatKhauMoi = document.getElementById("TextBoxMatKhauMoi").value;
    if (TextBoxMatKhauMoi == "") {
        alert("Mật khẩu mới không được rỗng");
        document.getElementById("TextBoxMatKhauMoi").focus();
        return false;
    }
    return true;
}
function ShowThemMoi() {
    taikhoan = "";
    document.getElementById("DropDownListNhom").value = 1;
    $("#ThongBao").hide();
    $("#ButtonLuu").hide();
    $("#thongbaomatkhau").hide();
    $("#ButtonThemMoi").show();
    $("#myModalLabel").html("Thêm mới tài khoản");

    $("#matkhau").html("Mật khẩu(*):");
    $("#nhaplaimatkhau").html("Nhập lại mật khẩu(*):");
    $("#rownhaplaimatkhau").show();

    $("#TextBoxHoTen").val("");
    $("#TextBoxEmail").val("");
    $("#TextBoxTaiKhoan").val("");
    $("#TextBoxKhoa").val("");
    $("#TextBoxGhiChu").val("");
}
function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}
function checktaikhoan(loai) {
    $.get("Check.aspx", {
        TextBoxTaiKhoan: $("#TextBoxTaiKhoan").val(),
        UserName: taikhoan
    },
	function (data) {
	    if (data == "1") {
	        $("#ThongBao").show();
	        $("#ThongBao").html('<p class="text-danger">Tài khoản đã tồn tại</p>');
	    }
	    if (data == "-1") {
	        $("#ThongBao").show();
	        $("#ThongBao").html('<p class="text-success">Tài khoản có thể sử dụng</p>');
	    }
	});
}

$(document).ready(function () {
    $('#TextBoxTaiKhoan').keyup(function () {
        if ($("#TextBoxTaiKhoan").val() != "") {
            checktaikhoan(taikhoan);
        }
    });
    $("input").keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            var id = $("#HiddenFieldID").val();
            if (id == "") {
                $("#ButtonThemMoi").click();
            }
            else {
                $("#ButtonLuu").click();
                $("#ButtonDangNhap").click();
            }
            return false;
        }
        event.stopPropagation();
    });
});
function ThemMoi() {
    if ($("#TextBoxHoTen").val() == "") {
        alert("Tên tài khoản không được rỗng");
        $("#TextBoxHoTen").focus();
        return false;
    }
    if ($("#TextBoxEmail").val() == "") {
        alert("Địa chỉ email không được rỗng");
        $("#TextBoxEmail").focus();
        return false;
    }
    if (!IsEmail($("#TextBoxEmail").val())) {
        alert("Địa chỉ email không đúng định dạng");
        $("#TextBoxEmail").focus();
        return false;
    }
    if ($("#TextBoxTaiKhoan").val() == "") {
        alert("Tài khoản không được rỗng");
        $("#TextBoxTaiKhoan").focus();
        return false;
    }
    if ($("#TextBoxMatKhau").val() == "") {
        alert("Mật khẩu không được rỗng");
        $("#TextBoxMatKhau").focus();
        return false;
    }
    if ($("#TextBoxNhapLaiMatKhau").val() == "") {
        alert("Nhập lại mật khẩu không được rỗng");
        $("#TextBoxNhapLaiMatKhau").focus();
        return false;
    }
    if ($("#TextBoxNhapLaiMatKhau").val() != $("#TextBoxMatKhau").val()) {
        alert("Nhập lại mật khẩu không trùng khớp");
        $("#TextBoxNhapLaiMatKhau").focus();
        return false;
    }
    if ($("#TextBoxKhoa").val() == "") {
        alert("Khoa không được rỗng");
        $("#TextBoxKhoa").focus();
        return false;
    }

    return true;
}
function ShowCapNhat(id, nhom) {

    $("#HiddenFieldID").val(id);

    document.getElementById("DropDownListNhom").value = nhom;

    $("#ThongBao").hide();
    $("#matkhau").html("Mật khẩu mới(*):");
    $("#nhaplaimatkhau").html("Nhập lại mật khẩu mới(*):");
    $("#thongbaomatkhau").show();
    $("#rownhaplaimatkhau").hide();

    var hoten = $("#hoten" + id).html();
    var email = $("#email" + id).html();
    taikhoan = $("#username" + id).html();
    var khoa = $("#khoa" + id).html();
    var mota = $("#mota" + id).html().replace(/<br>/g, "\r\n");

    $("#myModalLabel").html("Chỉnh sửa tài khoản " + taikhoan);

    $("#TextBoxHoTen").val(hoten);
    $("#TextBoxEmail").val(email);
    $("#TextBoxTaiKhoan").val(taikhoan);
    $("#TextBoxKhoa").val(khoa);
    $("#TextBoxGhiChu").val(mota);

    $("#ButtonLuu").show();
    $("#ButtonThemMoi").hide();
}

function CapNhat() {
    if ($("#TextBoxHoTen").val() == "") {
        alert("Tên tài khoản không được rỗng");
        $("#TextBoxHoTen").focus();
        return false;
    }
    if ($("#TextBoxEmail").val() == "") {
        alert("Địa chỉ email không được rỗng");
        $("#TextBoxEmail").focus();
        return false;
    }
    if (!IsEmail($("#TextBoxEmail").val())) {
        alert("Địa chỉ email không đúng định dạng");
        $("#TextBoxEmail").focus();
        return false;
    }
    if ($("#TextBoxTaiKhoan").val() == "") {
        alert("Tài khoản không được rỗng");
        $("#TextBoxTaiKhoan").focus();
        return false;
    }
    if ($("#TextBoxKhoa").val() == "") {
        alert("Khoa không được rỗng");
        $("#TextBoxKhoa").focus();
        return false;
    }

    return true;
}
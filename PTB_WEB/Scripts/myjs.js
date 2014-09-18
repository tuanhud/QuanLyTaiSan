$("#ButtonLuu").show();
$("#ButtonThemMoi").hide();
$("#ThongBao").hide();
var taikhoan;
var _TextBoxMailTieuDe_Focus = 0;
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
    document.getElementById("DropDownListNhom").disabled = false;
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

    return false;
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
    var taikhoandangnhap = $("#HiddenFieldUserName").val();
    var email = $("#email" + id).html();
    taikhoan = $("#username" + id).html();
    var khoa = $("#khoa" + id).html();
    var mota = $("#mota" + id).html().replace(/<br>/g, "\r\n");
    if (taikhoan == taikhoandangnhap)
        document.getElementById("DropDownListNhom").disabled = true;
    else
        document.getElementById("DropDownListNhom").disabled = false;

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

function TextBoxMailTieuDe_Focus() {
    _TextBoxMailTieuDe_Focus = 1;
}

function insertIntoCkeditor(str) {
    if (_TextBoxMailTieuDe_Focus == 1) {
        insertAtCaret('TextBoxMailTieuDe', str);
    }else{
        CKEDITOR.instances['TextBoxMailNoiDung'].insertText(str);
    }
}

function insertAtCaret(areaId, text) {
    var txtarea = document.getElementById(areaId);
    var scrollPos = txtarea.scrollTop;
    var strPos = 0;
    var br = ((txtarea.selectionStart || txtarea.selectionStart == '0') ?
        "ff" : (document.selection ? "ie" : false));
    if (br == "ie") {
        txtarea.focus();
        var range = document.selection.createRange();
        range.moveStart('character', -txtarea.value.length);
        strPos = range.text.length;
    }
    else if (br == "ff") strPos = txtarea.selectionStart;

    var front = (txtarea.value).substring(0, strPos);
    var back = (txtarea.value).substring(strPos, txtarea.value.length);
    txtarea.value = front + text + back;
    strPos = strPos + text.length;
    if (br == "ie") {
        txtarea.focus();
        var range = document.selection.createRange();
        range.moveStart('character', -txtarea.value.length);
        range.moveStart('character', strPos);
        range.moveEnd('character', 0);
        range.select();
    }
    else if (br == "ff") {
        txtarea.selectionStart = strPos;
        txtarea.selectionEnd = strPos;
        txtarea.focus();
    }
    txtarea.scrollTop = scrollPos;
}
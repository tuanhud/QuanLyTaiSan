using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class MuonPhong : System.Web.UI.Page
    {
        GiangVien _GiangVien = null;
        PhieuMuonPhong _PhieuMuonPhong = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Convert.ToString(Session["Username"]) != String.Empty)
                    {
                        HienDangNhap(false);
                        _GiangVien = GiangVien.getByUserName(Session["Username"].ToString());
                        TextBoxKhoa.Text = _GiangVien.khoa;
                    }
                    else
                    {
                        HienDangNhap(true);
                    }



                    if (Convert.ToString(Session["Username_Remember"]) != String.Empty)
                    {
                        TextBoxTaiKhoan.Text = Session["Username_Remember"].ToString();
                        TextBoxMatKhau.Text = Session["Password_Remember"].ToString();
                        CheckBoxNhoDangNhap.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        protected void HienDangNhap(bool hien)
        {
            if (hien)
            {
                PanelDangNhap.Visible = true;
                PanelMuonPhong.Visible = false;
            }
            else
            {
                PanelDangNhap.Visible = false;
                PanelMuonPhong.Visible = true;
            }
        }

        protected void ButtonDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        protected void DangNhap()
        {
            try
            {
                string Username = TextBoxTaiKhoan.Text;
                string Password = TextBoxMatKhau.Text;

                if (Username == "")
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "Tài khoản không được trống";
                    return;
                }
                if (Password == "")
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "Mật khẩu không được trống";
                    return;
                }

                _GiangVien = new GiangVien();
                _GiangVien.username = Username;
                _GiangVien.hashPassword(Password);
                Boolean KiemTraDangNhap = _GiangVien.checkLoginByUserName();
                if (KiemTraDangNhap)
                {
                    if (CheckBoxNhoDangNhap.Checked == true)
                    {
                        Session["Username_Remember"] = Username;
                        Session["Password_Remember"] = Password;
                    }
                    else
                    {
                        Session["Username_Remember"] = String.Empty;
                        Session["Password_Remember"] = String.Empty;
                        CheckBoxNhoDangNhap.Checked = false;
                    }
                    Session["Username"] = Username;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "Tài khoản hoặc mật khẩu không chính xác";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                PanelThongBao.Visible = true;
                LabelThongBao.Text = "<strong>Có lỗi xảy ra !</strong> Vui lòng kiểm tra lại thông tin.";
            }
        }

        protected void ButtonMuonPhong_Click(object sender, EventArgs e)
        {
            MuonPhongMoi();
        }

        protected void MuonPhongMoi()
        {
            try
            {
                if (TextBoxKhoa.Text.Equals(string.Empty))
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Khoa(Phòng) mượn không được rỗng";
                    TextBoxKhoa.Focus();
                    return;
                }
                if (TextBoxNgayMuon.Text.Equals(string.Empty))
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Ngày mượn phòng không được rỗng";
                    TextBoxNgayMuon.Focus();
                    return;
                }
                if (TextBoxThoiGianMuon.Text.Equals(string.Empty))
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Thời gian mượn phòng không được rỗng";
                    TextBoxThoiGianMuon.Focus();
                    return;
                }
                if (TextBoxThoiGianTra.Text.Equals(string.Empty))
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Thời gian trả phòng không được rỗng";
                    TextBoxThoiGianTra.Focus();
                    return;
                }
                if (TextBoxPhong.Text.Equals(string.Empty))
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Số phòng muốn mượn không được rỗng";
                    TextBoxPhong.Focus();
                    return;
                }
                if (TextBoxSoLuong.Text.Equals(string.Empty))
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Số lượng sinh viên không được rỗng";
                    TextBoxSoLuong.Focus();
                    return;
                }
                if (TextBoxLop.Text.Equals(string.Empty))
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Lớp không được rỗng";
                    TextBoxLop.Focus();
                    return;
                }
                if (TextBoxLyDoSuDung.Text.Equals(string.Empty))
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Lý do sử dụng không được rỗng";
                    TextBoxLyDoSuDung.Focus();
                    return;
                }
                
                string khoaphongmuon = TextBoxKhoa.Text;
                DateTime thoigianmuon = Convert.ToDateTime(TextBoxNgayMuon.Text + " " + TextBoxThoiGianMuon.Text);
                DateTime thoigiantra = Convert.ToDateTime(TextBoxNgayMuon.Text + " " + TextBoxThoiGianTra.Text);
                if (thoigiantra <= thoigianmuon)
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Thời gian trả phải lớn hơn thời gian mượn";
                    TextBoxThoiGianTra.Focus();
                    return;
                }
                try
                {
                    Convert.ToInt32(TextBoxPhong.Text);
                }
                catch
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Số lượng phòng mượn phải là số";
                    TextBoxPhong.Focus();
                    return;
                }
                try
                {
                    Convert.ToInt32(TextBoxSoLuong.Text);
                }
                catch
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Số lượng sinh viên phải là số";
                    TextBoxSoLuong.Focus();
                    return;
                }
                int phong = Convert.ToInt32(TextBoxPhong.Text);
                int soluong = Convert.ToInt32(TextBoxSoLuong.Text);
                string lop = TextBoxLop.Text;
                string lydosudung = TextBoxLyDoSuDung.Text;

                _PhieuMuonPhong = new PhieuMuonPhong();
                _PhieuMuonPhong.khoaphongmuon = khoaphongmuon;
                _PhieuMuonPhong.ngaymuon = thoigianmuon;
                _PhieuMuonPhong.ngaytra = thoigiantra;
                _PhieuMuonPhong.sophong = phong;
                _PhieuMuonPhong.soluongsv = soluong;
                _PhieuMuonPhong.lop = lop;
                _PhieuMuonPhong.lydomuon = lydosudung;
                _GiangVien = GiangVien.getByUserName(Session["Username"].ToString());
                _PhieuMuonPhong.giangvien = _GiangVien;

                if (_PhieuMuonPhong.add() > 0)
                {
                    PanelThongBaoMuonPhongThanhCong.Visible = true;
                }
                else
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "<strong>Có lỗi xảy ra !</strong> Vui lòng kiểm tra lại thông tin.";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                PanelThongBaoMuonPhong.Visible = true;
                LabelThongBaoMuonPhong.Text = "<strong>Có lỗi xảy ra !</strong> Vui lòng kiểm tra lại thông tin.";
            }
        }
    }
}
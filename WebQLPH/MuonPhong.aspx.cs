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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Đặt tên để set class, đặt tên in hoa
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "MUONPHONG";
                try
                {
                    if (Convert.ToString(Session["Username"]).Equals(String.Empty))
                        PanelDangNhap.Visible = true;
                    else
                    {
                        if (Convert.ToString(Session["KieuDangNhap"]).Equals("QuanTriVien"))
                            PanelKhongPhaiGiangVien.Visible = true;
                        else
                            PanelMuonPhong.Visible = true;
                        GiangVien _GiangVien = GiangVien.getByUserName(Session["Username"].ToString());
                        TextBoxKhoa.Text = _GiangVien.khoa;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        protected void ButtonMuonPhong_Click(object sender, EventArgs e)
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
                if (Convert.ToDateTime(TextBoxNgayMuon.Text)< DateTime.Now)
                {
                    PanelThongBaoMuonPhong.Visible = true;
                    LabelThongBaoMuonPhong.Text = "Ngày mượn phòng phải lớn hơn hoặc trùng với ngày hiện tại";
                    TextBoxNgayMuon.Focus();
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

                PhieuMuonPhong _PhieuMuonPhong = new PhieuMuonPhong();
                _PhieuMuonPhong.donvi = khoaphongmuon;
                _PhieuMuonPhong.ngaymuon = thoigianmuon;
                _PhieuMuonPhong.ngaytra = thoigiantra;
                _PhieuMuonPhong.sophong = phong;
                _PhieuMuonPhong.soluongsv = soluong;
                _PhieuMuonPhong.lop = lop;
                _PhieuMuonPhong.lydomuon = lydosudung;
                GiangVien _GiangVien = GiangVien.getByUserName(Session["Username"].ToString());
                _PhieuMuonPhong.giangvien = _GiangVien;

                if (_PhieuMuonPhong.add() > 0 && DBInstance.commit() > 0)
                {
                    PanelThongBaoMuonPhongThanhCong.Visible = true;
                    PanelMuonPhong.Visible = false;
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
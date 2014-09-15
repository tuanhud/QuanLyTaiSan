using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB
{
    public partial class ThongTinCaNhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Đặt tên để set class, đặt tên in hoa
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "THONGTINCANHAN";

                try
                {
                    if (Convert.ToString(Session["Username"]).Equals(String.Empty))
                        PanelDangNhap.Visible = true;
                    else
                    {
                        PanelThongTinCaNhan.Visible = true;
                        LoadThongTinCaNhan();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        protected void LoadThongTinCaNhan()
        {
            QuanTriVien _QuanTriVien = QuanTriVien.getByUserName(Convert.ToString(Session["UserName"]));
            LabelHoTen.Text = LabelHoTens.Text = _QuanTriVien.hoten;
            LabelEmail.Text = _QuanTriVien.email;
            LabelNhom.Text = _QuanTriVien.group.ten;
            HiddenFieldIDNhom.Value = _QuanTriVien.group_id.ToString();
            LabelTaiKhoan.Text = _QuanTriVien.username;
            LabelKhoa.Text = _QuanTriVien.donvi;
            LabelNgayTao.Text = Convert.ToDateTime(_QuanTriVien.date_create).ToString("d/M/yyyy HH\\hmm");
            LabelNgayChinhSua.Text = Convert.ToDateTime(_QuanTriVien.date_modified).ToString("d/M/yyyy HH\\hmm");
            LabelGhiChu.Text = StringHelper.ConvertRNToBR(_QuanTriVien.mota);
        }

        protected void LinkButtonEditThongTinCaNhan_Click(object sender, EventArgs e)
        {
            PanelThongBaoThanhCong.Visible = false;
            PanelThongBaoThatBai.Visible = false;

            PanelEditThongTinCaNhan.Visible = true;
            PanelThongTinCaNhan.Visible = false;

            TextBoxHoTen.Text = LabelHoTens.Text;
            TextBoxEmail.Text = LabelEmail.Text;

            List<Group> ListGroup = Group.getQuery().ToList();
            DropDownListNhom.DataSource = ListGroup;
            DropDownListNhom.DataBind();

            DropDownListNhom.SelectedValue = HiddenFieldIDNhom.Value;

            TextBoxTaiKhoan.Text = LabelTaiKhoan.Text;
            TextBoxTaiKhoan.Enabled = false;
            TextBoxDonVi.Text = LabelKhoa.Text;
            TextBoxGhiChu.Text = StringHelper.ConvertBRToRN(LabelGhiChu.Text);
        }

        protected void ButtonLuuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            QuanTriVien _QuanTriVien = QuanTriVien.getByUserName(Convert.ToString(Session["UserName"]));
            _QuanTriVien.hoten = TextBoxHoTen.Text;
            _QuanTriVien.email = TextBoxEmail.Text;
            if (!TextBoxMatKhauMoi.Text.Equals("")) _QuanTriVien.hashPassword(TextBoxMatKhauMoi.Text);
            _QuanTriVien.donvi = TextBoxDonVi.Text;
            _QuanTriVien.mota = TextBoxGhiChu.Text;
            if (_QuanTriVien.update() > 0 && DBInstance.commit() > 0)
            {
                Session["HoTen"] = _QuanTriVien.hoten;
                PanelThongBaoThanhCong.Visible = true;
                LabelThongBaoThanhCong.Text = "Cập nhật thông tin tài khoản thành công";
                ShowPanelThongTinCaNhan(true);
                LoadThongTinCaNhan();
            }
            else
            {
                PanelThongBaoThatBai.Visible = true;
                LabelThongBaoThatBai.Text = "Có lỗi trong khi chỉnh sửa. Vui lòng xem lại!";
            }
        }

        protected void ButtonHuy_Click(object sender, EventArgs e)
        {
            ShowPanelThongTinCaNhan(true);
        }

        protected void ShowPanelThongTinCaNhan(bool dung)
        {
            if (dung)
            {
                PanelEditThongTinCaNhan.Visible = false;
                PanelThongTinCaNhan.Visible = true;
            }
            else
            {
                PanelEditThongTinCaNhan.Visible = true;
                PanelThongTinCaNhan.Visible = false;
            }
        }
    }
}
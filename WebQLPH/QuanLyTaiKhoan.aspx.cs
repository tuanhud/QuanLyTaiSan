using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.Expires = -1;

            if (!IsPostBack)
            {
                // Đặt tên để set class, đặt tên in hoa
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "QUANLYTAIKHOAN";

                try
                {
                    if (Convert.ToString(Session["Username"]).Equals(String.Empty))
                        PanelDangNhap.Visible = true;
                    else
                    {
                        if (LaQuanTriVien())
                        {
                            PanelQuanLyTaiKhoan.Visible = true;
                            _QuanLyTaiKhoan();
                        }
                        else
                            PanelKhongPhaiQuanTriVien.Visible = true;
                    }

                    if (!String.IsNullOrEmpty(Request["op"]))
                    {
                        if (Request["op"].Equals("xoa"))
                        {
                            int id = Convert.ToInt32(Request["id"].ToString());
                            QuanTriVien _QuanTriVien = new QuanTriVien();
                            _QuanTriVien = QuanTriVien.getById(id);
                            if (_QuanTriVien.delete() > 0 && DBInstance.commit() > 0)
                            {
                                PanelThanhCong.Visible = true;
                                LabelThongBaoThanhCong.Text = "Đã xóa tài khoản <strong>" + _QuanTriVien.username + "</strong> ra khỏi hệ thống";
                                _QuanLyTaiKhoan();
                            }
                            else
                            {
                                PanelThatBai.Visible = true;
                                LabelThongBaoThatBai.Text = "Giảng viên này đã tạo phiếu mượn phòng. Không thể xóa!";
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        protected bool LaQuanTriVien()
        {
            return Convert.ToString(Session["KieuDangNhap"]).Equals("QuanTriVien");
        }

        protected void _QuanLyTaiKhoan()
        {
            List<QuanTriVien> ListGiangVien = QuanTriVien.getQuery().ToList();

            CollectionPagerQuanLyTaiKhoan.DataSource = ListGiangVien;
            CollectionPagerQuanLyTaiKhoan.BindToControl = RepeaterQuanLyTaiKhoan;
            RepeaterQuanLyTaiKhoan.DataSource = CollectionPagerQuanLyTaiKhoan.DataSourcePaged;
            RepeaterQuanLyTaiKhoan.DataBind();
        }

        protected string NgayTao()
        {
            DateTime dt = Convert.ToDateTime(Eval("date_create").ToString());
            return dt.ToString("HH\\hmm d/M/yyyy");
        }

        protected void ButtonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                QuanTriVien _QuanTriVien = new QuanTriVien();
                int id = Convert.ToInt32(HiddenFieldID.Value);
                _QuanTriVien = QuanTriVien.getById(id);
                _QuanTriVien.hoten = TextBoxHoTen.Text;
                _QuanTriVien.email = TextBoxEmail.Text;
                _QuanTriVien.username = TextBoxTaiKhoan.Text;
                if(!TextBoxMatKhau.Text.Equals(string.Empty))
                    _QuanTriVien.password = TextBoxMatKhau.Text;
                _QuanTriVien.donvi = TextBoxKhoa.Text;
                _QuanTriVien.mota = TextBoxGhiChu.Text;
                if (_QuanTriVien.update() > 0 && DBInstance.commit() > 0)
                {
                    PanelThanhCong.Visible = true;
                    LabelThongBaoThanhCong.Text = "Chỉnh sửa tài khoản <strong>" + _QuanTriVien.username + "</strong> thành công";
                    _QuanLyTaiKhoan();
                }
                else
                {
                    PanelThatBai.Visible = true;
                    LabelThongBaoThatBai.Text = "Có lỗi trong khi chỉnh sửa";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void ButtonThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                QuanTriVien _QuanTriVien = new QuanTriVien();
                _QuanTriVien.hoten = TextBoxHoTen.Text;
                _QuanTriVien.email = TextBoxEmail.Text;
                _QuanTriVien.username = TextBoxTaiKhoan.Text;
                _QuanTriVien.changePassword(TextBoxMatKhau.Text);
                _QuanTriVien.donvi = TextBoxKhoa.Text;
                _QuanTriVien.mota = TextBoxGhiChu.Text;
                if (_QuanTriVien.add() > 0 && DBInstance.commit() > 0)
                {
                    PanelThanhCong.Visible = true;
                    LabelThongBaoThanhCong.Text = "Thêm mới tài khoản <strong>" + _QuanTriVien.username + "</strong> thành công";
                    _QuanLyTaiKhoan();
                }
                else
                {
                    PanelThatBai.Visible = true;
                    LabelThongBaoThatBai.Text = "Có lỗi trong khi thêm";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
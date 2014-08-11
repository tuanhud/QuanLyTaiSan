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
                            GiangVien _GiangVien = new GiangVien();
                            _GiangVien = GiangVien.getById(id);
                            if (_GiangVien.delete() > 0 && DBInstance.commit() > 0)
                            {
                                PanelThanhCong.Visible = true;
                                LabelThongBaoThanhCong.Text = "Đã xóa tài khoản <strong>" + _GiangVien.username + "</strong> ra khỏi hệ thống";
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
            List<GiangVien> ListGiangVien = GiangVien.getQuery().ToList();

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
                GiangVien _GiangVien = new GiangVien();
                int id = Convert.ToInt32(HiddenFieldID.Value);
                _GiangVien = GiangVien.getById(id);
                _GiangVien.hoten = TextBoxHoTen.Text;
                _GiangVien.email = TextBoxEmail.Text;
                _GiangVien.username = TextBoxTaiKhoan.Text;
                if(!TextBoxMatKhau.Text.Equals(string.Empty))
                    _GiangVien.password = TextBoxMatKhau.Text;
                _GiangVien.khoa = TextBoxKhoa.Text;
                _GiangVien.mota = TextBoxGhiChu.Text;
                if (_GiangVien.update() > 0 && DBInstance.commit() > 0)
                {
                    PanelThanhCong.Visible = true;
                    LabelThongBaoThanhCong.Text = "Chỉnh sửa tài khoản <strong>" + _GiangVien.username + "</strong> thành công";
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
                GiangVien _GiangVien = new GiangVien();
                _GiangVien.hoten = TextBoxHoTen.Text;
                _GiangVien.email = TextBoxEmail.Text;
                _GiangVien.username = TextBoxTaiKhoan.Text;
                _GiangVien.changePassword(TextBoxMatKhau.Text);
                _GiangVien.khoa = TextBoxKhoa.Text;
                _GiangVien.mota = TextBoxGhiChu.Text;
                if (_GiangVien.add() > 0 && DBInstance.commit() > 0)
                {
                    PanelThanhCong.Visible = true;
                    LabelThongBaoThanhCong.Text = "Thêm mới tài khoản <strong>" + _GiangVien.username + "</strong> thành công";
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
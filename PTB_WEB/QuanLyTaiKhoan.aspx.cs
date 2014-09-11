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
                        if (PermissionHelper.QuyenHienThiQuanTriVien())
                        {
                            PanelQuanLyTaiKhoan.Visible = true;
                            _QuanLyTaiKhoan();
                        }
                        else
                            PanelKhongPhaiQuanTriVien.Visible = true;

                        if (!PermissionHelper.QuyenThemQuanTriVien())
                            ButtonThemMoiTaiKhoan.Visible = false;
                    }

                    if (!String.IsNullOrEmpty(Request["op"]))
                    {
                        if (Request["op"].Equals("xoa"))
                        {
                            Guid id = GUID.From(Request["id"]);
                            QuanTriVien _QuanTriVien = new QuanTriVien();
                            _QuanTriVien = QuanTriVien.getById(id);

                            if (!PermissionHelper.QuyenXoaQuanTriVien(_QuanTriVien))
                            {
                                PanelThatBai.Visible = true;
                                LabelThongBaoThatBai.Text = "Bạn không có quyền xóa tài khoản này";
                                return;
                            }

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

        protected void _QuanLyTaiKhoan()
        {
            List<QuanTriVien> ListGiangVien = QuanTriVien.getQuery().ToList();

            CollectionPagerQuanLyTaiKhoan.DataSource = ListGiangVien;
            CollectionPagerQuanLyTaiKhoan.BindToControl = RepeaterQuanLyTaiKhoan;
            RepeaterQuanLyTaiKhoan.DataSource = CollectionPagerQuanLyTaiKhoan.DataSourcePaged;
            RepeaterQuanLyTaiKhoan.DataBind();

            List<Group> ListGroup = Group.getQuery().ToList();
            DropDownListNhom.DataSource = ListGroup;
            DropDownListNhom.DataBind();
        }

        protected string _QuyenSuaQuanTriVien()
        {
            Guid id = GUID.From(Eval("id"));
            QuanTriVien _QuanTriVien = new QuanTriVien();
            _QuanTriVien = QuanTriVien.getById(id);
            if (PermissionHelper.QuyenSuaQuanTriVien(_QuanTriVien))
                return "<li><a href=\"#\" onclick=\"ShowCapNhat('" + Eval("id") + "','" + Eval("group_id") + "');\" data-target=\"#PopupQuanLyTaiKhoan\" data-toggle=\"modal\"><span class=\"glyphicon glyphicon-pencil\"></span>&nbsp;Cập nhật</a></li>";
            return "";
        }

        protected string _QuyenXoaQuanTriVien()
        {
            Guid id = GUID.From(Eval("id"));
            QuanTriVien _QuanTriVien = new QuanTriVien();
            _QuanTriVien = QuanTriVien.getById(id);
            if (PermissionHelper.QuyenXoaQuanTriVien(_QuanTriVien))
                return "<li><a href=\"?op=xoa&id=" + Eval("id") + "\" onclick=\"return confirm('Bạn chắc chắn muốn xóa tài khoản " + Eval("username") + "?');\"><span class=\"glyphicon glyphicon-remove\"></span>&nbsp;Xóa</a></li>";
            return "";
        }

        protected string NgayTao()
        {
            DateTime dt = Convert.ToDateTime(Eval("date_create").ToString());
            return dt.ToString("d/M/yyyy HH\\hmm");
        }

        protected string MoTa()
        {
            return StringHelper.ConvertRNToBR(Eval("mota").ToString());
        }

        protected void ButtonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                QuanTriVien _QuanTriVien = QuanTriVien.getById(HiddenFieldID.Value);

                if (!PermissionHelper.QuyenSuaQuanTriVien(_QuanTriVien))
                {
                    PanelThatBai.Visible = true;
                    LabelThongBaoThatBai.Text = "Bạn không có quyền sửa tài khoản này";
                    return;
                }

                _QuanTriVien.hoten = TextBoxHoTen.Text;
                _QuanTriVien.email = TextBoxEmail.Text;
                _QuanTriVien.group = Group.getById(DropDownListNhom.SelectedValue.ToString());// GUID.From(DropDownListNhom.SelectedValue);
                _QuanTriVien.username = TextBoxTaiKhoan.Text;
                if (!TextBoxMatKhau.Text.Equals(string.Empty))
                    _QuanTriVien.hashPassword(TextBoxMatKhau.Text);
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
                if (!PermissionHelper.QuyenThemQuanTriVien())
                {
                    PanelThatBai.Visible = true;
                    LabelThongBaoThatBai.Text = "Bạn không có quyền thêm mới tài khoản";
                    return;
                }

                QuanTriVien _QuanTriVien = new QuanTriVien();
                _QuanTriVien.hoten = TextBoxHoTen.Text;
                _QuanTriVien.email = TextBoxEmail.Text;
                _QuanTriVien.group = Group.getById(GUID.From(DropDownListNhom.SelectedValue));
                _QuanTriVien.username = TextBoxTaiKhoan.Text;
                _QuanTriVien.hashPassword(TextBoxMatKhau.Text);
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
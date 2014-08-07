using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQLPH
{
    public partial class QuanLyMuonPhong : System.Web.UI.Page
    {
        List<PhieuMuonPhong> ListPhieuMuonPhong = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.Expires = -1;

            _PageLoad();
        }
        protected void _PageLoad()
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                    {
                        HienDangNhap(false);
                    }
                    else
                    {
                        HienDangNhap(true);
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
            }
            else
            {
                PanelDangNhap.Visible = false;
                if (LaQuanTriVien())
                    HienPanelQuanTriVien(true);
            }
        }

        protected bool LaQuanTriVien()
        {
            return Convert.ToString(Session["KieuDangNhap"]).Equals("QuanTriVien");
        }

        protected void HienPanelQuanTriVien(bool hien)
        {
            if (hien)
            {
                ListPhieuMuonPhong = PhieuMuonPhong.getQuery().OrderByDescending(c => c.id).ToList();

                CollectionPagerQuanLyMuonPhongQuanTriVien.DataSource = ListPhieuMuonPhong;
                CollectionPagerQuanLyMuonPhongQuanTriVien.BindToControl = RepeaterQuanLyMuonPhongQuanTriVien;
                RepeaterQuanLyMuonPhongQuanTriVien.DataSource = CollectionPagerQuanLyMuonPhongQuanTriVien.DataSourcePaged;
                RepeaterQuanLyMuonPhongQuanTriVien.DataBind();

                PanelQuanLyMuonPhongQuanTriVien.Visible = true;
                PanelQuanLyMuonPhongGiangVien.Visible = false;
            }
            else
            {
                PanelQuanLyMuonPhongGiangVien.Visible = true;
                PanelQuanLyMuonPhongQuanTriVien.Visible = false;
            }
        }

        protected string NgayTao()
        {
            DateTime dt = Convert.ToDateTime(Eval("date_create").ToString());
            return dt.ToString("HH\\hmm d/M/yyyy");
        }
        protected string NgayMuon()
        {
            DateTime dt = Convert.ToDateTime(Eval("ngaymuon").ToString());
            return dt.ToString("d/M/yyyy");
        }
        protected string Tu()
        {
            DateTime dt = Convert.ToDateTime(Eval("ngaymuon").ToString());
            return dt.ToString("HH\\hmm");
        }
        protected string Den()
        {
            DateTime dt = Convert.ToDateTime(Eval("ngaytra").ToString());
            return dt.ToString("HH\\hmm");
        }
        protected string Duyet()
        {
            int trangthai = Convert.ToInt32(Eval("trangthai").ToString());
            string str = String.Format("data-toggle='modal' data-target='#PopupDuyet' onclick=\"return Duyet('{0}','{1}','{2}');\">", Eval("id"), Eval("trangthai"), Eval("ghichu"));
            switch (trangthai)
            {
                case 0:
                    str = "<button class='btn btn-primary btn-sm' " + str + "Chờ duyệt</span>";
                    break;
                case 1:
                    str = "<button class='btn btn-success btn-sm' " + str + "Chấp nhận</span>";
                    break;
                case -1:
                    str = "<button class='btn btn-danger btn-sm' " + str + "Hủy bỏ</span>";
                    break;
            }
            return str;
        }

        protected void ButtonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuMuonPhong _PhieuMuonPhong = new PhieuMuonPhong();
                _PhieuMuonPhong = PhieuMuonPhong.getById(Convert.ToInt32(HiddenFieldID.Value));
                _PhieuMuonPhong.trangthai = Convert.ToInt32(DropDownListTrangThai.SelectedValue);
                _PhieuMuonPhong.ghichu = TextBoxGhiChu.Text;
                QuanTriVien _QuanTriVien = new QuanTriVien();
                _QuanTriVien = QuanTriVien.getByUserName(Session["username"].ToString());
                _PhieuMuonPhong.quantrivien = _QuanTriVien;
                if (_PhieuMuonPhong.update() > 0)
                {
                    Response.Redirect(Request.RawUrl);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
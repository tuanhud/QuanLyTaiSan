using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;

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

            if (!IsPostBack)
            {
                // Đặt tên để set class, đặt tên in hoa
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "QUANLYMUONPHONG";

                try
                {
                    if (Convert.ToString(Session["Username"]).Equals(String.Empty))
                        PanelDangNhap.Visible = true;
                    else
                    {
                        PanelQuanLyPhongMuon.Visible = true;
                        QuanLyPhongMuon();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        protected void QuanLyPhongMuon()
        {
            QuanTriVien _QuanTriVien = QuanTriVien.getByUserName(Convert.ToString(Session["UserName"]));
            ListPhieuMuonPhong = PhieuMuonPhong.getQuery().Where(c => c.nguoimuon.id == _QuanTriVien.id).ToList();
            if (ListPhieuMuonPhong.Count > 0)
            {
                CollectionPagerQuanLyPhongBanMuon.DataSource = ListPhieuMuonPhong;
                CollectionPagerQuanLyPhongBanMuon.BindToControl = RepeaterQuanLyMuonPhong;
                RepeaterQuanLyPhongBanMuon.DataSource = CollectionPagerQuanLyPhongBanMuon.DataSourcePaged;
                RepeaterQuanLyPhongBanMuon.DataBind();

                PanelQuanLyPhongBanMuon.Visible = true;
            }

            if (PermissionHelper.QuyenQuanLyMuonPhong())
            {
                lidanhsachgiangvienmuonphong.Visible = true;
                ListPhieuMuonPhong = PhieuMuonPhong.getQuery().OrderByDescending(c => c.id).ToList();
                if (ListPhieuMuonPhong.Count > 0)
                {
                    CollectionPagerQuanLyMuonPhong.DataSource = ListPhieuMuonPhong;
                    CollectionPagerQuanLyMuonPhong.BindToControl = RepeaterQuanLyMuonPhong;
                    RepeaterQuanLyMuonPhong.DataSource = CollectionPagerQuanLyMuonPhong.DataSourcePaged;
                    RepeaterQuanLyMuonPhong.DataBind();

                    PanelQuanLyMuonPhong.Visible = true;
                }
            }
        }

        protected string NgayTao()
        {
            DateTime dt = Convert.ToDateTime(Eval("date_create").ToString());
            return dt.ToString("d/M/yyyy HH\\hmm");
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

        protected string TrangThai()
        {
            int trangthai = Convert.ToInt32(Eval("trangthai").ToString());
            string str = string.Empty;
            switch (trangthai)
            {
                case 0:
                    str = "<label class='label label-primary btn-sm'>Chờ duyệt</span>";
                    break;
                case 1:
                    str = "<label class='label label-success btn-sm'>Chấp nhận</span>";
                    break;
                case -1:
                    str = "<label class='label label-danger btn-sm'>Hủy bỏ</span>";
                    break;
            }
            return str;
        }

        protected string Duyet()
        {
            int trangthai = Convert.ToInt32(Eval("trangthai").ToString());
            string str = string.Empty;
            str = string.Format("data-toggle='modal' data-target='#PopupDuyet' onclick=\"return Duyet('{0}','{1}');\">", Eval("id"), Eval("trangthai"));
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
                _PhieuMuonPhong.nguoiduyet = _QuanTriVien;
                if (_PhieuMuonPhong.update() > 0 && DBInstance.commit() > 0)
                {
                    if (CheckBoxGuiMailThongBao.Checked == true)
                    {
                        string to = _PhieuMuonPhong.nguoiduyet.email;
                        string sub = "[Thông Báo] V/v mượn phòng ngày " + Convert.ToDateTime(_PhieuMuonPhong.date_create).ToString("d/M/yyyy");
                        string tinhtrang = string.Empty;
                        switch (_PhieuMuonPhong.trangthai)
                        {
                            case -1:
                                tinhtrang = "đã bị hủy bỏ";
                                break;
                            case 0:
                                tinhtrang = "đang được xét duyệt";
                                break;
                            case 1:
                                tinhtrang = "đã được chấp nhận";
                                break;
                        }
                        string msg = string.Format("<p><b>Chào {0}</b></p><p>Phiếu mượn phòng của bạn {1}</p><p>Ghi chú từ người duyệt:</p><p>{2}</p><p>Người duyệt: <b>{3}</b></p><p>Mọi thắc mắc xin liên hệ qua mail: {4}</p>", _PhieuMuonPhong.nguoiduyet.hoten, tinhtrang, _PhieuMuonPhong.mota.Replace("\r\n", "<br />"), _PhieuMuonPhong.nguoiduyet.hoten, _PhieuMuonPhong.nguoiduyet.email);
                        EmailHelper.sendMail(to, sub, msg);
                    }
                    QuanLyPhongMuon();
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
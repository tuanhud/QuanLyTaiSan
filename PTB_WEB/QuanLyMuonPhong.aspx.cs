using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB
{
    public partial class QuanLyMuonPhong : System.Web.UI.Page
    {
        List<PhieuMuonPhong> ListPhieuMuonPhong = null;
        public string tinhtrang = string.Empty;
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

                        if (Page.Request.QueryString["op"] != null)
                        {
                            if (Page.Request.QueryString["op"].Equals("xoa"))
                            {
                                Guid ID_PMP = GUID.From(Page.Request.QueryString["id"]);
                                PhieuMuonPhong _PhieuMuonPhong = PhieuMuonPhong.getById(ID_PMP);
                                HideAllAlert();
                                if (_PhieuMuonPhong.delete() > 0 && DBInstance.commit() > 0)
                                {
                                    ucSuccess.LabelInfo.Text = "Đã xóa phiếu mượn phòng này";
                                    ucSuccess.Visible = true;
                                    Response.Redirect("QuanLyMuonPhong.aspx");
                                }
                                else
                                {
                                    ucWarning.LabelInfo.Text = "Có lỗi xảy ra trong khi xóa. Vui lòng kiểm tra lại.";
                                    ucWarning.Visible = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ucDanger.LabelInfo.Text = "Có lỗi xảy ra. Vui lòng tải lại trang.";
                    ucDanger.Visible = true;
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
                _PhieuMuonPhong = PhieuMuonPhong.getById(GUID.From(HiddenFieldID.Value));
                _PhieuMuonPhong.trangthai = Convert.ToInt32(DropDownListTrangThai.SelectedValue);
                _PhieuMuonPhong.ghichu = TextBoxGhiChu.Text;
                QuanTriVien _QuanTriVien = new QuanTriVien();
                _QuanTriVien = QuanTriVien.getByUserName(Session["username"].ToString());
                _PhieuMuonPhong.nguoiduyet = _QuanTriVien;
                if (_PhieuMuonPhong.update() > 0 && DBInstance.commit() > 0)
                {
                    HideAllAlert();
                    ucSuccess.LabelInfo.Text = "Duyệt phòng thành công. ";
                    ucSuccess.Visible = true;

                    if (CheckBoxGuiMailThongBao.Checked == true)
                    {
                        string to = _PhieuMuonPhong.nguoiduyet.email;
                        string sub = PTB_WEB.Libraries.StringHelper.TitleContent(_PhieuMuonPhong);
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
                        string msg = PTB_WEB.Libraries.StringHelper.MailContent(_PhieuMuonPhong, tinhtrang);
                        if (QuanLyTaiSan.Libraries.EmailHelper.sendMail(to, sub, msg) > 0)
                        {
                            HideAllAlert();
                            ucSuccess.LabelInfo.Text += "Đã gửi mail thông báo đến giảng viên mượn phòng";
                            ucSuccess.Visible = true;
                        }
                        else
                        {
                            HideAllAlert();
                            ucWarning.LabelInfo.Text = "Đã xảy ra lỗi. Mail không gửi được đến giảng viên mượn phòng";
                            ucWarning.Visible = true;
                        }
                    }
                    QuanLyPhongMuon();
                }
                else
                {
                    HideAllAlert();
                    ucDanger.LabelInfo.Text = "Có lỗi xảy ra trong khi duyệt. Vui lòng kiểm tra lại";
                    ucDanger.Visible = true;
                }
            }
            catch (Exception ex)
            {
                HideAllAlert();
                ucDanger.LabelInfo.Text = "Có lỗi xảy ra trong khi duyệt. Vui lòng kiểm tra lại";
                ucDanger.Visible = true;
                Console.Write(ex);
            }
        }

        private void HideAllAlert()
        {
            ucDanger.Visible = ucWarning.Visible = ucSuccess.Visible = false;
        }

        protected String XoaPhieuMuonPhong()
        {
            return "<a href=\"?op=xoa&id=" + Eval("id") + "\" onclick=\"return confirm('Bạn chắc chắn muốn phiếu mượn phòng này ?');\"><img src=\"/Images/DeleteRed.png\" alt=\"Xóa\" /></a>";
        }

    }
}
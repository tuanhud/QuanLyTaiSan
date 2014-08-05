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
            ListPhieuMuonPhong = PhieuMuonPhong.getQuery().Where(c=>c.trangthai == 0).OrderByDescending(c=>c.id).Take(10).ToList();
            RepeaterQuanLyMuonPhong.DataSource = ListPhieuMuonPhong;
            RepeaterQuanLyMuonPhong.DataBind();
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
            string str = string.Empty;
            switch (trangthai)
            {
                case 0:
                    str = "<button class=\"btn btn-primary btn-sm\" data-toggle=\"modal\" data-target=\"#PopupDuyet\" onclick='return Duyet(\"" + Eval("id") + "\");'>Chờ duyệt</span>";
                    break;
                case 1:
                    str = "<button class=\"btn btn-success btn-sm\" data-toggle=\"modal\" data-target=\"#PopupDuyet\" onclick='return Duyet(\"" + Eval("id") + "\");'>Chấp nhận</span>";
                    break;
                case -1:
                    str = "<button class=\"btn btn-danger btn-sm\" data-toggle=\"modal\" data-target=\"#PopupDuyet\" onclick='return Duyet(\"" + Eval("id") + "\");'>Hủy bỏ</span>";
                    break;
            }
            return str;
        }

        protected void ButtonLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
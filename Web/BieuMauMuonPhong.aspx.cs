using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace Web
{
    public partial class BieuMauMuonPhong : System.Web.UI.Page
    {
        PhieuMuonPhong _PhieuMuonPhong = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelDone.Visible = false;
                PanelFails.Visible = false;
            }
        }

        protected void ButtonMuonPhong_Click(object sender, EventArgs e)
        {
            try
            {
                _PhieuMuonPhong.ngaymuon = (DateTime)ASPxDateEditNgayMuon.Date;
                _PhieuMuonPhong.ngaytra = (DateTime)ASPxDateEditNgayTra.Date;
                //_PhieuMuonPhong.phong = ASPxTextBoxPhong.Text;
                _PhieuMuonPhong.soluongsv = Int32.Parse(ASPxTextBoxSoLuong.Text);
                _PhieuMuonPhong.lop = ASPxTextBoxLop.Text;
                _PhieuMuonPhong.lydomuon = ASPxMemoLyDoMuon.Text;
                if (_PhieuMuonPhong.add() > 0)
                {
                    PanelDone.Visible = true;
                    //PanelProcess.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                PanelFails.Visible = true;
            }
        }
    }
}
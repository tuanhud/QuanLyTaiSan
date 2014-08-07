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
        GiangVien _GiangVien = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelDone.Visible = false;
                PanelFails.Visible = false;

                ASPxDateEditNgayMuon.Date = DateTime.Now;
                ASPxTimeEditTuGio.DateTime = DateTime.Now;
                ASPxTimeEditDenGio.DateTime = DateTime.Now;
            }
        }

        protected void CheckValidate()
        {
            if (ASPxTimeEditDenGio.DateTime <= ASPxTimeEditTuGio.DateTime)
                PanelFails.Visible = true;
                ASPxTimeEditDenGio.Focus();
                return;

        }

        protected void ButtonMuonPhong_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime abc = ASPxTimeEditTuGio.DateTime;
                CheckValidate();
                _PhieuMuonPhong = new PhieuMuonPhong();
                _PhieuMuonPhong.ngaymuon = ASPxDateEditNgayMuon.Date.Add(-ASPxDateEditNgayMuon.Date.TimeOfDay).Add(ASPxTimeEditTuGio.DateTime.TimeOfDay);
                _PhieuMuonPhong.ngaytra = ASPxDateEditNgayMuon.Date.Add(-ASPxDateEditNgayMuon.Date.TimeOfDay).Add(ASPxTimeEditDenGio.DateTime.TimeOfDay);
                //_PhieuMuonPhong.sophong = ASPxTextBoxPhong.Text;
                _PhieuMuonPhong.soluongsv = Int32.Parse(ASPxTextBoxSoLuong.Text);
                _PhieuMuonPhong.lop = ASPxTextBoxLop.Text;
                _PhieuMuonPhong.lydomuon = ASPxMemoLyDoMuon.Text;
                _GiangVien = new GiangVien();
                _GiangVien.username = "admin";
                _PhieuMuonPhong.giangvien = _GiangVien;                

                if (_PhieuMuonPhong.add() > 0)
                {
                    PanelDone.Visible = true;
                    PanelProcess.Visible = false;
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
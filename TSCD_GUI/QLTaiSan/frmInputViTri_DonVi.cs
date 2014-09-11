using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using TSCD.DataFilter;
using SHARED.Libraries;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmInputViTri_DonVi : DevExpress.XtraEditors.XtraForm
    {
        CTTaiSan objCTTaiSan = null;

        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;

        public frmInputViTri_DonVi()
        {
            InitializeComponent();
        }

        public frmInputViTri_DonVi(CTTaiSan _objCTTaiSan)
        {
            InitializeComponent();
            objCTTaiSan = _objCTTaiSan;
            loadData();
            setData();
        }

        public void setData(CTTaiSan _objCTTaiSan, DonVi _objDonVi)
        {
            try
            {
                objCTTaiSan = _objCTTaiSan;
                lookUpTinhTrang.EditValue = objCTTaiSan.tinhtrang_id;
                ucComboBoxDonVi1.DonVi = _objDonVi;
                ucComboBoxDonVi2.DonVi = _objDonVi;
                txtSoLuong.Properties.MinValue = 1;
                txtSoLuong.Properties.MaxValue = objCTTaiSan.soluong;
                txtSoLuong.EditValue = objCTTaiSan.soluong;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setData:" + ex.Message);
            }
        }

        private void setData()
        {
            try
            {
                dateNgayGhi.EditValue = objCTTaiSan.ngay;
                dateNgay_CT.EditValue = objCTTaiSan.chungtu_ngay;
                txtSoHieu_CT.Text = objCTTaiSan.chungtu_sohieu;
                lookUpTinhTrang.EditValue = objCTTaiSan.tinhtrang_id;
                ucComboBoxViTri1.Phong = objCTTaiSan.phong;
                ucComboBoxViTri2.ViTri = objCTTaiSan.vitri;
                ucComboBoxDonVi1.DonVi = objCTTaiSan.donviquanly;
                ucComboBoxDonVi2.DonVi = objCTTaiSan.donvisudung;
                txtSoLuong.Properties.MinValue = 1;
                txtSoLuong.Properties.MaxValue = objCTTaiSan.soluong;
                txtSoLuong.EditValue = objCTTaiSan.soluong;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setData:" + ex.Message);
            }
        }

        public void loadData()
        {
            try
            {
                List<DonVi> list = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                ucComboBoxDonVi1.DataSource = list;
                ucComboBoxDonVi2.DataSource = list;
                ucComboBoxViTri1.init(false, true);
                ucComboBoxViTri1.DataSource = ViTriHienThi.getAllHavePhong();
                ucComboBoxViTri2.DataSource = ViTriHienThi.getAll();
                lookUpTinhTrang.Properties.DataSource = TinhTrang.getQuery().OrderBy(c => c.order).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setData:" + ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput())
                {
                    DateTime ngayGhi = dateNgayGhi.EditValue != null ? dateNgayGhi.DateTime : DateTime.Now;
                    String soHieu_CT = txtSoHieu_CT.Text;
                    DateTime ngay_CT = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
                    int soLuong = Convert.ToInt32(txtSoLuong.EditValue);
                    TinhTrang tinhTrang = TinhTrang.getById(GUID.From(lookUpTinhTrang.EditValue));
                    Phong phong = ucComboBoxViTri1.Phong;
                    ViTri viTri = ucComboBoxViTri2.ViTri;
                    DonVi donViQL = ucComboBoxDonVi1.DonVi;
                    DonVi donViSD = ucComboBoxDonVi2.DonVi;
                    String ghiChu = txtGhiChu.Text;
                    int re = objCTTaiSan.chuyenDoi(donViQL, donViSD, tinhTrang, viTri, phong, objCTTaiSan.parent, ngay_CT, soHieu_CT, soLuong, ghiChu, ngayGhi);
                    if (re > 0 && DBInstance.commit() > 0)
                    {
                        XtraMessageBox.Show("Pass");
                        Guid id = CTTaiSan.getQuery().Where(c => c.taisan_id == objCTTaiSan.taisan_id && c.donviquanly_id == donViQL.id && c.soluong == soLuong).FirstOrDefault().id;
                        if (reloadAndFocused != null)
                            reloadAndFocused(id);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Fail");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOK_Click: " + ex.Message);
            }
        }

        private bool checkInput()
        {
            DonVi donViQL = ucComboBoxDonVi1.DonVi;
            if (donViQL == null && donViQL.id == Guid.Empty)
            {
                XtraMessageBox.Show("Chưa chọn đơn vị quản lý");
                return false;
            }
            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}